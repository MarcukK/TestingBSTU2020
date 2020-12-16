using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public class Catalog
    {
        public Catalog(string URL)
        {
            this.URL = URL;
        }
        public string URL;

        public override bool Equals(object obj)
        {
            var product = obj as Catalog;
            return this.URL.Equals(product.URL);
        }
    }
}
