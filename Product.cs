using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopDbLibNew
{
    public partial class Product
    {
        public Product()
        {
            ImageNavigation = new HashSet<Image>();
            ProductNomenclature = new HashSet<ProductNomenclature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public float? Price { get; set; }
        public float? Markup { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int KatalogId { get; set; }
        public int TypeProductId { get; set; }

        public virtual Katalog Katalog { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        public virtual ICollection<Image> ImageNavigation { get; set; }
        public virtual ICollection<ProductNomenclature> ProductNomenclature { get; set; }
    }
}
