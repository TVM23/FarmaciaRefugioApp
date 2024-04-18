using FarmaciaRefugio.AccesoDatos.Data;
using FarmaciaRefugio.AccesoDatos.Repositorio.IRepositorio;
using FarmaciaRefugio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaRefugio.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoDB = _db.Productos.FirstOrDefault(b => b.Id == producto.Id);
            if (productoDB != null)
            {
                if (producto.ImagenUrl != null)
                {
                    productoDB.ImagenUrl = producto.ImagenUrl;
                }
                productoDB.Nombre = producto.Nombre;
                productoDB.NumeroSerie = producto.NumeroSerie;
                productoDB.Descripcion = producto.Descripcion;
                productoDB.Precio = producto.Precio;
                productoDB.Costo = producto.Costo;
                productoDB.CategoriaId = producto.CategoriaId;
                productoDB.MarcaId = producto.MarcaId;
                productoDB.PadreId = producto.PadreId;
                productoDB.Estado = producto.Estado;
                _db.SaveChanges();
            }
        }
    }
}
