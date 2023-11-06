using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Netthandel.Models;

public class ShoppingCart
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("ProductId")]
    [ValidateNever]
    public int ProductId { get; set; }
    [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
    public int Count { get; set; }
    [ForeignKey("ApplicationUserId")]
    [ValidateNever]
    public string ApplicationUserId { get; set; }
}