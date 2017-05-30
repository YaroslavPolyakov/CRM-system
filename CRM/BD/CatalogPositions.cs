namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CatalogPositions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatalogPositions()
        {
            Managers = new HashSet<Managers>();
        }

        [Key]
        [Required]
        [MaxLength(20, ErrorMessage = "Поле 'Должность' не должно содержать более 20 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Должность' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,.]{1,20}", ErrorMessage = "Некорректно введена должность")]
        public string Position { get; set; }

        [Column(TypeName = "money")]
        [Required]
        [RegularExpression(@"[0-9,.$~]\d{1,20}$", ErrorMessage = "Некорректно введена зарплата")]
        public decimal? Pay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Managers> Managers { get; set; }
    }
}
