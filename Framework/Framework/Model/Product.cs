using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.DataLayer
{
    public class Product
    {
        public Product(string URL, string name, string color, string size, string item, string personalisation, string personalisationColor, string price, int count)
        {
            this.URL = URL;
            this.name = name;
            this.color = color;
            this.size = size;
            this.item = item;
            this.personalisation = personalisation;
            this.personalisationColor = personalisationColor;
            this.price = price;
            this.count = count;
        }
        public string URL;
        public string name;
        public string color;
        public string size;
        public string item;
        public string personalisation;
        public string personalisationColor;
        public string price;
        public int count;

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return this.URL.Equals(product.URL) &&
                    this.name.Equals(product.name) &&
                    this.color.Equals(product.color) &&
                    this.size.Equals(product.size) &&
                    this.item.Equals(product.item) &&
                    this.personalisation.Equals(product.personalisation) &&
                    this.personalisationColor.Equals(product.personalisationColor) &&
                    this.price.Equals(product.price) &&
                    this.count.Equals(product.count);
        }
    }
}
