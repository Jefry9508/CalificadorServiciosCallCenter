using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.CallCenterModel
{
    public class CallCenterContext : DbContext
    {
        public DbSet<ConversacionModel> Conversaciones { get; set; }

        public DbSet<CalificacionModel> Calificaciones { get; set; }

        public CallCenterContext(DbContextOptions<CallCenterContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var callCenter = new CallCenterModel();
            callCenter.Id = new Guid().ToString();
            callCenter.Nombre = "Call Me S.A.S.";

            var conversacion = new ConversacionModel();
            conversacion.Id = new Guid().ToString();
            conversacion.Titulo = "Conversacion 1";
            conversacion.Contenido = "11:51:00 CLIENTE1: Hola" + System.Environment.NewLine +
                                     "11:51:05 ASESOR1: Hola CLIENTE1, bienvenido al centro de servicio." + System.Environment.NewLine +
                                     "11:51:10 CLIENTE1: Buenas tardes, tengo un inconveniente URGENTE, URGENTE, muy URGENTE. " + System.Environment.NewLine +
                                     "11:51:15 ASESOR1: Con mucho gusto lo atenderemos." + System.Environment.NewLine +
                                     "11:51:25 CLIENTE1: Gracias.EXCELENTE SERVICIO.";
            conversacion.NroLineas = 5;
            conversacion.HoraInicio = new DateTime(2020, 11, 12, 11, 51, 0);
            conversacion.HoraFin = new DateTime(2020, 11, 12, 11, 51, 25);

            var calificacion = new CalificacionModel();
            calificacion.Id = new Guid().ToString();
            calificacion.Puntos = 170;
            calificacion.Estrellas = 5;

            modelBuilder.Entity<ConversacionModel>().HasData(callCenter);
            modelBuilder.Entity<ConversacionModel>().HasData(conversacion);
            modelBuilder.Entity<CalificacionModel>().HasData(calificacion);
        }
    }
}
