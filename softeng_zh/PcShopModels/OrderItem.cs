using System;
using System.Collections.Generic;

namespace cseresznye_XE6XKN.PcShopModels;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ComponentId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Component Component { get; set; } = null!;

    public virtual OrderHeader Order { get; set; } = null!;
}
