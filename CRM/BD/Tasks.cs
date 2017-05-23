namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }


        [StringLength(15,MinimumLength =3)]
        public string Client { get; set; }


        [StringLength(40, MinimumLength = 3)]
        public string Manager { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Task { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Info { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateStart { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateComplete { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Status { get; set; }

        public virtual CatalogStatus CatalogStatus { get; set; }

        public virtual CatalogTasks CatalogTasks { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Managers Managers { get; set; }
    }
}
