using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class ShowCaseEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [MaxLength(50)]
    public string Ingress { get; set; } = null!;
    [MaxLength(100)]
    public string DeliveryText { get; set; } = null!;
    [MaxLength(30)]
    public string ButtonText { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

}
