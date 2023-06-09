﻿
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class StoreContext: Microsoft.EntityFrameworkCore.DbContext
    {
		public StoreContext()
		{
		}

        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
    
