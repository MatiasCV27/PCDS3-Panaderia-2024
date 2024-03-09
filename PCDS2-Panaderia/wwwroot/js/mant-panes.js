var datatable;

$(document).ready(function () {
    cargarTablaPanes();
    var id = document.getElementById("idPanes");
    if (id.value > 0) {
        $('#modalCrearPanes').modal('show');
    }
});

function limpiarModalPanes() {
    document.getElementById("idPanes").value = 0;
    document.getElementById("nombrePan").value = "";
    document.getElementById("marcaPan").value = "";
    document.getElementById("costPan").value = 0;
    document.getElementById("stockPan").value = 0;
    document.getElementById("fcPan").value = "";
    document.getElementById("fvPan").value = "";
    document.getElementById("descPan").value = "";
    document.getElementById("imgPan").value = "";
}

function cargarTablaPanes() {
    datatable = $('#TablaPanes').DataTable({
        "ajax": {
            "url": "/Panes/Listar"
        },
        "columns": [
            {
                "data": "marcaP",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "nombreP",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "descripcionP",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "costoP",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "fechaCreacionP",
                "render": function (data, type, row) {
                    if (data) {
                        var date = new Date(data);
                        var formattedDate = date.toLocaleDateString("es-ES");
                        return `<span style="font-size: 15px;">${formattedDate}</span>`;
                    } else {
                        return "";
                    }
                }
            },
            {
                "data": "fechaVencimiP",
                "render": function (data, type, row) {
                    if (data) {
                        var date = new Date(data);
                        var formattedDate = date.toLocaleDateString("es-ES");
                        return `<span style="font-size: 15px;">${formattedDate}</span>`;
                    } else {
                        return "";
                    }
                }
            },
            {
                "data": "stockP",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "imagenP",
                "render": function (data, type, row) {
                    return '<img src="' + data + '" style="width: 50px; border: 2px solid black" />';
                }
            },
            {
                "data": "idPanes",
                "render": function (data) {
                    return `<div>
                                <a href="/Panes/Guardar/${data}" class="btn btn-success text-white" style="cursor: pointer;"><i class="bi bi-pencil-square"></i></a>
                                <a onclick=EliminarPan("/Panes/Eliminar/${data}") class="btn btn-danger text-white" style="cursor: pointer;"><i class="bi bi-trash-fill"></i></a>
                            </div>`;
                }
            },
        ],
        "language": {
            "url": '//cdn.datatables.net/plug-ins/2.0.1/i18n/es-ES.json',
        },
        
    });
}

function EliminarPan(url) {
    swal({
        title: "Estas seguro de eliminar este Pan",
        text: "El registro no se podra recuperar",
        icon: "warning",
        buttons: true
    }).then((borrar) => {
        if(borrar) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        alert(data.message);
                        datatable.ajax.reload();
                    } else {
                        alert(data.message);
                    }
                }
            })
        }
    });
}