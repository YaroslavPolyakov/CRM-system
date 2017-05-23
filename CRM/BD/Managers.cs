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
        [Required]
        [StringLength(40,MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50),MinLength(8)]
        public byte[] Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Position { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Group { get; set; }

        [Required]
        [StringLength(30,MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(9,MinimumLength = 9)]
        public string Passport { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateRecruitment { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 6)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        public virtual CatalogGroupManagers CatalogGroupManagers { get; set; }

        public virtual CatalogPositions CatalogPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
