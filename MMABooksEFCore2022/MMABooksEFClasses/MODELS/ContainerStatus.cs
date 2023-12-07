using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MODELS;

public partial class ContainerStatus
{
    public int ContainerStatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BrewContainer> BrewContainers { get; set; } = new List<BrewContainer>();
}
