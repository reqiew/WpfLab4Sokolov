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

namespace WpfLab4Sokolov
{
    /// <summary>
    /// Логика взаимодействия для AddTrain.xaml
    /// </summary>
    public partial class AddTrain : Window
    {
        public AddTrain()
        {
            InitializeComponent();
        }
        public int Num
        {
            get
            {
                return int.Parse(tbID.Text);
            }
            set
            {
                tbID.Text = value.ToString();
            }
        }
        public string? Punkt
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }
        public string Time
        {
            get
            {
                return TimeOnly.Parse(tbHealth.Text).ToLongTimeString();
            }
            set
            {
                tbHealth.Text = value.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
