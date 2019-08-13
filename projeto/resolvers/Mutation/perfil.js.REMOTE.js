const { perfis, proximoId } = require("../../data/db")

function findProfile(filtro) {
    if (!filtro) return -1

    const {id, nome} = filtro

    return perfis.findIndex(u=> u.id === id) == -1 ? 
        perfis.findIndex(u=> u.nome == nome) : 
        perfis.findIndex(u=> u.id === id);
}

module.exports = {
    novoPerfil(_, { dados }) {
        const perfilExistente = perfis.some(u=> u.nome.toLowerCase() === dados.nome.toLowerCase());

        console.log(dados)

        if (perfilExistente)
            throw new Error('Perfil já cadastrado')

        const perfil = {
            id: proximoId,
            ...dados
        }

        perfis.push(perfil);
        return perfil;
    },

    alterarPerfil(_, { filtro, dados }) {
        const i = findProfile(filtro)

        if (i < 0) return null

        const perfil = {
            ...perfis[i],
            id: perfis[i].id,
            ...dados
        }

        perfis.splice(i, 1, perfil)
        return perfil
    },

    excluirPerfil(_, { filtro }) {
        const i = findProfile(filtro)

        console.log(i)

        if (i < 0) return null

        const perfil = perfis.splice(i, 1)
        
console.log(perfil)

        return perfil
    }
}