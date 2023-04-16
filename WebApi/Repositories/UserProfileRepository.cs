using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class UserProfileRepository : Repository<UserProfileEntity>
{
    private readonly IdentityContext _identityContext;

    public UserProfileRepository(IdentityContext identity) : base(identity)
    {
        _identityContext = identity;
    }

}
