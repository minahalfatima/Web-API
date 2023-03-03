using MediatRProject.DatabaseProject;
using Microsoft.EntityFrameworkCore;

namespace MediatRProject.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SqlServerContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(SqlServerContext context)
        {
            _context = context;
            _entity=_context.Set<T>();
        }
        public void Add(T entity)
        {
            _entity.AddAsync(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
             _entity.Remove(entity);
             _context.SaveChanges();  
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities =await  _entity.ToListAsync();
            return entities;
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await _entity.FindAsync(id);
            return entity;
        }

        public void Update()
        {
            _context.SaveChanges();
        }
    }
}
