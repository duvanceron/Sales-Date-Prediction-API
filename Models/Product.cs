using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.Models;

public partial class Product
{
	[Key]
	public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public int Supplierid { get; set; }

    public int Categoryid { get; set; }

    public decimal Unitprice { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
