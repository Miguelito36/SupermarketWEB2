using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB2.Models
{
	public class PayMode
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "decimal(6,2)")]

		public string Observation { get; set; }
	}
}
