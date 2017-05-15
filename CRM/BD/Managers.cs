namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Managers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Managers()
        {
            Tasks = new HashSet<Tasks>();
        }

        [Key]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public byte[] Password { get; set; }

        [StringLength(20)]
        public string Position { get; set; }

        [StringLength(20)]
        public string Group { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(9)]
        public string Passport { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateRecruitment { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        public virtual CatalogGroupManagers CatalogGroupManagers { get; set; }

        public virtual CatalogPositions CatalogPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
