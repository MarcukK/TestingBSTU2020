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
                                     "archive beige",
                                     null,
                                     "80104301",
                                     "£550",
                                     1);
        public static readonly Product SonnyBumBagBlack = new Product(
                                     "https://uk.burberry.com/logo-detail-econyl-sonny-bum-bag-p80256681",
                                     "Logo Detail ECONYL® Sonny Bum Bag",
                                     "Black",
                                     null,
                                     "80256681",
                                     "£490",
                                     1);

        public static readonly Product OversizedShirt = new Product(
                                     "https://uk.burberry.com/logo-applique-silk-satin-oversized-shirt-p45669041",
                                     "Logo Appliqué Silk Satin Oversized Shirt",
                                     "Optic white",
                                     "04",
                                     "45669041",
                                     "£1,090",
                                     1);
    }
}
