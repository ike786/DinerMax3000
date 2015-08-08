using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinerMax3000.Business;

namespace DinerMax3000Console {
    class Program {
        static void Main(string[] args) {

            // List of all menus from the database
            List<Menu> menusFromDatabase = Menu.GetAllMenus();
            Menu firstMenu = menusFromDatabase[0];
            firstMenu.SaveNewMenuItem("Smorgas", "A classic nordic dish.", 10);

            menusFromDatabase = Menu.GetAllMenus();

            // New order for testing
            Order hungryGuestOrder = new Order();

            // for each menu in all menus in the database add each item to the order
            foreach (Menu currentMenu in menusFromDatabase) {

                foreach (MenuItem currentItem in currentMenu.items) {

                    hungryGuestOrder.items.Add(currentItem);

                }
            }

            // return the total price of the order from the Order class
            Console.WriteLine("The total is:" + hungryGuestOrder.Total);


            Console.ReadKey();
        }
    }
}
