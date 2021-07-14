﻿using Microsoft.EntityFrameworkCore;
using SpaceTransfer.Db.Models;

namespace SpaceTransfer.Db
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
			Database.EnsureCreated();   // создаем базу данных при первом обращении
		}
	}
}