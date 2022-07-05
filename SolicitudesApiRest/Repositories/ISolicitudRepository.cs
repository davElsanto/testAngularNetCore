using SolicitudesApiRest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SolicitudesApiRest.Repositories
{
    public interface ISolicitudRepository
    {
        Task<IEnumerable<Solicitud>> GetAllSolicitudes();
        Task<Solicitud> GetSolicitudPorId(int id);
        Task<bool> InsertSolicitud(Solicitud solicitud);
        Task<bool> UpdateSolicitud(Solicitud solicitud);
        Task<bool> DeleteSolicitud(int id);
    }
}