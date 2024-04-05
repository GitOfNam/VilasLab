using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
    [Table("Species")]
    public class BeanSpecies : DbBase<BeanSpecies>
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
