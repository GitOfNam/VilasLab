using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("TargetTest")]
	public class BeanTargetTest : DbBase<BeanTargetTest>
	{
		[Key]
		public string id { get; set; }
		public string name { get; set; }
		public string standard { get; set; }
		public int timeLine { get; set; }
	}
}