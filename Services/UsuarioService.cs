using reservaSalas.Interfaces;
using reservaSalas.Models;
using System.Security.AccessControl;

namespace reservaSalas.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            var existingUser = await _usuarioRepositorio.GetbyEmailAsync(usuario.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("E-mail já é cadastrado!");
            }

            await _usuarioRepositorio.AddSync(usuario);
            await _usuarioRepositorio.SaveChangesAsync();

            return usuario;
        }

        public async Task DeleteAsync(long id)
        {
            var usuario = await _usuarioRepositorio.GetbyIdAsync(id);

            if (usuario == null)
            {
                throw new InvalidOperationException("Usuário não encontrado!");
            }

            _usuarioRepositorio.Delete(usuario);
            await _usuarioRepositorio.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepositorio.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(long id)
        {
            return await _usuarioRepositorio.GetbyIdAsync(id);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _usuarioRepositorio.Update(usuario);
            await _usuarioRepositorio.SaveChangesAsync();
        }
    }
}
