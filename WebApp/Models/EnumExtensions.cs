using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApp.Models{
    public static class EnumExtensions
    {
        //// Enum değerlerini düzgün bir biçimde yazmak için yardımcı method
        
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())[0]
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name ?? enumValue.ToString();
        }

    }
    
}
