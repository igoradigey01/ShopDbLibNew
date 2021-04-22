using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopDbLibNew
{
    public partial class Nomenclature
    {
        public Nomenclature()
        {
            ProductNomenclature = new HashSet<ProductNomenclature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public float? Markup { get; set; }
        public string Image { get; set; }

        public virtual ICollection<ProductNomenclature> ProductNomenclature { get; set; }
    }
}
