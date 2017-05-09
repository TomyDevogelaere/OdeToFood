using System.ComponentModel.DataAnnotations;
namespace OdeToFood2017.Entities

{
    public enum CuisinType
    {
        None,
        Fastfood,
        Italian
    }
    public class Restaurant
    {
        public int Id { get; set; }
        [Required,MaxLength(80)]
        public string Name { get; set; }
        public CuisinType Cuisine { get; set; }
    }
}
