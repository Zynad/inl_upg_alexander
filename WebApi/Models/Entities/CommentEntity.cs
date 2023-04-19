using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class CommentEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string CustomerName { get; set; } = null!;
    [MaxLength(100)]
    public string CustomerEmail { get; set; } = null!;
    public string Comment { get; set; } = null!;
}
