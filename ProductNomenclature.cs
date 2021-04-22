﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopDbLibNew
{
    public partial class ProductNomenclature
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int NomenclatureId { get; set; }

        public virtual Nomenclature Nomenclature { get; set; }
        public virtual Product Product { get; set; }
    }
}
