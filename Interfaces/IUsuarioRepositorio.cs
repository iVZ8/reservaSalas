using reservaSalas.Models;

namespace reservaSalas.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetbyIdAsync(long id);
        Task<Usuario> GetbyEmailAsync(string email);
        Task AddSync(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        Task SaveChangesAsync();
    }
}
