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

        [MaxLength(15, ErrorMessage = "���� '��������' �� ������ ��������� ����� 15 ��������")]
        [MinLength(3, ErrorMessage = "���� '��������' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,]{1,15}", ErrorMessage = "����������� ������ ��������")]
        public string Client { get; set; }


        [MaxLength(40, ErrorMessage = "���� '�����������' �� ������ ��������� ����� 40 ��������")]
        [MinLength(3, ErrorMessage = "���� '�����������' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,]{1,40}", ErrorMessage = "����������� ������ �����������")]
        public string Manager { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "���� '������' �� ������ ��������� ����� 30 ��������")]
        [MinLength(3, ErrorMessage = "���� '������' �� ������ ��������� ����� 3 ��������")]
        [RegularExpression(@"[^0-9!`~:;@$%^*()_=/\?<>,.]{1,30}", ErrorMessage = "����������� ������� ������")]
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
