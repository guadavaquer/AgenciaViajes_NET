using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    class DAL //Clase con métodos para interactuar con la base de datos
    {
        private string connectionString;
        public DAL()
        {
            connectionString = Properties.Resources.ConnectionStr;
        }

        //Métodos clase Usuario

        //Consulta
        public List<Usuario> getUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Usuario";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetDouble(8), reader.GetBoolean(9));
                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misUsuarios;
        }

        public Usuario getUsuario(string mail)
        {
            Usuario usuario = null;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Usuario WHERE mail = '" + mail + "'";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        usuario = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetDouble(8), reader.GetBoolean(9));
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return usuario;
        }

        public bool insertUsuario(Usuario usuario)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "INSERT Usuario(Dni,Nombre,Apellido,Mail,Password,IntentosFallidos,Bloqueado,Credito,EsAdmin) VALUES " +
                "(@dni,@nombre, @apellido,@mail,@password,0,0,0,0)";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@dni", usuario.DNI);
                command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@mail", usuario.Mail);
                command.Parameters.AddWithValue("@password", usuario.Password);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }

        //Modificación
        public bool updateUsuario(Usuario usuario)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, Dni = @dni, Password = @password WHERE idUsuario = @idUsuario";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@nombre", usuario.Nombre); 
                command.Parameters.AddWithValue("@apellido", usuario.Apellido); 
                command.Parameters.AddWithValue("@dni", usuario.DNI);
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.Parameters.AddWithValue("@idUsuario", usuario.ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }

        public bool DeleteUsuario(Usuario usuario)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "DELETE FROM Usuario WHERE idUsuario = @idUsuario";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idUsuario", usuario.ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }


        public List<Hotel> getHoteles()
        {
            List<Hotel> hoteles = new List<Hotel>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Hotel";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Hotel aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {

                        var ciudad = this.getCiudad(reader.GetInt32(5));
                        aux = new Hotel(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDouble(3), reader.GetInt32(4), ciudad);
                        hoteles.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return hoteles;
        }

        public Hotel getHotel(int idHotel)
        {
            Hotel hotel = null;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Hotel WHERE idHotel = " + idHotel.ToString() ;

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        var ciudad = this.getCiudad(reader.GetInt32(5));
                        hotel = new Hotel(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDouble(3), reader.GetInt32(4), ciudad);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return hotel;
        }

        //Modificación
        public bool insertHotel(Hotel hotel)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "INSERT Hotel(Nombre,Capacidad,Costo,Vendido,idCiudad) VALUES " +
                "(@nombre,@capacidad,@costo,@vendido,@idCiudad)";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@nombre", hotel.Nombre);
                command.Parameters.AddWithValue("@capacidad", hotel.Capacidad);
                command.Parameters.AddWithValue("@costo", hotel.Costo);
                command.Parameters.AddWithValue("@vendido", hotel.Vendido);
                command.Parameters.AddWithValue("@idCiudad", hotel.Ubicacion.ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }
        public bool updateHotel(Hotel hotel)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "UPDATE Hotel SET Nombre = @nombre, Capacidad = @capacidad, Costo = @costo, Vendido = @vendido, idCiudad = @idCiudad WHERE idHotel = @idHotel";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@nombre", hotel.Nombre);
                command.Parameters.AddWithValue("@capacidad", hotel.Capacidad);
                command.Parameters.AddWithValue("@costo", hotel.Costo);
                command.Parameters.AddWithValue("@vendido", hotel.Vendido);
                command.Parameters.AddWithValue("@idCiudad", hotel.Ubicacion.ID);
                command.Parameters.AddWithValue("@idHotel", hotel.ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }

        public bool DeleteHotel(Hotel hotel)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "DELETE FROM Hotel WHERE idHotel = @idHotel";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idHotel", hotel.ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }


        //Métodos clase Ciudad

        public List<Ciudad> getCiudades()
        {
            List<Ciudad> misCiudades = new List<Ciudad>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Ciudades";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Ciudad aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Ciudad(reader.GetInt32(0), reader.GetString(1));
                        misCiudades.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misCiudades;
        }

        public Ciudad getCiudad(int idCiudad)
        {
            Ciudad ciudad = null;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Ciudad WHERE idCiudad = " + idCiudad.ToString();

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        ciudad = new Ciudad(reader.GetInt32(0), reader.GetString(1));
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return ciudad;
        }

        public bool insertCiudad(Ciudad ciudad)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "INSERT Ciudad(Nombre) VALUES " +
                "(@nombre)";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@nombre", ciudad.Nombre);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }

        public bool updateCiudad(Ciudad ciudad)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "UPDATE Ciudad SET Nombre = @nombre WHERE idCiudad = @idCiudad";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@nombre", ciudad.Nombre);
                command.Parameters.AddWithValue("@idCiudad", ciudad.ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }

        public bool DeleteCiudad(Ciudad ciudad)
        {
            // Definir la cadena de consulta para la actualización
            string queryString = "DELETE FROM Ciudad WHERE idCiudad = @idCiudad";
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@idCiudad", ciudad.ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return rowsAffected > 0; // Devuelve verdadero si al menos una fila se actualizó.
        }


        public void ResetarIntentosFallidos(Usuario usuario) {
            //Defino el string con la consulta que quiero realizar
            string queryString = "UPDATE Usuarios SET IntentosFallidos = 0 WHERE idUsuario = " + usuario.ID.ToString();

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void IncrementarIntentosFallidos(Usuario usuario)
        {
            string queryString = "UPDATE Usuarios SET IntentosFallidos = IntentosFallidos +1, Bloqueado = " + Convert.ToInt32(usuario.Bloqueado);
            queryString += " WHERE idUsuario = " + usuario.ID.ToString();

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        

        //Métodos clase Vuelo

        public List<Vuelo> getVuelos()
        {
            List<Vuelo> misVuelos = new List<Vuelo>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Vuelos";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Vuelo aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        var origen = this.getCiudad(reader.GetInt32(7));
                        var destino = this.getCiudad(reader.GetInt32(8));
                        aux = new Vuelo(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDouble(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6),  origen, destino);
                        misVuelos.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misVuelos;
        }

        public Vuelo getVuelo(string mail)
        {
            Vuelo vuelo = null;

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from Vuelos WHERE mail = '" + mail + "'";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        var origen = this.getCiudad(reader.GetInt32(7));
                        var destino = this.getCiudad(reader.GetInt32(8));
                        vuelo = new Vuelo(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDouble(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6), origen, destino);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();

                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return vuelo;
        }

    }
}