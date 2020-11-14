using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.CallCenterModel
{
    class ConversacionModel
    {
        private String titulo;
        private String contenido;
        private int nroLineas;
        private DateTime horaInicio;
        private DateTime horaFin;

        public string CallCenterId { get; set; }
        public CallCenterModel CallCenter { get; set; }
        public string CalificacionId { get; set; }
        public CalificacionModel Calificacion { get; set; }


        public string Contenido { get => contenido; set => contenido = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public int NroLineas { get => nroLineas; set => nroLineas = value; }
        public DateTime HoraInicio { get => horaInicio; set => horaInicio = value; }
        public DateTime HoraFin { get => horaFin; set => horaFin = value; }
        public string Id { get; set; }
    }
}
