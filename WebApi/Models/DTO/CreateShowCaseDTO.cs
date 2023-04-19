using System.Reflection;
using WebApi.Models.Entities;

namespace WebApi.Models.DTO;

public class CreateShowCaseDTO
{
    public string Title { get; set; } = null!;
    public string Ingress { get; set; } = null!;
    public string DeliveryText { get; set; } = null!;
    public string ButtonText { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public static implicit operator ShowCaseEntity(CreateShowCaseDTO dto)
    {
        return new ShowCaseEntity
        {
            Title = dto.Title,
            Ingress = dto.Ingress,
            DeliveryText = dto.DeliveryText,
            ButtonText = dto.ButtonText,
            ImageUrl = dto.ImageUrl,
        };
    }
}
