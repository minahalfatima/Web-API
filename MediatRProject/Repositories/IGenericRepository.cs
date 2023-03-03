namespace MediatRProject.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity); 
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        void Update();  
        void Delete(T entity);  
    }
}
