namespace resourceCollecter
{
    // for comments check reasource 1
    public class Resource3 : BaseResource
    {
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
        public double resource3ToRocket { get; set; }
        public double resource3Needed { get; set; }
        public double increaseResourcePerSecond1 { get; set; }
        public double increaseResourcePerSecond2 { get; set; }
        public double increaseResourcePerSecond3 { get; set; }
        public double increasePerSecond1UpgradeCost { get; set; }
        public double increasePerSecond2UpgradeCost { get; set; }
        public double increasePerSecond3UpgradeCost { get; set; }
        public double increasePerSecond1UpgradeCount { get; set; }
        public double increasePerSecond2UpgradeCount { get; set; }
        public double increasePerSecond3UpgradeCount { get; set; }

        public Resource3(double perClick, double perSecond, double count, double perClickUpgradeCost,
    double perSecondUpgrade1Cost, double perSecondUpgrade2Cost, double perSecondUpgrade3Cost)
        {
            _perClick = perClick;
            _perSecond = perSecond;
            _count = count;
            _perClickUpgradeCost = perClickUpgradeCost;
            _perSecondUpgrade1Cost = perSecondUpgrade1Cost;
            _perSecondUpgrade2Cost = perSecondUpgrade2Cost;
            _perSecondUpgrade3Cost = perSecondUpgrade3Cost;
            _perSecondUpgrade1Count = 0;
            _perSecondUpgrade2Count = 0;
            _perSecondUpgrade3Count = 0;
            _perClickUpgradeCount = 0;
            resource3ToRocket = 0;
            resource3Needed = 1000000;
            increaseResourcePerSecond1 = 3;
            increaseResourcePerSecond2 = 6;
            increaseResourcePerSecond3 = 9;
            increasePerSecond1UpgradeCost = 650;
            increasePerSecond2UpgradeCost = 1250;
            increasePerSecond3UpgradeCost = 1850;
            increasePerSecond1UpgradeCount = 0;
            increasePerSecond2UpgradeCount = 0;
            increasePerSecond3UpgradeCount = 0;
        }

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

        public override void IncreasePerSecond1()
        {
            if (_count >= _perSecondUpgrade1Cost)
            {
                _count -= _perSecondUpgrade1Cost;
                _perSecond += increaseResourcePerSecond1;
                _perSecondUpgrade1Cost *= 1.75;
                _perSecondUpgrade1Count++;
            }
        }

        public override void IncreasePerSecond2()
        {
            if (_count >= _perSecondUpgrade2Cost)
            {
                _count -= _perSecondUpgrade2Cost;
                _perSecond += increaseResourcePerSecond2;
                _perSecondUpgrade2Cost *= 2;
                _perSecondUpgrade2Count++;
            }
        }

        public override void IncreasePerSecond3()
        {
            if (_count >= _perSecondUpgrade3Cost)
            {
                _count -= _perSecondUpgrade3Cost;
                _perSecond += increaseResourcePerSecond3;
                _perSecondUpgrade3Cost *= 2.25;
                _perSecondUpgrade3Count++;
            }
        }
        public override void ContributeToRocket()
        {
            if (resource3ToRocket >= resource3Needed)
            {
                return;
            }

            if (_count >= resource3Needed - resource3ToRocket)
            {
                resource3ToRocket = resource3Needed;
                _count -= resource3Needed - resource3ToRocket;
            }
            else
            {
                resource3ToRocket += _count;
                _count = 0;
            }
        }

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
