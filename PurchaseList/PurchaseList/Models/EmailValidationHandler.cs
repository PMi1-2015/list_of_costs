using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PurchaseList.Models
{
    class EmailValidationHandler : ValidationHandler
    {
        public EmailValidationHandler(TextBox _toCheck, Label _validation, ValidationHandler _next = null) : base(_toCheck, _validation, _next)
        {
        }

        protected override bool IsValid()
        {
            try
            {
                MailAddress m = new MailAddress(ToCheck.Text);

                return true;
            }
            catch
            {
                return false;
            }
        }

        protected override void OutputError()
        {
            Validation.Content = "*Please enter a valid email";
        }
    }
}
