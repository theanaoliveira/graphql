const { usuarios, perfis } = require("../data/db")

module.exports = {
    ola() {
        return 'Hello World'
    },
    horaAtual()
    {
        return new Date
    },
    usuarioLogado(){
        return {
            id: 1,
            nome: 'Ana',
            email: 'anaoliveira@email.com',
            idade: 26,
            salario_real: 1000.99,
            vip: true
        }
    },
    produtoEmEstoque(){
        return {
            nome: 'Kindle',
            preco: 349.90,
            desconto: 0.5
        }
    },
    numerosMegaSena() {
        const crescente = (a, b) => a - b
        return Array(6).fill(0)
            .map(m=> parseInt(Math.random() * 60 + 1))
            .sort(crescente)
    },
    usuarios() {
        return usuarios
    },
    usuario(_, args) {
        const sels = usuarios.filter(u=> u.id === args.id)
        return sels ? sels[0] : null
    },
    perfis() {
        return perfis
    },
    perfil(_, { id }){
        const sels = perfis.filter(p=> p.id === id)
        return sels ? sels[0] : null
    }
}