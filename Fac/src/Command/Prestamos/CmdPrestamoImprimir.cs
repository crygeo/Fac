using Command;
using Fac.src.Dats.Objet;
using Fac.src.UserControls;
using Fac.src.View;
using Fac.src.View.Recurs;
using Fac.src.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Reflection;

namespace Fac.src.Command.Prestamo
{
    public class CmdPrestamoImprimir : CommandBase
    {

        public override void Execute(object parameter)
        {
            if (parameter is PrestamosTrabajador prt)
            {

                string pth = Path.Combine(Directory.GetCurrentDirectory(), "PDF", "Modelo", "Documentos.html");
                string namePDF = prt.Trabajador.Nombre.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyMMddHHmmss") + ".pdf";
                string pth2 = Path.Combine(Directory.GetCurrentDirectory(), "PDF", namePDF);

                string chromePath = FindChromeExecutable();

                var p = new System.Diagnostics.Process()
                {
                    StartInfo = {
                        FileName = chromePath,
                        Arguments = $@"/C --headless --disable-gpu --run-all-compositor-stages-before-draw --print-to-pdf-no-header --print-to-pdf=""{pth2}"" ""{CrearUrl(pth, prt)}""",
                }
                };

                p.Start();

                // ...then wait n milliseconds for exit (as after exit, it can't read the output)
                p.WaitForExit(60000);

                // read the exit code, close process
                int returnCode = p.ExitCode;
                p.Close();




                try
                {
                    var aa = System.IO.File.Exists(pth2);

                    // Check if the file exists
                    if (aa)
                    {
                        // Open the file using the default program
                        Process.Start("cmd", "/c start " + pth2);
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }



            }


        }


        private static string FindChromeExecutable()
        {
            string[] possiblePaths = {
            @"C:\Program Files\Google\Chrome\Application\chrome.exe",
            @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
        };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    return path;
                }
            }

            return null;
        }

        private string CrearUrl(string url, PrestamosTrabajador ptm)
        {
            string parm1 = $"nombre={ptm.Trabajador.Nombre}";
            string parm2 = $"dni={ptm.Trabajador.Dni}";
            string parm3 = $"cargo={ptm.Trabajador.Puesto}";
            string parm4 = $"telefono={(ptm.Trabajador.Telefono == "" ? "" : ptm.Trabajador.Telefono)}";
            string parm5 = $"monto={ptm.SilverPrestado.ToString("C")}";


            string dia = ptm.FechaEmicion.ToString("dddd"); // Obtén el día completo en minúsculas
            dia = char.ToUpper(dia[0]) + dia.Substring(1); // Convierte la primera letra en mayúscula
            string parm6 = $"fecha={dia} {ptm.FechaEmicion.ToString("d 'de' MMMM 'del' yyyy")}";

            var temp = string.Concat($"{url}?{parm1}&{parm2}&{parm3}&{parm4}&{parm5}&{parm6}");
            temp = temp.Replace(" ", "%20");
            return temp;
        }

    }



}

