using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MODELS;

public partial class AdjunctType
{
    public int AdjunctTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Adjunct> Adjuncts { get; set; } = new List<Adjunct>();
}
