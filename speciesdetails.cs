//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Herbarium
{
    using System;
    using System.Collections.Generic;
    
    public partial class speciesdetails
    {
        public int id { get; set; }
        public Nullable<int> speciesid { get; set; }
        public string lifetime { get; set; }
        public string structure { get; set; }
        public string blooming { get; set; }
        public string habitat { get; set; }
        public string height { get; set; }
        public Nullable<bool> endemism { get; set; }
        public string element { get; set; }
        public string turkeydist { get; set; }
        public string generaldist { get; set; }
        public string vilayets { get; set; }
        public string grids { get; set; }
    
        public virtual species species { get; set; }
    }
}