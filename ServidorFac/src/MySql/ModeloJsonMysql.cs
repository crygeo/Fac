using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql
{
    public struct ModeloJsonMysql
    {

        [JsonProperty("datasource")]
        public string Datasource { get; private set; }

        [JsonProperty("port")]
        public uint Port { get; private set; }

        [JsonProperty("username")]
        public string Username { get; private set; }

        [JsonProperty("password")]
        public string Password { get; private set; }

        [JsonProperty("database")]
        public string Database { get; private set; }

        public override string ToString()
        {
            return $"datasource={Datasource}; port={Port}; username={Username}; password={Password}; database={Database}; ";
        }

        public static ModeloJsonMysql buscarArchivo(string FilePath)
        {

            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);

                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<ModeloJsonMysql>(json); ;
                }

                return new ModeloJsonMysql();
            }
            else
            {
                throw new Exception("No existe esta ruta, " + FilePath);
            }

        }
    }
}
