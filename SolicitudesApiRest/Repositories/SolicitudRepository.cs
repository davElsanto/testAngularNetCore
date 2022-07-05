using SolicitudesApiRest.Model;
using SolicitudesApiRest.Repositories;
using SolicitudesApiRest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

namespace SolicitudesApiRest.Repositories{
    public class SolicitudRepository: ISolicitudRepository
    {
        private MySQLConfiguration connectionString;

        public SolicitudRepository(MySQLConfiguration connectionString)
        {
            this.connectionString = connectionString;
        }

        protected MySqlConnection dbConnection(){
            return new MySqlConnection(this.connectionString.ConnectionString);
        }
        
        public async Task<IEnumerable<Solicitud>> GetAllSolicitudes(){
            var db = dbConnection();
            string sql = @"
                select 
                    Id, 
                    UsuarioId, 
                    DescripcionSolicitud,
                    Justificativo,
                    Estado,
                    DetalleGestion,
                    FechaIngreso,
                    FechaActualizacion,
                    FechaGestion
                from Solicitudes
            ";
            return await db.QueryAsync<Solicitud>(sql, new {});
        }
        public async Task<Solicitud> GetSolicitudPorId(int id){
            var db = dbConnection();
            string sql = @"
                select 
                    Id, 
                    UsuarioId, 
                    DescripcionSolicitud,
                    Justificativo,
                    Estado,
                    DetalleGestion,
                    FechaIngreso,
                    FechaActualizacion,
                    FechaGestion
                from Solicitudes
                where id = @Id
            ";
            return await db.QueryFirstOrDefaultAsync<Solicitud>(sql, new { Id = id});
        }
        public async Task<bool> InsertSolicitud(Solicitud solicitud){
            var db = dbConnection();
            string sql = @"
                insert into Solicitudes(
                    UsuarioId, 
                    DescripcionSolicitud,
                    Justificativo,
                    Estado,
                    DetalleGestion,
                    FechaIngreso,
                    FechaActualizacion,
                    FechaGestion
                )
                values (
                    @UsuarioId,
                    @DescripcionSolicitud,
                    @Justificativo,
                    @Estado,
                    @DetalleGestion,
                    @FechaIngreso,
                    @FechaActualizacion,
                    @FechaGestion
                )
            ";
            var result = await db.ExecuteAsync(sql, new { 
                solicitud.UsuarioId,
                solicitud.DescripcionSolicitud,
                solicitud.Justificativo,
                solicitud.Estado,
                solicitud.DetalleGestion,
                solicitud.FechaIngreso,
                solicitud.FechaActualizacion,
                solicitud.FechaGestion
            });
            return result > 0;
        }
        public async Task<bool> UpdateSolicitud(Solicitud solicitud){
            var db = dbConnection();
            string sql = @"
                update Solicitudes
                set 
                    UsuarioId = @UsuarioId,
                    DescripcionSolicitud = @DescripcionSolicitud,
                    Justificativo = @Justificativo,
                    Estado = @Estado,
                    DetalleGestion = @DetalleGestion,
                    FechaIngreso = @FechaIngreso,
                    FechaActualizacion = @FechaActualizacion,
                    FechaGestion = @FechaGestion
                where Id = @id
            ";
            var result = await db.ExecuteAsync(sql, new { 
                solicitud.UsuarioId,
                solicitud.DescripcionSolicitud,
                solicitud.Justificativo,
                solicitud.Estado,
                solicitud.DetalleGestion,
                solicitud.FechaIngreso,
                solicitud.FechaActualizacion,
                solicitud.FechaGestion,
                solicitud.Id
            });
            return result > 0;
        }
        public async Task<bool> DeleteSolicitud(int id){
            var db = dbConnection();
            string sql = @"
                delete
                from Solicitudes
                where Id = @Id
            ";
            var result = await db.ExecuteAsync(sql, new { Id = id});
            return result > 0;
        }
    }
}