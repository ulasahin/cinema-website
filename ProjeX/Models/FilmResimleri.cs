//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjeX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FilmResimleri
    {
        public short Id { get; set; }
        public byte[] Image { get; set; }
        public Nullable<short> FilmId { get; set; }
    
        public virtual Filmler Filmler { get; set; }
    }
}
