using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Yyuri.Commons.Utilities
{
    /// <summary>
    /// using key in webconfig to generate lastkey, go to defination(F12) to view example
    ///     <example>
    ///     <add key="Project_Prefix" value="PJ" />
    ///     <add key = "Project_Seperator" value="_3" />
    ///     <add key = "Project_LastKey" value="" />
    ///     </example>
    /// </summary>
    public static class GenerationCode
    {
        private static Dictionary<string, string> _lastKey;

        private static string GetLastKeyByCodeType(CodeType codeType)
        {
            string type = codeType.ToString();
            if (_lastKey == null)
            {
                _lastKey = new Dictionary<string, string>();
            }
            if (!_lastKey.ContainsKey(type))
            {
                _lastKey.Add(type, string.Empty);
            }
            return _lastKey[type];
        }
        public enum CodeType
        {
            Project = 1
        }

        /// <summary>
        /// Get LastKey by CodeType
        /// </summary>
        /// <param name="codeType">GenerationCode.CodeType</param>
        /// <returns></returns>
        public static string GetLastKey(CodeType codeType)
        {
            string code = CreateLastKey(codeType);
            return code;
        }
        /// <summary>
        /// Update LastKey
        /// </summary>
        /// <param name="curKey">current key used</param>
        /// <param name="codeType">GenerationCode.CodeType</param>
        /// <returns>status success or failed</returns>
        public static bool UpdateLastKey(string curKey, CodeType codeType)
        {
            string seperator = string.Empty;
            string keyLenght = string.Empty;
            string lastKey = string.Empty;
            try
            {
                if(codeType == CodeType.Project)
                {
                    seperator = Constants.Project_Seperator;
                }
                //Handle if key not exists in web.config
                lastKey = GetLastKeyByCodeType(codeType);//_webConfigApp.AppSettings.Settings[codeType + "_LastKey"].Value;
                keyLenght = seperator.Substring(1);
                seperator = seperator[0].ToString();
            }
            catch (Exception ex)
            {
                return false;
            }
            string curLastKey = GetCurLastKey(curKey, seperator);
            if (curLastKey.Equals(lastKey))
            {
                int keyNumber = int.Parse(curLastKey.Split(seperator.ToCharArray())[1]);
                keyNumber += 1;
                lastKey = curLastKey.Split(seperator.ToCharArray())[0] + seperator + String.Format("{0:D" + keyLenght + "}", keyNumber);
                _lastKey[codeType.ToString()] = lastKey;//_webConfigApp.AppSettings.Settings[codeType + "_LastKey"].Value = lastKey;
                //_webConfigApp.Save();
            }
            return false;
        }
        /// <summary>
        /// Get lastkey from current key
        /// </summary>
        /// <param name="curKey">current key used</param>
        /// <param name="seperator">seperator</param>
        /// <returns>Lastkey used</returns>
        private static string GetCurLastKey(string curKey, string seperator)
        {
            try
            {
                string[] param = curKey.Split(seperator.ToCharArray());
                return param[1] + seperator + param[2];
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Create LastKey and Return Code
        /// </summary>
        /// <param name="codeType">GenerationCode.CodeType</param>
        /// <returns></returns>
        private static string CreateLastKey(CodeType codeType)
        {
            string prefix = string.Empty;
            string seperator = string.Empty;
            string keyLenght = string.Empty;
            string lastKey = string.Empty;
            string curDate = DateTime.Now.ToString("yyMMdd");
            try
            {
                if(codeType == CodeType.Project)
                {
                    prefix = Constants.Project_Prefix;
                    seperator = Constants.Project_Seperator;
                }
                //Handle if key not exists in web.config
                
                lastKey = GetLastKeyByCodeType(codeType);//_webConfigApp.AppSettings.Settings[codeType + "_LastKey"].Value;
                keyLenght = seperator.Substring(1);
                seperator = seperator[0].ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(lastKey) || !lastKey.Split(seperator.ToCharArray())[0].Equals(curDate))
            {
                //Generation Lastkey  
                int keyNumber = 1;
                lastKey = curDate + seperator + String.Format("{0:D" + keyLenght + "}", keyNumber);
                _lastKey[codeType.ToString()] = lastKey;//_webConfigApp.AppSettings.Settings[codeType + "_LastKey"].Value = lastKey;
                //_webConfigApp.Save();
            }
            return prefix + seperator + lastKey;
        }
    }
}
