namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Serialization;

    [Serializable]
    public partial class Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            Tasks = new HashSet<Tasks>();
        }

        [Key]
        [StringLength(15,MinimumLength =3)]
        [Required]
        [XmlAttribute]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string CheckingAccount { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Bank { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Director { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Accountant { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
