using HappyParking.Entity;
using HappyParking.Infraestructure.Interface;
using MySql.Data.MySqlClient;
using System.Data;

namespace HappyParking.Infraestructure.Repository
{
    public class UsuarioMySqlRepository: IUsuarioMySqlRepository
    {
        private readonly IConnectionBD _connectionBD;

        public UsuarioMySqlRepository(IConnectionBD connectionBD)
        {
            _connectionBD = connectionBD ?? throw new ArgumentNullException(nameof(connectionBD));

        }

        public async Task<Usuario> Insertar(Usuario entidad)
        {
            using (var connection = _connectionBD.GetConnectionMySql)
            {
                var transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd = new MySqlCommand("sp_usuario_add", (MySqlConnection)connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@incorreo", MySqlDbType.VarChar, 100).Value = entidad.Correo;
                    cmd.Parameters.Add("@inclave", MySqlDbType.VarChar, 20).Value = entidad.Clave;
                    cmd.Parameters.Add("@inestado", MySqlDbType.Int32).Value = entidad.Estado;
                    cmd.Parameters.Add("@idUsuario", MySqlDbType.Int64).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@iderror", MySqlDbType.Int64).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@mensaje", MySqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    var retorno = await cmd.ExecuteNonQueryAsync();

                    entidad.IdUsuario = (Int64)cmd.Parameters["@idUsuario"].Value;
                    entidad.Retorno = new RetornoResponse
                    {
                        IdError = (Int64)cmd.Parameters["@iderror"].Value,
                        Mensaje = cmd.Parameters["@mensaje"].Value.ToString() + ""
                    };

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }

                return entidad;
            }
        }
        public async Task<Usuario> Actualizar(Usuario entidad)
        {
            using (var connection = _connectionBD.GetConnectionMySql)
            {
                var transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd = new MySqlCommand("sp_usuario_edit", (MySqlConnection)connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inidusuario", MySqlDbType.Int64).Value = entidad.IdUsuario;
                    cmd.Parameters.Add("@inclave", MySqlDbType.VarChar, 20).Value = entidad.Clave;
                    cmd.Parameters.Add("@inidUsuarioModificacion", MySqlDbType.Int32).Value = entidad.IdUsuarioModificacion.Equals(0) ? DBNull.Value : entidad.IdUsuarioModificacion;
                    cmd.Parameters.Add("@inestado", MySqlDbType.Int32).Value = entidad.Estado;
                    cmd.Parameters.Add("@iderror", MySqlDbType.Int64).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@mensaje", MySqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    var retorno = await cmd.ExecuteNonQueryAsync();

                    entidad.Retorno = new RetornoResponse
                    {
                        IdError = (Int64)cmd.Parameters["@iderror"].Value,
                        Mensaje = cmd.Parameters["@mensaje"].Value.ToString() + ""
                    };

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }

                return entidad;
            }
        }
        public async Task<Usuario> Eliminar(Usuario entidad)
        {
            using (var connection = _connectionBD.GetConnectionMySql)
            {
                var transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd = new MySqlCommand("sp_usuario_delete", (MySqlConnection)connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inidusuario", MySqlDbType.Int64).Value = entidad.IdUsuario;
                    cmd.Parameters.Add("@inidUsuarioModificacion", MySqlDbType.Int32).Value = entidad.IdUsuarioModificacion.Equals(0) ? DBNull.Value : entidad.IdUsuarioModificacion;
                    cmd.Parameters.Add("@iderror", MySqlDbType.Int64).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@mensaje", MySqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    var retorno = await cmd.ExecuteNonQueryAsync();

                    entidad.Retorno = new RetornoResponse
                    {
                        IdError = (Int64)cmd.Parameters["@iderror"].Value,
                        Mensaje = cmd.Parameters["@mensaje"].Value.ToString() + ""
                    };

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }

                return entidad;
            }
        }

        public async Task<List<Usuario>> ObtenerPorConcepto(Usuario entidad)
        {
            var retorno = new List<Usuario>();
            MySqlDataReader reader= null;
            using (var connection = _connectionBD.GetConnectionMySql)
            {
                var transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd = new MySqlCommand("sp_usuario_get", (MySqlConnection)connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inidusuario", MySqlDbType.Int64).Value = entidad.IdUsuario;
                    cmd.Parameters.Add("@inidUsuarioModificacion", MySqlDbType.Int64).Value = entidad.IdUsuarioModificacion;
                    cmd.Parameters.Add("@infechainicio", MySqlDbType.VarChar,12).Value = entidad.Filtros?.FechaInicio;
                    cmd.Parameters.Add("@infechafin", MySqlDbType.VarChar,12).Value = entidad.Filtros?.FechaFin;

                    reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            var prop = new Usuario
                            {
                                IdUsuario = reader.GetInt64(0),
                                Correo = reader.GetString(1),
                                Clave = reader.GetString(2),
                                FechaCreacion = reader.GetString(3),
                                IdUsuarioModificacion = reader.GetInt64(4),
                                FechaActualizacion = reader.GetString(5),
                                Estado = reader.GetInt32(6)
                            };

                            retorno.Add(prop);
                        }
                    }
                    reader.Close();

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();

                    if(reader != null)
                        reader.Close();
                    throw;
                }
                finally
                {
                    connection.Close();
                }

                return retorno;
            }
        }

        public async Task<Usuario> ObtenerPorPropiedad(Usuario entidad)
        {
            MySqlDataReader reader = null;
            using (var connection = _connectionBD.GetConnectionMySql)
            {
                var transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd = new MySqlCommand("sp_usuario_get", (MySqlConnection)connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inidusuario", MySqlDbType.Int64).Value = entidad.IdUsuario;
                    cmd.Parameters.Add("@inidUsuarioModificacion", MySqlDbType.Int64).Value = entidad.IdUsuarioModificacion;
                    cmd.Parameters.Add("@infechainicio", MySqlDbType.VarChar, 12).Value = entidad.Filtros?.FechaInicio;
                    cmd.Parameters.Add("@infechafin", MySqlDbType.VarChar, 12).Value = entidad.Filtros?.FechaFin;

                    reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            entidad = new Usuario
                            {
                                IdUsuario = reader.GetInt64(0),
                                Correo = reader.GetString(1),
                                Clave = reader.GetString(2),
                                FechaCreacion = reader.GetString(3),
                                IdUsuarioModificacion = reader.GetInt64(4),
                                FechaActualizacion = reader.GetString(5),
                                Estado = reader.GetInt32(6)
                            };

                        }
                    }
                    reader.Close();

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();

                    if (reader != null)
                        reader.Close();
                    throw;
                }
                finally
                {
                    connection.Close();
                }

                return entidad;
            }
        }
        public async Task<Usuario> ValidaSesion(Usuario entidad)
        {
            MySqlDataReader reader = null;
            using (var connection = _connectionBD.GetConnectionMySql)
            {
                var transaction = connection.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd = new MySqlCommand("sp_usuario_login", (MySqlConnection)connection);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@incorreo", MySqlDbType.VarChar, 100).Value = entidad.Correo;
                    cmd.Parameters.Add("@inclave", MySqlDbType.VarChar, 20).Value = entidad.Clave;
                    cmd.Parameters.Add("@inidRol", MySqlDbType.Int32).Value = entidad.Estado;
                    cmd.Parameters.Add("@outidusuario", MySqlDbType.Int64).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@iderror", MySqlDbType.Int64).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@mensaje", MySqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    var retorno = await cmd.ExecuteNonQueryAsync();

                    entidad.IdUsuario = (Int64)cmd.Parameters["@outidusuario"].Value;
                    entidad.Retorno = new RetornoResponse
                    {
                        IdError = (Int64)cmd.Parameters["@iderror"].Value,
                        Mensaje = cmd.Parameters["@mensaje"].Value.ToString() + ""
                    };

                }
                catch (Exception)
                {
                    transaction.Rollback();

                    if (reader != null)
                        reader.Close();
                    throw;
                }
                finally
                {
                    connection.Close();
                }

                return entidad;
            }
        }
    }
}
