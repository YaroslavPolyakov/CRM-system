namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(15)]
        public string Client { get; set; }

        [StringLength(40)]
        public string Manager { get; set; }

        [StringLength(30)]
        public string Task { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateComplete { get; set; }

        [StringLength(15)]
        public string Status { get; set; }

        public virtual CatalogStatus CatalogStatus { get; set; }

        public virtual CatalogTasks CatalogTasks { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Managers Managers { get; set; }
    }
}
