using System;
using System.Collections.Generic;
using System.Linq;
using Pillar.Server.Models;
using Pillar.Server.DataContext.Context;

namespace Pillar.Server.DataContext.Repository
{
    public class PlayerRepository : 
        PillarRepository<PillarContext, Player>, IPlayerRepository
    {
        public PlayerRepository()
        {

        }

        public Player Get(int Id)
        {
            return Get(p => p.ID == Id).FirstOrDefault();
        }

        public bool Exists(int Id)
        {
            return Context.Players.Any(s => s.ID == Id);
        }
    }
}