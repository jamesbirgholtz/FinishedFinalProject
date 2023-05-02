using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace resourceCollecter
{


    public class Resource1 : BaseResource
    {
        // set the varibles to be changed
        public double _perClick { get; set; }
        public double _perSecond { get; set; }
        public double _count { get; set; }
        public double _perClickUpgradeCost { get; set; }
        public double _perSecondUpgrade1Cost { get; set; }
        public double _perSecondUpgrade2Cost { get; set; }
        public double _perSecondUpgrade3Cost { get; set; }
        public int _perSecondUpgrade1Count { get; set; }
        public int _perSecondUpgrade2Count { get; set; }
        public int _perSecondUpgrade3Count { get; set; }
        public int _perClickUpgradeCount { get; set; }
        public double resource1ToRocket { get; set; }
        public double resource1Needed { get; set; }
        public double increaseResourcePerSecond1 { get; set; }
        public double increaseResourcePerSecond2 { get; set; }
        public double increaseResourcePerSecond3 { get; set; }
        public double increasePerSecond1UpgradeCost { get; set; }
        public double increasePerSecond2UpgradeCost { get; set; }
        public double increasePerSecond3UpgradeCost { get; set; }
        public double increasePerSecond1UpgradeCount { get; set; }
        public double increasePerSecond2UpgradeCount { get; set; }
        public double increasePerSecond3UpgradeCount { get; set; }


        public Resource1(double perClick, double perSecond, double count, double perClickUpgradeCost,
           double perSecondUpgrade1Cost, double perSecondUpgrade2Cost, double perSecondUpgrade3Cost)
        {
            _perClick = perClick;
            _perSecond = perSecond;
            _count = count;
            _perClickUpgradeCost = perClickUpgradeCost;
            _perSecondUpgrade1Cost = perSecondUpgrade1Cost;
            _perSecondUpgrade2Cost = perSecondUpgrade2Cost;
            _perSecondUpgrade3Cost = perSecondUpgrade3Cost;
            // keeps count of the amount of tools/ upgrades the user has
            _perSecondUpgrade1Count = 0;
            _perSecondUpgrade2Count = 0;
            _perSecondUpgrade3Count = 0;
            _perClickUpgradeCount = 0;
            // the amount of resources that are already sent to the rocket
            resource1ToRocket = 0;
            // the amount of reasources needed to build the rocket
            resource1Needed = 1000000000;
            // the amount the tools per second give
            increaseResourcePerSecond1 = 15;
            increaseResourcePerSecond2 = 30;
            increaseResourcePerSecond3 = 45;
            // initial cost of the upgrades for the tools
            increasePerSecond1UpgradeCost = 200;
            increasePerSecond2UpgradeCost = 400;
            increasePerSecond3UpgradeCost = 650;
            // keeps track of the tool upgrades
            increasePerSecond1UpgradeCount = 0;
            increasePerSecond2UpgradeCount = 0;
            increasePerSecond3UpgradeCount = 0;
        }
        // method to increase the amount per click the user gets 
        public override void IncreasePerClick()
        {
            if (_count >= _perClickUpgradeCost)
            {
                _count -= _perClickUpgradeCost;
                _perClick *= 2;
                _perClickUpgradeCost *= 2;
                _perClickUpgradeCount++;
            }
        }
        // tool1
        public override void IncreasePerSecond1()
        {
            if (_count >= _perSecondUpgrade1Cost)
            {
                _count -= _perSecondUpgrade1Cost;
                _perSecond += increaseResourcePerSecond1;
                _perSecondUpgrade1Cost *= 1.25;
                _perSecondUpgrade1Count++;
            }
        }
        // tool2
        public override void IncreasePerSecond2()
        {
            if (_count >= _perSecondUpgrade2Cost)
            {
                _count -= _perSecondUpgrade2Cost;
                _perSecond += increaseResourcePerSecond2;
                _perSecondUpgrade2Cost *= 1.50;
                _perSecondUpgrade2Count++;
            }
        }
        // tool3
        public override void IncreasePerSecond3()
        {
            if (_count >= _perSecondUpgrade3Cost)
            {
                _count -= _perSecondUpgrade3Cost;
                _perSecond += increaseResourcePerSecond3;
                _perSecondUpgrade3Cost *= 1.75;
                _perSecondUpgrade3Count++;
            }
        }
        // send whatever amount of this reasource the user has to the rocket
        public override void ContributeToRocket()
        {
            if (resource1ToRocket >= resource1Needed)
            {
                return;
            }

            if (_count >= resource1Needed - resource1ToRocket)
            {
                resource1ToRocket = resource1Needed;
                _count -= resource1Needed - resource1ToRocket;
            }
            else
            {
                resource1ToRocket += _count;
                _count = 0;
            }
        }
        // tool1 upgrade
        public override void IncreasePerSecond1Upgrade()
        {
            if (_count >= increasePerSecond1UpgradeCost)
            {
                for (int i = 0; i < _perSecondUpgrade1Count; i++)
                {
                    _perSecond += increaseResourcePerSecond1;
                }
                increaseResourcePerSecond1 *= 2;
                _count -= increasePerSecond1UpgradeCost;
                increasePerSecond1UpgradeCost *= 2;
                increasePerSecond1UpgradeCount++;
            }
        }
        // tool2 upgrade
        public override void IncreasePerSecond2Upgrade()
        {
            if (_count >= increasePerSecond2UpgradeCost)
            {
                for (int i = 0; i < _perSecondUpgrade2Count; i++)
                {
                    _perSecond += increaseResourcePerSecond2;
                }
                increaseResourcePerSecond2 *= 2;
                _count -= increasePerSecond2UpgradeCost;
                increasePerSecond2UpgradeCost *= 2;
                increasePerSecond2UpgradeCount++;
            }
        }
        // tool3 upgrade
        public override void IncreasePerSecond3Upgrade()
        {
            if (_count >= increasePerSecond3UpgradeCost)
            {
                for (int i = 0; i < _perSecondUpgrade3Count; i++)
                {
                    _perSecond += increaseResourcePerSecond3;
                }
                increaseResourcePerSecond3 *= 2;
                _count -= increasePerSecond3UpgradeCost;
                increasePerSecond3UpgradeCost *= 2;
                increasePerSecond3UpgradeCount++;
            }
        }
    }
}
