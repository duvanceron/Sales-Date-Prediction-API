using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.Models;

public partial class OrderTotalsByYear
{
	[Key]
	public int? Orderyear { get; set; }

    public int? Qty { get; set; }
}
