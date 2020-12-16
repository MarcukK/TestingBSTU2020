using Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service
{
    public static class CatalogCreator
    {
        public static Catalog withWomensScarves()
        {
            return TestingCatalogs.WomensScarves;
        }
    }

}
