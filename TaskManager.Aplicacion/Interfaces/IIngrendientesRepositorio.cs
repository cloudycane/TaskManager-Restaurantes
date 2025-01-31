﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dominio.Entidades;

namespace TaskManager.Aplicacion.Interfaces
{
    public interface IIngrendientesRepositorio
    {
        Task CrearIngrendienteAsync(IngrendientesModel model);
        Task<List<IngrendientesModel>> ObtenerListadoIngrendientesAsync();
    }
}
