﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class ModificarPropuesta : System.Web.UI.Page
    {
        public string requerimiento
        {
            get
            {
                return this.tablaR.Text;
            }

            set
            {
                this.tablaR.Text = value;
            }
        }

        public Propuesta Prueba;
        LogicaM4 logicacompania = new LogicaM4();
        public List <Requerimiento> req;
        public bool modi;



        protected void Page_Load(object sender, EventArgs e)
        {
            string prueba = Request.QueryString.Get("id");
                       
            btn_Modifica(prueba);
            btn_ModificaReq(prueba);

            


            if (!IsPostBack)
            {
                llenarComboTipoCosto();
                llenarComboDuracion();
                llenarComboEstatus();

                
 
                foreach (Requerimiento elRequerimiento in req)
                {
                    requerimiento += RecursosGUI_M6.AbrirTR;

                    requerimiento += RecursosGUI_M6.AbrirTD + elRequerimiento.CodigoRequerimiento.ToString() + RecursosGUI_M6.CerrarTD;
                    requerimiento += RecursosGUI_M6.AbrirTD + elRequerimiento.Descripcion.ToString() + RecursosGUI_M6.CerrarTD;


                    requerimiento += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.btn_Modificar + RecursosGUI_M6.CerrarTD;
                    requerimiento += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.btn_eliminar + RecursosGUI_M6.CerrarTD;
                                     
                    requerimiento += RecursosGUI_M6.CerrarTR;

                }
                
            }

            textoDuracion.Value = Prueba.CantDuracion;
            comboDuracion.SelectedValue = Prueba.TipoDuracion;
            comboTipoCosto.SelectedValue = Prueba.Moneda;
            textoCosto.Value = Prueba.Costo.ToString();
            comboEstatus.SelectedValue = Prueba.Estatus;

        }






        /// <summary>
        /// Metodo de la acción modificar de la vista de listar propuesta. 
        /// </summary>
        /// <param name="idPropuesta"></param>


        public void btn_Modifica(String idPropuesta)
        {

            LogicaPropuesta logicaPropuesta = new LogicaPropuesta();

            Prueba = logicaPropuesta.TraerPropuesta(idPropuesta);

            Compania lacompania = new Compania();

            lacompania = logicacompania.SearchCompany(Int32.Parse(Prueba.IdCompañia));
            cliente_id.Value = lacompania.NombreCompania;
           
        }






        /// <summary>
        /// Metodo para cargar el o los requerimientos asociados a la propuesta seleccionada en la pantalla de listar. 
        /// </summary>
        /// <param name="idPropuesta"></param>

        public void btn_ModificaReq(String idPropuesta)
        {

            LogicaRequerimiento logreq = new LogicaRequerimiento();

            req = logreq.TraerRequerimientoPropuesta(idPropuesta);

        }



        /// <summary>
        /// Metodo para modificar el requerimiento desde el modal
        /// </summary>
        /// <param name="idRequerimiento"></param>
        /// <param name="descripcion"></param>

        public void btn_ModReq(String idRequerimiento, String descripcion)
        {
            Requerimiento vistaReq = new Requerimiento();
            LogicaRequerimiento logica = new LogicaRequerimiento();
            vistaReq.Descripcion = descripcion;
            vistaReq.CodigoRequerimiento = idRequerimiento;
            modi = logica.ModRequerimiento(vistaReq);

        }





        /// <summary>
        /// Metodo para modificar la propuesta completa en BD.
        /// </summary>


        //public void ModificarTotal()
        //{
        //    Propuesta propuestas = new Propuesta();

        //    propuestas.Descripcion = descripcion.Value;
        //    propuestas.TipoDuracion = comboDuracion.SelectedValue;
        //    propuestas.Acuerdopago = fpago.Value;
        //    propuestas.Estatus = comboEstatus.SelectedValue;
        //    propuestas.Moneda = comboTipoCosto.SelectedValue;
        //    propuestas.Feincio = DateTime.ParseExact(datepicker1.Value, "MM/dd/yyyy", null);
        //    propuestas.Fefinal = DateTime.ParseExact(datepicker2.Value, "MM/dd/yyyy", null);
        //    propuestas.Costo = int.Parse(textoCosto.Value);


        //    LogicaPropuesta propuesta = new LogicaPropuesta();
        //    propuesta.ModificarPropuesta(propuestas);
        //}


        public void llenarComboDuracion()
        {
            comboDuracion.Items.Add("Meses");
            comboDuracion.Items.Add("Dias");
            comboDuracion.Items.Add("Horas");
        }


        public void llenarComboTipoCosto()
        {
            comboTipoCosto.Items.Add("Bolivares");
            comboTipoCosto.Items.Add("Dolares");
            comboTipoCosto.Items.Add("Euros");
            comboTipoCosto.Items.Add("Bitcoins");
        }


        public void llenarComboEstatus()
        {
            comboEstatus.Items.Add("Pendiente");
            comboEstatus.Items.Add("Aprobado");
            comboEstatus.Items.Add("Cerrado");

        }



    }
}