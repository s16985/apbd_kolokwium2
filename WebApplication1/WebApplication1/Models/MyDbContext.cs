using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class MyDbContext : DbContext
	{

		public DbSet<Firefighter> Firefighters { get; set; }

		public DbSet<Action> Actions { get; set; }
		public DbSet<FireTruck> FireTrucks { get; set; }

		public DbSet<Firefighter_Action> Firefighter_Actions { get; set; }
		public DbSet<FireTruck_Action> FireTruck_Actions { get; set; }

		public MyDbContext()
		{

		}

		public MyDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Firefighter_Action>().HasKey(a => new { a.IdAction, a.IdFirefighter });
		}


	}
}
