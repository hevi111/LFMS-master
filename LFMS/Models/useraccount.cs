//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LFMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class useraccount
    {
        public int id { get; set; }
        public string email { get; set; }
        public Nullable<int> departmentid { get; set; }
        public string role { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }
}
