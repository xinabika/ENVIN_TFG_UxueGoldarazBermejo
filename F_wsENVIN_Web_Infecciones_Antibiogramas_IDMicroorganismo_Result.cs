//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SICCA_IC.Model
{
    using System;
    
    public partial class F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo_Result
    {
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public int wsENVIN_Web_Infecciones_Microorganismos_ID { get; set; }
        public string Microorganismo { get; set; }
        public int wsENVIN_Web_Infecciones_Antibiogramas_ID { get; set; }
        public int wsENVIN_Web_Maestro_Antibiogramas_ID { get; set; }
        public string Antibiograma { get; set; }
        public int wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ID { get; set; }
        public string Resistencia { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
    }
}
