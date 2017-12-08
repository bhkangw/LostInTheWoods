using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class Trail : BaseEntity
    {
        [Key]
        public int id {get; set;}

        [Required]
        [Display(Name="Trial Name")]
        public string Name {get;set;}

        [Required]
        [MinLength(5)]
        public string Description {get;set;}

        [Required]
        [Range(0,1000)]
        [Display(Name = "Trail Length (mi)")]
        public float Length {get;set;}

        [Required]
        [Display(Name = "Elevation Change (ft)")]
        public int Elevation {get;set;}

        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Latitude {get;set;}
    }
}