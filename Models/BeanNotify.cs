using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Notify")]
	public class BeanNotify : DbBase<BeanNotify>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string RelatedID { get; set; }
		public int? Status { get; set; }
		public string Title { get; set; }
		public Guid AssignTo { get; set; }
		public string Category { get; set; }
		public DateTime? Created { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime? Modified { get; set; }
	}
}