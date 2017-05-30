namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CatalogGroupManagers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatalogGroupManagers()
        {
            Managers = new HashSet<Managers>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Поле 'Группа' не должно содержать более 20 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Группа' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,.]{1,20}", ErrorMessage = "Некорректно введена группа")]
        public string Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Managers> Managers { get; set; }
    }
}
