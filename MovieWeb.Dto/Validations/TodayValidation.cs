using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Dto.Validations
{
    public class TodayValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;

            return dt.Date <= DateTime.Now.Date;
        }
    }
}
