﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ECommerce.Api.Orders.Db
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
