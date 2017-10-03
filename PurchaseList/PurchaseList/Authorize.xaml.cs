using PurchaseList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Authorize.xaml
    /// </summary>
    public partial class Authorize : Window
    {
        public Authorize()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DbService.SetOnlineUser(textBox.Text))
                {
                    Dashboard d = new Dashboard();
                    d.Show();
                    this.Close();
                }
            }
            catch (ArgumentNullException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
