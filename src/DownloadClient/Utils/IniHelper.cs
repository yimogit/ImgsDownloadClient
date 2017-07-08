using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YimoFramework.Utils
{
    public class IniHelper
    {
        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        private readonly int _retLength = 500;
        private readonly string _sPath = null;
        /// <summary>
        /// 初始化IniHelper
        /// </summary>
        /// <param name="path">ini文件保存路径</param>
        /// <param name="rl">默认500</param>
        public IniHelper(string path, int? rl = null)
        {
            this._sPath = path;
            this._retLength = rl.HasValue ? rl.Value : _retLength;
        }
        /// <summary>
        /// 设置Ini配置，默认配置节为Setting
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        /// <param name="section">配置节</param>
        public void WriteValue(string key, string value, string section = "Setting")
        {
            // section=配置节，key=键名，value=键值，path=路径
            WritePrivateProfileString(section, key, value, _sPath);
        }
        /// <summary>
        /// 根据键名节点读取Ini配置，默认节点为Setting
        /// </summary>
        /// <param name="key">键名</param>
        /// <param name="section">配置节</param>
        /// <returns></returns>
        public string ReadValue(string key, string section = "Setting")
        {
            // 每次从ini中读取多少字节
            System.Text.StringBuilder temp = new System.Text.StringBuilder(_retLength);
            // section=配置节，key=键名，temp=上面，path=路径
            GetPrivateProfileString(section, key, "", temp, _retLength, _sPath);
            return temp.ToString();
        }
    }
}
