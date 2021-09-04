<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Home.Master" CodeBehind="Index.aspx.vb" Inherits="TestDataTableVB.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Plugins/DataTables/css/dataTables.bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <section class="content-header">
        <h1>Test Datatable Js (VB.NET)
                       
                        <small>Example 2.0</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Layout</a></li>
            <li class="active">Top Navigation</li>
        </ol>
    </section>



    <!-- Main content -->
    <section class="content">
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Asistencia</h3>
            </div>

            <div class="text-center">
            <button id="btnRefrescar" class="btn btn-default"><i class="fa fa-refresh"></i>Refrescar</button>

            </div>


            <div class="box-body">
                <table id="tbl_Asistencias" class="table table-bordered table-hover dataTable">
                    <thead>
                        <tr>
                            <th>MASPE_CARNE</th>
                            <th>Entrada</th>
                            <th>Salida</th>
                            <th>Canal</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
        </div>

    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="Plugins/DataTables/js/jquery.dataTables.min.js"></script>
    <script src="Plugins/DataTables/js/dataTables.bootstrap.min.js"></script>
    <script src="js/MyScript.js"></script>
</asp:Content>
