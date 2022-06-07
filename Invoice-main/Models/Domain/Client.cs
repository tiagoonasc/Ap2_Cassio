using System.Collections.Generic;

namespace Invoicing.Models.Domain
{
	public class Client
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public List<Invoice> Invoices { get; set; }
	}
}

