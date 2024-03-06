var datatable;

// PANES

$(document).ready(function () {
    cargarTablaPanes();
    var id = document.getElementById("idPanes");
    if (id.value > 0) {
        $('#modalCrearPanes').modal('show');
    }
});

function limpiarModalPanes() {
    var idPanes = document.getElementById("idPanes");
    var nombrePan = document.getElementById("nombrePan");
    var marcaPan = document.getElementById("marcaPan");
    var costPan = document.getElementById("costPan");
    var stockPan = document.getElementById("stockPan");
    var fcPan = document.getElementById("fcPan");
    var fvPan = document.getElementById("fvPan");
    var descPan = document.getElementById("descPan");
    var imgPan = document.getElementById("imgPan");
    idPanes.value = 0; nombrePan.value = ""; marcaPan.value = "";
    costPan.value = 0, stockPan.value = 0; fcPan.value = "";
    fvPan.value = "", descPan.value = "", imgPan.value = "";
}

function cargarTablaPanes() {
    datatable = $('#TablaPanes').DataTable({
        "ajax": {
            "url": "/Panes/Listar"
        },
        "columns": [
            { "data": "marcaP" },
            { "data": "nombreP" },
            { "data": "descripcionP", "width": "30%" },
            { "data": "costoP" },
            {
                "data": "fechaCreacionP",
                "render": function (data, type, row) {
                    if (data) {
                        var date = new Date(data);
                        var formattedDate = date.toLocaleDateString("es-ES");
                        return formattedDate;
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
                        return formattedDate;
                    } else {
                        return "";
                    }
                }
            },
            { "data": "stockP" },
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

        ]
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