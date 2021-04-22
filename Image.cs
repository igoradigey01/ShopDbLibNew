﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopDbLibNew
{
    public partial class Image
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
