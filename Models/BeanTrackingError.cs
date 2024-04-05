using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VilasLab.Base;
namespace VilasLab.Models
{
    [Table("TrackingError")]
    public class BeanTrackingError : DbBase<BeanTrackingError>
    {
        [Key]
        public string Title { get; set; }
        public string TrackLog { get; set; }
        public DateTime? Created { get; set; }
    }
}
