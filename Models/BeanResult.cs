
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Result")]
	public class BeanResult : DbBase<BeanResult>
	{
		[Key]
		public Guid id { get; set; }
		public string idSample { get; set; }
		public string idTarget { get; set; }
		public DateTime startDate { get; set; }
		public DateTime testDate { get; set; }
		public string unit { get; set; }
		public string actualResult { get; set; }
		public Guid expectedResult { get; set; }
		public string conclusion { get; set; }
		public DateTime? completeDate { get; set; }
		public DateTime? Modified { get; set; }
		public Guid ModifiedBy { get; set; }
		public DateTime? Created { get; set; }
		public Guid CreatedBy { get; set; }
	}
}
