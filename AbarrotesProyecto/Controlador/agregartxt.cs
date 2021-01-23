using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AbarrotesProyecto.Controlador
{
   public  class agregartxt
    {
        private StreamWriter sw;

        public agregartxt()
        {
            sw = new StreamWriter("C:\\Users\\peche\\Documents\\Venta.txt");

            sw.Close();
        }

        public void GenerarCodigoIntermedioExpresion(string Dato)
        {
                GenerarCodigoIntermedioExpresion(Dato);

            // imprime            
            sw = File.AppendText("C:\\Users\\peche\\Documents\\Venta.txt");
            sw.WriteLine(Dato);
            sw.Close();



        }
    }
}
