namespace MyWebApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonitorTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MonitorTask_ID { get; set; }

        public int Monitor_ID { get; set; }

        public int Task_ID { get; set; }

        public virtual Monitor Monitor { get; set; }

        public virtual Task Task { get; set; }
    }
}
