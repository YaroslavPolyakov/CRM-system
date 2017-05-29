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
        [MaxLength(20, ErrorMessage = "���� '��������' �� ������ ��������� ����� 20 ��������")]
        [MinLength(3, ErrorMessage = "���� '��������' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^!`~:;@$%^*()_=/\?<>,]{1,20}", ErrorMessage = "����������� ������� ��������")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "���� '�����' �� ������ ��������� ����� 30 ��������")]
        [MinLength(3, ErrorMessage = "���� '�����' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^!`~:;@$%^*()_=?<>]{1,30}", ErrorMessage = "����������� ������ �����")]
        public string Address { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage = "���� '�������' �� ������ ��������� ����� 13 ��������")]
        [MinLength(13, ErrorMessage = "���� '�������' �� ������ ��������� ����� 13 ��������")]
        [RegularExpression(@"^\+375[1-9]\d{8}$", ErrorMessage = "����� �������� ������ ����� ������ +375XXXXXXXXX")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "���� 'E-mail' �� ������ ��������� ����� 30 ��������")]
        [MinLength(5, ErrorMessage = "���� 'E-mail' �� ������ ��������� ����� 5 ��������")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "����������� ������ ����� ����������� �����")]
        public string Email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "���� '��������� ����' �� ������ ��������� ����� 10 ��������")]
        [MinLength(10, ErrorMessage = "���� '��������� ����' �� ������ ��������� ����� 10 ��������")]
        [RegularExpression(@"[0-9]\d{9}$", ErrorMessage = "����������� ������ ��������� ����")]
        public string CheckingAccount { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "���� '����' �� ������ ��������� ����� 15 ��������")]
        [MinLength(3, ErrorMessage = "���� '����' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,+-]{1,15}$", ErrorMessage = "����������� ������� �������� �����")]
        public string Bank { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "���� '��������' �� ������ ��������� ����� 15 ��������")]
        [MinLength(3, ErrorMessage = "���� '��������' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,+-]{1,15}$", ErrorMessage = "����������� ������� ������� ��������� �����")]
        public string Director { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "���� '���������' �� ������ ��������� ����� 15 ��������")]
        [MinLength(3, ErrorMessage = "���� '���������' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,+-]{1,15}$", ErrorMessage = "����������� ������� ������� ����������")]
        public string Accountant { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
