using Fac.src.Dats.Objet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Dats
{
    public class DataManager
    {


        private readonly string FilePath = "";
        private readonly Type TypeDes;

        public DataManager(string filePath)
        {
            FilePath = filePath;
        }

        public void GuardarDatos(Object cheques)
        {
            string json = JsonConvert.SerializeObject(cheques);
            File.WriteAllText(FilePath, json);
        }

        public ObservableCollection<T> CargarDatos<T>()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);

                if (!string.IsNullOrEmpty(json))
                {
                    var veri = JsonConvert.DeserializeObject<ObservableCollection<T>>(json); ;
                    if (veri != null) return veri;
                }

                return new ObservableCollection<T>();
            }
            else
            {
                throw new Exception("No existe esta ruta, " + FilePath);
            }

        }
    }
}
