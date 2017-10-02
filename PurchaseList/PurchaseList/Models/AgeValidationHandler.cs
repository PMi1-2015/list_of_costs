using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PurchaseList.Models
{
    class AgeValidationHandler : ValidationHandler
    {
        public AgeValidationHandler(TextBox _toCheck, Label _validation, ValidationHandler _next = null) : base(_toCheck, _validation, _next)
        {
        }

        protected override bool IsValid()
        {
            int a = 0;
            if(!int.TryParse(ToCheck.Text,out a))
            {
                return false;
            }

            if (a <= 0 || a > 150) return false;

            return true;
        }

        protected override void OutputError()
        {
            Validation.Content = "*Age must be not empty, and lie between 0 and 150";
        }
    }
}
