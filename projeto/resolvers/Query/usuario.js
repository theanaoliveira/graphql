const { usuarios, perfis } = require("../../data/db")

module.exports = {
    usuarioLogado() {
        return {
            id: 1,
            nome: 'Ana',
            email: 'anaoliveira@email.com',
            idade: 26,
            salario_real: 1000.99,
            vip: true
        }
    },

    usuarios() {
        return usuarios
    },

    usuario(_, args) {
        const sels = usuarios.filter(u=> u.id === args.id)
        return sels ? sels[0] : null
    },
}