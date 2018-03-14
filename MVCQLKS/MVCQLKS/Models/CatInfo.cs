using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQLKS.Models
{
    public class CatInfo
    {
        public int CatIDInfo { get; set; }
        public string CatNameInfo { get; set; }
        public string CatTypeInfo { get; set; }
        public decimal PriceInfo { get; set; }
        public string NoteInfo { get; set; }
    }
}