//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.MonitorTasks = new HashSet<MonitorTask>();
        }
    
        public int Task_ID { get; set; }
        public string Task_Description { get; set; }
        public string Task_Schedule { get; set; }
        public string Task_Type { get; set; }
        public string Task_Status { get; set; }
        public int User_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitorTask> MonitorTasks { get; set; }
        public virtual User User { get; set; }
    }
}