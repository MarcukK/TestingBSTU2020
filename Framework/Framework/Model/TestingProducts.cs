using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject.DataLayer
{
    public static class TestingProducts
    {
        public static readonly Product CottonBumBag = new Product(
                                     "https://uk.burberry.com/medium-vintage-check-bonded-cotton-bum-bag-p80104301",
                                     "Medium Vintage Check Bonded Cotton Bum Bag",
                                     "Archive beige",
                                     null,
                                     "80104301",
                                     null,
                                     null,
                                     "£550",
                                     1);
        public static readonly Product SonnyBumBagBlack = new Product(
                                     "https://uk.burberry.com/logo-detail-econyl-sonny-bum-bag-p80256681",
                                     "Logo Detail ECONYL® Sonny Bum Bag",
                                     "Black",
                                     null,
                                     "80256681",
                                     null,
                                     null,
                                     "£490",
                                     1);

        public static readonly Product OversizedShirt = new Product(
                                     "https://uk.burberry.com/logo-applique-silk-satin-oversized-shirt-p45669041",
                                     "Logo Appliqué Silk Satin Oversized Shirt",
                                     "Optic white",
                                     "04",
                                     "45669041",
                                     null,
                                     null,
                                     "£1,090",
                                     1);
        public static readonly Product ClassicCashmereScarf = new Product(
                                     "https://uk.burberry.com/the-classic-check-cashmere-scarf-p80181731",
                                     "The Classic Check Cashmere Scarf",
                                     "ARCHIVE BEIGE",
                                     null,
                                     "80181731",
                                     //null,
                                     //null,
                                     "MKS",
                                     "Black",
                                     "£370",
                                     1);
        public static readonly Product ClassicCashmereScarfForMKS = new Product(
                                     "https://uk.burberry.com/the-classic-check-cashmere-scarf-p80181731",
                                     "The Classic Check Cashmere Scarf",
                                     "archive beige",
                                     null,
                                     "80181731",
                                     "MKS",
                                     "Black",
                                     "£370",
                                     1);

        public static readonly Product TwoSonnyBumBagBlack = new Product(
                                     "https://uk.burberry.com/logo-detail-econyl-sonny-bum-bag-p80256681",
                                     "Logo Detail ECONYL® Sonny Bum Bag",
                                     "Black",
                                     null,
                                     "80256681",
                                     null,
                                     null,
                                     "£980",
                                     2);

        public static readonly Product MrBurberryIndigoDeToilette100ml = new Product(
                                     "https://uk.burberry.com/mr-burberry-indigo-eau-de-toilette-100ml-p40675681",
                                     "Mr. Burberry Indigo Eau de Toilette 100ml",
                                     null,
                                     "100ml",
                                     "40675681",
                                     null,
                                     null,
                                     "£74",
                                     1);

        public static readonly Product MrBurberryIndigoDeToilette30ml = new Product(
                                     "https://uk.burberry.com/mr-burberry-indigo-eau-de-toilette-30ml-p40675701",
                                     "Mr. Burberry Indigo Eau de Toilette 30ml",
                                     null,
                                     "30ml",
                                     "40675701",
                                     null,
                                     null,
                                     "£47",
                                     1);
    }
}
