﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarLeads.aspx.cs" Inherits="Tangerine.GUI.M3.AgregarLeads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestión de leads
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Leads
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i> Home</a></li>
    <li><a href="#">Gestión de Leads</a></li>
    <li class="active">Agregar Leads</li>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
    


</div>
<form role="form" name="agregar_lead" id="agregar_lead" method="post"   runat="server">

 <div class="container">
	<div class="row" style="margin-top: 5%">
		<div class="col-md-6">
			<div id="id_otro" runat="server" class="form-group">
				<div class="icon-addon addon-lg">
					
					<input runat="server" type="text" placeholder="Nombre" class="form-control" id="nombre" name ="nombre">                    
					<input style="margin-top:5%" runat="server" type="text" placeholder="RIF" class="form-control" id="rif" name ="rif" >                   
					<input style="margin-top:5%" runat="server" type="text" placeholder="Email" class="form-control" id="email" name ="email" >                  
					<input style="margin-top:5%" runat="server" type="text" placeholder="Presupuesto" class="form-control" id="presupuesto" name ="presupuesto" >
                   
         		
                    <div class="box-body col-sm-12 col-md-12 col-lg-12 ">
    
                    </div>




  




                    
    

                   <!--  <th style="text-align:center;"><a id="btn-cancelar" type="submit" style="margin-top:5%; margin-right:5%; height:35px" class="btn btn-default pull-right" href="Listar.aspx"="#">Regresar></a></th> 
                    -->
                    <asp:Button id="btnaceptar" style="margin-top:5%" class="btn btn-primary" OnClick="btnaceptar_Click" type="submit" runat="server" Text = "Agregar"   ></asp:Button>
				</div>	
			
            </div>
		</div>
        
	</div>
</div>
</form>
</asp:Content>