﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;

namespace Persistencia
{
    public interface IZonaPersistencia
    {
        void AgregarZona(Zona Zo);
        void ModificarZona(Zona Zo);
        void EliminarZona(Zona Zo);
        List<Zona> Listo();
        List<Zona> ListoPorDpto(string _letraDpto);
        Zona Busco(string pLetra, string pAbrev);
        Zona BuscoTodas(string letraDpto, string abreviacion);
    }
}