using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _2021NCKH.Service
{
    public class CommonService
    {
            /// <summary>
            /// Mã hóa md5
            /// </summary>
            /// <param name="s">Chuỗi cần mã hóa md5</param>
            /// <returns>Chuỗi đã mã hóa md5</returns>
            public string hash(string s)
            {
                MD5 md = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(s);
                byte[] hash = md.ComputeHash(inputBytes);
                StringBuilder sbHash = new StringBuilder();
                foreach (byte b in hash)
                {
                    sbHash.Append(String.Format("{0:x2}", b));
                }
                return sbHash.ToString();
            }
    }
}