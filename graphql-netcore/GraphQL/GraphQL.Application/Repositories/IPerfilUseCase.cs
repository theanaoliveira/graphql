﻿using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IPerfilUseCase
    {
        List<Domain.Perfil.Perfil> Execute();
    }
}
