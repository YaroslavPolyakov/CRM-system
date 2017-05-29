namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Serialization;

    public partial class Managers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Managers()
        {
            Tasks = new HashSet<Tasks>();
        }

        [Key]
        [Required]
        [MaxLength(40, ErrorMessage = "Поле 'ФИО' не должно содержать более 40 символов")]
        [MinLength(3, ErrorMessage = "Поле 'ФИО' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,.]{1,40}", ErrorMessage = "Некорректно введено ФИО")]
        public string Name { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Поле 'Логин' не должно содержать более 10 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Логин' не должно содержать менее 3 символов")]
        public string Login { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Поле 'Пароль' не должно содержать более 50 символов")]
        [MinLength(8, ErrorMessage = "Поле 'Пароль' не должно содержать менее 8 символов")]
        public byte[] Password { get; set; }

        [Required]
        public string Position { get; set; }
        [Required]
        public int? Group { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Поле 'Адрес' не должно содержать более 30 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Адрес' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^!`~:;@$%^*()_=?<>]{1,30}", ErrorMessage = "Некорректно введен адрес")]
        public string Address { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage = "Поле 'Телефон' не должно содержать более 13 символов")]
        [MinLength(13, ErrorMessage = "Поле 'Телефон' не должно содержать менее 13 символов")]
        [RegularExpression(@"^\+375[1-9]\d{8}$", ErrorMessage = "Номер телефона должен иметь формат +375XXXXXXXXX")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "Поле 'Паспорт' не должно содержать более 9 символов")]
        [MinLength(9, ErrorMessage = "Поле 'Паспорт' не должно содержать менее 9 символов")]
        [RegularExpression(@"^[KB,HB,HM]{2}[0-9]{7}$", ErrorMessage = "Некорректно введен паспорт")]
        public string Passport { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateRecruitment { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Поле 'E-mail' не должно содержать более 30 символов")]
        [MinLength(5, ErrorMessage = "Поле 'E-mail' не должно содержать менее 5 символов")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Некорректно введен адрес электронной почты")]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        public virtual CatalogGroupManagers CatalogGroupManagers { get; set; }

        public virtual CatalogPositions CatalogPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
