//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BakkalWebProjesi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class stok_log_ins_del
    {
        public int stlid_id { get; set; }
        public int stok_id { get; set; }
        public Nullable<int> s_adedi { get; set; }
        public Nullable<System.DateTime> s_giris_tarihi { get; set; }
        public Nullable<System.DateTime> s_bitis_tarihi { get; set; }
        public System.DateTime islem_tarihi { get; set; }
        public string islem_turu { get; set; }
        public string islem_ip { get; set; }
    }
}
