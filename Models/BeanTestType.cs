using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
    [Table("TestType")]
    public class BeanTestType : DbBase<BeanTestType>
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
    }
}