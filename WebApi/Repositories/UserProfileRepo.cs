using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class UserProfileRepo : IdentityRepo<UserProfileEntity>
{
    public UserProfileRepo(IdentityContext context) : base(context)
    {
    }
}
