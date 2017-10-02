using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PurchaseList.Models
{
    class SurnameValidationHandler : ValidationHandler
    {
        public SurnameValidationHandler(TextBox _toCheck, Label _validation, ValidationHandler _next = null) : base(_toCheck, _validation, _next)
        {
        }

        protected override bool IsValid()
        {
            return !string.IsNullOrEmpty(ToCheck.Text) && ToCheck.Text.Length >= 2;
        }

        protected override void OutputError()
        {
            Validation.Content = "* Surname field must contain at least 2 characters";
        }
    }
}
