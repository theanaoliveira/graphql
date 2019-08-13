using GraphQL.Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Application.UseCases.Usuario
{
    public class UsuarioUseCase
    {
        public List<Domain.Usuario.Usuario> Execute()
        {
            return new List<Domain.Usuario.Usuario>() {
                    new Domain.Usuario.Usuario(1, "Ana Caroline", "anacaroline@usuario.com", 26, true, UsuarioStatus.ATIVO),
                    new Domain.Usuario.Usuario(1, "João da Silva", "joaosilva@usuario.com", 29, true, UsuarioStatus.ATIVO),
                    new Domain.Usuario.Usuario(1, "Daniela Santos", "danielasantos@usuario.com", 20, true, UsuarioStatus.BLOQUEADO),
                };
        }
    }
}
