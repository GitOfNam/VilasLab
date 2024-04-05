using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Customer")]
	public class BeanCustomer : DbBase<BeanCustomer>
	{
		[Key]
		public Guid id { get; set; }
		public string position { get; set; }
		public string accountName { get; set; }
		public string password { get; set; }
		public string fullName { get; set; }
		public bool gender { get; set; }
		public DateTime? birthDay { get; set; }
		public string address { get; set; }
		public byte[] imageSignaturePath { get; set; }
		public string email { get; set; }
		public bool status { get; set; }
		public bool? isDeleted { get; set; }
		public Guid idPermission { get; set; }
	}
}
