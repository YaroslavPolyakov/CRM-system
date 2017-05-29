namespace CRM.BD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Xml.Serialization;

    public partial class Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            Tasks = new HashSet<Tasks>();
        }

        [Key]
        [Required]
        [XmlAttribute]
        [MaxLength(20, ErrorMessage = "Поле 'Название' не должно содержать более 20 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Название' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^!`~:;@$%^*()_=/\?<>,]{1,20}", ErrorMessage = "Некорректно введено название")]
        public string Name { get; set; }

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
        [MaxLength(30, ErrorMessage = "Поле 'E-mail' не должно содержать более 30 символов")]
        [MinLength(5, ErrorMessage = "Поле 'E-mail' не должно содержать менее 5 символов")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "Некорректно введен адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Поле 'Расчётный счёт' не должно содержать более 10 символов")]
        [MinLength(10, ErrorMessage = "Поле 'Расчётный счёт' не должно содержать менее 10 символов")]
        [RegularExpression(@"[0-9]\d{9}$", ErrorMessage = "Некорректно введен расчётный счёт")]
        public string CheckingAccount { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Поле 'Банк' не должно содержать более 15 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Банк' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,+-]{1,15}$", ErrorMessage = "Некорректно введено название банка")]
        public string Bank { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Поле 'Директор' не должно содержать более 15 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Директор' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,+-]{1,15}$", ErrorMessage = "Некорректно введена фамилия директора банка")]
        public string Director { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Поле 'Бухгалтер' не должно содержать более 15 символов")]
        [MinLength(3, ErrorMessage = "Поле 'Бухгалтер' не должно содержать менее 3 символов")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,+-]{1,15}$", ErrorMessage = "Некорректно введена фамилия бухгалтера")]
        public string Accountant { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
