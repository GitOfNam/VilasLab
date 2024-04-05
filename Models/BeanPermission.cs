using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
    [Table("Permission")]
    public class BeanPermission : DbBase<BeanPermission>
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
    }
}