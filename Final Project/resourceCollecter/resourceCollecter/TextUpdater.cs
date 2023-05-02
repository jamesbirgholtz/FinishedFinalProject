using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace resourceCollecter
{
    public class TextUpdater
    {
        public static Dictionary<int, string[]> worldResourceNames = new Dictionary<int, string[]>
        {
            { 1, new string[] { "Water", "Coal", "Iron", "Gold" } },
            { 2, new string[] { "RA", "RB", "RC", "RD" } },
            { 3, new string[] { "RX", "RY", "RZ", "RW" } }
        };

        public static Dictionary<int, string[]> worldResourceImages = new Dictionary<int, string[]>
        {
            { 1, new string[] { "R1_W1.png", "R2_W1.png", "R3_W1.png", "R4_W1.png" } },
            { 2, new string[] { "R1_W2.png", "R2_W2.png", "R3_W2.png", "R4_W2.png" } },
            { 3, new string[] { "R1_W3.png", "R2_W3.png", "R3_W3.png", "R4_W3.png" } }
        };

        public static int currentWorld = 1;
        private readonly mainGameScreen _mainGameScreen;

        public TextUpdater(mainGameScreen mainGameScreen)
        {
            _mainGameScreen = mainGameScreen;
        }
        //update textboxes for the different worlds
        public static void UpdateWorldText(Resource1 resource1, Resource2 resource2, Resource3 resource3, Resource4 resource4,
            Label resource1TextBox, Label resource2TextBox, Label resource3TextBox, Label resource4TextBox,
            Button resource1PerClickUpgrade, Button resource2PerClickUpgrade, Button resource3PerClickUpgrade, Button resource4PerClickUpgrade,
            Button resource1Tool1, Button resource2Tool1, Button resource3Tool1, Button resource4Tool1,
            Button resource1Tool2, Button resource2Tool2, Button resource3Tool2, Button resource4Tool2,
            Button resource1Tool3, Button resource2Tool3, Button resource3Tool3, Button resource4Tool3,
            Button resource1ToRocket, Button resource2ToRocket, Button resource3ToRocket, Button resource4ToRocket,
            Button resource1Tool1Upgrade, Button resource2Tool1Upgrade, Button resource3Tool1Upgrade, Button resource4Tool1Upgrade,
            Button resource1Tool2Upgrade, Button resource2Tool2Upgrade, Button resource3Tool2Upgrade, Button resource4Tool2Upgrade,
            Button resource1Tool3Upgrade, Button resource2Tool3Upgrade, Button resource3Tool3Upgrade, Button resource4Tool3Upgrade)
        {
            string[] currentWorldResourceNames = worldResourceNames[currentWorld];
            string[] currentWorldResourceImages = worldResourceImages[currentWorld];

            //r1PicBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            //r2PicBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            //r3PicBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            //r4PicBox.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));

            resource1TextBox.Text = currentWorldResourceNames[0] + ":\n" + resource1._perSecond.ToString("F0") + " /s\n" + resource1._count.ToString("F0");
            resource2TextBox.Text = currentWorldResourceNames[1] + ":\n" + resource2._perSecond.ToString("F0") + " /s\n" + resource2._count.ToString("F0");
            resource3TextBox.Text = currentWorldResourceNames[2] + ":\n" + resource3._perSecond.ToString("F0") + " /s\n" + resource3._count.ToString("F0");
            resource4TextBox.Text = currentWorldResourceNames[3] + ":\n" + resource4._perSecond.ToString("F0") + " /s\n" + resource4._count.ToString("F0");

            resource1TextBox.Text = currentWorldResourceNames[0] + ": " + resource1._count.ToString("F0") + Environment.NewLine + currentWorldResourceNames[0] + " /s: " + resource1._perSecond.ToString("F0");
            resource1PerClickUpgrade.Text = currentWorldResourceNames[0] + " Per Click x2 \nCost: " + resource1._perClickUpgradeCost.ToString("F0");
            resource1PerClickUpgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            resource1Tool1.Text = currentWorldResourceNames[0] + " Miner\n" + resource1.increaseResourcePerSecond1 + " per second\n\n Cost: " + resource1._perSecondUpgrade1Cost.ToString("F0") + " " + currentWorldResourceNames[0];
            resource1Tool1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            resource1Tool2.Text = currentWorldResourceNames[0] + " Drill\n" + resource1.increaseResourcePerSecond2 + " per second\n\n Cost: " + resource1._perSecondUpgrade2Cost.ToString("F0") + " " + currentWorldResourceNames[0];
            resource1Tool2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            resource1Tool3.Text = currentWorldResourceNames[0] + " Excavator\n" + resource1.increaseResourcePerSecond3 + " per second\n\n Cost: " + resource1._perSecondUpgrade3Cost.ToString("F0") + " " + currentWorldResourceNames[0];
            resource1Tool3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));

            resource2TextBox.Text = currentWorldResourceNames[1] + ": " + resource2._count.ToString("F0") + Environment.NewLine + currentWorldResourceNames[1] + " /s: " + resource2._perSecond.ToString("F0");
            resource2PerClickUpgrade.Text = currentWorldResourceNames[1] + " Per Click x2 \nCost: " + resource2._perClickUpgradeCost.ToString("F0");
            resource2PerClickUpgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            resource2Tool1.Text = currentWorldResourceNames[1] + " Miner\n" + resource2.increaseResourcePerSecond1 + " per second\n\n Cost: " + resource2._perSecondUpgrade1Cost.ToString("F0") + " " + currentWorldResourceNames[1];
            resource2Tool1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            resource2Tool2.Text = currentWorldResourceNames[1] + " Drill\n" + resource2.increaseResourcePerSecond2 + " per second\n\n Cost: " + resource2._perSecondUpgrade2Cost.ToString("F0") + " " + currentWorldResourceNames[1];
            resource2Tool2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            resource2Tool3.Text = currentWorldResourceNames[1] + " Excavator\n" + resource2.increaseResourcePerSecond3 + " per second\n\n Cost: " + resource2._perSecondUpgrade3Cost.ToString("F0") + " " + currentWorldResourceNames[1];
            resource2Tool3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));


            resource3TextBox.Text = currentWorldResourceNames[2] + ": " + resource3._count.ToString("F0") + Environment.NewLine + currentWorldResourceNames[2] + " /s: " + resource3._perSecond.ToString("F0");
            resource3PerClickUpgrade.Text = currentWorldResourceNames[2] + " Per Click x2 \nCost: " + resource3._perClickUpgradeCost.ToString("F0");
            resource3PerClickUpgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            resource3Tool1.Text = currentWorldResourceNames[2] + " Miner\n" + resource3.increaseResourcePerSecond1 + " per second\n\n Cost: " + resource3._perSecondUpgrade1Cost.ToString("F0") + " " + currentWorldResourceNames[2];
            resource3Tool1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            resource3Tool2.Text = currentWorldResourceNames[2] + " Drill\n" + resource3.increaseResourcePerSecond2 + " per second\n\n Cost: " + resource3._perSecondUpgrade2Cost.ToString("F0") + " " + currentWorldResourceNames[2];
            resource3Tool2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            resource3Tool3.Text = currentWorldResourceNames[2] + " Excavator\n" + resource3.increaseResourcePerSecond3 + " per second\n\n Cost: " + resource3._perSecondUpgrade3Cost.ToString("F0") + " " + currentWorldResourceNames[2];
            resource3Tool3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));

            resource4TextBox.Text = currentWorldResourceNames[3] + ": " + resource4._count.ToString("F0") + Environment.NewLine + currentWorldResourceNames[3] + " /s: " + resource4._perSecond.ToString("F0");
            resource4PerClickUpgrade.Text = currentWorldResourceNames[3] + " Per Click x2 \nCost: " + resource4._perClickUpgradeCost.ToString("F0");
            resource4PerClickUpgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));
            resource4Tool1.Text = currentWorldResourceNames[3] + " Miner\n" + resource4.increaseResourcePerSecond1 + " per second\n\n Cost: " + resource4._perSecondUpgrade1Cost.ToString("F0") + " " + currentWorldResourceNames[3];
            resource4Tool1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));
            resource4Tool2.Text = currentWorldResourceNames[3] + " Drill\n" + resource4.increaseResourcePerSecond2 + " per second\n\n Cost: " + resource4._perSecondUpgrade2Cost.ToString("F0") + " " + currentWorldResourceNames[3];
            resource4Tool2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));
            resource4Tool3.Text = currentWorldResourceNames[3] + " Excavator\n" + resource4.increaseResourcePerSecond3 + " per second\n\n Cost: " + resource4._perSecondUpgrade3Cost.ToString("F0") + " " + currentWorldResourceNames[3];
            resource4Tool3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));

            resource1ToRocket.Text = "send " + currentWorldResourceNames[0] + " to rocket\n" + resource1.resource1ToRocket.ToString("F0") + " total sent\n" + (resource1.resource1Needed - resource1.resource1ToRocket).ToString("F0") + " needed!";
            resource1ToRocket.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            resource2ToRocket.Text = "send " + currentWorldResourceNames[1] + " to rocket\n" + resource2.resource2ToRocket.ToString("F0") + " total sent\n" + (resource2.resource2Needed - resource2.resource2ToRocket).ToString("F0") + " needed!";
            resource2ToRocket.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            resource3ToRocket.Text = "send " + currentWorldResourceNames[2] + " to rocket\n" + resource3.resource3ToRocket.ToString("F0") + " total sent\n" + (resource3.resource3Needed - resource3.resource3ToRocket).ToString("F0") + " needed!";
            resource3ToRocket.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            resource4ToRocket.Text = "send " + currentWorldResourceNames[3] + " to rocket\n" + resource4.resource4ToRocket.ToString("F0") + " total sent\n" + (resource4.resource4Needed - resource4.resource4ToRocket).ToString("F0") + " needed!";
            resource4ToRocket.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));

            resource1Tool1Upgrade.Text = currentWorldResourceNames[0] + " miner + " + resource1.increasePerSecond1UpgradeCount.ToString() + "\nCosts: " + resource1.increasePerSecond1UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[0];
            resource1Tool1Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            resource2Tool1Upgrade.Text = currentWorldResourceNames[1] + " miner + " + resource2.increasePerSecond1UpgradeCount.ToString() + "\nCosts: " + resource2.increasePerSecond1UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[1];
            resource2Tool1Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            resource3Tool1Upgrade.Text = currentWorldResourceNames[2] + " miner + " + resource3.increasePerSecond1UpgradeCount.ToString() + "\nCosts: " + resource3.increasePerSecond1UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[2];
            resource3Tool1Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            resource4Tool1Upgrade.Text = currentWorldResourceNames[3] + " miner + " + resource4.increasePerSecond1UpgradeCount.ToString() + "\nCosts: " + resource4.increasePerSecond1UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[3];
            resource4Tool1Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));

            resource1Tool2Upgrade.Text = currentWorldResourceNames[0] + " drill + " + resource1.increasePerSecond2UpgradeCount.ToString() + "\nCosts: " + resource1.increasePerSecond2UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[0];
            resource1Tool2Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            resource2Tool2Upgrade.Text = currentWorldResourceNames[1] + " drill + " + resource2.increasePerSecond2UpgradeCount.ToString() + "\nCosts: " + resource2.increasePerSecond2UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[1];
            resource2Tool2Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            resource3Tool2Upgrade.Text = currentWorldResourceNames[2] + " drill + " + resource3.increasePerSecond2UpgradeCount.ToString() + "\nCosts: " + resource3.increasePerSecond2UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[2];
            resource3Tool2Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            resource4Tool2Upgrade.Text = currentWorldResourceNames[3] + " drill + " + resource4.increasePerSecond2UpgradeCount.ToString() + "\nCosts: " + resource4.increasePerSecond2UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[3];
            resource4Tool2Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));

            resource1Tool3Upgrade.Text = currentWorldResourceNames[0] + " excavator + " + resource1.increasePerSecond3UpgradeCount.ToString() + "\nCosts: " + resource1.increasePerSecond3UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[0];
            resource1Tool3Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[0]));
            resource2Tool3Upgrade.Text = currentWorldResourceNames[1] + " excavator + " + resource2.increasePerSecond3UpgradeCount.ToString() + "\nCosts: " + resource2.increasePerSecond3UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[1];
            resource2Tool3Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[1]));
            resource3Tool3Upgrade.Text = currentWorldResourceNames[2] + " excavator + " + resource3.increasePerSecond3UpgradeCount.ToString() + "\nCosts: " + resource3.increasePerSecond3UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[2];
            resource3Tool3Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[2]));
            resource4Tool3Upgrade.Text = currentWorldResourceNames[3] + " excavator + " + resource4.increasePerSecond3UpgradeCount.ToString() + "\nCosts: " + resource4.increasePerSecond3UpgradeCost.ToString("F0") + " " + currentWorldResourceNames[3];
            resource4Tool3Upgrade.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(currentWorldResourceImages[3]));

            //tokenUpgrades.Text = "Upgrades\nTokens aquired: " + upgradeTree.UpgradeTokens;
        }
    }
}
