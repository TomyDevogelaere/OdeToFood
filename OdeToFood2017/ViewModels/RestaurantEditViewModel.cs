using OdeToFood2017.Entities;
using System.ComponentModel.DataAnnotations;
namespace OdeToFood2017.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required,MaxLength(80)]
        public string Name { get; set; }
        public CuisinType Cuisin { get; set; }
    }
}
