﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M3
{
    public partial class Promover : System.Web.UI.Page, IContratoConsultarClientePotencial
    {
        PresentadorConsultarClientePotencial presentadorMostrar;
        PresentadorPromoverClientePotencial presentadorPromover;
        int idClientePotencial;

        public Promover()
        {
            this.presentadorMostrar = new PresentadorConsultarClientePotencial(this);
            this.presentadorPromover = new PresentadorPromoverClientePotencial(this);
        }

        #region Contrato
        public Literal NombreEtiqueta
        {
            get
            {
                return this.Nombre;
            }

            set
            {
                this.Nombre = value;
            }
        }

        public Literal RIFEtiqueta
        {
            get
            {
                return this.Rif;
            }

            set
            {
                this.Rif = value;
            }
        }

        public Literal CorreoEtiqueta
        {
            get
            {
                return this.correo;
            }

            set
            {
                this.correo = value;
            }
        }

        public Literal EstatusEtiqueta
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        public Literal PresupuestoInicialEtiqueta
        {
            get
            {
                return this.presupuesto;
            }

            set
            {
                this.presupuesto = value;
            }
        }

        public Literal NumLlamadasEtiqueta
        {
            get
            {
                return this.llamadas;
            }

            set
            {
                this.llamadas = value;
            }
        }
        public Literal NumVisitasEtiqueta
        {
            get
            {
                return this.visitas;
            }

            set
            {
                this.visitas = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idClientePotencial = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idclp"], false));
                if (!IsPostBack)
                {
                    presentadorMostrar.Llenar(idClientePotencial);
                }
            }
            catch
            {
                Response.Redirect("Listar.aspx");
            }
        }

        protected void Promover_Click(object sender, EventArgs e)
        {
            presentadorPromover.Promover(idClientePotencial);
            Response.Redirect("Listar.aspx");
        }
    }
}