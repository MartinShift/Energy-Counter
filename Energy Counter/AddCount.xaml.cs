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

namespace Energy_Counter
{
    /// <summary>
    /// Interaction logic for AddCount.xaml
    /// </summary>
    public partial class AddCount : Window
    {
        public AddCount()
        {
            InitializeComponent();
        }
        public double Amount { get; set; }
        private void Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                Amount = double.Parse(amount.Text);
                Close();
            }   catch(Exception)
            {
                MessageBox.Show("Invalid Value!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }         
        }
    }
}
