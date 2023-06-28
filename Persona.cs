using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTranspaisDanielTorres
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Edad { get; set; } = 0;

        internal void GuardarInfo(List<Persona> personas)
        {
            foreach (var persona in personas)
            {
                if (!Existe(persona))
                {
                    Conexion.InsertarPersona(persona);
                }
            }
        }

        public bool Existe(Persona persona)
        {
            string nombreCompleto = persona.Nombre + " " + persona.Apellido;
            string nombreComparar = string.Empty;
            Persona personaTest = new Persona();
            if (persona.Id > 0)
            {
                DataTable dt = Conexion.GetPersona(persona.Id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        personaTest.Id = int.Parse(fila["id"].ToString());
                        personaTest.Nombre = fila["nombre"].ToString();
                        personaTest.Apellido = fila["apellido"].ToString();
                        personaTest.Edad = int.Parse(fila["edad"].ToString());
                    }
                }
                nombreComparar = personaTest.Nombre + " " + personaTest.Apellido;
                //if (nombreComparar == nombreCompleto) { return true; }

            }
            return nombreComparar == nombreCompleto ? true : false;
        }
    }
}
