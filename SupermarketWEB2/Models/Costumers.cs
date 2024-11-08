namespace SupermarketWEB2.Models
{
	public class Costumers
	{
		public int Id { get; set; }
		public string Document_Number { get; set; }
		public string First_Name { get; set; }
		public string Last_Name { get; set; }
		public string Address { get; set; }
		public DateTime? Birthday { get; set; }
		public string Phone_Number { get; set; }
		public string Email { get; set; }
	}
}
