using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MODELS;

public partial class HopType
{
    public int HopTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Hop> Hops { get; set; } = new List<Hop>();
}
