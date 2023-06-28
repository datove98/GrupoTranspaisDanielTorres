using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTranspaisDanielTorres
{
    public class Archivo
    {
        public Archivo() { }

        public static List<Persona> ObtenerInfo(string fileName)
        {
            List<Persona> Personas = new List<Persona>();
            var workbook = new XLWorkbook(fileName);
            var ws1 = workbook.Worksheet(1);
            var rows = ws1.RangeUsed().RowsUsed().Skip(1);
            foreach (var row in rows)
            {
                if (row.IsEmpty()) break;

                Persona persona = new Persona();
                //persona.Id = string.IsNullOrEmpty(row.Cell(1).Value.ToString()) ? int.Parse(row.Cell(1).Value.ToString()) : 0;
                persona.Id = !row.Cell(1).Value.IsBlank ? int.Parse(row.Cell(1).Value.ToString()) : 0;
                persona.Nombre = row.Cell(2).Value.ToString();
                persona.Apellido = row.Cell(3).Value.ToString();
                persona.Edad = !row.Cell(4).Value.IsBlank ? int.Parse(row.Cell(4).Value.ToString()) : 0;
                //persona.Edad =  int.Parse(row.Cell(4).Value.ToString());

                Personas.Add(persona);
            }
            return Personas;
        }
    }
}
