using Fac.src.Dats;
using Fac.src.Dats.Objet;
using Fac.src.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Model
{
    public class PagosM
    {
        private ObservableCollection<PrestamosTrabajador> Pagos { get; set; }
        private ObservableCollection<Trabajador> Personal { get; set; }

        private DataManager _pagoDataManager;
        private DataManager _trabajdorDataManager;

        public PagosM()
        {
            _pagoDataManager = new DataManager("src/Datos/adelantos.json");
            _trabajdorDataManager = new DataManager("src/Datos/personal.json");

            Pagos = _pagoDataManager.CargarDatos<PrestamosTrabajador>();
            Personal = _trabajdorDataManager.CargarDatos<Trabajador>();

        }

        public void GuardarDatos()
        {
            _pagoDataManager.GuardarDatos(Pagos);
            _trabajdorDataManager.GuardarDatos(Personal);
        }

        public void AgregarAdelanto(PrestamosTrabajador prest)
        {
            Pagos.Add(prest);
        }

        public void AgregarPersonal(Trabajador personal)
        {
            Personal.Add(personal);
        }

        public ObservableCollection<PrestamosTrabajador> ObtenerPrestamosTrabajadores()
        {
            return Pagos;
        }

        public ObservableCollection<Trabajador> ObtenerTrabajadores()
        {
            return Personal;
        }

    }

    
}
