using SICCATransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SICCA_IC.Model;
using static SICCATransversal.wsENVIN;

namespace SICCA_IC
{
    public class wsENVINManager
    {
        #region funciones

        public static IEnumerable<F_wsENVIN_Web_Pacientes_ViewModel> F_wsENVIN_Web_Pacientes(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Pacientes_Result> result = data.F_wsENVIN_Web_Pacientes(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_Pacientes_ViewModel
            {
                wsENVIN_Web_Pacientes_ID = dd.wsENVIN_Web_Pacientes_ID,
                PatientID = dd.PatientID,
                id_wsLEIRE_Datos_Ingresos = dd.id_wsLEIRE_Datos_Ingresos,
                NHC = dd.NHC,
                LogicalUnitID = dd.LogicalUnitID,
                wsENVIN_Web_Maestro_Pacientes_ORStatus_ID = dd.wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                ORStatus = dd.ORStatus,
                wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID = dd.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID,
                EstadoInforme = dd.EstadoInforme,
                EsCargaManual = dd.EsCargaManual,
                FechaCargaManual = dd.FechaCargaManual ?? DateTime.MinValue,
                FirstName = dd.FirstName,
                LastName = dd.LastName,
                Iniciales = dd.Iniciales,
                FechaNacimiento = dd.FechaNacimiento ?? DateTime.MinValue,
                Edad = dd.Edad ?? 0,
                wsENVIN_Web_Maestro_Pacientes_Sexo_ID = dd.wsENVIN_Web_Maestro_Pacientes_Sexo_ID ?? 0,
                Sexo = dd.Sexo,
                NumHabitacion = dd.NumHabitacion ?? 0,
                AddmissionDate = dd.AddmissionDate,
                FechaIngresoHospital = dd.FechaIngresoHospital ?? DateTime.MinValue,
                DischargeDate = dd.DischargeDate ?? DateTime.MinValue,
                FechaAltaHospital = dd.FechaAltaHospital ?? DateTime.MinValue,
                Exitus = dd.Exitus,
                FechaExitus = dd.FechaExitus ?? DateTime.MinValue,
                IdUsuarioUltimaModificacion = dd.IdUsuarioUltimaModificacion
            }).OrderBy(x => x.AddmissionDate);
        }//fin F_wsENVIN_Web_Pacientes


        public static IEnumerable<F_wsENVIN_Web_Pacientes_Filtrado_ViewModel> F_wsENVIN_Web_Pacientes_Filtrado(DateTime fechaInicio, DateTime fechaFin, int logicalUnitID, int EstadoInforme, String nombre, String apellidos, String nhc)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Pacientes_Filtrado_Result> result = data.F_wsENVIN_Web_Pacientes_Filtrado(fechaInicio, fechaFin, logicalUnitID, EstadoInforme, nombre, apellidos, nhc);
            return result.Select(dd => new F_wsENVIN_Web_Pacientes_Filtrado_ViewModel
            {
                wsENVIN_Web_Pacientes_ID=dd.wsENVIN_Web_Pacientes_ID,
                PatientID=dd.PatientID,
                id_wsLEIRE_Datos_Ingresos=dd.id_wsLEIRE_Datos_Ingresos,
                NHC=dd.NHC,
                LogicalUnitID=dd.LogicalUnitID,
                wsENVIN_Web_Maestro_Pacientes_ORStatus_ID = dd.wsENVIN_Web_Maestro_Pacientes_ORStatus_ID,
                ORStatus=dd.ORStatus,
                wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID = dd.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID,
                EstadoInforme=dd.EstadoInforme,
                EsCargaManual=dd.EsCargaManual,
                FechaCargaManual=dd.FechaCargaManual ?? DateTime.MinValue,
                FirstName=dd.FirstName,
                LastName=dd.LastName,
                Iniciales=dd.Iniciales,
                FechaNacimiento=dd.FechaNacimiento ?? DateTime.MinValue,
                Edad =dd.Edad??0,
                wsENVIN_Web_Maestro_Pacientes_Sexo_ID=dd.wsENVIN_Web_Maestro_Pacientes_Sexo_ID??0,
                Sexo =dd.Sexo,
                NumHabitacion=dd.NumHabitacion ?? 0,
                AddmissionDate= dd.AddmissionDate ,
                FechaIngresoHospital=dd.FechaIngresoHospital ?? DateTime.MinValue,
                DischargeDate=dd.DischargeDate ?? DateTime.MinValue,
                FechaAltaHospital=dd.FechaAltaHospital ?? DateTime.MinValue,
                Exitus =dd.Exitus,
                FechaExitus=dd.FechaExitus ?? DateTime.MinValue,
                IdUsuarioUltimaModificacion=dd.IdUsuarioUltimaModificacion
            }).OrderBy(x => x.AddmissionDate);
        }//fin F_wsENVIN_Web_Pacientes_Filtrado

        public static IEnumerable<F_wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ViewModel> F_wsENVIN_Web_Maestro_Pacientes_EstadosInforme(int wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Pacientes_EstadosInforme_Result> result = data.F_wsENVIN_Web_Maestro_Pacientes_EstadosInforme(wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ViewModel
            {
                wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID = dd.wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID,
                EstadoInforme = dd.EstadoInforme,
                ColorWeb=dd.ColorWeb
            });
        }//fin F_wsENVIN_Web_Pacientes_Filtrado


        #region Funciones FichaIngreso
        #region Funciones FichaIngreso obtener datos
        public static IEnumerable<F_wsENVIN_Web_FichaIngreso_DatosAdministrativos_ViewModel> F_wsENVIN_Web_FichaIngreso_DatosAdministrativos(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FichaIngreso_DatosAdministrativos_Result> result = data.F_wsENVIN_Web_FichaIngreso_DatosAdministrativos(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_FichaIngreso_DatosAdministrativos_ViewModel
            {
             
                wsENVIN_Web_Pacientes_ID=dd.wsENVIN_Web_Pacientes_ID,
                NHC=dd.NHC,
                Iniciales=dd.Iniciales,
                FechaNacimiento=dd.FechaNacimiento ?? DateTime.MinValue,
                Edad = dd.Edad ?? 0,
                wsENVIN_Web_Maestro_Pacientes_Sexo_ID = dd.wsENVIN_Web_Maestro_Pacientes_Sexo_ID ?? 0,
                Sexo = dd.Sexo,
                NumHabitacion =dd.NumHabitacion,
                FechaIngresoHospital=dd.FechaIngresoHospital,
                AddmissionDate=dd.AddmissionDate,
                DischargeDate=dd.DischargeDate,
                FechaAltaHospital=dd.FechaAltaHospital,
                Exitus=dd.Exitus,
                FechaExitus=dd.FechaExitus,
                IdUsuarioUltimaModificacion=dd.IdUsuarioUltimaModificacion

            });
        }//fin F_wsENVIN_Web_FichaIngreso_DatosAdministrativos

        public static IEnumerable<F_wsENVIN_Web_FichaIngreso_General_ViewModel> F_wsENVIN_Web_FichaIngreso_General(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FichaIngreso_General_Result> result = data.F_wsENVIN_Web_FichaIngreso_General(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_FichaIngreso_General_ViewModel
            {
                wsENVIN_Web_FichaIngreso_General_ID=dd.wsENVIN_Web_FichaIngreso_General_ID,
                wsENVIN_Web_Pacientes_ID =dd.wsENVIN_Web_Pacientes_ID,
                wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID=dd.wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                DiagnosticoENVIN=dd.DiagnosticoENVIN,
                Apache_II =dd.Apache_II,
                Glasgow=dd.Glasgow,
                wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID=dd.wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID,
                OrigenPaciente=dd.OrigenPaciente,
                wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID =dd.wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID,
                TipoDeAdmision=dd.TipoDeAdmision,
                PacienteTraumatizado =dd.PacienteTraumatizado,
                PacienteCoronario=dd.PacienteCoronario,
                ATB48hPrevias=dd.ATB48hPrevias,
                wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID=dd.wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                CirugiaPrevia=dd.CirugiaPrevia,
                PacienteCovid19 =dd.PacienteCovid19,
                IdUsuarioUltimaModificacion=dd.IdUsuarioUltimaModificacion,
                FechaValidacion=dd.FechaValidacion,
                IdUsuarioValidacion=dd.IdUsuarioValidacion
            });
        }//fin F_wsENVIN_Web_FichaIngreso_General

        public static IEnumerable<F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ViewModel> F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_Result> result = data.F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ViewModel
            {
                wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID=dd.wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID,
                wsENVIN_Web_Pacientes_ID = dd.wsENVIN_Web_Pacientes_ID,
                Diabetes=dd.Diabetes,
                InsuficienciaRenal=dd.InsuficienciaRenal,
                Inmunodepresion=dd.Inmunodepresion,
                Neoplasia=dd.Neoplasia,
                Cirrosis=dd.Cirrosis,
                EPOC=dd.EPOC,
                DesnutricionHipoalbuminemia=dd.DesnutricionHipoalbuminemia,
                TransplanteOrganoSolido=dd.TransplanteOrganoSolido,
                IdUsuarioUltimaModificacion=dd.IdUsuarioUltimaModificacion,
                FechaValidacion=dd.FechaValidacion,
                IdUsuarioValidacion=dd.IdUsuarioValidacion
            });
        }//fin F_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias

        public static IEnumerable<F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ViewModel> F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_Result> result = data.F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ViewModel
            {
                wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID =dd.wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID,
                wsENVIN_Web_Pacientes_ID = dd.wsENVIN_Web_Pacientes_ID,
                CirugiaUrgente=dd.CirugiaUrgente,
                DerivacionVentricularExterna=dd.DerivacionVentricularExterna,
                DepuracionExtrarrenal=dd.DepuracionExtrarrenal,
                NutricionParenteral=dd.NutricionParenteral,
                Neutropenia=dd.Neutropenia,
                ECMO=dd.ECMO,
                CateterVenosoCentral=dd.CateterVenosoCentral,
                ViaAereaArtificial=dd.ViaAereaArtificial,
                SondaUrinaria=dd.SondaUrinaria,
                Impella=dd.Impella,
                AsistenciaVentricular=dd.AsistenciaVentricular,
                BCIA=dd.BCIA,
                IdUsuarioUltimaModificacion=dd.IdUsuarioUltimaModificacion,
                FechaValidacion=dd.FechaValidacion,
                IdUsuarioValidacion=dd.IdUsuarioValidacion
            });
        }//fin F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo


        public static IEnumerable<F_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ViewModel> F_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Result> result = data.F_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ViewModel
            {
                wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID = dd.wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID,
                wsENVIN_Web_Pacientes_ID = dd.wsENVIN_Web_Pacientes_ID,
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID,
                NombreInfeccion = dd.NombreInfeccion,
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID=dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
                Cuando=dd.Cuando,
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID,
                Tipo = dd.Tipo,
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
                Localizacion = dd.Localizacion,
                Fecha = dd.Fecha,
                IdUsuarioUltimaModificacion = dd.IdUsuarioUltimaModificacion,
                FechaValidacion = dd.FechaValidacion,
                IdUsuarioValidacion = dd.IdUsuarioValidacion
            });
        }//fin F_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo
        #endregion

        #region Funciones FichaIngreso Maestros

        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN(int wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN(wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                DiagnosticoENVIN = dd.DiagnosticoENVIN,
                IdExterno=dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN

        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente(int wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente(wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID,
                OrigenPaciente = dd.OrigenPaciente,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente


        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision(int wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision(wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID,
                TipoDeAdmision = dd.TipoDeAdmision,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision


        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia(int wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia(wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                CirugiaPrevia = dd.CirugiaPrevia,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision


        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion(int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID,
                NombreInfeccion = dd.NombreInfeccion,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion

        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando(int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
                Cuando = dd.Cuando,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando

        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion(int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
                Localizacion = dd.Localizacion,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion

        public static IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ViewModel> F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo(int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_Result> result = data.F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo(wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ViewModel
            {
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID = dd.wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID,
                Tipo = dd.Tipo,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo

        #endregion

        #endregion


        #region factores de riesgo individual

        #region funciones factores de riesgo individual obtener datos

         public static IEnumerable<F_wsENVIN_Web_FactoresRiesgoIndividual_ViewModel> F_wsENVIN_Web_FactoresRiesgoIndividual(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FactoresRiesgoIndividual_Result> result = data.F_wsENVIN_Web_FactoresRiesgoIndividual(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_FactoresRiesgoIndividual_ViewModel
            {
             wsENVIN_Web_FactoresRiesgoIndividual_ID=dd.wsENVIN_Web_FactoresRiesgoIndividual_ID
            ,wsENVIN_Web_Pacientes_ID=dd.wsENVIN_Web_Pacientes_ID
            ,Periodo1ViaAereaArtificial_Inicio=dd.Periodo1ViaAereaArtificial_Inicio
            ,Periodo1ViaAereaArtificial_Fin=dd.Periodo1ViaAereaArtificial_Fin
            ,Periodo2ViaAereaArtificial_Inicio=dd.Periodo2ViaAereaArtificial_Inicio
            ,Periodo2ViaAereaArtificial_Fin=dd.Periodo2ViaAereaArtificial_Fin
            ,Periodo3ViaAereaArtificial_Inicio=dd.Periodo3ViaAereaArtificial_Inicio
            ,Periodo3ViaAereaArtificial_Fin=dd.Periodo3ViaAereaArtificial_Fin
            ,FechaInicioTraqueostomia=dd.FechaInicioTraqueostomia
            ,Periodo1VMNI_Inicio=dd.Periodo1VMNI_Inicio
            ,Periodo1VMNI_Fin=dd.Periodo1VMNI_Fin
            ,Periodo2VMNI_Inicio=dd.Periodo2VMNI_Inicio
            ,Periodo2VMNI_Fin=dd.Periodo2VMNI_Fin
            ,Periodo3VMNI_Inicio=dd.Periodo3VMNI_Inicio
            ,Periodo3VMNI_Fin=dd.Periodo3VMNI_Fin
            ,Fecha1Reintubacion=dd.Fecha1Reintubacion
            ,Fecha2Reintubacion=dd.Fecha2Reintubacion
            ,PeriodoSondaUrinaria_Inicio=dd.PeriodoSondaUrinaria_Inicio
            ,PeriodoSondaUrinaria_Fin=dd.PeriodoSondaUrinaria_Fin
            ,Periodo1CVC_Inicio=dd.Periodo1CVC_Inicio
            ,Periodo1CVC_Fin=dd.Periodo1CVC_Fin
            ,Periodo2CVC_Inicio=dd.Periodo2CVC_Inicio
            ,Periodo2CVC_Fin=dd.Periodo2CVC_Fin
            ,Periodo3CVC_Inicio=dd.Periodo3CVC_Inicio
            ,Periodo3CVC_Fin=dd.Periodo3CVC_Fin
            ,PeriodoCateterArterial_Inicio=dd.PeriodoCateterArterial_Inicio
            ,PeriodoCateterArterial_Fin=dd.PeriodoCateterArterial_Fin
            ,PeriodoNutricionParenteral_Inicio=dd.PeriodoNutricionParenteral_Inicio
            ,PeriodoNutricionParenteral_Fin=dd.PeriodoNutricionParenteral_Fin
            ,PeriodoNutricionEnteral_Inicio=dd.PeriodoNutricionEnteral_Inicio
            ,PeriodoNutricionEnteral_Fin=dd.PeriodoNutricionEnteral_Fin
            ,ECMO_Inicio=dd.ECMO_Inicio
            ,ECMO_Fin=dd.ECMO_Fin
            ,IdUsuarioUltimaModificacion=dd.IdUsuarioUltimaModificacion
            ,FechaValidacion=dd.FechaValidacion
            ,IdUsuarioValidacion=dd.IdUsuarioValidacion

            });
        }//fin F_wsENVIN_Web_FactoresRiesgoIndividual


        #endregion


        #region  funciones factores de riesgo individual maestros

        public static IEnumerable<F_wsENVIN_Web_Bloques_Controles_ViewModel> F_wsENVIN_Web_Bloques_Controles(int wsENVIN_Web_Bloques_ID, int wsENVIN_Web_Controles_Grupos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Bloques_Controles_Result> result = data.F_wsENVIN_Web_Bloques_Controles(wsENVIN_Web_Bloques_ID, wsENVIN_Web_Controles_Grupos_ID);
            return result.Select(dd => new F_wsENVIN_Web_Bloques_Controles_ViewModel
            {
               wsENVIN_Web_Bloques_Controles_ID=dd.wsENVIN_Web_Bloques_Controles_ID,
                wsENVIN_Web_Bloques_ID=dd.wsENVIN_Web_Bloques_ID,
                wsENVIN_Web_Controles_Grupos_ID=dd.wsENVIN_Web_Controles_Grupos_ID,
                wsENVIN_Web_Controles_ID=dd.wsENVIN_Web_Controles_ID,
                wsENVIN_Web_Bloques_Definicion=dd.wsENVIN_Web_Bloques_Definicion,
                wsENVIN_Web_Controles_Grupos_Definicion=dd.wsENVIN_Web_Controles_Grupos_Definicion,
                wsENVIN_Web_Controles_Definicion=dd.wsENVIN_Web_Controles_Definicion,
                wsENVIN_Web_Controles_Tipos_ID=dd.wsENVIN_Web_Controles_Tipos_ID,
                wsENVIN_Web_Controles_Tipos_Definicion=dd.wsENVIN_Web_Controles_Tipos_Definicion,
                esEtiqueta=dd.esEtiqueta,
                TextoEtiqueta=dd.TextoEtiqueta

            });
        }//fin F_wsENVIN_Web_Bloques_Controles


        #endregion

        #endregion

        #region antibioticos


        #region antibioticos obtener datos


        public static IEnumerable<F_wsENVIN_Web_Antibioticos_ViewModel> F_wsENVIN_Web_Antibioticos(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Antibioticos_Result> result = data.F_wsENVIN_Web_Antibioticos(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_Antibioticos_ViewModel
            {
                wsENVIN_Web_Antibioticos_ID=dd.wsENVIN_Web_Antibioticos_ID
                ,wsENVIN_Web_Pacientes_ID=dd.wsENVIN_Web_Pacientes_ID
                ,LogicalUnitID = dd.LogicalUnitID
                ,PlannedOrderID = dd.PlannedOrderID
                ,Antibiotico = dd.Antibiotico
                ,FechaInicio = dd.FechaInicio
                ,FechaFin = dd.FechaFin
                ,wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID = dd.wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID
                ,Indicacion = dd.Indicacion
                ,wsENVIN_Web_Maestro_Infecciones_Localizacion_ID = dd.wsENVIN_Web_Maestro_Infecciones_Localizacion_ID
                ,Localizacion = dd.Localizacion
                ,wsENVIN_Web_Maestro_Antibioticos_Motivo_ID = dd.wsENVIN_Web_Maestro_Antibioticos_Motivo_ID
                ,Motivo = dd.Motivo
                ,wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID = dd.wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID
                ,Confirmacion = dd.Confirmacion
                ,wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID = dd.wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID
                ,CambioDeAntibiotico = dd.CambioDeAntibiotico
                ,wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID = dd.wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID
                ,MotivoDelCambio = dd.MotivoDelCambio
                ,IdUsuarioUltimaModificacion = dd.IdUsuarioUltimaModificacion
                ,FechaValidacion = dd.FechaValidacion
                ,IdUsuarioValidacion = dd.IdUsuarioValidacion
                ,Estado = dd.Estado

            }).OrderByDescending(x => x.Estado).ThenByDescending(x =>x.FechaInicio);

        }//fin F_wsENVIN_Web_Antibioticos


        #endregion

        #region antibioticos maestros

        public static IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ViewModel> F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico(int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_Result> result = data.F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico(wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ViewModel
            {
                wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID = dd.wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                CambioDeAntibiotico = dd.CambioDeAntibiotico,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico


        public static IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ViewModel> F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion(int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion_Result> result = data.F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion(wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ViewModel
            {
                wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID = dd.wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID,
                Confirmacion = dd.Confirmacion,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_Antibioticos_Confirmacion


        public static IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_Indicacion_ViewModel> F_wsENVIN_Web_Maestro_Antibioticos_Indicacion(int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_Indicacion_Result> result = data.F_wsENVIN_Web_Maestro_Antibioticos_Indicacion(wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Antibioticos_Indicacion_ViewModel
            {
                wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID = dd.wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID,
                Indicacion = dd.Indicacion,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_Antibioticos_Indicacion


        public static IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_Motivo_ViewModel> F_wsENVIN_Web_Maestro_Antibioticos_Motivo(int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_Motivo_Result> result = data.F_wsENVIN_Web_Maestro_Antibioticos_Motivo(wsENVIN_Web_Maestro_Antibioticos_Motivo_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Antibioticos_Motivo_ViewModel
            {
                wsENVIN_Web_Maestro_Antibioticos_Motivo_ID = dd.wsENVIN_Web_Maestro_Antibioticos_Motivo_ID,
                Motivo = dd.Motivo,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_Antibioticos_Motivo


        public static IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ViewModel> F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio(int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_Result> result = data.F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio(wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ViewModel
            {
                wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID = dd.wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID,
                MotivoDelCambio = dd.MotivoDelCambio,
                IdExterno = dd.IdExterno
            });
        }//fin F_wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio





        #endregion


        #endregion

        #region Infecciones
        public static IEnumerable<F_wsENVIN_Web_Infecciones_ViewModel> F_wsENVIN_Web_Infecciones(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Infecciones_Result> result = data.F_wsENVIN_Web_Infecciones(wsENVIN_Web_Pacientes_ID);
            return result.Select(dd => new F_wsENVIN_Web_Infecciones_ViewModel
            {
                AjusteTratamiento = dd.AjusteTratamiento,
                DiagnosticoClinico = dd.DiagnosticoClinico,
                Bacteriemia = dd.Bacteriemia,
                Exposicion48hprevias = dd.Exposicion48hprevias,
                FechaValidacion = dd.FechaValidacion ?? DateTime.MinValue,
                FechaInfeccion = dd.FechaInfeccion ?? DateTime.MinValue,
                IdUsuarioUltimaModificacion = dd.IdUsuarioUltimaModificacion,
                IdUsuarioValidacion = dd.IdUsuarioValidacion,
                Localizacion = dd.Localizacion,
                LugarInsercion = dd.LugarInsercion,
                Muestra = dd.Muestra,
                OrigenInfeccion = dd.OrigenInfeccion,
                RespuestaInflamatoria = dd.RespuestaInflamatoria,
                TipoCateter = dd.TipoCateter,
                TratamientoAntibiotico = dd.TratamientoAntibiotico,
                TratamientoApropiado = dd.TratamientoApropiado,
                wsENVIN_Web_Infecciones_ID = dd.wsENVIN_Web_Infecciones_ID,
                wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID = dd.wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID ?? 0,
                wsENVIN_Web_Maestro_Infecciones_Localizacion_ID = dd.wsENVIN_Web_Maestro_Infecciones_Localizacion_ID ?? 0,
                wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID = dd.wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID ?? 0,
                wsENVIN_Web_Maestro_Infecciones_Muestra_ID = dd.wsENVIN_Web_Maestro_Infecciones_Muestra_ID ?? 0,
                wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID = dd.wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID ?? 0,
                wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID = dd.wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID ?? 0,
                wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID = dd.wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID ?? 0,
                wsENVIN_Web_Pacientes_ID = dd.wsENVIN_Web_Pacientes_ID,
              
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ViewModel> F_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_Result> result = data.F_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                DiagnosticoClinico = dd.DiagnosticoClinico,
                wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID = dd.wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_Localizacion_ViewModel> F_wsENVIN_Web_Maestro_Infecciones_Localizacion()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_Localizacion_Result> result = data.F_wsENVIN_Web_Maestro_Infecciones_Localizacion(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Infecciones_Localizacion_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                Localizacion = dd.Localizacion,
                TipoMuestra = dd.TipoMuestra ?? 0,
                wsENVIN_Web_Maestro_Infecciones_Localizacion_ID = dd.wsENVIN_Web_Maestro_Infecciones_Localizacion_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_Muestra_ViewModel> F_wsENVIN_Web_Maestro_Infecciones_Muestra()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_Muestra_Result> result = data.F_wsENVIN_Web_Maestro_Infecciones_Muestra(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Infecciones_Muestra_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                TipoMuestra = dd.TipoMuestra,
                Muestra = dd.Muestra,
                wsENVIN_Web_Maestro_Infecciones_Muestra_ID = dd.wsENVIN_Web_Maestro_Infecciones_Muestra_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ViewModel> F_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_Result> result = data.F_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                OrigenInfeccion = dd.OrigenInfeccion,
                wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID = dd.wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ViewModel> F_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_Result> result = data.F_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                RespuestaInflamatoria = dd.RespuestaInflamatoria,
                wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID = dd.wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_TipoCateter_ViewModel> F_wsENVIN_Web_Maestro_Infecciones_TipoCateter()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_TipoCateter_Result> result = data.F_wsENVIN_Web_Maestro_Infecciones_TipoCateter(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Infecciones_TipoCateter_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                TipoCateter = dd.TipoCateter,
                wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID = dd.wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ViewModel> F_wsENVIN_Web_Maestro_Infecciones_LugarInsercion()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Infecciones_LugarInsercion_Result> result = data.F_wsENVIN_Web_Maestro_Infecciones_LugarInsercion(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                LugarInsercion = dd.LugarInsercion,
                wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID = dd.wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Microorganismos_ViewModel> F_wsENVIN_Web_Maestro_Microorganismos()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Microorganismos_Result> result = data.F_wsENVIN_Web_Maestro_Microorganismos(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Microorganismos_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                GrupoMicroorganismo = dd.GrupoMicroorganismo,
                Microorganismo = dd.Microorganismo,
                wsENVIN_Web_Maestro_Microorganismos_ID = dd.wsENVIN_Web_Maestro_Microorganismos_ID,
                wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID = dd.wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID ?? 0
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo_ViewModel> F_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo(int wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo_Result> result = data.F_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo(wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_Antibiogramas_IDGrupo_ViewModel
            {
                Antibiograma = dd.Antibiograma,
                GrupoMicroorganismo = dd.GrupoMicroorganismo,
                Obligatoriedad = dd.Obligatoriedad,
                wsENVIN_Web_Maestro_Antibiogramas_ID = dd.wsENVIN_Web_Maestro_Antibiogramas_ID ?? 0,
                wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID = dd.wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Microorganismos_UFC_10_ViewModel> F_wsENVIN_Web_Maestro_Microorganismos_UFC_10()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Microorganismos_UFC_10_Result> result = data.F_wsENVIN_Web_Maestro_Microorganismos_UFC_10(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Microorganismos_UFC_10_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                UFC_10 = dd.UFC_10,
                wsENVIN_Web_Maestro_Microorganismos_UFC_10_ID = dd.wsENVIN_Web_Maestro_Microorganismos_UFC_10_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion_ViewModel> F_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion(int wsENVIN_Web_Infecciones_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion_Result> result = data.F_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion(wsENVIN_Web_Infecciones_ID);
            return result.Select(dd => new F_wsENVIN_Web_Infecciones_Microorganismos_IDInfeccion_ViewModel
            {
                FechaValidacion = dd.FechaValidacion,
                GrupoMicroorganismo = dd.GrupoMicroorganismo,
                IdUsuarioUltimaModificacion = dd.IdUsuarioUltimaModificacion,
                IdUsuarioValidacion = dd.IdUsuarioValidacion,
                Microorganismo = dd.Microorganismo,
                wsENVIN_Web_Infecciones_ID = dd.wsENVIN_Web_Infecciones_ID,
                wsENVIN_Web_Infecciones_Microorganismos_ID = dd.wsENVIN_Web_Infecciones_Microorganismos_ID,
                wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID = dd.wsENVIN_Web_Maestro_Microorganismos_GrupoMicroorganismos_ID ?? 0,
                wsENVIN_Web_Maestro_Microorganismos_ID = dd.wsENVIN_Web_Maestro_Microorganismos_ID,
                wsENVIN_Web_Pacientes_ID = dd.wsENVIN_Web_Pacientes_ID,
                wsENVIN_Web_Maestro_Microorganismos_UFC_10_ID = dd.wsENVIN_Web_Maestro_Microorganismos_UFC_10_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ViewModel> F_wsENVIN_Web_Maestro_Antibiogramas_Resistencia()
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_Antibiogramas_Resistencia_Result> result = data.F_wsENVIN_Web_Maestro_Antibiogramas_Resistencia(0);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ViewModel
            {
                IdExterno = dd.IdExterno ?? 0,
                Resistencia = dd.Resistencia,
                wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ID = dd.wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ID
            });
        }

        public static IEnumerable<F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo_ViewModel> F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo(int wsENVIN_Web_Infecciones_Microorganismos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo_Result> result = data.F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo(wsENVIN_Web_Infecciones_Microorganismos_ID);
            return result.Select(dd => new F_wsENVIN_Web_Infecciones_Antibiogramas_IDMicroorganismo_ViewModel
            {
                wsENVIN_Web_Pacientes_ID = dd.wsENVIN_Web_Pacientes_ID,
                wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ID = dd.wsENVIN_Web_Maestro_Antibiogramas_Resistencia_ID,
                wsENVIN_Web_Maestro_Antibiogramas_ID = dd.wsENVIN_Web_Maestro_Antibiogramas_ID,
                wsENVIN_Web_Infecciones_Microorganismos_ID = dd.wsENVIN_Web_Infecciones_Microorganismos_ID,
                wsENVIN_Web_Infecciones_Antibiogramas_ID = dd.wsENVIN_Web_Infecciones_Antibiogramas_ID,
                Resistencia = dd.Resistencia,
                Antibiograma = dd.Antibiograma,
                FechaValidacion = dd.FechaValidacion ?? DateTime.MinValue,
                IdUsuarioUltimaModificacion = dd.IdUsuarioUltimaModificacion,
                IdUsuarioValidacion = dd.IdUsuarioValidacion,
                Microorganismo = dd.Microorganismo
            });
        }
        #endregion

        #region tabla de factores mensuales
        public static IEnumerable<F_wsENVIN_Web_FactoresMensuales_ViewModel> F_wsENVIN_Web_FactoresMensuales(int LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FactoresMensuales_Result> result = data.F_wsENVIN_Web_FactoresMensuales(LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
            return result.Select(dd => new F_wsENVIN_Web_FactoresMensuales_ViewModel
            {
                wsENVIN_Web_FactoresMensuales_ID=dd.wsENVIN_Web_FactoresMensuales_ID,
                wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID=dd.wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID,
                Mes=dd.Mes,
                wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID=dd.wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
                Anno=dd.Anno,
                LogicalUnitID =dd.LogicalUnitID,
                NumPacientesIngresados=dd.NumPacientesIngresados,
                NumPacientesNuevos=dd.NumPacientesNuevos ,
                NumPacientesConATB=dd.NumPacientesConATB,
                NumPacientesConBMR=dd.NumPacientesConBMR,
                NumPacientesAislados=dd.NumPacientesAislados,
                NumPacientesA_PreventivoContacto=dd.NumPacientesA_PreventivoContacto,
                NumPacientesA_Contacto=dd.NumPacientesA_Contacto,
                NumPacientesA_Protector=dd.NumPacientesA_Protector,
                NumPacientesA_Gotas=dd.NumPacientesA_Gotas,
                NumPacientesA_GotasContacto=dd.NumPacientesA_GotasContacto,
                NumPacientesA_Aereo=dd.NumPacientesA_Aereo,
                NumPacientesA_AereoContacto=dd.NumPacientesA_AereoContacto,
                NumPacientesConViaAerea=dd.NumPacientesConViaAerea,
                NumPacientesConSondaUrinaria=dd.NumPacientesConSondaUrinaria,
                NumPacientesConArteria=dd.NumPacientesConArteria,
                NumPacientesConViaCentral=dd.NumPacientesConViaCentral,
                FechaComputo=dd.FechaComputo,
                IdUsuarioUltimaModificacion = dd.IdUsuarioUltimaModificacion,
                FechaValidacion =dd.FechaValidacion,
                IdUsuarioValidacion=dd.IdUsuarioValidacion

            }).OrderBy(x => x.FechaComputo); 
        }//fin F_wsENVIN_Web_FactoresMensuales


        public static IEnumerable<F_wsENVIN_Web_FactoresMensuales_SumatorioMensual_ViewModel> F_wsENVIN_Web_FactoresMensuales_SumatorioMensual(int LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_FactoresMensuales_SumatorioMensual_Result> result = data.F_wsENVIN_Web_FactoresMensuales_SumatorioMensual(LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
            return result.Select(dd => new F_wsENVIN_Web_FactoresMensuales_SumatorioMensual_ViewModel
            {
                wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID = dd.wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID,
                wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID = dd.wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID,
                Mes = dd.Mes,
                wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID = dd.wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
                Anno = dd.Anno,
                LogicalUnitID = dd.LogicalUnitID,
                NumPacientesIngresados = dd.NumPacientesIngresados,
                NumPacientesNuevos = dd.NumPacientesNuevos,
                NumPacientesConATB = dd.NumPacientesConATB,
                NumPacientesConBMR = dd.NumPacientesConBMR,
                NumPacientesAislados = dd.NumPacientesAislados,
                NumPacientesA_PreventivoContacto = dd.NumPacientesA_PreventivoContacto,
                NumPacientesA_Contacto = dd.NumPacientesA_Contacto,
                NumPacientesA_Protector = dd.NumPacientesA_Protector,
                NumPacientesA_Gotas = dd.NumPacientesA_Gotas,
                NumPacientesA_GotasContacto = dd.NumPacientesA_GotasContacto,
                NumPacientesA_Aereo = dd.NumPacientesA_Aereo,
                NumPacientesA_AereoContacto = dd.NumPacientesA_AereoContacto,
                NumPacientesConViaAerea = dd.NumPacientesConViaAerea,
                NumPacientesConSondaUrinaria = dd.NumPacientesConSondaUrinaria,
                NumPacientesConArteria = dd.NumPacientesConArteria,
                NumPacientesConViaCentral = dd.NumPacientesConViaCentral,
                FechaComputo = dd.FechaComputo,
                IdUsuarioUltimaModificacion=dd.IdUsuarioUltimaModificacion,
                FechaValidacion = dd.FechaValidacion,
                IdUsuarioValidacion = dd.IdUsuarioValidacion

            });
        }//fin F_wsENVIN_Web_FactoresMensuales_SumatorioMensual


        public static IEnumerable<F_wsENVIN_Web_Maestro_FactoresMensuales_Meses_ViewModel> F_wsENVIN_Web_Maestro_FactoresMensuales_Meses(int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FactoresMensuales_Meses_Result> result = data.F_wsENVIN_Web_Maestro_FactoresMensuales_Meses(wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FactoresMensuales_Meses_ViewModel
            {
                wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID = dd.wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID,
                Mes = dd.Mes

            });
        }//fin F_wsENVIN_Web_Maestro_FactoresMensuales_Meses

        public static IEnumerable<F_wsENVIN_Web_Maestro_FactoresMensuales_Annos_ViewModel> F_wsENVIN_Web_Maestro_FactoresMensuales_Annos(int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            IEnumerable<F_wsENVIN_Web_Maestro_FactoresMensuales_Annos_Result> result = data.F_wsENVIN_Web_Maestro_FactoresMensuales_Annos(wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID);
            return result.Select(dd => new F_wsENVIN_Web_Maestro_FactoresMensuales_Annos_ViewModel
            {
                wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID = dd.wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
                Anno = dd.Anno

            });
        }//fin F_wsENVIN_Web_Maestro_FactoresMensuales_Annos

        #endregion
        #endregion

        #region SP
        public static int SP_wsENVIN_ActualizarEstadoPaciente(int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_ActualizarEstadoPaciente( wsENVIN_Web_Pacientes_ID).FirstOrDefault() ?? 0;
        }



        public static int SP_wsENVIN_Web_Pacientes(int PatientID, int id_wsLEIRE_Datos_Ingresos, String NHC, short LogicalUnitID, short wsENVIN_Web_Maestro_ORStatus_ID,
               short wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID, Boolean EsCargaManual, DateTime FechaCargaManual,
               String FirstName, String LastName, DateTime FechaNacimiento, short wsENVIN_Web_Maestro_Pacientes_Sexo_ID, short NumHabitacion,
               DateTime AddmissionDate, DateTime FechaIngresoHospital, DateTime DischargeDate, DateTime FechaAltaHospital,
               Boolean Exitus, DateTime FechaExitus, String IdUsuarioUltimaModificacion, int wsENVIN_Web_Pacientes_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Pacientes(PatientID, id_wsLEIRE_Datos_Ingresos, NHC, LogicalUnitID, wsENVIN_Web_Maestro_ORStatus_ID,
                 wsENVIN_Web_Maestro_Pacientes_EstadosInforme_ID, EsCargaManual, FechaCargaManual,
                 FirstName, LastName, FechaNacimiento, wsENVIN_Web_Maestro_Pacientes_Sexo_ID, NumHabitacion,
                 AddmissionDate, FechaIngresoHospital, DischargeDate, FechaAltaHospital,
                 Exitus, FechaExitus, IdUsuarioUltimaModificacion, wsENVIN_Web_Pacientes_ID).FirstOrDefault() ?? 0;
        }


        #region SP FICHA DE INGRESO
        public static int SP_wsENVIN_Web_FichaIngreso_General(int wsENVIN_Web_Pacientes_ID, short Apache_II, short Glasgow, Boolean PacienteTraumatizado, Boolean PacienteCoronario,
                Boolean ATB48hPrevias, Boolean PacienteCovid19, short wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                short wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID, short wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID, short wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                String IdUsuarioUltimaModificacion, DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_General_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FichaIngreso_General(wsENVIN_Web_Pacientes_ID, Apache_II, Glasgow, PacienteTraumatizado, PacienteCoronario,
                                            ATB48hPrevias, PacienteCovid19, wsENVIN_Web_Maestro_FichaIngreso_DiagnosticosENVIN_ID,
                                            wsENVIN_Web_Maestro_FichaIngreso_OrigenPaciente_ID, wsENVIN_Web_Maestro_FichaIngreso_TipoDeAdmision_ID, wsENVIN_Web_Maestro_FichaIngreso_CirugiaPrevia_ID,
                                            IdUsuarioUltimaModificacion, FechaValidacion, IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_General_ID).FirstOrDefault() ?? 0;

        }

        public static int SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(int wsENVIN_Web_Pacientes_ID, Boolean Diabetes, Boolean InsuficienciaRenal, Boolean Inmunodepresion, Boolean Neoplasia, Boolean Cirrosis,
                Boolean EPOC, Boolean DesnutricionHipoalbuminemia, Boolean TransplanteOrganoSolido, String IdUsuarioUltimaModificacion, DateTime FechaValidacion,
                String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias(wsENVIN_Web_Pacientes_ID, Diabetes, InsuficienciaRenal,
                                                                                             Inmunodepresion, Neoplasia, Cirrosis,
                                                                                             EPOC, DesnutricionHipoalbuminemia, TransplanteOrganoSolido, IdUsuarioUltimaModificacion, FechaValidacion,
                                                                                             IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_ComorbilidadesPrevias_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(int wsENVIN_Web_Pacientes_ID, Boolean CirugiaUrgente, Boolean DerivacionVentricularExterna, Boolean DepuracionExtrarrenal,
               Boolean NutricionParenteral, Boolean Neutropenia, Boolean ECMO, Boolean CateterVenosoCentral, Boolean ViaAereaArtificial,
               Boolean SondaUrinaria, Boolean Impella, Boolean AsistenciaVentricular, Boolean BCIA, String IdUsuarioUltimaModificacion,
               DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FichaIngreso_FactoresDeRiesgo(wsENVIN_Web_Pacientes_ID, CirugiaUrgente, DerivacionVentricularExterna, DepuracionExtrarrenal,
                                            NutricionParenteral, Neutropenia, ECMO, CateterVenosoCentral, ViaAereaArtificial,
                                            SondaUrinaria, Impella, AsistenciaVentricular, BCIA, IdUsuarioUltimaModificacion,
                                            FechaValidacion, IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_FactoresDeRiesgo_ID).FirstOrDefault() ?? 0;
        }


        public static int SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(int wsENVIN_Web_Pacientes_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
               int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID, int wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
               DateTime Fecha, String IdUsuarioUltimaModificacion,
               DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion(wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_ID, wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Cuando_ID,
                wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Tipo_ID, wsENVIN_Web_Maestro_FichaIngreso_ColonizacionInfeccion_Localizacion_ID,
                Fecha, IdUsuarioUltimaModificacion,
                FechaValidacion, IdUsuarioValidacion, wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del(int wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_Del(wsENVIN_Web_FichaIngreso_ColonizacionInfeccion_ID).FirstOrDefault() ?? 0;
        }

        #endregion


        #region sp antibioticos

        public static int SP_wsENVIN_Web_Antibioticos(int wsENVIN_Web_Pacientes_ID, int LogicalUnitID, int PlannedOrderID, String Antibiotico, DateTime FechaInicio,
                 DateTime FechaFin, int wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID, int wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_Motivo_ID, int wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID, int wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                 int wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID, String IdUsuarioUltimaModificacion,
                 DateTime FechaValidacion, String IdUsuarioValidacion, bool Estado, int wsENVIN_Web_Antibioticos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Antibioticos(wsENVIN_Web_Pacientes_ID, LogicalUnitID, PlannedOrderID, Antibiotico, FechaInicio,
                  FechaFin, wsENVIN_Web_Maestro_Antibioticos_Indicacion_ID, wsENVIN_Web_Maestro_Infecciones_Localizacion_ID,
                  wsENVIN_Web_Maestro_Antibioticos_Motivo_ID, wsENVIN_Web_Maestro_Antibioticos_Confirmacion_ID, wsENVIN_Web_Maestro_Antibioticos_CambioDeAntibiotico_ID,
                  wsENVIN_Web_Maestro_Antibioticos_MotivoDelCambio_ID, IdUsuarioUltimaModificacion,
                  FechaValidacion, IdUsuarioValidacion, Estado, wsENVIN_Web_Antibioticos_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_Antibioticos_Del(int wsENVIN_Web_Antibioticos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Antibioticos_Del(wsENVIN_Web_Antibioticos_ID).FirstOrDefault() ?? 0;
        }

        #endregion


        #region sp factores de riesgo individual

        public static int SP_wsENVIN_Web_FactoresRiesgoIndividual(int wsENVIN_Web_Pacientes_ID, DateTime Periodo1ViaAereaArtificial_Inicio, DateTime Periodo1ViaAereaArtificial_Fin, DateTime Periodo2ViaAereaArtificial_Inicio, DateTime Periodo2ViaAereaArtificial_Fin,
                DateTime Periodo3ViaAereaArtificial_Inicio, DateTime Periodo3ViaAereaArtificial_Fin, DateTime FechaInicioTraqueostomia,
                DateTime Periodo1VMNI_Inicio, DateTime Periodo1VMNI_Fin, DateTime Periodo2VMNI_Inicio, DateTime Periodo2VMNI_Fin, DateTime Periodo3VMNI_Inicio,
                DateTime Periodo3VMNI_Fin, DateTime Fecha1Reintubacion, DateTime Fecha2Reintubacion, DateTime PeriodoSondaUrinaria_Inicio, DateTime PeriodoSondaUrinaria_Fin,
                DateTime Periodo1CVC_Inicio, DateTime Periodo1CVC_Fin, DateTime Periodo2CVC_Inicio, DateTime Periodo2CVC_Fin,
                DateTime Periodo3CVC_Inicio, DateTime Periodo3CVC_Fin, DateTime PeriodoCateterArterial_Inicio, DateTime PeriodoCateterArterial_Fin,
                DateTime PeriodoNutricionParenteral_Inicio, DateTime PeriodoNutricionParenteral_Fin, DateTime PeriodoNutricionEnteral_Inicio, DateTime PeriodoNutricionEnteral_Fin,
                DateTime ECMO_Inicio, DateTime ECMO_Fin, String IdUsuarioUltimaModificacion, DateTime FechaValidacion, String IdUsuarioValidacion, int wsENVIN_Web_FactoresRiesgoIndividual_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FactoresRiesgoIndividual(wsENVIN_Web_Pacientes_ID, Periodo1ViaAereaArtificial_Inicio, Periodo1ViaAereaArtificial_Fin, Periodo2ViaAereaArtificial_Inicio, Periodo2ViaAereaArtificial_Fin,
                 Periodo3ViaAereaArtificial_Inicio, Periodo3ViaAereaArtificial_Fin, FechaInicioTraqueostomia,
                 Periodo1VMNI_Inicio, Periodo1VMNI_Fin, Periodo2VMNI_Inicio, Periodo2VMNI_Fin, Periodo3VMNI_Inicio,
                 Periodo3VMNI_Fin, Fecha1Reintubacion, Fecha2Reintubacion, PeriodoSondaUrinaria_Inicio, PeriodoSondaUrinaria_Fin,
                 Periodo1CVC_Inicio, Periodo1CVC_Fin, Periodo2CVC_Inicio, Periodo2CVC_Fin,
                 Periodo3CVC_Inicio, Periodo3CVC_Fin, PeriodoCateterArterial_Inicio, PeriodoCateterArterial_Fin,
                 PeriodoNutricionParenteral_Inicio, PeriodoNutricionParenteral_Fin, PeriodoNutricionEnteral_Inicio, PeriodoNutricionEnteral_Fin,
                 ECMO_Inicio, ECMO_Fin, IdUsuarioUltimaModificacion, FechaValidacion, IdUsuarioValidacion, wsENVIN_Web_FactoresRiesgoIndividual_ID).FirstOrDefault() ?? 0;
        }


        public static int SP_wsENVIN_Web_FactoresRiesgoIndividual_Del(int wsENVIN_Web_FactoresRiesgoIndividual_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FactoresRiesgoIndividual_Del(wsENVIN_Web_FactoresRiesgoIndividual_ID).FirstOrDefault() ?? 0;
        }

        #endregion

        #region Infecciones
        public static int SP_wsENVIN_Web_Infecciones(int wsENVIN_Web_Pacientes_ID, short wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID, short? wsENVIN_Web_Maestro_Infecciones_Localizacion_ID, bool? bacteriemia, short wsENVIN_Web_Maestro_Infecciones_Muestra_ID,
               short wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID, bool exposicion48hprevias, bool? tratamientoAntibiotico,
               bool? tratamientoApropiado, bool? ajusteTratamiento, short? wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID, short wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID, short wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID,
               String idUsuarioUltimaModificacion, DateTime fechaValidacion, String idUsuarioValidacion, DateTime fechaInfeccion, int? wsENVIN_Web_Infecciones_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Infecciones(wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_Infecciones_OrigenInfeccion_ID, wsENVIN_Web_Maestro_Infecciones_Localizacion_ID, bacteriemia, wsENVIN_Web_Maestro_Infecciones_Muestra_ID,
                 wsENVIN_Web_Maestro_Infecciones_DiagnosticoClinico_ID, exposicion48hprevias, tratamientoAntibiotico,
                 tratamientoApropiado, ajusteTratamiento, wsENVIN_Web_Maestro_Infecciones_RespuestaInflamatoria_ID, wsENVIN_Web_Maestro_Infecciones_TipoCateter_ID, wsENVIN_Web_Maestro_Infecciones_LugarInsercion_ID,
                 idUsuarioUltimaModificacion, fechaValidacion, idUsuarioValidacion, fechaInfeccion, wsENVIN_Web_Infecciones_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_Infecciones_Del(int? wsENVIN_Web_Infecciones_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Infecciones_Del(wsENVIN_Web_Infecciones_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_Infecciones_Microorganismos(int wsENVIN_Web_Infecciones_ID, short wsENVIN_Web_Maestro_Microorganismos_ID, short? wsENVIN_Web_Pacientes_ID, int? wsENVIN_Web_Maestro_Microorganismos_UFC_ID, String idUsuarioUltimaModificacion,
               DateTime fechaValidacion, String idUsuarioValidacion, int? wsENVIN_Web_Infecciones_Microorganismos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Infecciones_Microorganismos(wsENVIN_Web_Infecciones_ID, wsENVIN_Web_Maestro_Microorganismos_ID, wsENVIN_Web_Pacientes_ID, wsENVIN_Web_Maestro_Microorganismos_UFC_ID,
                 idUsuarioUltimaModificacion, fechaValidacion, idUsuarioValidacion, wsENVIN_Web_Infecciones_Microorganismos_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_Infecciones_Microorganismos_Del(int wsENVIN_Web_Infecciones_Microorganismos_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Infecciones_Microorganismos_Del(wsENVIN_Web_Infecciones_Microorganismos_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_Infecciones_Antibiogramas(int wsENVIN_Web_Infecciones_Microorganismos_ID, short wsENVIN_Web_Maestro_Antibiogramas_ID, short? wsENVIN_Web_Pacientes_ID, short wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID,
               String idUsuarioUltimaModificacion, DateTime fechaValidacion, String idUsuarioValidacion, int? wsENVIN_Web_Infecciones_Antibiogramas_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Infecciones_Antibiogramas(wsENVIN_Web_Infecciones_Microorganismos_ID, wsENVIN_Web_Maestro_Antibiogramas_ID, wsENVIN_Web_Pacientes_ID, wsENVN_Web_Maestro_Antibiogramas_Resistencia_ID,
                 idUsuarioUltimaModificacion, fechaValidacion, idUsuarioValidacion, wsENVIN_Web_Infecciones_Antibiogramas_ID).FirstOrDefault() ?? 0;
        }

        public static int SP_wsENVIN_Web_Infecciones_Antibiogramas_Del(int? wsENVIN_Web_Infecciones_Antibiogramas_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_Infecciones_Antibiogramas_Del(wsENVIN_Web_Infecciones_Antibiogramas_ID).FirstOrDefault() ?? 0;
        }
        #endregion


        #region tabla factores mensuales

        public static int SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual(short LogicalUnitID, int wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, int wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
               short NumPacientesIngresados, short NumPacientesNuevos,
                short NumPacientesConATB,
                short NumPacientesConBMR,
                short NumPacientesAislados,
                short NumPacientesA_PreventivoContacto,
                short NumPacientesA_Contacto,
                short NumPacientesA_Protector,
                short NumPacientesA_Gotas,
                short NumPacientesA_GotasContacto,
                short NumPacientesA_Aereo,
                short NumPacientesA_AereoContacto,
                short NumPacientesConViaAerea,
                short NumPacientesConSondaUrinaria,
                short NumPacientesConArteria,
                short NumPacientesConViaCentral,
                DateTime FechaComputo,
                String IdUsuarioUltimaModificacion,
                DateTime FechaValidacion,
               String IdUsuarioValidacion,
                int wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID)
        {
            SICCA_ICEntities data = new SICCA_ICEntities();
            return data.SP_wsENVIN_Web_FactoresMensuales_SumatorioMensual(LogicalUnitID, wsENVIN_Web_Maestro_FactoresMensuales_Meses_ID, wsENVIN_Web_Maestro_FactoresMensuales_Annos_ID,
                NumPacientesIngresados, NumPacientesNuevos,
                 NumPacientesConATB,
                 NumPacientesConBMR,
                 NumPacientesAislados,
                 NumPacientesA_PreventivoContacto,
                 NumPacientesA_Contacto,
                 NumPacientesA_Protector,
                 NumPacientesA_Gotas,
                 NumPacientesA_GotasContacto,
                 NumPacientesA_Aereo,
                 NumPacientesA_AereoContacto,
                 NumPacientesConViaAerea,
                 NumPacientesConSondaUrinaria,
                 NumPacientesConArteria,
                 NumPacientesConViaCentral,
                 FechaComputo,
                 IdUsuarioUltimaModificacion,
                 FechaValidacion,
                IdUsuarioValidacion,
                 wsENVIN_Web_FactoresMensuales_SumatorioMensual_ID).FirstOrDefault() ?? 0;
        }

        #endregion

        #endregion


    }
}
