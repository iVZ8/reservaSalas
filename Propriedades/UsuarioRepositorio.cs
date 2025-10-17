using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using reservaSalas.Data;
using reservaSalas.Interfaces;
using reservaSalas.Models;
using System.Threading.Tasks;

namespace reservaSalas.Propriedades
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext context)
        {
            _context = context;
        }

        public async Task AddSync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetbyEmailAsync(string email)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> GetbyIdAsync(long id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }
    }
}
