using PurchaseList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PurchaseList
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public ValidationHandler Chain { get; set; }

        public ValidationHandler GenerateHandlerChain()
        {
            ValidationHandler name = new NameValidationHandler(this.Name, this.Name_Validation);
            ValidationHandler surname = new SurnameValidationHandler(this.Surname, this.Surname_Validation);
            ValidationHandler country = new CountryValidationHandler(this.Country, this.Country_Validation);
            ValidationHandler age = new AgeValidationHandler(this.Age, this.Age_Validation);
            ValidationHandler email = new EmailValidationHandler(this.Email, this.Email_Validation);

            name.Next = surname;
            surname.Next = country;
            country.Next = age;
            age.Next = email;

            return name;
        }

        public Register()
        {
            InitializeComponent();
            Chain = GenerateHandlerChain();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Chain.Handle())
                {
                    User u = new User()
                    {
                        Name = Name.Text,
                        Surname = Surname.Text,
                        Country = Country.Text,
                        Age = int.Parse(Age.Text),
                        Email = Email.Text
                    };

                    DbService.AddUser(u);

                    this.QueryResult.Foreground = new SolidColorBrush(Colors.Green);
                    this.QueryResult.Content = "User successfully registered";
                    Thread.Sleep(1000);
                    this.Close();
                }
            }
            catch(AccessViolationException)
            {
                this.QueryResult.Content = "User with this email algready exists";
            }
            catch
            {
                this.Foreground = new SolidColorBrush(Colors.Red);
                this.QueryResult.Content = "Some error occured. Please try again";
            }
        }
    }
}
