using WebApi.Models.Entities;
using WebApi.Contexts;

namespace WebApi.Repositories;

public class CategoryRepo : DataRepo<CategoryEntity>
{
    public CategoryRepo(DataContext dataContext) : base(dataContext)
    {
    }
}
