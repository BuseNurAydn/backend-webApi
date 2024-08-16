using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public enum TaxCalculationType
    {
        [Display(Name = "Taksit Tutarı")]
        TaksitTutari = 1,
        [Display(Name = "Kâr Payı Tutarı")]
        KarPayiTutari = 2,
        [Display(Name = "Komisyon Tutarı")]
        KomisyonTutari = 3,
        [Display(Name = "Gecikme Tutarı")]
        GecikmeTutari = 4
    }
}
