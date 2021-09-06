
$(document).ready(function () {
    ListarAsistencia();
});




function ListarAsistencia() {
    $.ajax({
        type: "POST",
        url: "Index.aspx/ListarAsistencias",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            if (xhr.status === 401) {
                location.reload();
            }
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },

        success: function (data) {
            
            if (data.d.length >= 1) {
                RowListarProduccion(data.d);
                $("#modal-default").modal("show");
            } else {
                console.log("No Cargar Modal")
            }


        },

        complete: function (xhr, status) {

            $("#modal-default").modal("show");
        }
    });
}

function RowListarProduccion(obj) {
    $('#tbl_Asistencias').DataTable({
        "bDestroy": true,
        "searching": true,
        "ordering": true,
        "info": false,
        "oLanguage": {
            "oPaginate": {
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "sSearch": "Buscar :",
            "sLengthMenu": "Ver _MENU_ Registros",
            "sInfo": "Mostrando _START_ a _END_ de _TOTAL_ entradas",
            "sInfoFiltered": " - filtrado de _MAX_ entradas totales",
            "sEmptyTable": "No hay documento de Medida Preventiva para mostrar !!!",
            "sProcessing": "Procesando !!!"
        },
        data: obj,
        columns: [
            { data: 'MASPE_CARNE' },
            {
                data: null, render: function (data, type, row) {
                    if (data.Entrada != null) {
                        var FechaEntrada = new Date(parseInt(data.Entrada.replace("/Date(", "").replace(")/", "")));
                        return FechaEntrada.toLocaleTimeString();
                    } else {
                        return 'Sin Marcar';
                    }

                }
            },
            {
                data: null, render: function (data, type, row) {

                    if (data.Salida != null) {
                        var FechaSalida = new Date(parseInt(data.Salida.replace("/Date(", "").replace(")/", "")));
                        return FechaSalida.toLocaleTimeString();
                    } else {
                        return 'Sin Marcar';
                    }

                }
            },
            {
                data: null, render: function (data, type, row) {

                    if (data.Canal == 1) {
                        return '<i class="fa fa-android "  title="Marcó Entrada y Salida"></i>';
                    }
                    else {
                        return '<i class="fa fa-television "  title="No Marcó Entrada y Salida"></i>';
                    }

                }, "className": "text-center"
            },
            {
                data: null, render: function (data, type, row) {

                    if (data.Entrada != null && data.Salida != null) {
                        return '<i class="fa fa-check text-success" style="color:green" title="Marcó Entrada y Salida"></i>';
                    } else if (data.Entrada != null) {
                        return '<i class="fa fa-warning text-danger" style="color:orange" title="Falta Marcar Salida"></i>';
                    }
                    else {
                        return '<i class="fa fa-close text-danger" style="color:red" title="No Marcó Entrada y Salida"></i>';
                    }

                }, "className": "text-center", "bSortable": false
            }
        ]
    });
}


//Funcion Opcional para actualizacion automatica cada 30 segundo
setInterval(ListarAsistencia, 30000);


$(document).on('click', '#btnRefrescar', function (e) {
    e.preventDefault();
    ListarAsistencia();
});