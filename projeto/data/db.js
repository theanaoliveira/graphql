let id = 1;

function proximoId()
{
    return id++;
}

const usuarios = [
    {
        id: proximoId(),
        nome: 'João Silva',
        email: 'jsilva@gmail.com',
        idade: 29,
        perfil_id: 1,
        status: 'ATIVO',
        salario: 1000
    },
    {
        id: proximoId(),
        nome: 'Rafael Junior',
        email: 'rafajunior@gmail.com',
        idade: 30,
        perfil_id: 1,
        status: 'BLOQUEADO',
        salario: 1000
    },
    {
        id: proximoId(),
        nome: 'Daniela Smith',
        email: 'dsmith@gmail.com',
        idade: 24,
        perfil_id: 2,
        status: 'ATIVO',
        salario: 1000
    },
]

const perfis = [
    {
        id: 1,
        nome: 'Comum'
    },
    {
        id: 2,
        nome: 'Administrador'
    }
]

module.exports = { usuarios, perfis, proximoId }