﻿using System;
using System.Collections.Generic;

namespace MMABooksEFClasses.MODELS;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int CustomerId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public decimal ProductTotal { get; set; }

    public decimal SalesTax { get; set; }

    public decimal Shipping { get; set; }

    public decimal InvoiceTotal { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Invoicelineitem> Invoicelineitems { get; set; } = new List<Invoicelineitem>();
}