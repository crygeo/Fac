using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funciones;
using MySql.Data.MySqlClient;



namespace Fac.src.MySql
{
    public class ConectMysql
    {
        private static ConfigJson config;

        private bool isUsed = false;
        private MySqlConnection connection;


        // Constructor privado, asegura que solo una instancia de la clase se puede crear.
        public ConectMysql()
        {
            // Configuración de la clase para manejar la conexión a la base de datos.
            config = new ConfigJson();

            PruebaDeConexion();
        }


        // Método que devuelve la conexión a la base de datos, o null si hay un error.
        private MySqlConnection Connection()
        {
            if (!isUsed) return Error();
            return connection;
        }

        // Método para realizar una consulta a la base de datos y obtener un MySqlDataReader.
        public async Task<MySqlDataReader> EjecutarComandoObtenerResultados(MySqlCommand cmd)
        {
            // Uso del bloque using para garantizar la liberación de recursos.
            using (var conn = Connection())
            {
                //Prepara el commando.
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                // Abre la conexión asincrónicamente.
                await conn.OpenAsync();

                // Ejecuta la consulta y devuelve el lector de datos.
                using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                {
                    return reader;
                }
            }
        }

        public async Task EjecutarComando(MySqlCommand cmd)
        {
            // Uso del bloque using para garantizar la liberación de recursos.
            using (var conn = Connection())
            {
                //Prepara el commando.
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                // Abre la conexión asincrónicamente.
                await conn.OpenAsync();

                // Ejecuta la consulta.
                await cmd.ExecuteNonQueryAsync();
                
            }
        }

        // Método que realiza una prueba de conexión durante la creación del singleton.
        private void PruebaDeConexion()
        {
            try
            {
                // Crea una nueva instancia de MySqlConnection con la cadena de conexión configurada.
                connection = new MySqlConnection(config.GetStringBuilder());

                // Abre la conexión asincrónicamente y espera a que la operación se complete.
                connection.OpenAsync().Wait();
                isUsed = true;
                // Imprime un mensaje indicando que la conexión fue exitosa.
                StyleConsole.PrintConsoleContainer("Conexión a la DB exitosa.");

                // Cierra la conexión asincrónicamente.
                connection.CloseAsync();
            }
            catch (MySqlException ex)
            {
                // En caso de un error, imprime un mensaje y la información del error.
                StyleConsole.PrintConsoleContainer("Error en la conexión a la DB.");
                Console.WriteLine($"Texto del error:\n{ex.Message}");
            }
        }

        // Método que devuelve null e imprime un mensaje de error en la conexión.
        private MySqlConnection Error()
        {
            StyleConsole.PrintConsoleContainer("Error en la conexión a la DB.");
            return null;
        }
    }


}
