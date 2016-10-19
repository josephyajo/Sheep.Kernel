using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sheep.Kernel.Convertion
{
    public class ConvertionHandler
    {
        public static string ToGB2312(string str)
        {
            string result = str;
            MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            byte[] bts = new byte[2];
            foreach (Match m in mc)
            {
                bts[0] = (byte)int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
                bts[1] = (byte)int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                string oldStr = m.Value;
                string newStr = Encoding.Unicode.GetString(bts);
                result = result.Replace(oldStr, newStr);
            }
            return result;
        }

        public static string ToUnicode(string str)
        {
            byte[] bts = Encoding.Unicode.GetBytes(str);
            string result = "";
            for (int i = 0; i < bts.Length; i += 2) result += "\\u" + bts[i + 1].ToString("x").PadLeft(2, '0') + bts[i].ToString("x").PadLeft(2, '0');
            return result;
        }
    }
}
