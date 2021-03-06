﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using System.Data;
using DominioTangerine.Entidades.M2;
using DominioTangerine;
using DatosTangerine.InterfazDAO.M2;
using ExcepcionesTangerine.M2;
using System.Data.SqlClient;

namespace DatosTangerine.DAO.M2
{
    public class DAORol : DAOGeneral, IDAORol
    {
        #region IDAO

        /// <summary>
        /// Método para agregar un rol
        /// </summary>
        /// <param name="theRol">Es el rol del usuario</param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Agregar( Entidad theRol )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para modificar un rol
        /// </summary>
        /// <param name="theRol">Es el rol del usuario</param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Modificar( Entidad theRol )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para consultar un rol por id
        /// </summary>
        /// <param name="theRol">Es el rol del usuario</param>
        /// <returns>Retorna la consulta</returns>
        public Entidad ConsultarXId( Entidad theRol )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para consultar todos los roles
        /// </summary>
        /// <returns>Retorna todos los roles</returns>
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDAORol

            /// <summary>
            /// Método para modificar el rol del usuario
            /// </summary>
            /// <param name="theUsuario">Recibe un objeto de tipo Entidad que tiene los valores del usuario</param>
            /// <returns>Retorna true cuando el rol del usuario se modifico exitosamente</returns>
            public bool ModificarRolUsuario( Entidad theUsuario )
            {
                List<Parametro> parametros = new List<Parametro>();
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario;
                Parametro elParametro;

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroUsuario , SqlDbType.VarChar , usuario.nombreUsuario , false );
                    parametros.Add(elParametro);

                    elParametro = new Parametro( ResourceUser.ParametroRolUsuario , SqlDbType.VarChar , usuario.rol.nombre , false );
                    parametros.Add(elParametro);

                    List<Resultado> results = EjecutarStoredProcedure( ResourceUser.ModificarRolUsuario , parametros );
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeFinInfoLogger ,
                                     System.Reflection.MethodBase.GetCurrentMethod().Name );

                return true;
            }

            /// <summary>
            /// Método que obtiene el rol y los menús que poseen opciones prohibidas para el usuario
            /// </summary>
            /// <param name="codigoRol">Recibe el codigo de un rol de un usuario</param>
            /// <returns>El rol del usuario</returns>
            public Entidad ObtenerRolUsuario( int codigoRol )
            {
                Entidad theRol = DominioTangerine.Fabrica.FabricaEntidades.crearRolVacio();
                DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )theRol;

                Entidad theMenu;
                Entidad theLista = DominioTangerine.Fabrica.FabricaEntidades.crearListaGenericaVaciaMenu();
                DominioTangerine.Entidades.M2.ListaGenericaM2<DominioTangerine.Entidades.M2.MenuM2> lista
                    = ( DominioTangerine.Entidades.M2.ListaGenericaM2<DominioTangerine.Entidades.M2.MenuM2> )theLista;

                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                bool esAdministrador = true;

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroRolCodigo , SqlDbType.Int , codigoRol.ToString() , false );
                    parametros.Add( elParametro );

                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.ObtenerRolUsuario , parametros );

                    bool rolAgregado = false;

                    //Por cada fila de la tabla voy a guardar los datos 
                    foreach ( DataRow row in dt.Rows )
                    {
                        string rolNombre = row[ ResourceUser.RolNombre ].ToString();
                        string menNombre = row[ ResourceUser.RolMenu ].ToString();

                        if ( rolAgregado == false )
                        {
                            rol.nombre = rolNombre;
                            rolAgregado = true;
                        }

                        Entidad theOpciones = ObtenerOpciones(menNombre, codigoRol);
                        ListaGenericaM2<DominioTangerine.Entidades.M2.OpcionM2> opciones
                            = ( ListaGenericaM2<DominioTangerine.Entidades.M2.OpcionM2> )theOpciones;

                        theMenu = DominioTangerine.Fabrica.FabricaEntidades.crearMenuCompleto( menNombre , opciones );
                        DominioTangerine.Entidades.M2.MenuM2 menu = ( DominioTangerine.Entidades.M2.MenuM2 )theMenu;

                        lista.agregarElemento( menu );

                        esAdministrador = false;
                    }

                    if ( esAdministrador )
                    {
                        rol.nombre = "Administrador";
                    }
                    rol.menu = lista;

                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex);
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex);
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex);
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex);
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                     ResourceUser.MensajeFinInfoLogger,
                                     System.Reflection.MethodBase.GetCurrentMethod().Name);

                return rol;
            }

            /// <summary>
            /// Método que devuelve las opciones de un menú prohibidas para un rol
            /// </summary>
            /// <param name="nombreMenu">Es el menu que proporcionara el sistema</param>
            /// <param name="codigoRol">El codigo de un rol de un ususario especifico</param>
            /// <returns>Una lista con las opciones</returns>
            public Entidad ObtenerOpciones( string nombreMenu , int codigoRol )
            {

                Entidad theLista = DominioTangerine.Fabrica.FabricaEntidades.crearListaGenericaVaciaOpcion();
                DominioTangerine.Entidades.M2.ListaGenericaM2<DominioTangerine.Entidades.M2.OpcionM2> lista
                    = ( DominioTangerine.Entidades.M2.ListaGenericaM2<DominioTangerine.Entidades.M2.OpcionM2> )theLista;
                Entidad theOpcion;
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroMenuNombre , SqlDbType.VarChar , nombreMenu , false );
                    parametros.Add( elParametro );

                    elParametro = new Parametro( ResourceUser.ParametroRolCodigo , SqlDbType.Int , codigoRol.ToString() , false );
                    parametros.Add( elParametro );

                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.ObtenerOpciones , parametros );

                    //Por cada fila de la tabla voy a guardar los datos 
                    foreach ( DataRow row in dt.Rows )
                    {
                        string nombreOpcion = row[ResourceUser.OpcNombre].ToString();
                        string url = row[ ResourceUser.OpcUrl ].ToString();

                        theOpcion = DominioTangerine.Fabrica.FabricaEntidades.crearOpcionCompleta( nombreOpcion , url );
                        DominioTangerine.Entidades.M2.OpcionM2 opcion = ( DominioTangerine.Entidades.M2.OpcionM2 )theOpcion;
                        lista.agregarElemento( opcion );
                    }
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeFinInfoLogger ,
                                     System.Reflection.MethodBase.GetCurrentMethod().Name );

                return lista;
            }

            /// <summary>
            /// Método que retorna el rol de un usuario con sus privilegios pasando como parámetro el nombre del rol
            /// </summary>
            /// <param name="nombreRol">Un rol en especifico, por ejemplo, gerente</param>
            /// <returns>El rol del usuario por nombre</returns>
            public Entidad ObtenerRolUsuarioPorNombre( string nombreRol )
            {

                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();
                Entidad rol = DominioTangerine.Fabrica.FabricaEntidades.crearRolVacio();

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroRolNombre , SqlDbType.VarChar , nombreRol.ToString() , false );
                    parametros.Add(elParametro);

                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.ObtenerRolUsuarioPorNombre , parametros );

                    foreach ( DataRow row in dt.Rows )
                    {
                        int idRol = int.Parse( row[ ResourceUser.RolId ].ToString() );
                        rol = ObtenerRolUsuario( idRol );
                    }
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( NullReferenceException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error de referencia a un valor null" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                return rol;
            }

        #endregion
    }
}
