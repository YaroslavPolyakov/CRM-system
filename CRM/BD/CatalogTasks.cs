namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CatalogTasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatalogTasks()
        {
            Tasks = new HashSet<Tasks>();
        }

        [Key]
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Task { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
