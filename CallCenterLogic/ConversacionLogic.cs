using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CallCenter.CallCenterLogic
{
    class ConversacionLogic
    {

        private static readonly string[] ListaPalabras = new[]
        {
            "Gracias", " Buena Atención", "Muchas Gracias", "EXCELENTE SERVICIO"
        };

        private static readonly int puntosUrgente = -2;
        private static readonly int puntosExcelenteServicio = 100;
        private static readonly int puntosOtrasPalabras = 10;
        private static readonly int puntosMenor1Min = 50;
        private static readonly int puntosMayorIgual1Min = 25;
        private static readonly int puntosConversacionAbandonada = -100;

        private Dictionary<long, String> PalabrasClave;

        public enum ListaPalabrasEnum : long
        {
            Gracias = 0,
            BuenaAtencion,
            MuchasGracias,
            ExcelenteServicio,
            Urgente
        }

        public ConversacionLogic()
        {
            PalabrasClave = new Dictionary<long, string>();

            for (int i = 0; i < ListaPalabras.Length; i++)
            {
                PalabrasClave.Add(i, ListaPalabras[i]);
            }
        }

        public int HallarCalificacion(string conversacion)
        {
            var puntuacion = 0;

            puntuacion += CalificarCantidadLineas(conversacion);
            puntuacion += CalificarCoincidenciasPalabras(conversacion);
            puntuacion += CalificarDuracionConversacion(conversacion);

            return puntuacion;
        }

        private int CalificarCantidadLineas(string conversacion)
        {
            var cantidadLineas = 0;
            var puntaje = 0;

            cantidadLineas = conversacion.Split(System.Environment.NewLine.ToCharArray()).Length;

            if (cantidadLineas == 1)
            {
                puntaje = puntosConversacionAbandonada;
            }
            else
            {
                if (cantidadLineas <= 5)
                {
                    puntaje = 20;

                }
                else
                {
                    puntaje = 10;
                }
            }
            
            return puntaje;
        }

        private int CalificarCoincidenciasPalabras(string conversacion)
        {
            int puntaje = 0;
            int totalUrgente = 0;
            int totalExcelenteServicio = 0;
            int totalOtrasPalabras = 0;


            totalUrgente = Regex.Matches(conversacion, PalabrasClave[(long)ListaPalabrasEnum.Urgente]).Count;
            totalExcelenteServicio = Regex.Matches(conversacion, PalabrasClave[(long)ListaPalabrasEnum.ExcelenteServicio]).Count;

            totalOtrasPalabras = Regex.Matches(conversacion, PalabrasClave[(long)ListaPalabrasEnum.ExcelenteServicio]).Count;
            totalOtrasPalabras += Regex.Matches(conversacion, PalabrasClave[(long)ListaPalabrasEnum.MuchasGracias]).Count;
            totalOtrasPalabras += Regex.Matches(conversacion, PalabrasClave[(long)ListaPalabrasEnum.Gracias]).Count;
            totalOtrasPalabras += Regex.Matches(conversacion, PalabrasClave[(long)ListaPalabrasEnum.BuenaAtencion]).Count;

            puntaje = (totalUrgente * puntosUrgente) + (totalExcelenteServicio * puntosExcelenteServicio) + (totalOtrasPalabras * puntosOtrasPalabras);

            return puntaje;
        }

        private int CalificarDuracionConversacion(string conversacion)
        {
            var puntaje = 0;

            var lineasTexto = conversacion.Split(System.Environment.NewLine.ToCharArray());

            var formatoHoraInicio = lineasTexto[0].Substring(0, 8).Split(':');
            var formatoHoraFin = lineasTexto[lineasTexto.Length-1].Substring(0, 8).Split(':');

            var horaInicio = new DateTime(1, 1, 1, int.Parse(formatoHoraInicio[0]), int.Parse(formatoHoraInicio[1]), int.Parse(formatoHoraInicio[3]));
            var horaFin = new DateTime(1, 1, 1, int.Parse(formatoHoraFin[0]), int.Parse(formatoHoraFin[1]), int.Parse(formatoHoraFin[3]));

            var tiempoDuracion = horaInicio.Subtract(horaFin).TotalMinutes;

            if (tiempoDuracion < 1)
            {
                puntaje = puntosMenor1Min;
            }
            else
            {
                puntaje = puntosMayorIgual1Min;
            }
            return puntaje;
        }
    }
}
