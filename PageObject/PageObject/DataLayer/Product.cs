using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.DataLayer
{
    public class Product
    {
        public Product(string URL, string name, string color, string size, string item, string price, int count)
        {
            this.URL = URL;
            this.name = name;
            this.color = color;
            this.size = size;
            this.item = item;
            this.price = price;
            this.count = count;
        }
        public string URL;
        public string name;
        public string color;
        public string size;
        public string item;
        public string price;
        public int count;

        public bool Equals(Product obj)
        {
            if (this.URL.Equals(obj.URL) &&
                    this.name.Equals(obj.name) &&
                    this.color.Equals(obj.color) &&
                    this.size.Equals(obj.size) &&
                    this.item.Equals(obj.item) &&
                    this.price.Equals(obj.price) &&
                    this.count.Equals(obj.count))
                return true;
            return false;
        }
    }
}
