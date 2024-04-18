var datatable;

$(document).ready(function () {
    cargarTablaPanes();
    var id = document.getElementById("idUsuario");
    if (id.value > 0) {
        $('#modalCrearUsuarios').modal('show');
    }
});

function limpiarModaUser() {
    document.getElementById("idUsuario").value = 0;
    document.getElementById("nombreUser").value = "";
    document.getElementById("correoUser").value = "";
    document.getElementById("passwordUser").value = "";
}

function cargarTablaPanes() {
    datatable = $('#TablaUser').DataTable({
        "ajax": {
            "url": "/Usuarios/ListarUser"
        },
        "columns": [
            {
                "data": "usuario",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "correo",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "rol",
                "render": function (data, type, row) {
                    return `<span style="font-size: 15px;">${data}</span>`;
                }
            },
            {
                "data": "idUsuario",
                "render": function (data) {
                    return `<div>
                                <a href="/Usuarios/Guardar/${data}" class="btn btn-success text-white" style="cursor: pointer;"><i class="bi bi-pencil-square"></i></a>
                                <a onclick=EliminarUser("/Usuarios/Eliminar/${data}") class="btn btn-danger text-white" style="cursor: pointer;"><i class="bi bi-trash-fill"></i></a>
                            </div>`;
                }
            },
        ],
        "language": {
            "url": '//cdn.datatables.net/plug-ins/2.0.1/i18n/es-ES.json',
        },

    });
}

function EliminarUser(url) {
    swal({
        title: "Estas seguro de eliminar este Pan",
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