using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario usuario)
        {
            using (SqlConnection conexion = new(Conexion.rutaConexion)) //sql da la conexion a base de datos del sql server ruta conexion es un coection string
            {
                SqlCommand cmd = new("usp_registrar", conexion);//creamos un comand sql q ue es el que da las ordenes a sql de que se va a ejecutar
                cmd.CommandType = CommandType.StoredProcedure;//en este caso vamos a ejecutar un procedimiento almacenado store procedure para registrar un dato 
                cmd.Parameters.AddWithValue("@documentoidentidad", usuario.DocumentoIdentidad); // se adiciona parametro al comand 
                cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", usuario.Ciudad);
                try//CTRL KS ABREVIA LAS PETICIONES  el try intenta hacer una operacion logica que pude fallar si lo hace regresa si no catch captura el error de lo que no pudo hacer
                {
                    conexion.Open(); //aqui se abre la conexion a la base de datos
                    cmd.ExecuteNonQuery();
                    return true;// si todo sale continua la operacions
                }
                catch (Exception)// si sale mal aqui captura la informacion mala
                {
                    return false;// y retorna como un false
                    throw;
                }
            }
        }

        internal static Usuario Obtener(int id)
        {
            throw new NotImplementedException();
        }

        internal static List<Usuario> listar()
        {
            throw new NotImplementedException();
        }

        public static bool Modificar(Usuario usuario)
        {
            using (SqlConnection conexion = new(Conexion.rutaConexion)) //sql da la conexion a base de datos del sql server ruta conexion es un conection string
            {
                SqlCommand cmd = new("usp_registrar", conexion);//creamos un comand sql q ue es el que da las ordenes a sql de que se va a ejecutar
                cmd.CommandType = CommandType.StoredProcedure;//en este caso vamos a ejecutar un procedimiento almacenado store procedure para registrar un dato 
                cmd.Parameters.AddWithValue("@documentoidentidad", usuario.IdUsuario);//para modificar es igual pero se aumenta el id de usuario
                cmd.Parameters.AddWithValue("@documentoidentidad", usuario.DocumentoIdentidad); // se adiciona parametro al comand 
                cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", usuario.Ciudad);
                try//CTRL KS ABREVIA LAS PETICIONES  el try intenta hacer una operacion logica que pude fallar si lo hace regresa si no catch captura el error de lo que no pudo hacer
                {
                    conexion.Open(); //aqui se abre la conexion a la base de datos
                    cmd.ExecuteNonQuery();
                    return true;// si todo sale continua la operacions
                }
                catch (Exception)// si sale mal aqui captura la informacion mala
                {
                    return false;// y retorna como un false
                    throw;
                }


            }
        }
        public static List<Usuario> TraerInformacionDeUsuario()// este es el maldito metodo
        {
            List<Usuario> listaUsuario = new();
            using SqlConnection conexion = new(Conexion.rutaConexion);//aqui preparo conexion de base de datos
            SqlCommand command = new("usp_listar", conexion)
            {
                CommandType = CommandType.StoredProcedure//vamos a hacer un tipo de procedimiento almacenado
            };

            try
            {
                conexion.Open();//aqui abrimos conexion
                                // command.ExecuteNonQuery();//ejecutamos el Query

                using (SqlDataReader reader = command.ExecuteReader())//ejecutamos un lector es decir vamos a leer el procedimiento en este caso listar
                {
                    while (reader.Read()) //elaboramos un mientrs while que nos dice mientras sea true seguira el bucle 
                    {
                        listaUsuario.Add(new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),//por lo general vienen en tipo objet lo que se lee es decir el reader aqui como es int se convierte a int para ser almacenado en la variable IdUsuario 
                            DocumentoIdentidad = reader["DocumentoIdentidad"].ToString(),//este objeto lo pasamos a string para ser almacenado en la variable DocumentoIdentidad
                            Ciudad = reader["Ciudad"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString())

                        });
                    }
                }
                return listaUsuario;

            }
            
            catch (Exception ex)
            {
                return listaUsuario;
            }
            
        }

        

        public static Usuario Obtener(int idusuario, string? DocumentoIdentidad, string? Nombres, string? Telefono, string? Correo, string? Ciudad, DateTime FechaRegistro)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conexion=new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idusuario);

                try
                {
                    conexion.Open();
                   // cmd.ExecuteNonQuery();

                    using SqlDataReader reader = cmd.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            usuario = new Usuario();
                            {
                                idusuario = Convert.ToInt32(reader["IdUsuario"]);
                                DocumentoIdentidad = reader["DocumentoIdentidad"].ToString();
                                Nombres = reader["Nombres"].ToString();
                                Telefono = reader["Telefono"].ToString();
                                Correo = reader["Correo"].ToString();
                                Ciudad= reader["Ciudad"].ToString();
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()); 
                            };
                        }
                    }
                    return usuario;
                }
                catch(Exception ex)
                {
                    return usuario;
                }
            }
    
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection conexion = new(Conexion.rutaConexion))
            {
                SqlCommand command = new("usp_eliminar", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idusuario", id);

                try//ctr k s abreviatura
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
    }
}
