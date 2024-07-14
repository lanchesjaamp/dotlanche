import http from 'k6/http';
import { check, sleep } from 'k6';
import { uuidv4 } from 'https://jslib.k6.io/k6-utils/1.4.0/index.js';

// Configurações do teste de carga
export let options = {
    stages: [
        { duration: '30s', target: 100 }, // Aumenta para 10 usuários em 30 segundos
        { duration: '2m', target: 1000 }, // Mantém 10 usuários por 1 minuto
        { duration: '10s', target: 0 }, // Diminui para 0 usuários em 10 segundos
    ],
};

// Função para gerar um CPF aleatório
function generateCPF() {
    let num = () => Math.floor(Math.random() * 9) + 1;
    let cpf = '';
    for (let i = 0; i < 11; i++) {
        cpf += num().toString();
    }
    return cpf;
}

export default function () {
    let url = 'http://127.0.0.1:49727/Cliente'; // URL do endpoint

    // Criação dinâmica do payload JSON usando __VU e __ITER para garantir unicidade
    let payload = JSON.stringify({
        Name: `User${__VU}${__ITER}`, // Nome único baseado no usuário virtual e iteração
        Cpf: generateCPF(), // CPF aleatório gerado pela função generateCPF
        Email: `user${__VU}${__ITER}@example.com`, // Email único baseado no usuário virtual e iteração
    });

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
        'is status 200': (r) => r.status === 200, // Verifica se o status da resposta é 200
    });

    sleep(1); // Pausa de 1 segundo entre as solicitações
}
