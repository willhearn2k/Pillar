using System;
using System.Collections.Generic;
using System.Linq;
using Pillar.Server.Models;

namespace Pillar.Server.DataContext.Repository
{
    public interface IPlayerRepository : IPillarRepository<Player>
    {
        Player Get(int Id);
        bool Exists(int Id);
    }
}