using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLab4Sokolov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Train<int>[]? Trains { get; set; } = null;
        private bool isHealthSort = true;
        public MainWindow()
        {
            InitializeComponent();
            mmCopy.IsEnabled = false;
            mmCreate.IsEnabled = false;
            tbCreate.IsEnabled = false;
            tbCopy.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbCount.Text.Length != 0)
            {
                Trains = null;
                Trains = new Train<int>[int.Parse(tbCount.Text)];
                MessageBox.Show("Массив размером " + Trains.Length + " элемента создан");
                Train<int>.Count = 0;
                mmCopy.IsEnabled = true;
                mmCreate.IsEnabled = true;
                tbCreate.IsEnabled = true;
                tbCopy.IsEnabled = true;
                trainList.ItemsSource = null;
                stCount.Content = "Создано " + Train<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Введите размер массива");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void mmCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }
        void GridViewColumnHeaderClickedHandler(object sender,
                                        RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked!.Content.ToString() == "Время")
            {
                if (isHealthSort)
                {
                    Array.Sort(Trains!);
                }
                else
                {
                    Trains = Trains!.OrderByDescending(p => p.Time).ToArray();
                }
                isHealthSort = !isHealthSort;
            }
            if (headerClicked!.Content.ToString() == "Номер")
            {
                if (!isHealthSort)
                {
                    Array.Sort(Trains!);

                }
                else
                {
                    Trains = Trains!.OrderByDescending(p => p.Num).ToArray();
                }
             isHealthSort = !isHealthSort;
            
            
            }

                trainList.ItemsSource = null;
            trainList.ItemsSource = Trains;
        }
            

        private void tbCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        private void tbCreate_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void Copy()
        {
            if (trainList.SelectedItems.Count != 0)
            {
                Train<int>? Train = trainList.SelectedItem as Train<int>;
                Trains![Train<int>.Count] = (Train<int>)Train!.Clone();
                trainList.ItemsSource = null;
                trainList.ItemsSource = Trains;
                Train<int>.Count++;
                stCount.Content = "Создано " + Train<int>.Count + " из " + tbCount.Text;
            }
        }
        private void Add()
        {
            if (Trains!.Length > Train<int>.Count)
            {
                AddTrain add = new AddTrain();
                if (add.ShowDialog() == true)
                {
                    Trains[Train<int>.Count] = new Train<int>();
                    Trains[Train<int>.Count].Num = add.Num;
                    Trains[Train<int>.Count].Punkt = add.Punkt;
                    Trains[Train<int>.Count].Time = TimeOnly.Parse(add.Time);
                    
                    Train<int>.Count++;
                }
                trainList.ItemsSource = null;
                trainList.ItemsSource = Trains;
                stCount.Content = "Создано " + Train<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Массив полностью заполнен");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }
    }
}