using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
    [Table("Requirement")]
    public class BeanRequirement : DbBase<BeanRequirement>
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string idTarget { get; set; }
    }
}
