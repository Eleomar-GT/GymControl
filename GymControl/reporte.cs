using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymControl
{
    internal class reporte
    {
        public static void GenerarReporteTxt(List<Pago> pagos, string rutaArchivo)
        {
            var sb = new StringBuilder();

            sb.AppendLine("========================================");
            sb.AppendLine("        REPORTE DE PAGOS - GYM CONTROL");
            sb.AppendLine("========================================");
            sb.AppendLine($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Total de registros: {pagos.Count}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine();

            sb.AppendLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-10} {4,-12} {5,-10}",
                "ID", "Socio", "Concepto", "Monto", "Fecha", "Método"));
            sb.AppendLine(new string('-', 80));

            foreach (var p in pagos.OrderBy(p => p.Fecha))
            {
                sb.AppendLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-10:C2} {4,-12:dd/MM/yyyy} {5,-10}",
                    p.Id, p.NombreSocio, p.Concepto, p.Monto, p.Fecha, p.MetodoPago));
            }

            sb.AppendLine(new string('-', 80));
            decimal total = pagos.Sum(p => p.Monto);
            sb.AppendLine($"TOTAL RECAUDADO: {total:C2}");
            sb.AppendLine("========================================");

            File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
        }

        // Reporte filtrado por rango de fechas (útil para "corte de caja")
        public static void GenerarReportePorFecha(List<Pago> pagos, DateTime desde, DateTime hasta, string rutaArchivo)
        {
            var filtrados = pagos
                .Where(p => p.Fecha.Date >= desde.Date && p.Fecha.Date <= hasta.Date)
                .ToList();

            GenerarReporteTxt(filtrados, rutaArchivo);
        }
    }
}
