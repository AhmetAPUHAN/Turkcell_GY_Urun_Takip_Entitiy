//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Turkcell_GY_Urun_Takip_Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLSatıslar
    {
        public int Id { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Musteri { get; set; }
        public Nullable<byte> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<decimal> Toplam { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
    
        public virtual TBLMusteri TBLMusteri { get; set; }
        public virtual TBLUrunler TBLUrunler { get; set; }
    }
}
