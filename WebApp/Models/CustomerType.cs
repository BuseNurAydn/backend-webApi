using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public enum CustomerType
    {
        [Display(Name = "Bireysel Müşteri")]
        BireyselMusteri = 1,
        [Display(Name = "Kurumsal Müşteri")]
        KurumsalMusteri = 2,
        [Display(Name = "Şahıs Şirketi")]
        SahisSirketi = 3,
        [Display(Name = "Ortak Müşteri")]
        OrtakMusteri = 4,
        [Display(Name = "Şubeli Kuruluş Müşteri")]
        SubeliKurulusMusteri = 5,
        [Display(Name = "Test Automation")]
        TestAutomation = 6
    }
}
