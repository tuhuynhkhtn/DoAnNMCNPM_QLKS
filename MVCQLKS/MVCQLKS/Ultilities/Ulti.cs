using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using MVCQLKS.Models;

namespace MVCQLKS.Ultilities
{
    public class Ulti
    {
        public static string Md5Hash(string str)
        {
            using (var md5 = MD5.Create())
            {
                byte[] arr = Encoding.ASCII.GetBytes(str);
                byte[] arrMd5 = md5.ComputeHash(arr);
                StringBuilder sb = new StringBuilder();
                foreach(var b in arrMd5)
                {
                    sb.AppendFormat("{0:X}", b);
                }
                return sb.ToString();
            }
        }

        public static decimal GetCatPrice(int id)
        {
            decimal gia = 0;
            using (var dc = new QLKSEntities())
            {
                var cat = dc.Categories.Where(c => c.CatID == id).FirstOrDefault();
                if (cat != null)
                {
                    gia = cat.Price;
                    return gia;
                }
            }
            return gia;
        }
    }
}