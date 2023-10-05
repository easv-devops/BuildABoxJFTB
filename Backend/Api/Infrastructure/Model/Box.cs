using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model;

public class Box
{
    public int ProductID { get; set; }
    
    [Required]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public string ImageURL { get; set; }
    
    [Required]
    public decimal Length { get; set; }
    
    [Required]
    public decimal Width { get; set; }
    
    [Required]
    public decimal Height { get; set; }
}