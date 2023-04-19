using WebApi.Models.Entities;

namespace WebApi.Models.DTO;

public class CommentDTO
{
    public string CustomerName { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    public string Comment { get; set; } = null!;

    public static implicit operator CommentEntity(CommentDTO dto)
    {
        return new CommentEntity
        {
            CustomerEmail = dto.CustomerEmail,
            CustomerName = dto.CustomerName,
            Comment = dto.Comment
        };
    }
}
