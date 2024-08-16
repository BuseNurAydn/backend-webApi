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

        
    }
}
