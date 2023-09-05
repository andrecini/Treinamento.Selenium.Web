$(document).ready(function () {
    const selectEstado = document.getElementById('estado');

    const estadosBrasil = [
        "Acre", "Alagoas", "Amapá", "Amazonas", "Bahia", "Ceará", "Distrito Federal",
        "Espírito Santo", "Goiás", "Maranhão", "Mato Grosso", "Mato Grosso do Sul",
        "Minas Gerais", "Pará", "Paraíba", "Paraná", "Pernambuco", "Piauí", "Rio de Janeiro",
        "Rio Grande do Norte", "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina", "São Paulo", "Sergipe", "Tocantins"
    ];

    estadosBrasil.forEach(estado => {
        const option = document.createElement('option');
        option.value = estado;
        option.text = estado;
        selectEstado.appendChild(option);
    });

    var estadoOculto = $('#estado-hidden').val();
    $('#estado').val(estadoOculto);
});