using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YimoFramework.Extensions;
using YimoFramework.Utils;

namespace DownloadClient
{
    public partial class frmDown : Form
    {
        public frmDown()
        {
            Init();
            InitializeComponent();
        }

        private static readonly string IniConfig = AppDomain.CurrentDomain.BaseDirectory + "config.ini";
        private readonly IniHelper _iniHelper = new IniHelper(IniConfig);
        private void frmDown_Load(object sender, EventArgs e)
        {
            LoadClient();
        }

        public void Init()
        {
            this.StartPosition = FormStartPosition.CenterScreen;//窗体居中显示
            this.MaximizeBox = false;//不显示最大化按钮
            this.FormBorderStyle = FormBorderStyle.FixedSingle;//禁止放大缩小
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_ControlAdded); //注册全选功能
        }
        #region 文本框能够使用Ctrl+A 全选功能
        private void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            //使“未来”生效
            e.Control.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_ControlAdded);
            //使“子孙”生效
            foreach (Control c in e.Control.Controls)
            {
                Control_ControlAdded(sender, new ControlEventArgs(c));
            }
            //使“过去”生效
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.KeyPress += TextBox_KeyPress;
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null)
                return;
            if (e.KeyChar == (char)1)
            {
                textBox.SelectAll();
                e.Handled = true;
            }
        }
        #endregion
        #region 追加日志

        private static int _maxLogmsgTextLength = 10;
        void txtLogMsg_TextChanged(object sender, EventArgs e)
        {
            if (txtLogMsg.Text.Length > _maxLogmsgTextLength)
            {
                txtLogMsg.Text = txtLogMsg.Text.Substring(_maxLogmsgTextLength / 2);
            }
            txtLogMsg.SelectionStart = txtLogMsg.Text.Length;//设置选中文字的开始位置为文本框的文字的长度，如果超过了文本长度，则默认为文本的最后。
            txtLogMsg.SelectionLength = 0;//设置被选中文字的长度为0（将光标移动到文字最后）
            txtLogMsg.ScrollToCaret();//将滚动条移动到光标位置
        }
        private void AppendLogMsg(string msg)
        {
            //在UI线程中执行
            txtLogMsg.BeginInvoke(new Action(() =>
            {
                txtLogMsg.AppendText(msg);
                txtLogMsg.AppendText(Environment.NewLine);
            }));
        }
        #endregion

        public void LoadClient()
        {
            //日志输出文本框设置
            this.txtLogMsg.ScrollBars = ScrollBars.Vertical;//日志输出显示纵向滚动条
            this.txtImageUrls.ScrollBars = ScrollBars.Vertical;
            //this.txtLogMsg.ReadOnly = true; //输出日志只读
            this.txtLogMsg.Multiline = true;
            this.txtLogMsg.TextChanged += txtLogMsg_TextChanged;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["MAX_LOGMSG_TEXT_LENGTH"], out _maxLogmsgTextLength);
            #region 读取配置
            txtSaveDir.Text = _iniHelper.ReadValue("txtSaveDir");
            txtDomain.Text = _iniHelper.ReadValue("txtDomain");
            txtImageUrls.Text = _iniHelper.ReadValue("txtImageUrls");
            txtPageUrl.Text = _iniHelper.ReadValue("txtPageUrl");
            #endregion
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadImgs_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            //本地上传
            //if (txtImageUrls.Text.IsNullOrEmpty())
            //{
            //    var selectImgs = OpenImagesDialog(true);
            //    var saveDir = Path.Combine(txtSaveDir.Text);
            //    var result = FileHelper.CopyFileToDir(selectImgs, saveDir);

            //    result.Item1.Keys.ToList().ForEach(item => AppendLogMsg(item + ":" + result.Item1[item]));
            //    result.Item2.ForEach(item => AppendLogMsg("文件复制失败：" + item));
            //    return;
            //}
            var writeMsg = new Action<string>(AppendLogMsg);
            var txtImgs = txtImageUrls.Text;
            Task.Run(() =>
            {
                RegexHelper _regexHelper = new RegexHelper();
                List<string> imgs = _regexHelper.GetImages(txtImgs, txtDomain.Text);
                if (imgs.Count == 0)
                {
                    writeMsg("未提取到可保存的图片");
                }
                //下载远程图片
                var saveDir = Path.Combine(txtSaveDir.Text);
                var result = FileHelper.SaveImageToLocal(saveDir, imgs, writeMsg);
                writeMsg("提取图片成功：成功" + result.Item1.Count + "，失败：" + result.Item2.Count);
            });
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            #region 保存配置
            _iniHelper.WriteValue("txtSaveDir", txtSaveDir.Text); 
            _iniHelper.WriteValue("txtDomain", txtDomain.Text); 
            _iniHelper.WriteValue("txtImageUrls", txtImageUrls.Text); 
            _iniHelper.WriteValue("txtPageUrl", txtPageUrl.Text); 
            #endregion
            AppendLogMsg("保存成功");
        }

        /// <summary>
        /// 校验输入
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {

            if (this.txtSaveDir.Text.IsNullOrEmpty())
            {
                txtSaveDir.Text = AppDomain.CurrentDomain.BaseDirectory;
            }
            return true;
        }
        /// <summary>
        /// 打开图片选择框 
        /// </summary>
        /// <returns></returns>
        private List<string> OpenImagesDialog(bool isMulti = true)
        {
            var openFileDialog = new OpenFileDialog();
            const string imgExts = "图像文件 (*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png)|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png";
            openFileDialog.Filter = imgExts;
            openFileDialog.Multiselect = isMulti;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            var result = new List<string>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                result.AddRange(openFileDialog.FileNames);
            }
            return result;
        }

        private void txtImageUrls_TextChanged(object sender, EventArgs e)
        {
            if (this.txtImageUrls.Text.IsNullOrEmpty())
            {
                this.btnUploadImgs.Text = "选择图片";
            }
            else
            {
                this.btnUploadImgs.Text = "上传图片";
            }
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            var openDir = this.txtSaveDir.Text;
            System.Diagnostics.Process.Start("Explorer.exe", openDir);
        }

        private void btnGetHtml_Click(object sender, EventArgs e)
        {
            string pageUrl = txtPageUrl.Text;
            if (pageUrl.IsNullOrEmpty())//获取页面中的图片
            {
                AppendLogMsg("输入地址输入地址啊");
            }
            Task.Run(() =>
            {
                HttpHelper httpHelper = new HttpHelper();
                var html = httpHelper.GetHtml(new HttpItem()
                {
                    URL = pageUrl
                });
                txtImageUrls.Text = html.Html;
                AppendLogMsg("获取网页成功");
            });
            return;
        }

        private void txtPageUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
