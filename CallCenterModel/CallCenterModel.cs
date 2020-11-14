using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.CallCenterModel
{
    class CallCenterModel
    {
        private string nombre;
        public string Id { get; set; }

        public List<ConversacionModel> Conversaciones { get; set; }

        public string Nombre { get => nombre; set => nombre = value; }
    }
}
