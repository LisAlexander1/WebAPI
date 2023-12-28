using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

[Owned]
public class Product : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    [JsonPropertyName("price")]
    public double Price { get; set; }
}