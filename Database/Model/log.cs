﻿//------------------------------------------------------------------------------
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

    public partial class log
    {
        public int id { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
        public string logtext { get; set; }
        public string details { get; set; }

        public virtual user user { get; set; }
    }
}
