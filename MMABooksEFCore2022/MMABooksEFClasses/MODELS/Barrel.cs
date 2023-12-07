﻿using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MODELS;

public partial class Barrel
{
    public int BrewContainerId { get; set; }

    public string Treatment { get; set; } = null!;

    public virtual BrewContainer BrewContainer { get; set; } = null!;
}
