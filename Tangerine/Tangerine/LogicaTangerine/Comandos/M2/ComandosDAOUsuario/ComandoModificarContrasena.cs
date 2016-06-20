﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M2.ComandosDAOUsuario
{
    public class ComandoModificarContrasena : Comando<Boolean>
    {
        public DominioTangerine.Entidad _theUsuario;

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="theUsuario"></param>
        public ComandoModificarContrasena( DominioTangerine.Entidad theUsuario )
        {
            _theUsuario = theUsuario;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método ModificarContraseniaUsuario
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override bool Ejecutar()
        {
            bool resultado = false;
            try
            {
                IDAOUsuarios ModificarContrasena = FabricaDAOSqlServer.crearDaoUsuario();
                resultado = ModificarContrasena.ModificarContraseniaUsuario( _theUsuario );
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " +
                                                                     "ModificarContraseniaUsuario()", ex);
            }

            return resultado;
        }
    }
}