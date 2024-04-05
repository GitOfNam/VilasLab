
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Factory")]
	public class BeanFactory : DbBase<BeanFactory>
	{
		[Key]
		public Guid id { get; set; }
		public string name { get; set; }
		public string shift { get; set; }
		public string address { get; set; }
	}
}
