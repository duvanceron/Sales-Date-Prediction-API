using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.Models;

public partial class Shipper
{
	[Key]
	public int Shipperid { get; set; }

    public string Companyname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
