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
            btnDel.IsEnabled = true;

            listboxTesztadatok.SelectionChanged += ListBox_SelectionChanged;
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
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDel.IsEnabled = listboxTesztadatok.SelectedItem != null;
            btnEdit.IsEnabled = listboxTesztadatok.SelectedItem != null;
            btnUp.IsEnabled = listboxTesztadatok.SelectedItem != null;
            btnDown.IsEnabled = listboxTesztadatok.SelectedItem != null;
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            listboxTesztadatok.Items.Remove(listboxTesztadatok.SelectedItem);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztott = listboxTesztadatok.SelectedItem.ToString();
            string beviteliMezo = txtboxBevitel.Text;
            if (beviteliMezo.Trim() == "" || beviteliMezo == kivalasztott) MessageBox.Show("Hiba! Nem változott az adat."); else if (listboxTesztadatok.Items.Contains(beviteliMezo)) MessageBox.Show("A módosítás utáni érték már szerepel a listában."); else listboxTesztadatok.Items[listboxTesztadatok.SelectedIndex] = beviteliMezo;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (listboxTesztadatok.SelectedIndex == 0)
            {
                MessageBox.Show("Első elemet hova viszed fel?");
            }
            else
            {
                int currentIndex = listboxTesztadatok.SelectedIndex;
                int previousIndex = currentIndex - 1;

                object temp = listboxTesztadatok.Items[currentIndex];
                listboxTesztadatok.Items[currentIndex] = listboxTesztadatok.Items[previousIndex];
                listboxTesztadatok.Items[previousIndex] = temp;

                listboxTesztadatok.SelectedIndex = previousIndex;
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (listboxTesztadatok.SelectedIndex == listboxTesztadatok.Items.Count - 1)
            {
                MessageBox.Show("Utolsó elemet hova viszed le?");
            }
            else
            {
                int currentIndex = listboxTesztadatok.SelectedIndex;
                int nextIndex = currentIndex + 1;

                object temp = listboxTesztadatok.Items[currentIndex];
                listboxTesztadatok.Items[currentIndex] = listboxTesztadatok.Items[nextIndex];
                listboxTesztadatok.Items[nextIndex] = temp;

                listboxTesztadatok.SelectedIndex = nextIndex;
            }
        }
    }
}