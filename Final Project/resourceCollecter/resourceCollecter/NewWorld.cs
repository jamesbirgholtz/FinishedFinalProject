using resourceCollecter.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resourceCollecter
{
    internal class NewWorld
    {
        private readonly mainGameScreen _mainGameScreen;
        private readonly Resource1 _resource1;
        private readonly Resource2 _resource2;
        private readonly Resource3 _resource3;
        private readonly Resource4 _resource4;

        public NewWorld(mainGameScreen mainGameScreen, Resource1 resource1, Resource2 resource2, Resource3 resource3, Resource4 resource4)
        {
            _mainGameScreen = mainGameScreen;
            _resource1 = resource1;
            _resource2 = resource2;
            _resource3 = resource3;
            _resource4 = resource4;
        }
        //method to call when the launch button is clicked, resetting the values to the default
        public void ResetValues()
        {
            _resource1._perSecond = 0;
            _resource1._count = 0;
            _resource1._perClick = 1000000000;
            _resource1._perSecondUpgrade1Count = 0;
            _resource1._perSecondUpgrade2Count = 0;
            _resource1._perSecondUpgrade3Count = 0;
            _resource1._perClickUpgradeCount = 0;
            _resource1.resource1ToRocket = 0;
            _resource1.resource1Needed = 1000000000;
            _resource1.increaseResourcePerSecond1 = 15;
            _resource1.increaseResourcePerSecond2 = 30;
            _resource1.increaseResourcePerSecond3 = 45;
            _resource1.increasePerSecond1UpgradeCost = 200;
            _resource1.increasePerSecond2UpgradeCost = 400;
            _resource1.increasePerSecond3UpgradeCost = 650;
            _resource1.increasePerSecond1UpgradeCount = 0;
            _resource1.increasePerSecond2UpgradeCount = 0;
            _resource1.increasePerSecond3UpgradeCount = 0;

            _resource2._perClick = 10000000000;
            _resource2._perSecond = 0;
            _resource2._count = 0;
            _resource2._perSecondUpgrade1Count = 0;
            _resource2._perSecondUpgrade2Count = 0;
            _resource2._perSecondUpgrade3Count = 0;
            _resource2._perClickUpgradeCount = 0;
            _resource2.resource2ToRocket = 0;
            _resource2.resource2Needed = 500000000;
            _resource2.increaseResourcePerSecond1 = 5;
            _resource2.increaseResourcePerSecond2 = 10;
            _resource2.increaseResourcePerSecond3 = 15;
            _resource2.increasePerSecond1UpgradeCost = 350;
            _resource2.increasePerSecond2UpgradeCost = 650;
            _resource2.increasePerSecond3UpgradeCost = 950;
            _resource2.increasePerSecond1UpgradeCount = 0;
            _resource2.increasePerSecond2UpgradeCount = 0;
            _resource2.increasePerSecond3UpgradeCount = 0;

            _resource3._perSecond = 0;
            _resource3._perClick = 10000000000;
            _resource3._count = 0;
            _resource3._perSecondUpgrade1Count = 0;
            _resource3._perSecondUpgrade2Count = 0;
            _resource3._perSecondUpgrade3Count = 0;
            _resource3._perClickUpgradeCount = 0;
            _resource3.resource3ToRocket = 0;
            _resource3.resource3Needed = 1000000;
            _resource3.increaseResourcePerSecond1 = 3;
            _resource3.increaseResourcePerSecond2 = 6;
            _resource3.increaseResourcePerSecond3 = 9;
            _resource3.increasePerSecond1UpgradeCost = 650;
            _resource3.increasePerSecond2UpgradeCost = 1250;
            _resource3.increasePerSecond3UpgradeCost = 1850;
            _resource3.increasePerSecond1UpgradeCount = 0;
            _resource3.increasePerSecond2UpgradeCount = 0;
            _resource3.increasePerSecond3UpgradeCount = 0;

            _resource4._perSecond = 0;
            _resource4._perClick = 1000000000000;
            _resource4._count = 0;
            _resource4._perSecondUpgrade1Count = 0;
            _resource4._perSecondUpgrade2Count = 0;
            _resource4._perSecondUpgrade3Count = 0;
            _resource4._perClickUpgradeCount = 0;
            _resource4.resource4ToRocket = 0;
            _resource4.resource4Needed = 100000;
            _resource4.increaseResourcePerSecond1 = 1;
            _resource4.increaseResourcePerSecond2 = 2;
            _resource4.increaseResourcePerSecond3 = 3;
            _resource4.increasePerSecond1UpgradeCost = 1250;
            _resource4.increasePerSecond2UpgradeCost = 2450;
            _resource4.increasePerSecond3UpgradeCost = 3650;
            _resource4.increasePerSecond1UpgradeCount = 0;
            _resource4.increasePerSecond2UpgradeCount = 0;
            _resource4.increasePerSecond3UpgradeCount = 0;
        }
    }
}
