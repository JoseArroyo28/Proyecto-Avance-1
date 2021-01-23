using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarrotesProyecto.Modelo
{
    public class Producto
    {
        public Int64 idProduucto { get; set; }
        public String nombrePro { get; set; }
        public String marcaPro { get; set; }
        public String netoPro { get; set; }
        public String categoriaPro { get; set; }
        public String stockPro { get; set; }
        public String estadoPro { get; set; }
        public byte [] imagenpro { get; set; }
        public string codigobarraPro { get; set; }
        public double precioCompra { get; set; }
        public double precioVenta { get; set; }



        public Producto() { }

        public Producto(Int64 idProduucto, String nombrePro, String marcaPro, String netoPro, String categoriaPro, String stockPro, String estadoPro, byte[] imagenpro, String codigobarraPro, double precioCompra, double precioVenta)
        {
            this.idProduucto = idProduucto;
            this.nombrePro = nombrePro;
            this.marcaPro = marcaPro;
            this.netoPro = netoPro;
            this.categoriaPro = categoriaPro;
            this.stockPro = stockPro;
            this.estadoPro = estadoPro;
            this.imagenpro = imagenpro;
            this.codigobarraPro = codigobarraPro;
            this.precioCompra = precioCompra;
            this.precioVenta     = precioVenta;
        }
    }
}
