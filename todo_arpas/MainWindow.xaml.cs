using System.ComponentModel;
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
        private int operationCount = 0;
        public bool closeable = false;
        public MainWindow()
        {
            InitializeComponent();

            btnDel.Click += (sender, e) => IncrementOperationCount();
            btnAdd.Click += (sender, e) => IncrementOperationCount();
            btnEdit.Click += (sender, e) => IncrementOperationCount();
            btnUp.Click += (sender, e) => IncrementOperationCount();
            btnDown.Click += (sender, e) => IncrementOperationCount();
            btnDelAll.Click += (sender, e) => IncrementOperationCount();
            btnSortAsc.Click += (sender, e) => IncrementOperationCount();
            btnSortDesc.Click += (sender, e) => IncrementOperationCount();
            btnCopy.Click += (sender, e) => IncrementOperationCount();


            for (int i = 0; i < 5; i++)
            {
                listboxTesztadatok.Items.Insert(i, $"adat{i+1}");
            }
            listboxTesztadatok.SelectedIndex = 0;
            btnDel.IsEnabled = true;

            listboxTesztadatok.SelectionChanged += ListBox_SelectionChanged;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !closeable;
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt && e.SystemKey == Key.F4)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
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
        private void SwapItems(int currentIndex, int newIndex)
        {
            object temp = listboxTesztadatok.Items[currentIndex];
            listboxTesztadatok.Items[currentIndex] = listboxTesztadatok.Items[newIndex];
            listboxTesztadatok.Items[newIndex] = temp;

            listboxTesztadatok.SelectedIndex = newIndex;
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

                SwapItems(currentIndex, previousIndex);
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

                SwapItems(currentIndex, nextIndex);
            }
        }
        private void Sort(bool ascending)
        {
            List<string> items = new List<string>();
            foreach (var item in listboxTesztadatok.Items)
            {
                items.Add(item.ToString());
            }

            items = (ascending ? items.OrderBy(x => x) : items.OrderByDescending(x => x)).ToList();

            listboxTesztadatok.Items.Clear();

            foreach (var item in items)
            {
                listboxTesztadatok.Items.Add(item);
            }
        }
        private void SortAscending()
        {
            Sort(true);
        }

        private void SortDescending()
        {
            Sort(false);
        }
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == btnSortAsc)
            {
                SortAscending();
            }
            else if (clickedButton == btnSortDesc)
            {
                SortDescending();
            }
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            if (listboxMasik.Visibility != Visibility.Visible) listboxMasik.Visibility = Visibility.Visible;
            listboxMasik.Items.Add(listboxTesztadatok.SelectedItem);
        }

        private void IncrementOperationCount()
        {
            operationCount++;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ennyi műveletet hajtott végre a felhasználó: {operationCount}");

            closeable = true;
            this.Close();
        }
    }
}