using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Sample")]
	public class BeanSample : DbBase<BeanSample>
	{
		[Key]
		public string id { get; set; }
		public string name { get; set; } // Ca sản xuất
		public Guid idType { get; set; }
		public Guid idSpecies { get; set; }
		public Guid idIngredient { get; set; }
		public Guid idCustomer { get; set; }
		public Guid idFactory { get; set; }
		public int idMachine { get; set; }
		public string idTarget { get; set; }
		public string descript { get; set; }
		public Guid idClient { get; set; }
		public decimal pressure { get; set; }
		public decimal diameter { get; set; }
		public int sampleNumber { get; set; }
		public bool status { get; set; }
		public DateTime? startDate { get; set; }
		public DateTime? completeDate { get; set; }
		public DateTime? overdue { get; set; }
		public DateTime? Modified { get; set; }
		public Guid ModifiedBy { get; set; }
		public DateTime? Created { get; set; }
		public Guid CreatedBy { get; set; }
	}
}
