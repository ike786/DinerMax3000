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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DinerMAx3000WPFClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            DinerMax3000.WPFClient.DinerMax3000ViewModel currentViewModel =
                (DinerMax3000.WPFClient.DinerMax3000ViewModel)DataContext;

            foreach (var currentMenuItem in currentViewModel.NewMenuItems) { // for each MenuItem in NewMenuItems (list of MenuItems) 

                currentViewModel.SelectedMenu.SaveNewMenuItem(currentMenuItem.title, currentMenuItem.description, currentMenuItem.price); // add each MenuItems properties to the DB
            
            }
        
            BindingOperations.GetBindingExpressionBase(cboAllMenus, ComboBox.ItemsSourceProperty).UpdateTarget(); // Update combo box 
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {
            DinerMax3000.Business.MenuItem newMenuItem = e.Row.Item as DinerMax3000.Business.MenuItem; // cast datagrid row as a MenuItem object. IF it can't it will be null

            if (newMenuItem != null && e.EditAction==DataGridEditAction.Commit && e.Row.IsNewItem) { // if newMenuItem is not null && the datagrid action is commit (ike pressing enter etc) && datagrid edit is a new row

                // get data context from view model
                DinerMax3000.WPFClient.DinerMax3000ViewModel currentViewmodel =
                    (DinerMax3000.WPFClient.DinerMax3000ViewModel)DataContext;

                // Add MunuItem Object to list
                currentViewmodel.NewMenuItems.Add(newMenuItem);
            
                
            
            }

        }
    }
}
