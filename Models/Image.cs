//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImagesManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GUID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public double Rating { get; set; }
    }
}