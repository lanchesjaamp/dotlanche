import http from 'k6/http';
import { check, sleep } from 'k6';
import { randomIntBetween } from 'https://jslib.k6.io/k6-utils/1.2.0/index.js';
import { randomString } from 'https://jslib.k6.io/k6-utils/1.2.0/index.js';


// Configurações do teste de carga
export let options = {
    stages: [
        { duration: '30s', target: 100 }, // Aumenta para 10 usuários em 30 segundos
        { duration: '2m', target: 1000 }, // Mantém 10 usuários por 1 minuto
        { duration: '10s', target: 0 }, // Diminui para 0 usuários em 10 segundos
    ],
};

// Função para gerar um produto aleatório
function generatePayload() {
    return {
        name: randomString(10),
        categoriaId: randomIntBetween(1, 4),
        description: randomString(20),
        price: randomIntBetween(10, 50)
    }
}

export default function () {
    let url = 'http://localhost:30000/Produto'; // URL do endpoint

    // Criação dinâmica do payload JSON
    let payload = JSON.stringify(generatePayload());

    // Configuração dos headers
    let params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    // Envio da solicitação POST
    let res = http.post(url, payload, params);

    // Verificação da resposta
    check(res, {
        'is status 201': (r) => r.status === 201, // Verifica se o status da resposta é 201
    });

    sleep(1); // Pausa de 1 segundo entre as solicitações
}
