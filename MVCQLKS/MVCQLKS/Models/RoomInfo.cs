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
        public string RoomTypeInfo { get; set; }
        public decimal PriceInfo { get; set; }
        public string NoteInfo { get; set; }
        public int StatusInfo { get; set; }
        public int MaximumCusInfo { get; set; }

    }

    public enum ValueRoomType
    {
        A,
        B,
        C
    }
}