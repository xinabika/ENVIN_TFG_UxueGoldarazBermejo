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
    
    public partial class F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_Result
    {
        public int wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID { get; set; }
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public bool CirugiaUrgente { get; set; }
        public bool DerivacionVentricularExterna { get; set; }
        public bool DepuracionExtrarrenal { get; set; }
        public bool NutricionParenteral { get; set; }
        public bool Neutropenia { get; set; }
        public bool ECMO { get; set; }
        public bool CateterVenosoCentral { get; set; }
        public bool ViaAereaArtificial { get; set; }
        public bool SondaUrinaria { get; set; }
        public bool Impella { get; set; }
        public bool AsistenciaVentricular { get; set; }
        public bool BCIA { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
    }
}
