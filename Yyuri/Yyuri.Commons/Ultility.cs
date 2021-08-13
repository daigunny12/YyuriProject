using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Yyuri.Commons.Constants;

namespace Yyuri.Commons
{
    public static class Ultility
    {
        public static string NormalizeSqlString(string source)
        {
            if (!String.IsNullOrEmpty(source))
                source = source.Trim();
            return source;
        }

        public static bool IsValidEmailAddress(string emailAddress)
        {
            if (!String.IsNullOrEmpty(emailAddress))
                return System.Text.RegularExpressions.Regex.IsMatch(emailAddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return false;
        }

        public static int GetUnixTimestamp()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }

        public static List<String> GetMatches(String source)
        {
            List<String> keys = new List<string>();

            string pattern = @"{{(.+?)}}";
            System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(source, pattern);
            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                keys.Add(m.Value);
            }

            return keys;
        }

        public static string GetFullName(string firstName, string lastName)
        {
            string fullName = String.Format("{0} {1}", firstName, lastName);
            return fullName.Trim();

        }

        public static string GetFirstName(string fullName)
        {
            string firstName = fullName;
            int pos = fullName.IndexOf(" ");

            if (pos > 0)
                firstName = fullName.Substring(0, pos);

            return firstName.Trim();
        }

        public static string GetLastName(string fullName)
        {
            string lastName = String.Empty;

            int pos = fullName.IndexOf(" ");
            if (pos > 0)
                lastName = fullName.Substring(pos + 1, fullName.Length - pos - 1);

            return lastName.Trim();
        }

        public static string GetMonthName(Month month)
        {
            string[] months = new string[] { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            return months[(int)month];
        }

        public static string CreatePassword(int length)
        {
            const string validCharaters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string validDigits = "1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int pos = rnd.Next(length - 1);

            while (0 < --length)
            {
                if (rnd.NextDouble() > 0.3)
                {
                    res.Append(validCharaters[rnd.Next(validCharaters.Length)]);
                }
                else
                {
                    res.Append(validDigits[rnd.Next(validDigits.Length)]);
                } 
            }

            res.Insert(pos, '@');

            return res.ToString();
        }


        public static string DateToString(this DateTime dateTime)
        {
            var value = dateTime.ToString(Constants.DateFormat);
            return value;
        }
        public static DateTime StringToDate(this string dateTime)
        {
            var value = DateTime.ParseExact(dateTime, Constants.DateFormat, CultureInfo.InvariantCulture);
            return value;
        }


        public static string NullableDateToString(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            var value = dateTime.Value.ToString(Constants.DateFormat);
            return value;
        }
        public static DateTime? StringToNullableDate(this string dateTime)
        {
            if (string.IsNullOrEmpty(dateTime))
            {
                return null;
            }
            var value = DateTime.ParseExact(dateTime, Constants.DateFormat, CultureInfo.InvariantCulture);
            return value;
        }

        public static string BuildAttachmentLink(IFormFile file, string uploadPath, string folderUpload)
        {
            if (file != null)
            {
                string uniqueFileName = string.Empty;
                var filePath = string.Empty;

                uniqueFileName = string.Format("{0}-{1}", Guid.NewGuid().ToString(), file.FileName);
                filePath = string.Format("~/{0}/{1}", folderUpload, uniqueFileName);
                var fileFullPath = Path.Combine(uploadPath, uniqueFileName);

                using (var fileStream = new FileStream(fileFullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(fileFullPath);
                //attachment.Dispose();
                return filePath;
            }
            return string.Empty;
        }
        public static DateTime TimeToDate(int H, int M)
        {
            var now = DateTime.Now;
            DateTime value = new DateTime(now.Year, now.Month, now.Day, H, M, 0);
            return value;
        }
    }
}
