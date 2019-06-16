using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionMeteorologica.Api.Dto
{
    public class EstacionMeteorologicaDto
    {
        public CondicionesActuales CondicionesActuales { get; set; }
        //public EstadisticasDelTiempo EstadisticasDelTiempo { get; set; }
        public PronosticoSimple PronosticoSimple { get; set; }
    }
}
