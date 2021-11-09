using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCClinica.Data;
using MVCClinica.Models;
using System.Data.Entity;

namespace MVCClinica.Admin
{
    public static class AdmMedico
    {
        private static MedicoDbContext context = new MedicoDbContext();

        public static List<Medico> Listar()
        {
            return context.Medicos.ToList();
        }

        public static Medico Listar(int id)
        {
            return context.Medicos.Find(id);
        }

        public static Medico Buscar(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }
        public static void Cargar(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
        }
        public static void Modificar(Medico medico)
        {
            context.Medicos.Attach(medico);
            context.Entry(medico).State = EntityState.Modified;
            context.SaveChanges();
        }
        public static void Eliminar(Medico medico)
        {
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }
        public static List<Medico> TraerEspecialidad(string especialidad)
        {
            List<Medico> medicoEspecialidad = (from e in context.Medicos
                                               where e.Especialidad == especialidad
                                               select e).ToList();
            return medicoEspecialidad;
        }
        public static List<Medico> TraerNombreApellido(string nombre,string apellido)
        {
            List<Medico> medicoNombreApellido = (from m in context.Medicos
                                               where m.Nombre == nombre
                                               && m.Apellido == apellido
                                               select m).ToList();
            return medicoNombreApellido;
        }
    }
}