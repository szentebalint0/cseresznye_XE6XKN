using System;
using System.Collections.Generic;

namespace cseresznye_XE6XKN.PcShopModels;

public partial class Component
{
    public int ComponentId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public virtual ComponentCategory Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
