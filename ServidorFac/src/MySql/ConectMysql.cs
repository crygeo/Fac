using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fac.src.MySql;
using Funciones;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ServidorFac;



namespace MySql
{
    public class ConectMysql
    {
        private readonly Servidor servidor;

        private static bool isUsed = false;

        public ConectMysql(Servidor servidor)
        {
            this.servidor=servidor;
            PruebaDeConexion();
        }


        // Método que devuelve la conexión a la base de datos, o null si hay un error.
        public MySqlConnection Connection()
        {
            if (!isUsed) return Error();
            return new MySqlConnection(servidor.modeloJsonMysql.ToString());
        }


        // Método que realiza una prueba de conexión durante la creación del singleton.
        private void PruebaDeConexion()
        {
            if (isUsed) return;
            try
            {
                // Crea una nueva instancia de MySqlConnection con la cadena de conexión configurada.
                using (var cn = new MySqlConnection(servidor.modeloJsonMysql.ToString()))
                {

                    // Abre la conexión asincrónicamente y espera a que la operación se complete.
                    cn.OpenAsync().Wait();

                    isUsed = true;
                    // Imprime un mensaje indicando que la conexión fue exitosa.
                    Console.WriteLine("\n");
                    StyleConsole.PrintConsoleContainer("Conexión a la DB exitosa.");

                }
            }
            catch (MySqlException ex)
            {
                // En caso de un error, imprime un mensaje y la información del error.
                Console.WriteLine("\n");
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
