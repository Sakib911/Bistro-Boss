﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BistroContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
      
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<DeliveryMan> DeliveryMans { get; set; }
       
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<WorkerLocationcs> WorkerLocationcs { get; set; }
    }
}

