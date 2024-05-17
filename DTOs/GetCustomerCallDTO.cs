namespace Task.DTOs
{
	public class GetCustomerCallDTO
	{
		public int CustomerId { get; set;}
		public int Id { get; set; }
		public string Description { get; set; }
		public string Call_Address { get; set; }
		public DateOnly Date { get; set; }
		public string Employee { get; set; }
		public bool IsDone { get; set; }
		public string Call_Type { get; set; }
	}
}
