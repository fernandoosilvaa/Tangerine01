﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="Agregar proyecto.aspx.cs" Inherits="Tangerine.GUI.M7.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de Proyectos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Proyectos</a></li>
    <li class="active">Crear Proyecto</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="row">
            <!-- left column -->
            <div class="col-md-6">
              <!-- general form elements -->
              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Nuevo Proyecto</h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                <form role="form" runat = "server" id="generar_proyecto" method="post" runat="server">
                  <div class="box-body" runat="server">
                     <div class="form-group" runat="server">
                      <label for="labelPropuesta_M7">Propuetsa Aprobada *</label>
                     <select class="form-control" name="Propuesta Aprobada" > 
                     <option>sistema A</option>
                     <option> sistema B</option> </select>
                    </div>
                      
                      <div class="form-group" runat="server">
                      <label for="InputNombreProyecto">Nombre de proyecto *</label>
                      <input runat="server" type="text" class="form-control" id="textInputNombreProyecto" placeholder="Nombre Proyecto" name="textInputNombreProyecto"  >
                    </div>

                    <div class="form-group" runat="server">
                      <label for="InputCodigo">Codigo del proyecto * </label>
                      <input runat="server" type="text" class="form-control" id="textInputCodigo" name="textInputCodigo" placeholder="123456789" >
                    </div>

                      <div class="form-group" runat="server">
                      <label for="InputFechaInicio">Fecha de inicio *</label>
                      <input runat="server" type="text" class="form-control" id="textInputFechaInicio" name="textInputFechaInicio" placeholder="dd/mm/aaaa">
                    </div>

                        <div class="form-group" runat="server">
                      <label for="InputFechaEstimada">Fecha Estimada de culminación *</label>
                      <input runat="server" type="date" class="form-control" id="textInputFechaEstimada" name="textInputFechaEstimada" placeholder="dd/mm/aaaa">
                    </div>

                      
                        <div class="form-group" runat="server">
                      <label for="InputCosto">Costo estimado *</label>
                      <input runat="server" type="text" class="form-control" id="textInputCosto" name="textInputCosto" placeholder="0 Bs"  >
                    </div>
                       <div class="form-group" runat="server">
                      <label for="InputPorcentaje">Porcentaje de realizacion *</label>
                      <input runat="server" type="text" class="form-control" id="textInputPorcentaje" name="textInputPorcentaje" placeholder="0 %"  > 
                    </div>
                    
                      <hr />

                  </div><!-- /.box-body -->

                  <div class="box-footer">
                      
                    <asp:Button id="btnGenerar" style="margin-top:5%" class="btn btn-primary" OnClick="btnGenerar_Click" type="submit" runat="server" Text = "Generar" ></asp:Button>
               
                       </div><div>  <label>* Todos los campos son obligatorios</label></div>
                
              </div><!-- /.box -->
         
            </div><!--/.col (left) -->
            <!-- right column -->
            <div class="col-md-6">

                <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">Personal del Proyecto </h3>
                </div><!-- /.box-header -->
                <!-- form start -->
                
                  <div class="box-body">

                 <div class="form-group">
                      <label for="labelGerete_M7">Gerente de proyecto *</label>
                     <select class="form-control" name="gerenteProyecto" > 
                     <option>Pedro Perez</option>
                     <option> Ana Rodriguez</option> </select>
                    </div>

                      <hr />

                       <div class="form-group">
                      <label for="labelPersonal_M7">Personal Responsable *</label>
                     <select class="form-control" name="personalProyecto" > 
                     <option>jose</option>
                     <option> pedro</option> 
                         <option> maria</option>
                         <option> ana</option>
                     </select>
                    <asp:Button id="btnAgregar" style="margin-top:5%" class="btn btn-primary"  type="submit" runat="server" Text = "Agregar"   ></asp:Button>
                  
                    </div>
                      <hr />

                       <div class="form-group">
                      <label for="labelencargado_M7">Encargado de la empresa contratante *</label>
                     <select class="form-control" name="EncargadoProyecto" > 
                     <option>Pedro Perez</option>
                     <option> Ana Rodriguez</option> </select>
                    </div>
         </form>
                    </div>
          </div>
          </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">   
</asp:Content>
