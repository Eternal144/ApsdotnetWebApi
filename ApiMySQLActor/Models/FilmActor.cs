using System;
using System.Collections.Generic;

namespace ApiMySQLActor.Models
{
    public partial class FilmActor
    {
        public int ActorId { get; set; }
        public short FilmId { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Record record { get; set; }
        public Film Film { get; set; }
    }
}
