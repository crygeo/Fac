using Fac.src.Dats.Objet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace Fac.src.Model
{
    public class BankM
    {
        public ObservableCollection<Cheque> _cheques { get; set; }
        public ObservableCollection<Transancion> _transanciones { get; set; }

        public BankM()
        {
            _cheques = ChequesDataManager.CargarCheques();
            _transanciones = TransacionesDataManager.CargarTransaciones();

        }

        public void GuardarDatos()
        {
            ChequesDataManager.GuardarCheques(_cheques);
            TransacionesDataManager.GuardarTransaciones(_transanciones);
        }

        public ObservableCollection<Cheque> ObtenerCheques()
        {
            return _cheques;
        }
        public ObservableCollection<Transancion> ObtenerTransaciones()
        {
            return _transanciones;
        }

        public void AgregarCheques(Cheque newCheque)
        {
            _cheques.Add(newCheque);
        }

        public void AgregarTransaciones(Transancion newTransancion)
        {
            _transanciones.Add(newTransancion);
        }

    }


    public static class ChequesDataManager
    {
        private static readonly string FilePath = "src/Datos/cheques.json";

        public static void GuardarCheques(ObservableCollection<Cheque> cheques)
        {
            string json = JsonConvert.SerializeObject(cheques);
            File.WriteAllText(FilePath, json);
        }

        public static ObservableCollection<Cheque> CargarCheques()
        {
            try
            {

                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);

                    if (!string.IsNullOrEmpty(json))
                    {
                        var veri = JsonConvert.DeserializeObject<ObservableCollection<Cheque>>(json); ;
                        if (veri != null) return veri;
                    }

                }

                return new ObservableCollection<Cheque>(); // Retorna una colección vacía si esta vacio el archivo o la URL no existe
            }
            catch (FileNotFoundException)
            {
                return new ObservableCollection<Cheque>(); // Retorna una colección vacía si el archivo no existe
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                return new ObservableCollection<Cheque>();
            }
        }
    }
    public static class TransacionesDataManager
    {
        private static readonly string FilePath = "src/Datos/transaciones.json";

        public static void GuardarTransaciones(ObservableCollection<Transancion> transaciones)
        {
            string json = JsonConvert.SerializeObject(transaciones);
            File.WriteAllText(FilePath, json);
        }

        public static ObservableCollection<Transancion> CargarTransaciones()
        {
            try
            {

                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);

                    if (!string.IsNullOrEmpty(json))
                    {
                        var veri = JsonConvert.DeserializeObject<ObservableCollection<Transancion>>(json); ;
                        if (veri != null) return veri;
                    }

                }

                return new ObservableCollection<Transancion>(); // Retorna una colección vacía si esta vacio el archivo o la URL no existe
            }
            catch (FileNotFoundException)
            {
                return new ObservableCollection<Transancion>(); // Retorna una colección vacía si el archivo no existe
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                return new ObservableCollection<Transancion>();
            }
        }
    }

}
