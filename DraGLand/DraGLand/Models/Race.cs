using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraGLand.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public string FirstUserName { get; set; }
        public string SecondUserName { get; set; }
        public string BetType { get; set; }
        public int Bet { get; set; }
        public int PossibleWin { get; set; }
        public string Status { get; set; }
    }
}