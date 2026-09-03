using Microsoft.EntityFrameworkCore;

namespace ZombieParty.Models.Data
{
    public class ZombiePartyDbContext
    {
        public ZombiePartyDbContext(DbContextOptions<ZombiePartyDbContext> options) : base(options)
        {

        }
        public DbSet<NOM_CLASSE> NOM_CLASSE_AVEC_UN_S { get; set; }
    }

    




    }





