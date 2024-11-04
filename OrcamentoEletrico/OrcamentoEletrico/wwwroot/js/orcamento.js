document.getElementById('orcamentoForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const pessoaId = document.getElementById('pessoaId').value;
    const metrosQuadrados = document.getElementById('metrosQuadrados').value;
    const numeroDePavimentos = document.getElementById('numeroDePavimentos').value;
    const classificacao = document.getElementById('classificacao').value;

    const imovelData = {
        pessoaId: parseInt(pessoaId),
        metrosQuadrados: parseInt(metrosQuadrados),
        numeroDePavimentos: parseInt(numeroDePavimentos),
        classificacao: parseInt(classificacao)
    };
    console.log(imovelData);
    try {
        const response = await fetch('https://localhost:7285/api/Orcamento/gerar-orcamento', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(imovelData)
        });

        if (!response.ok) {
            throw new Error('Erro ao gerar orçamento: ' + response.statusText);
        }

        const data = await response.json();
        document.getElementById('responseMessage').innerText = `Orçamento gerado com sucesso! Valor: R$ ${data.valorOrcamento.toFixed(2)}`;
    } catch (error) {
        document.getElementById('responseMessage').innerText = error.message;
    }
});
