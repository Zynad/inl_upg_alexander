using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class ShowCaseRepo : DataRepo<ShowCaseEntity>
{
    public ShowCaseRepo(DataContext dataContext) : base(dataContext)
    {
    }
}
