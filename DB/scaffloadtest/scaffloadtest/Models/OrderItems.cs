﻿using System;
using System.Collections.Generic;

namespace scaffloadtest.Models
{
    public partial class OrderItems
    {
        public int? OrderId { get; set; }
        public int? ItemId { get; set; }

        public virtual Items Item { get; set; }
        public virtual Orders Order { get; set; }
    }
}
