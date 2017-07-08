using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Drawing;

namespace YimoFramework.Utils
{
    public class FileHelper
    {
        public static string WriteFile(string input, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return "写入的文件名不能为空";
            }
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                using (var w = new StreamWriter(path))
                {
                    w.Write(input);
                    w.Flush();
                    w.Close();
                }
            }
            catch
            {
                return null;
            }
            return string.Empty;
        }

        public static string ReadFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }
            try
            {
                var result = string.Empty;
                var finfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
                using (var fs = finfo.OpenRead())
                {
                    var r = new StreamReader(fs);
                    result = r.ReadToEnd();
                    r.Close();
                }
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }


        public static List<string> CopyFileToDir(string[] selectImgs, string txtSaveDir)
        {
            if (!Directory.Exists(txtSaveDir))
            {
                Directory.CreateDirectory(txtSaveDir);
            }
            var errorFiles = new List<string>();
            for (int i = 0; i < selectImgs.Length; i++)
            {
                if (!File.Exists(selectImgs[i]))
                {
                    errorFiles.Add(selectImgs[i]);
                }
                else
                {
                    var savePath = Path.Combine(txtSaveDir, Guid.NewGuid() + Path.GetExtension(selectImgs[i]));
                    File.Copy(selectImgs[i], savePath);
                }

            }
            return errorFiles;
        }
        /// <summary>
        /// 复制文件到指定目录
        /// </summary>
        /// <param name="sourcePaths">要复制的文件路径集合</param>
        /// <param name="targetDir">目标目录</param>
        /// <returns>Item1:对应路径，Item2:失败文件路径</returns>
        public static Tuple<Dictionary<string, string>, List<string>> CopyFileToDir(List<string> sourcePaths, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            var errorFiles = new List<string>();
            var saveDirs = new Dictionary<string, string>();
            sourcePaths.ForEach(item =>
            {
                //路径不存在或者路径已存在则失败
                if (!File.Exists(item) || saveDirs.ContainsKey(item))
                {
                    errorFiles.Add(item);
                }
                else
                {
                    var saveName = Guid.NewGuid() + Path.GetExtension(item);
                    var savePath = Path.Combine(targetDir, saveName);
                    File.Copy(item, savePath);
                    saveDirs.Add(item, savePath);
                }
            });
            var result = new Tuple<Dictionary<string, string>, List<string>>(saveDirs, errorFiles);
            return result;
        }


        /// <summary>
        /// 根据url下载图片
        /// </summary>
        /// <param name="urls"></param>
        public static Tuple<Dictionary<string, string>, List<string>> SaveImageToLocal(string saveDir, List<string> urls, Action<string> action, bool isGuid = false)
        {
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            var errorFiles = new List<string>();
            var saveDirs = new Dictionary<string, string>();
            HttpHelper _httpHelper = new HttpHelper();
            var fileName = Guid.NewGuid().ToString();
            foreach (var item in urls)
            {
                try
                {
                    var image = _httpHelper.GetImage(new HttpItem()
                    {
                        URL = item,
                        Method = "GET"
                    });
                    fileName = isGuid ? fileName : (Path.GetFileName(item));
                    var savePath = Path.Combine(saveDir, fileName + Path.GetExtension(item));
                    saveDirs.Add(item, savePath);
                    using (Bitmap bitmap = new Bitmap(image))
                    {
                        bitmap.Save(savePath);
                    }
                    action(item + " -------> " + savePath);
                }
                catch
                {
                    action("图片下载失败：" + item);
                    errorFiles.Add(item);
                }
            }
            var result = new Tuple<Dictionary<string, string>, List<string>>(saveDirs, errorFiles);
            return result;
        }
    }
}
