using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using PasswordHandler.Models;

namespace PasswordHandler.Attributes
{
    public class MinimumLengthAttribute : ValidationAttribute
    {

        private readonly int _length;
        public MinimumLengthAttribute(int length)
        {
            _length = length;
        }


        public override bool IsValid(object value)
        {
            int length = Convert.ToInt32(value.ToString());
            return  length >= _length;
        }
    }
}
