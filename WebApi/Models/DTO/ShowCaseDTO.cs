using WebApi.Models.Entities;

namespace WebApi.Models.DTO;

public class ShowCaseDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Ingress { get; set; } = null!;
    public string DeliveryText { get; set; } = null!;
    public string ButtonText { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public static implicit operator ShowCaseDTO(ShowCaseEntity entity)
    {
        return new ShowCaseDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Ingress = entity.Ingress,
            DeliveryText = entity.DeliveryText,
            ButtonText = entity.ButtonText,
            ImageUrl = entity.ImageUrl,
        };
    }
}
