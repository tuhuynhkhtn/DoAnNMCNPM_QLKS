//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCQLKS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public int MaximumCus { get; set; }
    }
}
