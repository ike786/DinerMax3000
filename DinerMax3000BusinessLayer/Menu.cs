using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinerMax3000.Business.dsDinerMax3000TableAdapters;

namespace DinerMax3000.Business {
    public class Menu {

        public string name {get; set;}
        public List<MenuItem> items{get; set;}

        // Contructor

        public Menu() {
            items = new List<MenuItem>();
        }

        private int _databaseId;

        public void SaveNewMenuItem(string Name, string Description, double Price) {

            MenuItemTableAdapter taMenuItem = new MenuItemTableAdapter();
            taMenuItem.InsertNewMenuItem(Name, Description, Price, _databaseId);
        
        }


        //Static method for returning data 

        public static List<Menu> GetAllMenus() {

            // Set up table adapters

            MenuTableAdapter taMenu = new MenuTableAdapter();
            MenuItemTableAdapter taMenuItem = new MenuItemTableAdapter();

            // assign data table to results from table adapter

            var dtMenu = taMenu.GetData();
            List<Menu> allMenus = new List<Menu>();

            // iterate  through rows in the datatable and do stuff n things

            foreach (dsDinerMax3000.MenuRow menuRow in dtMenu.Rows) {

                Menu currentMenu = new Menu(); // new menu object instance
                currentMenu.name = menuRow.Name; // get the assign it the name from the dataset
                currentMenu._databaseId = menuRow.id;
                allMenus.Add(currentMenu); // add it to the list of menus

                // get all the menu items of each menu while in the Menu loop and add to a list

                var dtMenuItems = taMenuItem.GetMenuItemsByMenuId(menuRow.id); 

                foreach (dsDinerMax3000.MenuItemRow menuItemRow in dtMenuItems.Rows) { // for every menu item in the data table dtMenuItems
                
                    currentMenu.AddMenuItem(menuItemRow.Name, menuItemRow.Description, menuItemRow.Price); // add the menu items to the current menu object, from the dataset
                
                }

                
            
            }

            return allMenus;

        
        }


        public void AddMenuItem(string Title, string Description, double Price) {
            MenuItem item = new MenuItem();
            item.title = Title;
            item.description = Description;
            item.price = Price;
            items.Add(item);
        
        }


    }
}
