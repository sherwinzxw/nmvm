//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nmvm.Models.nmvm
{
    using System;
    using System.Collections.Generic;
    
    public partial class Backfill
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public int BackfillEmployeeId { get; set; }
        public decimal BackfillFte { get; set; }
        public Nullable<System.DateTime> BackfillFrom { get; set; }
        public Nullable<System.DateTime> BackfillTo { get; set; }
        public Nullable<int> BackfillDurationHours { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedByDisplayName { get; set; }
        public string CreatedBySystemName { get; set; }
        public System.DateTime ModifiedDateTime { get; set; }
        public string ModifiedByDisplayName { get; set; }
        public string ModifiedBySystemName { get; set; }
    }
}
