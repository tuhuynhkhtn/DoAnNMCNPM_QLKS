using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQLKS.Models
{
    public class RoomInfo
    {
        public int RoomIDInfo { get; set; }
        public string RoomNameInfo { get; set; }
        public int CatIDInfo { get; set; }
        //public Nullable<decimal> PriceInfo { get; set; }
        public decimal PriceInfo { get; set; }
        public int StatusInfo { get; set; }
    }
}