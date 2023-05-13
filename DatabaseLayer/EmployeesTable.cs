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
    
    public partial class EmployeesTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeesTable()
        {
            this.CertificateTables = new HashSet<CertificateTable>();
            this.EducationTables = new HashSet<EducationTable>();
            this.JobApplyTables = new HashSet<JobApplyTable>();
            this.LanguageTables = new HashSet<LanguageTable>();
            this.SkillTables = new HashSet<SkillTable>();
            this.WorkExperienceTables = new HashSet<WorkExperienceTable>();
        }
    
        public int EmployeeID { get; set; }
        public int JobCategoryID { get; set; }
        public int UserID { get; set; }
        public string EmployeeName { get; set; }
        public System.DateTime DOB { get; set; }
        public string CNIC { get; set; }
        public string FNIC { get; set; }
        public string FatherName { get; set; }
        public int CountryID { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Qualification { get; set; }
        public string PermanentAddress { get; set; }
        public int CurrentJobStatusID { get; set; }
        public string Description { get; set; }
        public string JobReferences { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CertificateTable> CertificateTables { get; set; }
        public virtual CountryTable CountryTable { get; set; }
        public virtual CurrentJobStatusTable CurrentJobStatusTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationTable> EducationTables { get; set; }
        public virtual JobCategoryTable JobCategoryTable { get; set; }
        public virtual UsersTable UsersTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobApplyTable> JobApplyTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LanguageTable> LanguageTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkillTable> SkillTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkExperienceTable> WorkExperienceTables { get; set; }
    }
}
