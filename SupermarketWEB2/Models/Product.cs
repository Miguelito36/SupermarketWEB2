﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB2.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "decimal(6,2)")]
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
