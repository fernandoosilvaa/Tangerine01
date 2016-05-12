﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/Tangerine.Master" AutoEventWireup="true" CodeBehind="AgregarPropuesta.aspx.cs" Inherits="Tangerine.GUI.M6.AgregarPropuesta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/M6/js/modulo6.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    Gestion de Propuesta
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Subtitulo" runat="server">
    Agregar Propuesta
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Breadcrumps" runat="server">
    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
    <li><a href="#">Gestión de Propuesta</a></li>
    <li class="active">Agregar Propuesta</li>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .main-footer {
            float: left;
            position: relative;
            width: 100%;
        }

        .content-wrapper {
            float: left;
        }

        .input-group, .form-control {
            width: 95%;
        }

        .date {
            width: 48.5% !important;
            float: left;
        }

        #div-precondiciones {
            margin-bottom: 20px;
        }

            #div-precondiciones .form-group {
                padding: 15px 0;
            }

        @media only screen and (max-width: 550px) {
            .date {
                width: 100% !important;
                float: left;
            }
        }
    </style>



    <div class="col-md-6">

        <div class="box box-primary" style="height: inherit !important">

            <!-- form start -->
            <form role="form">

                <div class="box-body">

                    <div class="form-group">

                        <label>Cliente (compañía contratante)</label>
                        <select class="form-control" id="cliente" runat="server">
                            <option>Trascend</option>
                            <option>Tebca</option>
                            <option>Trascend</option>
                            <option>Pepsi</option>
                        </select>



                    </div>

                    <div class="form-group">
                        <label>Objeto del proyecto</label>
                        <textarea class="form-control" rows="3" placeholder="Escribir ..." id="descripcion" runat="server"> </textarea>
                    </div>

                    <div class="form-group">
                        <label>Alcance del Proyecto</label>
                        <div class="form-group">
                            <div id="div-precondiciones" class="col-sm-10 col-md-10 col-lg-10">

                                <div class="form-group">
                                    <div class="col-sm-11 col-md-11 col-lg-11">
                                        <input runat="server" type="text" placeholder="Requerimiento" class="form-control" id="precondicion_0" name="precondicion_0" />
                                    </div>
                                    <div class="col-sm-1 col-md-1 col-lg-1">
                                        <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarPrecondicion()"></button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="form-group">
                        <label for="input_horas" style="width: 100%; float: left; display: block;">Duracion del Proyecto</label>

                        <div class="input-group input-group-sm">
                            <div class="input-group-btn">
                                <div class="dropdown">
                                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-expanded="false" >
                                        Duracion
                    <span class="fa fa-caret-down"></span>
                                    </button>
                                    <ul class="dropdown-menu" id="duracion" name="duracion" runat="server">
                                        <li><a href="#">Meses</a></li>
                                        <li><a href="#">Dias</a></li>
                                        <li><a href="#">Horas</a></li>
                                    </ul>
                                </div>
                            </div>
                            <!-- /btn-group -->
                            <input type="text" class="form-control">
                        </div>


                    </div>


                    <div class="form-group date">
                        <label>Fecha estimada Incio:</label>

                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input class="form-control pull-right" id="datepicker1" type="text" runat="server">
                        </div>
                        <!-- /.input group -->
                    </div>

                    <div class="form-group date">
                        <label>Fecha estimada Final:</label>

                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <input class="form-control pull-right" id="datepicker2" type="text" runat="server">
                        </div>
                        <!-- /.input group -->
                    </div>
                    <!-- /.form group -->


                    <!-- /.box-body -->



                    <div class="form-group">
                        <label for="input_costo">Costo del Proyecto</label>
                        <div class="input-group input-group-sm">
                            <div class="input-group-btn">
                                <div class="dropdown">
                                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-expanded="false" id="Moneda" runat="server">
                                        Moneda
                                        <span class="fa fa-caret-down"></span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">Bolivar</a></li>
                                        <li><a href="#">Dolar</a></li>
                                        <li><a href="#">Euro</a></li>
                                        <li><a href="#">Bitcoin</a></li>
                                    </ul>

                                </div>
                            </div>
                            <!-- /btn-group -->
                            <input type="text" class="form-control" id="costo" runat="server">
                            <%--<span class="input-group-addon">.00</span>--%>
                        </div>



                    </div>



                    <div class="form-group">
                        <label>Forma de Pago</label>
                        <select class="form-control" id="fpago" runat="server">
                            <option></option>
                            <option data-icon="fa-heart">Deposito</option>
                            <option>Transferencia</option>
                            <option>Otro</option>
                        </select>
                    </div>



                    <div class="form-group">
                        <label>Estatus</label>
                        <select class="form-control" id="estatus" runat="server">
                            <option></option>
                            <option>Aprobado</option>
                            <option>Pendiente</option>
                            <option>En ejecucion</option>
                        </select>
                    </div>






                </div>

            </form>

            <div class="box-footer">
                <asp:Button ID="btnagregar" class="btn btn-primary"
                    OnClick="btnagregar_Click" type="submit" runat="server"
                    Text="Agregar"></asp:Button>
            </div>

        </div>
    </div>





</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="contenidoCentral" runat="server">
</asp:Content>
