using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPI.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public int Score { get; set; }
    }
}
