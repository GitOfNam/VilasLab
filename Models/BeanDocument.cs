using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
	[Table("Document")]
	public class BeanDocument : DbBase<BeanDocument>
	{
		[Key]
		public string id { get; set; }
		public string name { get; set; }
		public byte[] arrFileSigned { get; set; }
		public byte[] arrFilePDF { get; set; }
		public byte[] arrFileDocSigned { get; set; }
		public string fileName { get; set; }
		public string fileNameSigned { get; set; }
		public string idSample { get; set; }
		public int idTemplate { get; set; }
		public int status { get; set; }
		public DateTime? Modified { get; set; }
		public Guid ModifiedBy { get; set; }
		public DateTime? Created { get; set; }
		public Guid CreatedBy { get; set; }
	}
}
