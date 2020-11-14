using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.CallCenterModel
{
    class CalificacionModel
    {
        private int puntos;
        private int estrellas;

        public string Id { get; set; }
        public string CallCenterId { get; set; }
        public CallCenterModel CallCenter { get; set; }
        public string ConversacionId { get; set; }
        public ConversacionModel Conversacion { get; set; }

        public int Puntos { get => puntos; set => puntos = value; }
        public int Estrellas { get => estrellas; set => estrellas = value; }
    }
}
