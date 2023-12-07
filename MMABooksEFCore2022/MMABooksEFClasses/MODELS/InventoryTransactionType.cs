using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MODELS;

public partial class InventoryTransactionType
{
    public int InventoryTransactionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
}
