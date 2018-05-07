using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQLKS.Models
{
    public class OrderInfo
    {
        public int OrderIDInfo { get; set; }
        public int CusIDInfo { get; set; }
        public decimal TotalInfo { get; set; }
        public int StatusPayInfo { get; set; }
    }
}