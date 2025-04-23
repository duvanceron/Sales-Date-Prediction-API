using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.Models;

public partial class Category
{
	[Key]
	public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
