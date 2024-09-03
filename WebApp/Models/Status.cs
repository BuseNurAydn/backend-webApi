using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public enum Status
    {
        [Display(Name = "Aktif")]
        Aktif = 1,

        [Display(Name = "Pasif")]
        Pasif = 0
    }
}
