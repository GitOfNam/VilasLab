using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Template")]
	public class BeanTemplate : DbBase<BeanTemplate>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string name { get; set; }
		public byte[] arrFileDoc { get; set; }
		public string fileName { get; set; }
		public DateTime? Modified { get; set; }
		public Guid ModifiedBy { get; set; }
		public DateTime? Created { get; set; }
		public Guid CreatedBy { get; set; }
	}
}