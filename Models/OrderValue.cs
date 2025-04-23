using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.Models;

public partial class OrderValue
{
	[Key]
	public int Orderid { get; set; }

    public int? Custid { get; set; }

    public int Empid { get; set; }

    public int Shipperid { get; set; }

    public DateTime Orderdate { get; set; }

    public decimal? Val { get; set; }
}
