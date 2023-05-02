using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resourceCollecter
{
    public class GameState
    {
        // things that need to be saved in order for the game to be reloaded properly
        public Resource1 resource1 { get; set; }
        public Resource2 resource2 { get; set; }
        public Resource3 resource3 { get; set; }
        public Resource4 resource4 { get; set; }
        public int currentWorld { get; set; }

        // maybe the upgrade tree as well?
    }
}
