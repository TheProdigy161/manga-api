using System.Linq.Expressions;
using AutoMapper;
using MangaApi.Database;
using Microsoft.EntityFrameworkCore;
using MangaApi.Models;

namespace MangaApi.Services.Interfaces;

public interface IBaseService<T> where T : BaseEntity
{
    Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includes);
    Task<ICollection<T>> GetAll(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes);
    Task<bool> Create(T newModel);
    Task<bool> Update(T model);
}