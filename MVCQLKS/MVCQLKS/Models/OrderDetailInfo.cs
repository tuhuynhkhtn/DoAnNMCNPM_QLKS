using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQLKS.Models
{
    public class OrderDetailInfo
    {
        public int OrderIDInfo { get; set; }
        public int RoomIDInfo { get; set; }
        public int QuantityInfo { get; set; }
        public int StatusForeignCusInfo { get; set; }
        public System.DateTime OrderCheckInInfo { get; set; }
        public System.DateTime OrderCheckOutInfo { get; set; }
        public int NODOrderInfo { get; set; }
        public decimal PriceInfo { get; set; }
        public decimal AmountInfo { get; set; }
    }
}