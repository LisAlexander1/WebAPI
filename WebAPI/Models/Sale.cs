﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Query;

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
    [JsonIgnore]
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
    
    [Required]
    public int SellsCount { get; set; }
    
    [NotMapped]
    public double Sum => SellsCount * Product?.Price ?? 0;
}