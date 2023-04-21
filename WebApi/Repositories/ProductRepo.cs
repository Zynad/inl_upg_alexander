using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class ProductRepo : DataRepo<ProductEntity>
{
    private readonly DataContext _dataContext;
    public ProductRepo(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _dataContext.Products.Include("Category").Include("Tag").ToListAsync();
    }

    public override async Task<IEnumerable<ProductEntity>> GetListAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        return await _dataContext.Products.Include("Category").Include("Tag").Where(predicate).ToListAsync();
    }

    public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        var result = await _dataContext.Products.Include("Category").Include("Tag").FirstOrDefaultAsync(predicate);

        if (result != null)
            return result;

        return null!;
    }
}
