using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Fac.src.MySql;

public class ConfigJson
{

    private const string FilePath = "src/MySql/ConfigMysql.json";
    public ModeloJsonMysql mysql { get; private set; }
    public ConfigJson()
    {
        mysql = buscarArchivo(FilePath);
    }

    private ModeloJsonMysql buscarArchivo(string FilePath)
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

    public string GetStringBuilder()
    {
        return $"datasource={mysql.Datasource}; port={mysql.Port}; username={mysql.Username}; password={mysql.Password}; database={mysql.Database}; ";
    }



}
