document.querySelectorAll('.IdServico').forEach(check => {
    check.addEventListener('change', () => {
        const checkboxes = document.querySelectorAll('input[name="idServico"]:checked');
        let selectedIds = [];
        checkboxes.forEach((checkbox) => {
            selectedIds.push(checkbox.value); // Use checkbox.value para coletar os valores
        });
        console.log('IDs selecionados dentro do event listener: ', selectedIds);
        $('#idServicosSelecionados').val(selectedIds.join(','));
    });
});

$('#submitBtn').click(function () {
    const selectedIds = $('#idServicosSelecionados').val().split(',').map(Number);
    console.log('IDs selecionados no submit: ', selectedIds);

    $.ajax({
        url: '/Home/SeuMetodo', // Substitua com a URL do seu método no controlador
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(selectedIds),
        success: function (response) {
            console.log('IDs recebidos: ', response.receivedIds);
            alert('Dados enviados com sucesso!');
        },
        error: function (xhr, status, error) {
            alert('Ocorreu um erro: ' + error);
        }
    });
});
