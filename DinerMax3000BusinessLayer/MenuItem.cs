using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMax3000.Business {
    public class MenuItem {

        public string title{get;set;}
        public string description{get;set;}

        public double price {
        
            get {return _price;}
            set {
        
                if (value > 0) {
            
                    _price = value;
            
                } else {
            
                    throw new ApplicationException("You cannot have free or negative items");
            
                }
        
            }
        
        }

        private double _price;


    }
}
