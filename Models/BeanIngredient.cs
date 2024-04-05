using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
    [Table("Ingredient")]
    public class BeanIngredient : DbBase<BeanIngredient>
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
    }
}