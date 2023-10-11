using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.RegularExpressions;


namespace Infrastructure.Model;

public class Box
{
    public int ProductID { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    [StringLength(int.MaxValue, MinimumLength = 3, ErrorMessage = "Title to short")]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Image is required")]
    public string ImageURL { get; set; }
    
    [Range(0, double.MaxValue, ErrorMessage = "Value must be non-negative")]
    [Required(ErrorMessage = "Length is required")]
    public double Length { get; set; }
    [Required(ErrorMessage = "width is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Value must be non-negative")]
    public double Width { get; set; }
    [Required(ErrorMessage = "Width is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Value must be non-negative")]
    public decimal Height { get; set; }
}
