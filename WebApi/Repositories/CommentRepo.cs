using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class CommentRepo : DataRepo<CommentEntity>
{
    public CommentRepo(DataContext dataContext) : base(dataContext)
    {
    }
}
