using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sales_Date_Prediction.Models;
[Table("Orders")]
public partial class Order
{
	[Key]
	public int Orderid { get; set; }

    public int? Custid { get; set; }

    public int Empid { get; set; }

    public DateTime Orderdate { get; set; }

    public DateTime Requireddate { get; set; }

    public DateTime? Shippeddate { get; set; }

    public int Shipperid { get; set; }

    public decimal Freight { get; set; }

    public string Shipname { get; set; } = null!;

    public string Shipaddress { get; set; } = null!;

    public string Shipcity { get; set; } = null!;

    public string? Shipregion { get; set; }

    public string? Shippostalcode { get; set; }

    public string Shipcountry { get; set; } = null!;

    public virtual Customer? Cust { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Shipper Shipper { get; set; } = null!;
}
