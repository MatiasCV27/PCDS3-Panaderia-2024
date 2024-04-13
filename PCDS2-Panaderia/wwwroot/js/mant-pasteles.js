var datatable;

$(document).ready(function () {
    cargarTablaTortas();
    var id = document.getElementById("idTortas");
    if (id.value > 0) {
        $('#modalCrearTortas').modal('show');
    }
});

function limpiarModalPanes() {
    document.getElementById("idTortas").value = 0;
    document.getElementById("nombreTorta").value = "";
    document.getElementById("marcaTorta").value = "";
    document.getElementById("costoTorta").value = 0;
    document.getElementById("stockTorta").value = 0;
    document.getElementById("descTorta").value = "";
    document.getElementById("imgTorta").value = "";
}

function cargarTablaTortas() {
    datatable = $('#TablaTortas').DataTable({
        "ajax": {
            "url": "/Tortas/Listar"
        },
        "columns": [
            {
                "data": "marcaB",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "nombreT",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "descripcionT",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "costoT",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "stockT",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "imagenT",
                "render": function (data, type, row) {
                    return '<img src="' + data + '" style="width: 50px; border: 2px solid black" />';
                }
            },
            {
                "data": "idTortas",
                "render": function (data) {
                    return `<div>
                                <a href="/Tortas/Guardar/${data}" class="btn btn-success text-white" style="cursor: pointer;"><i class="bi bi-pencil-square"></i></a>
                                <a onclick=EliminarPan("/Tortas/Eliminar/${data}") class="btn btn-danger text-white" style="cursor: pointer;"><i class="bi bi-trash-fill"></i></a>
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
        title: "Estas seguro de eliminar este pastel",
        text: "El registro no se podra recuperar",
        icon: "warning",
        buttons: true
    }).then((borrar) => {
        if (borrar) {
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