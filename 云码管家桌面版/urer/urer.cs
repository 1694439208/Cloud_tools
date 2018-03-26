using System;
using System.Collections.Generic;
using System.Text;
using JSBeautifyLib;
using v8sharp;
using System.Drawing;
using System.Text.RegularExpressions;

namespace 云码管家桌面版.urer
{
    class urer
    {
        public static string urere = string.Empty;
        public static string passd = string.Empty;
        public static string name = string.Empty;
        public static Image img = null;
        public static bool login = false;
        /// <summary>
        /// 执行js V8方法
        /// </summary>
        /// <param name="reString">Js代码</param>
        /// <param name="para">参数字符串(使用逗号分隔)</param>
        /// <param name="MethodName">方法名称</param>
        public static string V8Method(string reString, string para, string MethodName)
        {
            V8Engine engine = V8Engine.Create();//创建V8对象
            V8Script script = engine.Compile(reString);//编译
            try
            {
                engine.Execute(script);//将编译的脚本加载到V8引擎中
                string res = engine.Execute(string.Format("{0}({1})", MethodName, para)).ToString();//执行结果
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;//异常信息
            }
        }
        /// <summary>
        /// 执行js
        /// </summary>
        /// <param name="ex">方法</param>
        /// <param name="str">js结构</param>
        public static string jsEval(string ex, string str)
        {
            return V8Method(str,ex.Split('(')[1].Split(')')[0], ex.Split('(')[0]);
        }
        #region 获取指定节点数量
        /// <summary>
        /// 获取指定节点数量
        /// </summary>
        /// <param name="data">json文本</param>
        /// <param name="str">节点</param>
        /// <returns>int</returns>
        public static string get_ing(string data, string str)
        {
            string jsontet = json_js.Replace("【json】", data).Replace("【dian】", str);
            string i = jsEval("a()", jsontet);
            return i;
        }
        #endregion
        #region 预定义字段
        public static string json_js = "function a(){var a=【json】; return a.【dian】.length;}";//节点数量
        public static string json_js_1 = "function a(){var a=【json】; return a.【dian】;}";//节点文本
        public static string json_js_2 = "function a(){var a=【json】; a.【dian】.push('【shu】');return a.【dian】.length;}";//追加节点
        #endregion
        #region 获取指定节点文本
        /// <summary>
        /// 节点文本获取
        /// </summary>
        /// <param name="data"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string get_text(string data, string str)
        {
            string jsontxt = json_js_1.Replace("【json】", data).Replace("【dian】", str);
            string i = jsEval("a()", jsontxt);
            return i;
        }
        #endregion
        #region 追加节点
        /// <summary>
        /// 追加节点
        /// </summary>
        /// <param name="data"></param>
        /// <param name="str"></param>
        /// <param name="dian"></param>
        /// <returns></returns>
        public static string get_add(string data, string str, string dian)
        {
            string jsontxt = json_js_2.Replace("【json】", data).Replace("【dian】", str).Replace("【shu】", dian);
            string i = jsEval("a()", jsontxt);
            return i;
        }
        #endregion
        #region sql注入攻击
        public static string[] words = { "select", "insert", "delete", "count(", "drop table", "update", "truncate", "asc(", "mid(", "char(", "xp_cmdshell", "exec", "master", "net", "and", "or", "where" };

        public static string CheckParam(string Value)
        {
            Value = Value.Replace("'", "");
            Value = Value.Replace(";", "");
            Value = Value.Replace("--", "");
            Value = Value.Replace("/**/", "");
            return Value;
        }
        public static string CheckParamThrow(string Value)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (Value.IndexOf(words[i], StringComparison.OrdinalIgnoreCase) > 0)
                {
                    string pattern = string.Format(@"[\W]{0}[\W]", words[i]);
                    Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
                    if (rx.IsMatch(Value))
                        throw new Exception("发现sql注入痕迹!");
                }
            }
            return CheckParam(Value);
        }
        /// <summary>
        /// 查找是否含有非法参数
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool CheckParamBool(string Value)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (Value.IndexOf(words[i], StringComparison.OrdinalIgnoreCase) > 0)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
