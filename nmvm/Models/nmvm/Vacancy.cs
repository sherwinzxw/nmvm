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
    
    public partial class Vacancy
    {
        public int Id { get; set; }
        public string VacancyType { get; set; }
        public int ContractId { get; set; }
        public int PositionId { get; set; }
        public decimal VacantFte { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonDetails { get; set; }
        public System.DateTime VacantFromDateTime { get; set; }
        public Nullable<System.DateTime> VacantToDateTime { get; set; }
        public int VacantDurationHours { get; set; }
        public string Comments { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedByDisplayName { get; set; }
        public string CreatedByUserName { get; set; }
        public string ModifiedByUserName { get; set; }
        public System.DateTime ModifiedDateTime { get; set; }
        public string ModifiedByDisplayName { get; set; }
    }
}
