var datatable;

$(document).ready(function () {
    cargarTablaPanes();
    var id = document.getElementById("idBocaditos");
    if (id.value > 0) {
        $('#modalCrearBoca').modal('show');
    }
});

function limpiarModalPanes() {
    document.getElementById("idBocaditos").value = 0;
    document.getElementById("nombreBoca").value = "";
    document.getElementById("marcanBoca").value = "";
    document.getElementById("costBoca").value = 0;
    document.getElementById("stockBoca").value = 0;
    document.getElementById("descBoca").value = "";
    document.getElementById("imgBoca").value = "";
}

function cargarTablaPanes() {
    datatable = $('#TablaBoca').DataTable({
        "ajax": {
            "url": "/Bocaditos/Listar"
        },
        "columns": [
            {
                "data": "marcaB",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "nombreB",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "descripcionB",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "costoB",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "stockB",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "imagenB",
                "render": function (data, type, row) {
                    return '<img src="' + data + '" style="width: 50px; border: 2px solid black" />';
                }
            },
            {
                "data": "idBocaditos",
                "render": function (data) {
                    return `<div>
                                <a href="/Bocaditos/Guardar/${data}" class="btn btn-success text-white" style="cursor: pointer;"><i class="bi bi-pencil-square"></i></a>
                                <a onclick=EliminarBoca("/Bocaditos/Eliminar/${data}") class="btn btn-danger text-white" style="cursor: pointer;"><i class="bi bi-trash-fill"></i></a>
                            </div>`;
                }
            },
        ],
        "language": {
            "url": '//cdn.datatables.net/plug-ins/2.0.1/i18n/es-ES.json',
        },

    });
}

function EliminarBoca(url) {
    swal({
        title: "Estas seguro de eliminar este bocadito",
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