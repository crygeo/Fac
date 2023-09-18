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
using Fac.src.Dats;

namespace Fac.src.Model
{
    public class BankM
    {
        public ObservableCollection<Cheque> _cheques { get; set; }
        public ObservableCollection<Transancion> _transanciones { get; set; }

        private DataManager ChequesDataManager { get; set; }
        private DataManager TransacionDataManager { get; set; }

        public BankM()
        {
            ChequesDataManager = new DataManager("src/Datos/cheques.json");
            TransacionDataManager = new DataManager("src/Datos/transaciones.json");

            _cheques = ChequesDataManager.CargarDatos<Cheque>();
            _transanciones = TransacionDataManager.CargarDatos<Transancion>();

        }

        public void GuardarDatos()
        {
            ChequesDataManager.GuardarDatos(_cheques);
            TransacionDataManager.GuardarDatos(_transanciones);
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




}
