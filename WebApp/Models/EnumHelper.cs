using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApp.Models
{
    public class EnumHelper
    {
        //Veritabanındaki enum değerlerini frontend'e taşımak için önce bu değerleri JSON formatına dönüştürcez
        public static List<SelectListItem> GetEnumSelectList<T>() where T : Enum
        {
            var enumType = typeof(T);
            return Enum.GetValues(enumType)
                .Cast<T>()
                .Select(e => new SelectListItem
                {
                    Value = Convert.ToInt32(e).ToString(),
                    Text = e.GetType()
                            .GetMember(e.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            ?.GetName() ?? e.ToString()
                }).ToList();
        }
    }
}
