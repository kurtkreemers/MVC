using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BierenMVCSecurity
{
    public class AlcoholValueControlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            return ((float)value >= 0 && (float)value <= 15);
        }
    }
}