using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("DocumentSigner")]
	public class BeanDocumentSigner : DbBase<BeanDocumentSigner>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public Guid idUser { get; set; }
		public string idDocument { get; set; }
		public string signaturePosition { get; set; }
		public bool? status { get; set; }
		public int? index { get; set; }
		public DateTime? Modified { get; set; }
		public Guid ModifiedBy { get; set; }
		public DateTime? Created { get; set; }
		public Guid CreatedBy { get; set; }
	}
}
