using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class Entity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Entity()
        {
            Id = default; //hiçbir şey verilmezse id ye, o id tipinin defaultu neyse o verilsin
        }
        public Entity(TId id)
        {
            Id = id;            
        }

    }
}
