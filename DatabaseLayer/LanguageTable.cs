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
    
    public partial class LanguageTable
    {
        public int LanguageID { get; set; }
        public int EmployeeID { get; set; }
        public string LanguageName { get; set; }
        public string LanguageProficiency { get; set; }
    
        public virtual EmployeesTable EmployeesTable { get; set; }
    }
}
