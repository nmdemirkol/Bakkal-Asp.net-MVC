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
    
    public partial class smaddeleri_log_ins_del
    {
        public int smlid_id { get; set; }
        public int sm_id { get; set; }
        public Nullable<double> si_miktar { get; set; }
        public Nullable<double> si_fiyat { get; set; }
        public Nullable<double> si_iskonto { get; set; }
        public Nullable<int> satis_id { get; set; }
        public Nullable<int> urun_id { get; set; }
        public System.DateTime islem_tarihi { get; set; }
        public string islem_turu { get; set; }
        public string islem_ip { get; set; }
    }
}
