using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class TaxDefinition
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName ="nvarchar(100)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(100)")] 
        public string LegalTaxCode { get; set; }

        [Column(TypeName = "nvarchar(100)")] 
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(300)")] 
        public string Description { get; set; }
        public decimal Ratio { get; set; }

        public CustomerType CustomerType { get; set; } //enum olarak
        public TaxCalculationType TaxCalculationType { get; set; } //enum olarak

        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        [NotMapped]  //veritabanına kaydedilmeyecek
        public Status Status { get; set; } = Status.Aktif; //enum olarak / ilk kayıt atarken varsayılan olarak aktif

        [Column("Durum")]
        public bool StatusBool
        {
            get => Status == Status.Aktif; //aktif ise true
            set => Status = value ? Status.Aktif : Status.Pasif; // true ise Aktif, değilse Pasif
        }

    

    }
}
