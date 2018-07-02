using System;

namespace Volunteering.Domain.ValidationAttribute

{
   public  class MinDateAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public  bool IsValid(DateTime value)
        {
            //DateTime d = Convert.ToDateTime(value);
            return value >= DateTime.Now; //Dates Greater than or equal to today are valid (true)
        }

    }
}