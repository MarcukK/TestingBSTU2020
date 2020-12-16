using PageObject.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public static class ProductCreator
    {
        public static Product withManySizes_04()
        {
            return TestingProducts.OversizedShirt;
        }
        public static Product withManyColors_Black()
        {
            return TestingProducts.SonnyBumBagBlack;
        }
        public static Product withManyColors_ArchiveBeige()
        {
            return TestingProducts.CottonBumBag;
        }
        public static Product withPersonalisation()
        {
            return TestingProducts.ClassicCashmereScarf;
        }
        public static Product withPersonalisation_MKS()
        {
            return TestingProducts.ClassicCashmereScarf;
        }
        public static Product withCountAndPriceMultiplyedByTwo()
        {
            return TestingProducts.TwoSonnyBumBagBlack;
        }
        public static Product with100ml()
        {
            return TestingProducts.MrBurberryIndigoDeToilette100ml;
        }
        public static Product with30ml()
        {
            return TestingProducts.MrBurberryIndigoDeToilette30ml;
        }
    }
}
