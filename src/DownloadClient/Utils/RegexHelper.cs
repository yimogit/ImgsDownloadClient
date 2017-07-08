using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YimoFramework.Utils
{
    /// <summary>
    /// 常用正则
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 获取完整路径的图片
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public List<string> GetImages(string html, string prefix = "")
        {
            Regex regex = new Regex("(http:|https:|rtsp:)//([^\"|,|。| ])*?(\\.jpg|\\.gif|\\.png|\\.jpeg|\\.ico)", RegexOptions.IgnoreCase);
            var matches = regex.Matches(html);
            List<string> result = new List<string>();
            string imgUrl = string.Empty;
            foreach (Match m in matches)
            {
                if (!result.Contains(m.Value))
                {
                    result.Add(m.Value);
                }
            }
            if (!string.IsNullOrEmpty(prefix))
            {
                result.AddRange(GetStreamlineImages(html, prefix));
            }
            return result.Distinct().ToList();
        }
        /// <summary>
        /// 从html中的src属性获取图片完整路径
        /// </summary>
        /// <param name="html"></param>
        /// <param name="byTags"></param>
        /// <returns></returns>
        public List<string> GetStreamlineImages(string html, string prefix)
        {
            Regex regex = new Regex("['|\"]([^\"|,|。| ]+?(\\.jpg|\\.gif|\\.png|\\.jpeg|\\.ico))['|\"]");
            var matches = regex.Matches(html);
            List<string> result = new List<string>();
            string imgUrl = string.Empty;
            foreach (Match m in matches)
            {
                imgUrl = m.Groups[1].Value;
                if (!result.Contains(imgUrl))
                {
                    if (imgUrl.IndexOf("http") != 0)
                    {
                        imgUrl = prefix +"/"+ imgUrl;
                    }
                    result.Add(imgUrl);
                }
            }
            return result;
        }
    }
}
