const usuarios = [
    {
        id: 1,
        nome: 'João Silva',
        email: 'jsilva@gmail.com',
        idade: 29,
        perfil_id: 1,
        status: 'ATIVO'
    },
    {
        id: 2,
        nome: 'Rafael Junior',
        email: 'rafajunior@gmail.com',
        idade: 30,
        perfil_id: 1,
        status: 'BLOQUEADO'
    },
    {
        id: 3,
        nome: 'Daniela Smith',
        email: 'dsmith@gmail.com',
        idade: 24,
        perfil_id: 2,
        status: 'ATIVO'
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

module.exports = { usuarios, perfis }