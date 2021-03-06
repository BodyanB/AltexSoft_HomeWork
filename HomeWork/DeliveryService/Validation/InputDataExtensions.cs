using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DeliveryService.Validation
{
  public static  class InputDataExtensions
    {
        public static bool IsPhoneNumber(this string number)
        {
            var pattern = @"^([+]38)?0[(]?[0-9]{2}[)]?[\s]?[0-9]{3}[\s]?[0-9]{2}[\s]?[0-9]{2}$";
            var expression = new Regex(pattern);
            return expression.IsMatch(number);
        }
        public static bool IsEmail(this string email)
        {
            var pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var expression = new Regex(pattern);
            return expression.IsMatch(email);
        }
        public static bool IsAddress(this string address)
        {
            var pattern = @"^ул(ица\s|[.][\s]?){1}[А-Яа-я]{5}[А-Яа-я\s]*[.,]{1}[\s]?д(ом|[.]){1}[\s]?[0-9]{1,3}(,[\s]?кв(артира|[.]){1}[\s]?[0-9]{1,4})?$";
            var expression = new Regex(pattern, RegexOptions.IgnoreCase);
            return expression.IsMatch(address);
        }
    }
}
