using SolicitudesApiRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SolicitudesApiRest.Repositories
{
    public interface IUsurioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioPorId(int id);
        Task<bool> InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(int id);
    }
}