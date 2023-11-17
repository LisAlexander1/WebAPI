
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class Sale : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public DateTime SellDateTime { get; set; }
    
    [Required]
    [ForeignKey("Product")]
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
    
    [Required]
    public int SellsCount { get; set; }
}