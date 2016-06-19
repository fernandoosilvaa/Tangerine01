﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;
using Tangerine_Contratos.M10;
using Tangerine_Presentador.M10;
using Tangerine_Contratos.M1;

namespace Tangerine.GUI.M1
{
    public partial class CrearEmpleado : System.Web.UI.Page, IContratoCrearEmpleado
    {
        private PresentadorCrearEmpleado presentador;
        string active = "Activo";
        Hashtable elementos = new Hashtable();

        public CrearEmpleado()
        {
            presentador= new PresentadorCrearEmpleado(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            #region LLENAR combo de genero
            if (!IsPostBack)
            {
                presentador.LlenarComboEmpleado();
                presentador.LlenarComboNivelEstudio();
                presentador.ObtenerPaises();
                presentador.ObtenerCargos();
            }
            #endregion
        }       

        protected void SelectedJob_Change(object sender, EventArgs e)
        {
            try
            {
                JobSummary.InnerText = "";
                JobSummary.InnerText += elementos[SelectedListJob.SelectedItem.Text].ToString();
            }
            catch (Exception ex)
            {
                JobSummary.InnerText = "";
            }

        }

        protected void SelectedCountry_Change(object sender, EventArgs e)
        {

            presentador.SelectedPaisChanged();      
            

        }

        protected void SelectedState_Change(object sender, EventArgs e)
        {

        }

        protected void SelectedStudy_Change(object sender, EventArgs e)
        {

        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            presentador.AgregarEmpleado();

            LogicaM10 logicEmployee = new LogicaM10();
            
            /*Empleado empleado = new Empleado(0, FirstName.Value, SecondNamee.Value, FirstLastName.Value,
                                                SecondLastName.Value, SelectedListGender.SelectedItem.Text.ToString(),
                                                int.Parse(Cedula.Value),
                                                DateTime.ParseExact(DateEmployee.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                                active, LevelListStudy.SelectedItem.Text, EmailPerson.Value, jobForEmployee(),
                                                newAddress());
            
             */
            Empleado empleado = new Empleado();
            logicEmployee.AddNewEmpleado(empleado);
            Response.Redirect("../M1/EmpleadosAdmin.aspx");
        }

        private List<LugarDireccion> newAddress()
        {
            List<LugarDireccion> direccion = new List<LugarDireccion>();

            direccion.Add(new LugarDireccion(SelectedListCountry.SelectedItem.Text.ToString(), "Pais"));
            direccion.Add(new LugarDireccion(SelectedListState.SelectedItem.Text.ToString(), "Estado"));
            direccion.Add(new LugarDireccion(CityAddress.Value, "Ciudad"));
            direccion.Add(new LugarDireccion(AddresEspecific.Value, "Direccion"));

            return direccion;
        }

        private Cargo jobForEmployee()
        {
            return new Cargo(SelectedListJob.SelectedItem.Text.ToString(), JobSummary.Value,
                                    DateTime.ParseExact(DateJob.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    JobMode.Value, Double.Parse(SalaryJob.Value));

        }

        private void FillSelectedListGender()
        {
            SelectedListGender.Items.Insert(0, "Seleccione Genero");
            SelectedListGender.Items.Insert(1, "Masculino");
            SelectedListGender.Items.Insert(2, "Femenino");
            SelectedListGender.DataBind();
        }

        private void FillLevelListStudy()
        {
            LevelListStudy.Items.Insert(0, "Seleccione Nivel de Estudio");
            LevelListStudy.Items.Insert(1, "Universitario en proceso");
            LevelListStudy.Items.Insert(2, "Universitario completado");
            LevelListStudy.Items.Insert(3, "Bachiller");
            LevelListStudy.DataBind();
        }

        private void FillSelectedListJob()
        {
            LogicaM10 componentes = new LogicaM10();
            ;
            int x = 1;
            SelectedListJob.Items.Insert(0, "Seleccione un cargo");
            foreach (Cargo cargos in componentes.ItemsForListJobs())
            {
                elementos.Add(cargos.Nombre, cargos.Descripcion);
                SelectedListJob.Items.Insert(x, cargos.Nombre);
                x++;
            }

        }

        private void FillSelectedListCountry()
        {
            LogicaM10 componentes = new LogicaM10();
            int x = 1;
            SelectedListCountry.Items.Insert(0, "Seleccione un pais");
            foreach (LugarDireccion paises in componentes.ItemsForListCountry())
            {
                SelectedListCountry.Items.Insert(x, paises.LugNombre);
                x++;
            }
        }

        private void FillSelectedListState()
        {
            SelectedListState.Items.Insert(0, "Seleccione un Estado");
            SelectedListGender.DataBind();
        }
 
#region Contrato

        DropDownList IContratoCrearEmpleado.IcomboGenero
        {
            get{return SelectedListGender;}
            set{SelectedListGender = value;}
        }

        DropDownList IContratoCrearEmpleado.IcomboNivelEstudio
        {
            get{return LevelListStudy;}
            set { LevelListStudy = value;}
        }

        DropDownList IContratoCrearEmpleado.IcomboPais
        {
            get{return SelectedListCountry;}
            set{SelectedListCountry = value;}
        }

        DropDownList IContratoCrearEmpleado.IcomboCargo
        {
            get{return SelectedListJob;}
            set{SelectedListJob = value;}
        }
        DropDownList IContratoCrearEmpleado.IcomboEstado   
        {
            get {return SelectedListState;}
            set {SelectedListState = value;}
        }

        String IContratoCrearEmpleado.ItextCedula
        {
            get {return Cedula.Value;}
            set {Cedula.Value = value;} 
        }

        String IContratoCrearEmpleado.ItextFirstName
        {
            get { return FirstName.Value; }
            set { FirstName.Value = value; } 
        }
        String IContratoCrearEmpleado.ItextSecondNamee
        {
            get { return SecondNamee.Value; }
            set { SecondNamee.Value = value; }
        }
        String IContratoCrearEmpleado.ItextFirstLastName
        {
            get { return FirstLastName.Value; }
            set { FirstLastName.Value = value; }
        }
        String IContratoCrearEmpleado.ItextSecondLastName
        {
            get { return SecondLastName.Value; }
            set { SecondLastName.Value = value; }
        }
        String IContratoCrearEmpleado.ItextDateEmployee
        {
            get { return DateEmployee.Value; }
            set { DateEmployee.Value = value; }
        }
        String IContratoCrearEmpleado.ItextDateJob
        {
            get { return DateJob.Value; }
            set { DateJob.Value = value; }
        }
        String IContratoCrearEmpleado.ItextJobMode
        {
            get { return JobMode.Value; }
            set { JobMode.Value = value; }
        }
        String IContratoCrearEmpleado.ItextSalaryJob
        {
            get { return SalaryJob.Value; }
            set { SalaryJob.Value = value; }
        }
        String IContratoCrearEmpleado.ItextCityAddress
        {
            get { return CityAddress.Value; }
            set { CityAddress.Value = value; }
        }
        String IContratoCrearEmpleado.ItextAddresEspecific
        {
            get { return AddresEspecific.Value; }
            set { AddresEspecific.Value = value; }
        }
        String IContratoCrearEmpleado.ItextEmailPerson
        {
            get { return EmailPerson.Value; }
            set { EmailPerson.Value = value; }
        }
        String IContratoCrearEmpleado.ItextPhonePerson
        {
            get { return PhonePerson.Value; }
            set { PhonePerson.Value = value; }
        }
               

#endregion
    }
}