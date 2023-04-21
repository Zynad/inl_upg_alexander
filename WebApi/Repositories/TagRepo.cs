using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class TagRepo : DataRepo<TagEntity>
{
    public TagRepo(DataContext dataContext) : base(dataContext)
    {
    }
    
}
