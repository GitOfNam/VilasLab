using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
    [Table("Machine")]
    public class BeanMachine : DbBase<BeanMachine>
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public Guid idFactory { get; set; }
    }
}