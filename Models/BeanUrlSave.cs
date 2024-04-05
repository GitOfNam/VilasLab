using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilasLab.Base;

namespace VilasLab.Models
{
    [Table("UrlSave")]
    public class BeanUrlSave : DbBase<BeanUrlSave>
    {
        [Key]
        public string title { get; set; }
        public string urlLink { get; set; }
        public bool isRemember { get; set; }
    }
}
