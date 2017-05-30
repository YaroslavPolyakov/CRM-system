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

        [MaxLength(15, ErrorMessage = "Поле 'Заказчик' не должно содержать более 15 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Заказчик' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,]{1,15}", ErrorMessage = "Некорректно введен заказчик")]
        public string Client { get; set; }


        [MaxLength(40, ErrorMessage = "Поле 'Исполнитель' не должно содержать более 40 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Исполнитель' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,]{1,40}", ErrorMessage = "Некорректно введен исполнитель")]
        public string Manager { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Поле 'Задача' не должно содержать более 30 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Задача' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,.]{1,30}", ErrorMessage = "Некорректно введена задача")]
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

        [StringLength(15)]
        public string Status { get; set; }

        public virtual CatalogStatus CatalogStatus { get; set; }

        public virtual CatalogTasks CatalogTasks { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Managers Managers { get; set; }
    }
}
