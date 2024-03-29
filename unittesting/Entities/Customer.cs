﻿using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace unittesting.Entities
{
    public class Customer
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public List<Order> Orders { get; set; } = new List<Order>();
    }
}
