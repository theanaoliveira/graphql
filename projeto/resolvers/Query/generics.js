const { usuarios, perfis } = require("../../data/db")

module.exports = {
    ola() {
        return 'Hello World'
    },

    horaAtual()
    {
        return new Date
    },

    numerosMegaSena() {
        const crescente = (a, b) => a - b
        return Array(6).fill(0)
            .map(m=> parseInt(Math.random() * 60 + 1))
            .sort(crescente)
    },

    produtoEmEstoque(){
        return {
            nome: 'Kindle',
            preco: 349.90,
            desconto: 0.5
        }
    },
}