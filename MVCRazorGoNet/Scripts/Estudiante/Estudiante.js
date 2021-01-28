function GetEstudiante() {

    var Estudiante = {
        Estudiante: {
            NumMatricula: $("#txtNumMatricula").val(),
            Nombre: $("#txtNombre").val(),
            ApellidoPaterno: $("#txtApellidoPaterno").val(),
            ApellidoMaterno: $("#txtApellidoMaterno").val(),
            Carrera: $("#txtCarrera").val(),
            Edad: parseInt($("#txtEdad").val())
        }
    };

    $.ajax({
        type: "POST",
        url: "https://localhost:44320/api/Estudiantes",
        data: JSON.stringify(Estudiante),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (datos) {

            if (datos.Success) {

                if (datos.ListEstudiante.length > 0) {

                    $("#divListEstudiantes").empty();

                    $("#divListEstudiantes").append('<ul>');

                    datos.ListEstudiante.forEach(function (entry) {
                        $("#divListEstudiantes").append('<li class="EstiloBAMSA">' + entry.NumMatricula + '-' + entry.Nombre + '-' + entry.ApellidoPaterno + '-' +
                            entry.ApellidoMaterno + '-' + entry.Carrera + '-' + entry.Edad + '</li>');
                    });

                    $("#divListEstudiantes").append('</ul>');
                    
                }                

            }
            else
            {
                alert("ErrorCode:" + datos.ErrorCode + "\n ErrorMessage:" + datos.ErrorMsg);
            }
        },
        error: function (error) {
            alert("Error:" + error.responseText);
            
        }
    });
}