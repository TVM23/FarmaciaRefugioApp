﻿using FarmaciaRefugio.AccesoDatos.Data;
using FarmaciaRefugio.AccesoDatos.Repositorio.IRepositorio;
using FarmaciaRefugio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaRefugio.AccesoDatos.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Categoria categoria)
        {
            var categoriaDB = _db.Categorias.FirstOrDefault(b => b.Id == categoria.Id);
            if (categoriaDB != null)
            {
                categoriaDB.Nombre = categoria.Nombre;
                categoriaDB.Descripcion = categoria.Descripcion;
                categoriaDB.Estado = categoria.Estado;
                _db.SaveChanges();
            }
        }
    }
}
