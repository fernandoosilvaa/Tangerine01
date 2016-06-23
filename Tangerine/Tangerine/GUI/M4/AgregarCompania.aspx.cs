﻿using DominioTangerine;
using LogicaTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M4;
using Tangerine_Presentador.M4;

namespace Tangerine.GUI.M4
{
    public partial class AgregarCompania : System.Web.UI.Page , IContratoAgregarCompania
    {
        PresentadorAgregarCompania Presentador;
        string error;

        public AgregarCompania() {
            Presentador = new PresentadorAgregarCompania(this);
        }

        #region Contrato
        public string inputNombre1
        {
            get
            {
                return InputNombre1.Value;
            }
            set
            {
                InputNombre1.Value = value;
            }
        }
        public string inputAcronimo1
        {
            get
            {
                return InputAcronimo1.Value;
            }
            set
            {
                InputAcronimo1.Value = value;
            }
        }
        public string inputRIF1
        {
            get
            {
                return InputRIF1.Value;
            }
            set
            {
                InputRIF1.Value = value;
            }
        }
        public DropDownList inputDireccion1
        {
            get
            {
                return InputDireccion1;
            }
            set
            {
                InputDireccion1 = value;
            }
        }
        public string inputEmail1
        {
            get
            {
                return InputEmail1.Value;
            }
            set
            {
                InputEmail1.Value = value;
            }
        }
        public string inputTelefono1
        {
            get
            {
                return InputTelefono1.Value;
            }
            set
            {
                InputTelefono1.Value = value;
            }
        }
        public string Datepicker1
        {
            get
            {
                return datepicker1.Value;
            }
            set
            {
                datepicker1.Value = value;
            }
        }
        public string inputPresupuesto1
        {
            get
            {
                return InputPresupuesto1.Value;
            }
            set
            {
                InputPresupuesto1.Value = value;
            }
        }
        public string inputPlazoPago1
        {
            get
            {
                return InputPlazoPago1.Value;
            }
            set
            {
                InputPlazoPago1.Value = value;
            }
        }

       public DropDownList direccion 
        {
            get
            {
                return this.InputDireccion1;
            }
            set
            {
                //InputDireccion1 = value;
            } 
        }
       public string msjError
       {
           get 
           {
               return error;
           }
           set 
           {
               error = value;
           }
       }
        #endregion

        /// <summary>
        /// Método de carga de página en el cual carga los lugares tipo ciudad en un combobox.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presentador.CargarLugares();
            }
            
        }

        /// <summary>
        /// Método que concreta la agregación de una nueva compañía luego de ser presionado el botón agregar.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void btnagregar_Click(object sender, EventArgs e)
        {
            
            if(Presentador.AgregarCompania())
                Server.Transfer("ConsultarCompania.aspx", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('"+ msjError +"')", true); 

        }
    }
}