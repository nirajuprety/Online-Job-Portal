//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class EducationTable
    {
        public int EducationID { get; set; }
        public string InstituteName { get; set; }
        public string TitleofEducation { get; set; }
        public string Degree { get; set; }
        public System.DateTime FromYear { get; set; }
        public System.DateTime ToYear { get; set; }
        public string City { get; set; }
        public int CountryID { get; set; }
        public int EmployeeID { get; set; }
    
        public virtual CountryTable CountryTable { get; set; }
        public virtual EmployeesTable EmployeesTable { get; set; }
    }
}
