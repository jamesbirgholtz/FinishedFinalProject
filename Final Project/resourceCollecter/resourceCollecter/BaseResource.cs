using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resourceCollecter
{
    // base resource for the resources to inherit 
    public abstract class BaseResource : IResource
    {
        public double PerClick { get; protected set; }
        public double PerSecond { get; protected set; }
        public double Count { get; protected set; }
        public abstract void IncreasePerClick();
        public abstract void ContributeToRocket();
        public abstract void IncreasePerSecond1();
        public abstract void IncreasePerSecond2();
        public abstract void IncreasePerSecond3();
        public abstract void IncreasePerSecond1Upgrade();
        public abstract void IncreasePerSecond2Upgrade();
        public abstract void IncreasePerSecond3Upgrade();

    }
}
