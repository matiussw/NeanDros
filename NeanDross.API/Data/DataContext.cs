using System;
using Microsoft.EntityFrameworkCore;
using NeanDros.Shared.Entities;

namespace NeanDross.API.Data
{
	public class DataContext :DbContext

	{
		public DataContext(DbContextOptions<DataContext> options): base(options)
		{

		}
		public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
		
        }
    }
}

