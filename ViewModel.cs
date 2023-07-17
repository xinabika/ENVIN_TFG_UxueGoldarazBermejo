 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SICCATransversal
{
 #region ENVIN

    public partial class F_wsENVIN_Web_Pacientes_Filtrado_ViewModel
    {
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public int PatientID { get; set; }
        public int id_wsLEIRE_Datos_Ingresos { get; set; }
        public string NHC { get; set; }
        public short LogicalUnitID { get; set; }
        public short wsENVIN_Web_Maestro_Pacientes_ORStatus_ID { get; set; }
        public string ORStatus { get; set; }
        public short wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID { get; set; }
        public string EstadoInforme { get; set; }
        public bool EsCargaManual { get; set; }
        public System.DateTime FechaCargaManual { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Iniciales { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int wsENVIN_Web_Maestro_Pacientes_Sexo_ID { get; set; }
        public string Sexo { get; set; }
        public short NumHabitacion { get; set; }
        public System.DateTime AddmissionDate { get; set; }
        public System.DateTime FechaIngresoHospital { get; set; }
        public System.DateTime DischargeDate { get; set; }
        public System.DateTime FechaAltaHospital { get; set; }
        public bool Exitus { get; set; }
        public System.DateTime FechaExitus { get; set; }
        public String IdUsuarioUltimaModificacion { get; set; }
    }

    public partial class F_wsENVIN_Web_Pacientes_ViewModel
    {
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public int PatientID { get; set; }
        public int id_wsLEIRE_Datos_Ingresos { get; set; }
        public string NHC { get; set; }
        public short LogicalUnitID { get; set; }
        public short wsENVIN_Web_Maestro_Pacientes_ORStatus_ID { get; set; }
        public string ORStatus { get; set; }
        public short wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID { get; set; }
        public string EstadoInforme { get; set; }
        public bool EsCargaManual { get; set; }
        public System.DateTime FechaCargaManual { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Iniciales { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int wsENVIN_Web_Maestro_Pacientes_Sexo_ID { get; set; }
        public string Sexo { get; set; }
        public short NumHabitacion { get; set; }
        public System.DateTime AddmissionDate { get; set; }
        public System.DateTime FechaIngresoHospital { get; set; }
        public System.DateTime DischargeDate { get; set; }
        public System.DateTime FechaAltaHospital { get; set; }
        public bool Exitus { get; set; }
        public System.DateTime FechaExitus { get; set; }
        public String IdUsuarioUltimaModificacion { get; set; }
        public String fechaNacimientoString { get; set; } // este campo es solo para la visualizacion de web (problema de fechas anteriores a 1970 en JS)
    }


    public partial class F_wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ViewModel
    {
        public int wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID { get; set; }
        public string EstadoInforme { get; set; }
        public string ColorWeb { get; set; }
    }

    public partial class F_wsENVIN_Web_FichaIngreso_DatosAdministrativos_ViewModel
    {
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public string NHC { get; set; }
        public string Iniciales { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public Nullable<int> Edad { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_Pacientes_Sexo_ID { get; set; }
        public string Sexo { get; set; }
        public Nullable<short> NumHabitacion { get; set; }
        public Nullable<System.DateTime> FechaIngresoHospital { get; set; }
        public System.DateTime AddmissionDate { get; set; }
        public Nullable<System.DateTime> DischargeDate { get; set; }
        public Nullable<System.DateTime> FechaAltaHospital { get; set; }
        public bool Exitus { get; set; }
        public Nullable<System.DateTime> FechaExitus { get; set; }
        public String IdUsuarioUltimaModificacion { get; set; }
        public String fechaNacimientoString { get; set; } // este campo es solo para la visualizacion de web (problema de fechas anteriores a 1970 en JS)
    }

    public partial class F_wsENVIN_Web_FichaIngreso_General_ViewModel
    {
        public int wsENVIN_Web_FichaIngreso_General_ID { get; set; }
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public Nullable<short> wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID { get; set; }
        public string DiagnosticoENVIN { get; set; }
        public Nullable<short> Apache_II { get; set; }
        public Nullable<short> Glasgow { get; set; }
        public Nullable<short> wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID { get; set; }
        public string OrigenPaciente { get; set; }
        public Nullable<short> wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID { get; set; }
        public string TipoDeAdmision { get; set; }
        public bool PacienteTraumatizado { get; set; }
        public bool PacienteCoronario { get; set; }
        public bool ATB48hPrevias { get; set; }
        public Nullable<short> wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID { get; set; }
        public string CirugiaPrevia { get; set; }
        public bool PacienteCovid19 { get; set; }
        public String IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public String IdUsuarioValidacion { get; set; }
    }

    public partial class F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ViewModel
    {
        public int wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID { get; set; }
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public bool Diabetes { get; set; }
        public bool InsuficienciaRenal { get; set; }
        public bool Inmunodepresion { get; set; }
        public bool Neoplasia { get; set; }
        public bool Cirrosis { get; set; }
        public bool EPOC { get; set; }
        public bool DesnutricionHipoalbuminemia { get; set; }
        public bool TransplanteOrganoSolido { get; set; }
        public String IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public String IdUsuarioValidacion { get; set; }
    }

    public partial class F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ViewModel
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
        public String IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public String IdUsuarioValidacion { get; set; }
    }

    public partial class F_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ViewModel
    {
        public int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID { get; set; }
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID { get; set; }
        public string NombreInfeccion { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID { get; set; }
        public string Cuando { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID { get; set; }
        public string Localizacion { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public String IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public String IdUsuarioValidacion { get; set; }
    }


    public partial class F_wsENVIN_Web_Antibioticos_ViewModel
    {
        public int wsENVIN_Web_Antibioticos_ID { get; set; }
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public short LogicalUnitID { get; set; }
        public int PlannedOrderID { get; set; }
        public string Antibiotico { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID { get; set; }
        public string Indicacion { get; set; }
        public Nullable<short> wsENVIN_Web_Maestro_Infecciones_Localizacion_ID { get; set; }
        public string Localizacion { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_Antibioticos_Motivo_ID { get; set; }
        public string Motivo { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID { get; set; }
        public string Confirmacion { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID { get; set; }
        public string CambioDeAntibiotico { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID { get; set; }
        public string MotivoDelCambio { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }

        public bool Estado { get; set; }
    }


    public partial class F_wsENVIN_Web_FactoresRiesgoIndividual_ViewModel
    {
        public int wsENVIN_Web_FactoresRiesgoIndividual_ID { get; set; }
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public Nullable<System.DateTime> Periodo1ViaAereaArtificial_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo1ViaAereaArtificial_Fin { get; set; }
        public Nullable<System.DateTime> Periodo2ViaAereaArtificial_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo2ViaAereaArtificial_Fin { get; set; }
        public Nullable<System.DateTime> Periodo3ViaAereaArtificial_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo3ViaAereaArtificial_Fin { get; set; }
        public Nullable<System.DateTime> FechaInicioTraqueostomia { get; set; }
        public Nullable<System.DateTime> Periodo1VMNI_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo1VMNI_Fin { get; set; }
        public Nullable<System.DateTime> Periodo2VMNI_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo2VMNI_Fin { get; set; }
        public Nullable<System.DateTime> Periodo3VMNI_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo3VMNI_Fin { get; set; }
        public Nullable<System.DateTime> Fecha1Reintubacion { get; set; }
        public Nullable<System.DateTime> Fecha2Reintubacion { get; set; }
        public Nullable<System.DateTime> PeriodoSondaUrinaria_Inicio { get; set; }
        public Nullable<System.DateTime> PeriodoSondaUrinaria_Fin { get; set; }
        public Nullable<System.DateTime> Periodo1CVC_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo1CVC_Fin { get; set; }
        public Nullable<System.DateTime> Periodo2CVC_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo2CVC_Fin { get; set; }
        public Nullable<System.DateTime> Periodo3CVC_Inicio { get; set; }
        public Nullable<System.DateTime> Periodo3CVC_Fin { get; set; }
        public Nullable<System.DateTime> PeriodoCateterArterial_Inicio { get; set; }
        public Nullable<System.DateTime> PeriodoCateterArterial_Fin { get; set; }
        public Nullable<System.DateTime> PeriodoNutricionParenteral_Inicio { get; set; }
        public Nullable<System.DateTime> PeriodoNutricionParenteral_Fin { get; set; }
        public Nullable<System.DateTime> PeriodoNutricionEnteral_Inicio { get; set; }
        public Nullable<System.DateTime> PeriodoNutricionEnteral_Fin { get; set; }
        public Nullable<System.DateTime> ECMO_Inicio { get; set; }
        public Nullable<System.DateTime> ECMO_Fin { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID { get; set; }
        public string DiagnosticoENVIN { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID { get; set; }
        public string OrigenPaciente { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID { get; set; }
        public string TipoDeAdmision { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID { get; set; }
        public string CirugiaPrevia { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID { get; set; }
        public string NombreInfeccion { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID { get; set; }
        public string Cuando { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID { get; set; }
        public string Localizacion { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ViewModel
    {
        public int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Bloques_Controles_ViewModel
    {
        public int wsENVIN_Web_Bloques_Controles_ID { get; set; }
        public int wsENVIN_Web_Bloques_ID { get; set; }
        public int wsENVIN_Web_Controles_Grupos_ID { get; set; }
        public int wsENVIN_Web_Controles_ID { get; set; }
        public string wsENVIN_Web_Bloques_Definicion { get; set; }
        public string wsENVIN_Web_Controles_Grupos_Definicion { get; set; }
        public string wsENVIN_Web_Controles_Definicion { get; set; }
        public int wsENVIN_Web_Controles_Tipos_ID { get; set; }
        public string wsENVIN_Web_Controles_Tipos_Definicion { get; set; }
        public bool esEtiqueta { get; set; }
        public string TextoEtiqueta { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ViewModel
    {
        public int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID { get; set; }
        public string CambioDeAntibiotico { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }


    public partial class F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ViewModel
    {
        public int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID { get; set; }
        public string Confirmacion { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }


    public partial class F_wsENVIN_Web_Maestro_Antibioticos_Indicacion_ViewModel
    {
        public int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID { get; set; }
        public string Indicacion { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }


    public partial class F_wsENVIN_Web_Maestro_Antibioticos_Motivo_ViewModel
    {
        public int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID { get; set; }
        public string Motivo { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }


    public partial class F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ViewModel
    {
        public int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID { get; set; }
        public string MotivoDelCambio { get; set; }
        public Nullable<int> IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Infecciones_ViewModel
    {
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public int wsENVIN_Web_Infecciones_ID { get; set; }
        public int wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID { get; set; }
        public string OrigenInfeccion { get; set; }
        public int wsENVIN_Web_Maestro_Infecciones_Localizacion_ID { get; set; }
        public string Localizacion { get; set; }
        public bool Bacteriemia { get; set; }
        public int wsENVIN_Web_Maestro_Infecciones_Muestra_ID { get; set; }
        public string Muestra { get; set; }
        public int wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID { get; set; }
        public string DiagnosticoClinico { get; set; }
        public bool Exposicion48hprevias { get; set; }
        public bool TratamientoAntibiotico { get; set; }
        public bool TratamientoApropiado { get; set; }
        public bool AjusteTratamiento { get; set; }
        public int wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID { get; set; }
        public string RespuestaInflamatoria { get; set; }
        public int wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID { get; set; }
        public string TipoCateter { get; set; }
        public int wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID { get; set; }
        public string LugarInsercion { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public DateTime FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
        public DateTime FechaInfeccion { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ViewModel
    {
        public int wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID { get; set; }
        public string DiagnosticoClinico { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Infecciones_Localizacion_ViewModel
    {
        public int wsENVIN_Web_Maestro_Infecciones_Localizacion_ID { get; set; }
        public string Localizacion { get; set; }
        public int TipoMuestra { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Infecciones_Muestra_ViewModel
    {
        public int wsENVIN_Web_Maestro_Infecciones_Muestra_ID { get; set; }
        public string Muestra { get; set; }
        public int TipoMuestra { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ViewModel
    {
        public int wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID { get; set; }
        public string OrigenInfeccion { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ViewModel
    {
        public int wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID { get; set; }
        public string RespuestaInflamatoria { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Infecciones_TipoCateter_ViewModel
    {
        public int wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID { get; set; }
        public string TipoCateter { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ViewModel
    {
        public int wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID { get; set; }
        public string LugarInsercion { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Microorganismos_ViewModel
    {
        public int wsENVIN_Web_Maestro_Microorganismos_ID { get; set; }
        public string Microorganismo { get; set; }
        public int wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID { get; set; }
        public string GrupoMicroorganismo { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo_ViewModel
    {
        public int wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID { get; set; }
        public string GrupoMicroorganismo { get; set; }
        public int wsENVIN_Web_Maestro_Antibiogramas_ID { get; set; }
        public string Antibiograma { get; set; }
        public string Obligatoriedad { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Microorganismos_UFC_10_ViewModel
    {
        public int wsENVIN_Web_Maestro_Microorganismos_UFC_10_ID { get; set; }
        public string UFC_10 { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo_ViewModel
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
        public DateTime FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ViewModel
    {
        public int wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ID { get; set; }
        public string Resistencia { get; set; }
        public int IdExterno { get; set; }
    }

    public partial class F_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion_ViewModel
    {
        public int wsENVIN_Web_Pacientes_ID { get; set; }
        public int wsENVIN_Web_Infecciones_ID { get; set; }
        public int wsENVIN_Web_Infecciones_Microorganismos_ID { get; set; }
        public int wsENVIN_Web_Maestro_Microorganismos_ID { get; set; }
        public string Microorganismo { get; set; }
        public int wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID { get; set; }
        public string GrupoMicroorganismo { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
        public int wsENVIN_Web_Maestro_Microorganismos_UFC_10_ID { get; set; }
    }

    public partial class F_wsENVIN_Web_FactoresMensuales_ViewModel
    {
        public int wsENVIN_Web_FactoresMensuales_ID { get; set; }
        public int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID { get; set; }
        public string Mes { get; set; }
        public int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID { get; set; }
        public int Anno { get; set; }
        public short LogicalUnitID { get; set; }
        public short NumPacientesIngresados { get; set; }
        public short NumPacientesNuevos { get; set; }
        public short NumPacientesConATB { get; set; }
        public short NumPacientesConBMR { get; set; }
        public short NumPacientesAislados { get; set; }
        public short NumPacientesA_PreventivoContacto { get; set; }
        public short NumPacientesA_Contacto { get; set; }
        public short NumPacientesA_Protector { get; set; }
        public short NumPacientesA_Gotas { get; set; }
        public short NumPacientesA_GotasContacto { get; set; }
        public short NumPacientesA_Aereo { get; set; }
        public short NumPacientesA_AereoContacto { get; set; }
        public short NumPacientesConViaAerea { get; set; }
        public short NumPacientesConSondaUrinaria { get; set; }
        public short NumPacientesConArteria { get; set; }
        public short NumPacientesConViaCentral { get; set; }
        public Nullable<System.DateTime> FechaComputo { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
    }

    public partial class F_wsENVIN_Web_FactoresMensuales_SumatorioMensual_ViewModel
    {
        public Nullable<int> wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID { get; set; }
        public string Mes { get; set; }
        public Nullable<int> wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID { get; set; }
        public Nullable<int> Anno { get; set; }
        public Nullable<int> LogicalUnitID { get; set; }
        public Nullable<int> NumPacientesIngresados { get; set; }
        public Nullable<int> NumPacientesNuevos { get; set; }
        public Nullable<int> NumPacientesConATB { get; set; }
        public Nullable<int> NumPacientesConBMR { get; set; }
        public Nullable<int> NumPacientesAislados { get; set; }
        public Nullable<int> NumPacientesA_PreventivoContacto { get; set; }
        public Nullable<int> NumPacientesA_Contacto { get; set; }
        public Nullable<int> NumPacientesA_Protector { get; set; }
        public Nullable<int> NumPacientesA_Gotas { get; set; }
        public Nullable<int> NumPacientesA_GotasContacto { get; set; }
        public Nullable<int> NumPacientesA_Aereo { get; set; }
        public Nullable<int> NumPacientesA_AereoContacto { get; set; }
        public Nullable<int> NumPacientesConViaAerea { get; set; }
        public Nullable<int> NumPacientesConSondaUrinaria { get; set; }
        public Nullable<int> NumPacientesConArteria { get; set; }
        public Nullable<int> NumPacientesConViaCentral { get; set; }
        public Nullable<System.DateTime> FechaComputo { get; set; }
        public string IdUsuarioUltimaModificacion { get; set; }
        public Nullable<System.DateTime> FechaValidacion { get; set; }
        public string IdUsuarioValidacion { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FactoresMensuales_Meses_ViewModel
    {
        public int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID { get; set; }
        public string Mes { get; set; }
    }

    public partial class F_wsENVIN_Web_Maestro_FactoresMensuales_Annos_ViewModel
    {
        public int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID { get; set; }
        public int Anno { get; set; }
    }


    #endregion
    }