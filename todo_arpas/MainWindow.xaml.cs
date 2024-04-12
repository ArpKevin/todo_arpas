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

namespace todo_arpas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            for (int i = 0; i < 5; i++)
            {
                listboxTesztadatok.Items.Insert(i, $"adat{i+1}");
            }
            listboxTesztadatok.SelectedIndex = 0;
            btnTorles.IsEnabled = true;
        }

        private void btnDelAll_Click(object sender, RoutedEventArgs e)
        {
            listboxTesztadatok.Items.Clear();
            btnDelAll.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string adat = txtboxBevitel.Text;
            if (adat.Trim() == "")
            {
                MessageBox.Show("Nincs megadva érték.");
            }
            else if (listboxTesztadatok.Items.Contains(adat))
            {
                MessageBox.Show("Már benne van.");
            }
            else
            {
                listboxTesztadatok.Items.Add(adat);
            }
            txtboxBevitel.Clear();
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (listboxTesztadatok.SelectedItem != null) listboxTesztadatok.Items.Remove(listboxTesztadatok.SelectedItem); else btnTorles.IsEnabled = false;
        }
    }
}