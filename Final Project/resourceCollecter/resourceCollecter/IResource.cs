using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resourceCollecter
{
    public interface IResource
    {
        // interface for the base resource to inherit
        double PerClick { get; }
        double PerSecond { get; }
        double Count { get; }
    }
}
