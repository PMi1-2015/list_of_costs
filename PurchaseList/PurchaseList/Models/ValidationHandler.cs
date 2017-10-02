using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PurchaseList.Models
{
    public abstract class ValidationHandler
    {
        public ValidationHandler Next { get; set; }
        protected TextBox ToCheck { get; set; }
        protected Label Validation { get; set; }

        public ValidationHandler(TextBox _toCheck, Label _validation, ValidationHandler _next)
        {
            Next = _next;
            ToCheck = _toCheck;
            Validation = _validation;
        }

        

        public bool Handle()
        {
            if (!IsValid())
            {
                Validation.Foreground = new SolidColorBrush(Colors.Red);
                OutputError();

                return false;
            }
            else
            {
                Validation.Content = "";

                if(Next != null)
                {
                    return Next.Handle();
                }
            }

            return true;
        }

        protected abstract void OutputError();

        protected abstract bool IsValid();
    }
}
