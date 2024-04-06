using System.Linq.Expressions;
using AutoMapper;
using MangaApi.Database;
using Microsoft.EntityFrameworkCore;
using MangaApi.Models;
using MangaApi.Services.Interfaces;

namespace MangaApi.Services;

public class BaseService<T> : IBaseService<T> where T : BaseEntity
{
    protected readonly ILogger<BaseService<T>> _logger;
    protected readonly MangaContext _context;
    protected readonly IMapper _mapper;

    public BaseService(ILogger<BaseService<T>> logger, MangaContext context, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }

    public async Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().AsQueryable();

        if (includes is not null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<T>> GetAll(PaginationOptions paginationOptions)
    {
        IQueryable<T> query = _context.Set<T>().AsQueryable();

        if (paginationOptions is not null)
        {
            query = query.Skip(paginationOptions.Offset).Take(paginationOptions.Limit);
        }

        return new T[0];
    }

    public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().AsQueryable();

        if (where is not null)
        {
            query = query.Where(where);
        }

        if (includes is not null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }
        
        return await query.ToArrayAsync();
    }

    public async Task<bool> Create(T newModel)
    {
        try
        {
            await _context.Set<T>().AddAsync(newModel);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to create: {e.Message}");
            return false;
        }
    }

    public async Task<bool> Update(T model)
    {
        try
        {
            T existingModel = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (existingModel is null)
            {
                throw new Exception($"Failed to find item with the id {model.Id}.");
            }

            _mapper.Map<BaseEntity, T>(existingModel, model);
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to update: {e.Message}");
            return false;
        }
    }
}