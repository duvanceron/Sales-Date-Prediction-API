using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales_Date_Prediction.Models;

public partial class Employee
{
    [Key]
	public int Empid { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Titleofcourtesy { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime Hiredate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Region { get; set; }

    public string? Postalcode { get; set; }

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? Mgrid { get; set; }

    public virtual ICollection<Employee> InverseMgr { get; set; } = new List<Employee>();

    public virtual Employee? Mgr { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
