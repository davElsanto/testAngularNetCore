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
    public class UsurioRepository: IUsurioRepository
    {
        private MySQLConfiguration connectionString;

        public UsurioRepository(MySQLConfiguration connectionString)
        {
            this.connectionString = connectionString;
        }

        protected MySqlConnection dbConnection(){
            return new MySqlConnection(this.connectionString.ConnectionString);
        }
        
        public async Task<IEnumerable<Usuario>> GetAllUsuarios(){
            var db = dbConnection();
            string sql = @"
                select Id, Nombre, Clave, EsAdmin
                from Usuarios
            ";
            return await db.QueryAsync<Usuario>(sql, new {});
        }
        public async Task<Usuario> GetUsuarioPorId(int id){
            var db = dbConnection();
            string sql = @"
                select Id, Nombre, Clave, EsAdmin
                from Usuarios
                where id = @Id
            ";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id});
        }
        public async Task<bool> InsertUsuario(Usuario usuario){
            var db = dbConnection();
            string sql = @"
                insert into Usuarios(Nombre, Clave, EsAdmin)
                values (@Nombre, @Clave, @EsAdmin)
            ";
            var result = await db.ExecuteAsync(sql, new { 
                usuario.Nombre, 
                usuario.Clave, 
                usuario.EsAdmin
            });
            return result > 0;
        }
        public async Task<bool> UpdateUsuario(Usuario usuario){
            var db = dbConnection();
            string sql = @"
                update Usuarios
                set 
                    Nombre = @Nombre, 
                    Clave = @Clave, 
                    EsAdmin = @EsAdmin
                where Id = @id
            ";
            var result = await db.ExecuteAsync(sql, new { 
                usuario.Nombre, 
                usuario.Clave, 
                usuario.EsAdmin,
                usuario.Id
            });
            return result > 0;
        }
        public async Task<bool> DeleteUsuario(int id){
            var db = dbConnection();
            string sql = @"
                delete
                from Usuarios
                where Id = @Id
            ";
            var result = await db.ExecuteAsync(sql, new { Id = id});
            return result > 0;
        }
    }
}