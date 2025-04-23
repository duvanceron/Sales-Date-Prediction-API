using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.Models;

public partial class Supplier
{
	[Key]
	public int Supplierid { get; set; }

    public string Companyname { get; set; } = null!;

    public string Contactname { get; set; } = null!;

    public string Contacttitle { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Fax { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
