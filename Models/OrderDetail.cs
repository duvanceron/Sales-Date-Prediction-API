using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Date_Prediction.Models;

public partial class OrderDetail
{
	[Key]
	public int Orderid { get; set; }

    public int Productid { get; set; }

    public decimal Unitprice { get; set; }

    public short Qty { get; set; }

    public decimal Discount { get; set; }
    [ForeignKey("Orderid")]
    public virtual Order Order { get; set; } = null!;
	[ForeignKey("Productid")]
	public virtual Product Product { get; set; } = null!;
}
