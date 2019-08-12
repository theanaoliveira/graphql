const usuario = require('./usuario')
const perfil = require('./perfil')
const generics = require('./generics')

module.exports = {
    ...usuario,
    ...perfil,
    ...generics
}