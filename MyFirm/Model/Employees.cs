//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyFirm.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employees
    {
        public Employees()
        {
            this.Customers = new HashSet<Customers>();
            this.Tasks = new HashSet<Tasks>();
        }
    
        public int emp_id { get; set; }
        public string emp_login { get; set; }
        public string emp_password { get; set; }
        public string emp_name { get; set; }
        public string emp_surName { get; set; }
        public string emp_phone { get; set; }
        public string emp_email { get; set; }
        public Nullable<System.DateTime> emp_dateBirth { get; set; }
    
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
