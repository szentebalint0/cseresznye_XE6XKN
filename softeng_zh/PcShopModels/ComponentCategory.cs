using System;
using System.Collections.Generic;

namespace cseresznye_XE6XKN.PcShopModels;

public partial class ComponentCategory
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();
}
