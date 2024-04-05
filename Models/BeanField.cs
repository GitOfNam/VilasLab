using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Field")]
	public class BeanField : DbBase<BeanField>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string name { get; set; }
		public string value { get; set; }
		public string defaultText { get; set; }
		public bool isHTML { get; set; }
		public int idTemplate { get; set; }
		public DateTime? Modified { get; set; }
		public Guid ModifiedBy { get; set; }
		public DateTime? Created { get; set; }
		public Guid CreatedBy { get; set; }
	}
}
