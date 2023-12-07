using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MODELS;

public partial class AddressType
{
    public int AddressTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<SupplierAddress> SupplierAddresses { get; set; } = new List<SupplierAddress>();
}
