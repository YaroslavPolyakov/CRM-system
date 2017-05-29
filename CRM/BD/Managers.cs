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
        [MaxLength(40, ErrorMessage = "���� '���' �� ������ ��������� ����� 40 ��������")]
        [MinLength(3, ErrorMessage = "���� '���' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,.]{1,40}", ErrorMessage = "����������� ������� ���")]
        public string Name { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "���� '�����' �� ������ ��������� ����� 10 ��������")]
        [MinLength(3, ErrorMessage = "���� '�����' �� ������ ��������� ����� 3 ��������")]
        public string Login { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "���� '������' �� ������ ��������� ����� 50 ��������")]
        [MinLength(8, ErrorMessage = "���� '������' �� ������ ��������� ����� 8 ��������")]
        public byte[] Password { get; set; }

        [Required]
        public string Position { get; set; }
        [Required]
        public int? Group { get; set; }

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
        [MaxLength(9, ErrorMessage = "���� '�������' �� ������ ��������� ����� 9 ��������")]
        [MinLength(9, ErrorMessage = "���� '�������' �� ������ ��������� ����� 9 ��������")]
        [RegularExpression(@"^[KB,HB,HM]{2}[0-9]{7}$", ErrorMessage = "����������� ������ �������")]
        public string Passport { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? DateRecruitment { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "���� 'E-mail' �� ������ ��������� ����� 30 ��������")]
        [MinLength(5, ErrorMessage = "���� 'E-mail' �� ������ ��������� ����� 5 ��������")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}", ErrorMessage = "����������� ������ ����� ����������� �����")]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Info { get; set; }

        public virtual CatalogGroupManagers CatalogGroupManagers { get; set; }

        public virtual CatalogPositions CatalogPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
