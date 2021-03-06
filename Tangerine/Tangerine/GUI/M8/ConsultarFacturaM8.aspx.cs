﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;

namespace Tangerine.GUI.M8
{
    public partial class ConsultarFacturaM8 : System.Web.UI.Page, IContratoConsultarFactura
    {
        
        #region contrato
        
        public string facturasCreadas
        {
            get
            {
                return this.tabla.Text;
            }

            set
            {
                this.tabla.Text = value;
            }
        }
        public string alertaClase
        {
            set { alert.Attributes[ResourceGUIM8.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[ResourceGUIM8.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
#endregion

        #region presentador
        PresentadorConsultaFactura _presentador;

        public ConsultarFacturaM8()
        {
            _presentador = new PresentadorConsultaFactura(this);
        }
        #endregion        
        
        /// <summary>
        /// Carga la ventana Consultar Factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="estado">Para manejar la alerta a UI de acciones positivas en otras ventanas,
        /// no obligatorio</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Esto ocurre cuando se modifica una factura, se muestra mensaje a usuario
                string _estado = Request.QueryString[ResourceGUIM8.estado];
                if (_estado != null)
                    _presentador.Alerta(_estado);
            }
            catch
            {
                //No hago nada, no es obligatorio el parametro
            }
            if (!IsPostBack)
            {
                _presentador.cargarConsultarFacturas();
            }
        }
    }
}
