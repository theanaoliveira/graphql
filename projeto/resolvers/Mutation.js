const { usuarios, proximoId } = require("../data/db")

function findUser(filtro) {
    if (!filtro) return -1

    const {id, email} = filtro

    return usuarios.findIndex(u=> u.id === id) == -1 ? 
        usuarios.findIndex(u=> u.email == email) : 
        usuarios.findIndex(u=> u.id === id);
}


module.exports = {   
    //{ nome, email, idade }
    novoUsuario(_, { dados })
    {
        const emailExistente = usuarios.some(u=> u.email === dados.email);

        if (emailExistente)
            throw new Error('E-mail já cadastrado')

        const novo = {
            id : proximoId,
            ...dados,
            perfil_id: 1,
            status: 'ATIVO'
        }

        usuarios.push(novo);
        return novo;
    },

    excluirUsuario(_, { filtro })
    {
        const i = findUser(filtro)

        if (i < 0) return null

        const excluidos = usuarios.splice(i, 1);

        return excluidos ? excluidos[0] : null;
    },

    alterarUsuario(_, { dados, filtro })
    {
        const i = findUser(filtro)

        if (i < 0) return null

        const usuario = {
            ...usuarios[i],
            ...dados
        }

        usuarios.splice(i, 1, usuario)

        return usuario;
    }
}