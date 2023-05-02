using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

namespace resourceCollecter
{
    public partial class mainGameScreen : Form
    {
        private TextUpdater _textUpdater;
        private Resource1 resource1;
        private Resource2 resource2;
        private Resource3 resource3;
        private Resource4 resource4;
        private FormControls _formControls;
        private BaseResource baseResource;
        private NewWorld _newWorld;
        private SaveManager saveManager;
        private bool saveFilePathCreated = false;
        private string saveFilePath;
        private static Image backgroundImage;

        public Panel _tool1Upgrades => tool1Upgrades;
        public Panel _tool2Upgrades => tool2Upgrades;
        public Panel _tool3Upgrades => tool3Upgrades;



        public mainGameScreen()
        {
            InitializeComponent();
            resource1 = new Resource1(100000000, 0, 0, 100, 150, 300, 600);
            resource2 = new Resource2(100000000, 0, 0, 200, 300, 600, 900);
            resource3 = new Resource3(100000000, 0, 0, 400, 600, 1200, 1800);
            resource4 = new Resource4(100000000, 0, 0, 800, 1200, 2400, 3600);
            saveManager = new SaveManager();
            _formControls = new FormControls(this);
            _textUpdater = new TextUpdater(this);
            _newWorld = new NewWorld(this, resource1, resource2, resource3, resource4);
            textUpdater.Start();
            autoSaveTimer.Tick += autoSaveTimer_Tick;
            UpdateTextOnForm();

            // Load the background image from the embedded resource
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "resourceCollecter.Resources.backgroundimage.jpg";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    Image backgroundImage = Image.FromStream(stream);
                    this.BackgroundImage = backgroundImage;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.DoubleBuffered = true;
                }
                else
                {
                    // Handle the case when the resource is not found
                    return;
                }

            }
        }

        private void mainGameScreen_Load(object sender, EventArgs e)
        {
            _formControls = new FormControls(this);
            _formControls.UpdateOriginalFormSize(Size);

        }
        // keeps track of the resources needed to build the rocket and then sends it to the progress bar
        private void rocketProgressTracker()
        {
            //total to the resources needed
            double rocketResourcesNeeded = resource1.resource1Needed + resource2.resource2Needed + resource3.resource3Needed + resource4.resource4Needed;
            //total of the resources collected
            double rocketResourcesCollected = resource1.resource1ToRocket + resource2.resource2ToRocket + resource3.resource3ToRocket + resource4.resource4ToRocket;
            //creates a percentage of the resources needed so the progress bar can take the value
            double rocketProgress = rocketResourcesCollected / rocketResourcesNeeded * 100;
            rocketProgressBar.Value = (int)rocketProgress;

            //once the progress bar is 100 turn off the buttons and show the launch button
            if (rocketProgressBar.Value == 100)
            {
                resource1ToRocket.Enabled = false;
                resource2ToRocket.Enabled = false;
                resource3ToRocket.Enabled = false;
                resource4ToRocket.Enabled = false;
                resourceButton.Enabled = false;
                resourceButton.Visible = false;
                launchButton.Visible = true;
                launchButton.Enabled = true;
            }
        }
        // timers

        // text update timer, updates every 100ms
        private void textUpdater_Tick(object sender, EventArgs e)
        {
            UpdateTextOnForm();
            rocketProgressTracker();
        }

        // per second timer, addds the persecond count to each of the counts per second (maybe can change with an upgrade in the future)
        private void perSecondKeeper_Tick(object sender, EventArgs e)
        {
            resource1._count += resource1._perSecond;
            resource2._count += resource2._perSecond;
            resource3._count += resource3._perSecond;
            resource4._count += resource4._perSecond;
        }
        // save game after 15 seconds 
        private void autoSaveTimer_Tick(object sender, EventArgs e)
        {
            // after 15 second the game autosaves if saveFilePathCreated = true
            if (saveFilePathCreated)
            {
                SaveGame();
            }

            // sets the text of auto save textbox to game autosaved
            autoSaveTextBox.Text = "Game autosaved";
        }
        // clear the auto save text box every second
        private void timerSavedMessage_Tick(object sender, EventArgs e)
        {
            // clear the message after 1 seconds
            if (autoSaveTextBox.Text != "")
            {
                autoSaveTextBox.Text = "";
            }
        }


        // sets this form as the form to resize in the appply resize function insie of the formcontrols class
        private void mainGameScreen_Resize(object sender, EventArgs e)
        {
            _formControls.ApplyResize(this);
        }

        // buttons to show the upgrades for the different panels
        private void showTool1Upgrades_Click(object sender, EventArgs e)
        {
            _formControls.showSubMenu(tool1Upgrades);
        }

        private void showTool2Upgrades_Click(object sender, EventArgs e)
        {
            _formControls.showSubMenu(tool2Upgrades);
        }

        private void showTool3Upgrades_Click(object sender, EventArgs e)
        {
            _formControls.showSubMenu(tool3Upgrades);
        }

        private void resourceButton_Click(object sender, EventArgs e)
        {
            resource1._count += resource1._perClick;
            resource2._count += resource2._perClick;
            resource3._count += resource3._perClick;
            resource4._count += resource4._perClick;
            UpdateTextOnForm();
        }
        public void UpdateTextOnForm()
        {
            // calls to the textupdater class and sets all of the required properties in order for the class to update the form ( could cause fault
            // but im not sure of another way to do this without having the text inside of the main form which makes it very messy) 
            TextUpdater.UpdateWorldText(resource1, resource2, resource3, resource4,
             resource1TextBox, resource2TextBox, resource3TextBox, resource4TextBox,
             resource1PerClickUpgrade, resource2PerClickUpgrade, resource3PerClickUpgrade, resource4PerClickUpgrade,
             resource1Tool1, resource2Tool1, resource3Tool1, resource4Tool1,
             resource1Tool2, resource2Tool2, resource3Tool2, resource4Tool2,
             resource1Tool3, resource2Tool3, resource3Tool3, resource4Tool3,
             resource1ToRocket, resource2ToRocket, resource3ToRocket, resource4ToRocket,
             resource1Tool1Upgrade, resource2Tool1Upgrade, resource3Tool1Upgrade, resource4Tool1Upgrade,
             resource1Tool2Upgrade, resource2Tool2Upgrade, resource3Tool2Upgrade, resource4Tool2Upgrade,
             resource1Tool3Upgrade, resource2Tool3Upgrade, resource3Tool3Upgrade, resource4Tool3Upgrade);
        }
        // r1 buttons
        private void resource1PerClickUpgrade_Click(object sender, EventArgs e)
        {
            resource1.IncreasePerClick();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource1Tool1_Click(object sender, EventArgs e)
        {
            resource1.IncreasePerSecond1();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource1Tool2_Click(object sender, EventArgs e)
        {
            resource1.IncreasePerSecond2();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource1Tool3_Click(object sender, EventArgs e)
        {
            resource1.IncreasePerSecond3();
            UpdateTextOnForm();
            SaveGame();
        }
        // r2 buttons
        private void resource2PerClickUpgrade_Click(object sender, EventArgs e)
        {
            resource2.IncreasePerClick();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource2Tool1_Click(object sender, EventArgs e)
        {
            resource2.IncreasePerSecond1();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource2Tool2_Click(object sender, EventArgs e)
        {
            resource2.IncreasePerSecond2();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource2Tool3_Click(object sender, EventArgs e)
        {
            resource2.IncreasePerSecond3();
            UpdateTextOnForm();
            SaveGame();
        }
        // r3 buttons
        private void resource3PerClickUpgrade_Click(object sender, EventArgs e)
        {
            resource3.IncreasePerClick();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource3Tool1_Click(object sender, EventArgs e)
        {
            resource3.IncreasePerSecond1();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource3Tool2_Click(object sender, EventArgs e)
        {
            resource3.IncreasePerSecond2();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource3Tool3_Click(object sender, EventArgs e)
        {
            resource3.IncreasePerSecond3();
            UpdateTextOnForm();
            SaveGame();
        }
        // r4 buttons
        private void resource4PerClickUpgrade_Click(object sender, EventArgs e)
        {
            resource4.IncreasePerClick();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource4Tool1_Click(object sender, EventArgs e)
        {
            resource4.IncreasePerSecond1();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource4Tool2_Click(object sender, EventArgs e)
        {
            resource4.IncreasePerSecond2();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource4Tool3_Click(object sender, EventArgs e)
        {
            resource4.IncreasePerSecond3();
            UpdateTextOnForm();
            SaveGame();
        }
        // building the rocket buttons
        private void resource1ToRocket_Click(object sender, EventArgs e)
        {
            resource1.ContributeToRocket();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource2ToRocket_Click(object sender, EventArgs e)
        {
            resource2.ContributeToRocket();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource3ToRocket_Click(object sender, EventArgs e)
        {
            resource3.ContributeToRocket();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource4ToRocket_Click(object sender, EventArgs e)
        {
            resource4.ContributeToRocket();
            UpdateTextOnForm();
            SaveGame();
        }

        // tool1 upgrades
        private void resource1Tool1Upgrade_Click(object sender, EventArgs e)
        {
            resource1.IncreasePerSecond1Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource2Tool1Upgrade_Click(object sender, EventArgs e)
        {
            resource2.IncreasePerSecond1Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource3Tool1Upgrade_Click(object sender, EventArgs e)
        {
            resource3.IncreasePerSecond1Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource4Tool1Upgrade_Click(object sender, EventArgs e)
        {
            resource4.IncreasePerSecond1Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }
        // tool2 updgrades
        private void resource1Tool2Upgrade_Click(object sender, EventArgs e)
        {
            resource1.IncreasePerSecond2Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource2Tool2Upgrade_Click(object sender, EventArgs e)
        {
            resource2.IncreasePerSecond2Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource3Tool2Upgrade_Click(object sender, EventArgs e)
        {
            resource3.IncreasePerSecond2Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource4Tool2Upgrade_Click(object sender, EventArgs e)
        {
            resource4.IncreasePerSecond2Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }
        // tool3 upgrades
        private void resource1Tool3Upgrade_Click(object sender, EventArgs e)
        {
            resource1.IncreasePerSecond3Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource2Tool3Upgrade_Click(object sender, EventArgs e)
        {
            resource2.IncreasePerSecond3Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource3Tool3Upgrade_Click(object sender, EventArgs e)
        {
            resource3.IncreasePerSecond3Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void resource4Tool3Upgrade_Click(object sender, EventArgs e)
        {
            resource4.IncreasePerSecond3Upgrade();
            UpdateTextOnForm();
            SaveGame();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            // once the launch button in pressed call to the newworld class to use the reset values method 
            // sets everything back to the default value
            _newWorld.ResetValues();
            // increases the current world counter so the ui changes
            TextUpdater.currentWorld++;
            // enable or disable buttons so the ui is correct
            launchButton.Enabled = false;
            launchButton.Visible = false;
            resourceButton.Enabled = true;
            resourceButton.Visible = true;
            resource1ToRocket.Enabled = true;
            resource2ToRocket.Enabled = true;
            resource3ToRocket.Enabled = true;
            resource4ToRocket.Enabled = true;

            if (TextUpdater.currentWorld == 4) {
                TextUpdater.currentWorld = 1;
            }

        }

        private void saveGameButton_Click(object sender, EventArgs e)
        {
            // if there is no save file path
            if (saveFilePathCreated == false)
            {
                // open a dialog box so that the user can edit the name of the file and save it where they want
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    saveFileDialog.DefaultExt = "json";
                    saveFileDialog.AddExtension = true;

                   
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var gameStateToSave = new GameState
                        {
                            // variables of the gamestate to be saved
                            resource1 = resource1,
                            resource2 = resource2,
                            resource3 = resource3,
                            resource4 = resource4,
                            currentWorld = TextUpdater.currentWorld,
                        };
                        // calls to the savemanager class, using the save game state method to save the game state
                        saveManager.SaveGameState(gameStateToSave, saveFileDialog.FileName);
                        // set the save file path to the file name
                        saveFilePath = saveFileDialog.FileName;
                        // message showing where the game was saved
                        MessageBox.Show($"Game state saved to: {saveFileDialog.FileName}");
                    }
                }
                saveFilePathCreated = true;
            }
            // if there is already a save file path, just save the game state but do not display the messagebox
            if (saveFilePathCreated) {
                try
                {   
                    //save gamestate variables
                    var gameStateToSave = new GameState
                    {
                        resource1 = resource1,
                        resource2 = resource2,
                        resource3 = resource3,
                        resource4 = resource4,
                        currentWorld = TextUpdater.currentWorld
                    };
                    // calls to the save game state method in the save manager class, uses the savefilepath that is already created
                    saveManager.SaveGameState(gameStateToSave, saveFilePath);
                }
                catch (Exception ex)
                {
                    // Handle exceptions that might occur during the save process
                    Console.WriteLine("Error saving the game: " + ex.Message);
                }
            }
            //start the auto saver when the button is clicked
            autoSaveTimer.Start();

        }

        private void loadGameButton_Click(object sender, EventArgs e)
        {
            // using the dilog box filter only the json files
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // load the game state as using the load game state method in the save manager class as long as its not null
                    var loadedGameState = saveManager.LoadGameState(openFileDialog.FileName);
                    if (loadedGameState != null)
                    {
                        resource1 = loadedGameState.resource1;
                        resource2 = loadedGameState.resource2;
                        resource3 = loadedGameState.resource3;
                        resource4 = loadedGameState.resource4;
                        TextUpdater.currentWorld = loadedGameState.currentWorld;
                        TextUpdater.UpdateWorldText(resource1, resource2, resource3, resource4, resource1TextBox, resource2TextBox, resource3TextBox, resource4TextBox,
                        resource1PerClickUpgrade, resource2PerClickUpgrade, resource3PerClickUpgrade, resource4PerClickUpgrade,
                        resource1Tool1, resource2Tool1, resource3Tool1, resource4Tool1,
                        resource1Tool2, resource2Tool2, resource3Tool2, resource4Tool2,
                        resource1Tool3, resource2Tool3, resource3Tool3, resource4Tool3,
                        resource1ToRocket, resource2ToRocket, resource3ToRocket, resource4ToRocket,
                        resource1Tool1Upgrade, resource2Tool1Upgrade, resource3Tool1Upgrade, resource4Tool1Upgrade,
                        resource1Tool2Upgrade, resource2Tool2Upgrade, resource3Tool2Upgrade, resource4Tool2Upgrade,
                        resource1Tool3Upgrade, resource2Tool3Upgrade, resource3Tool3Upgrade, resource4Tool3Upgrade);

                        // set the save file path as the file name of the opened file ; start the save game timer
                        saveFilePath = openFileDialog.FileName;
                        saveFilePathCreated = true;
                        autoSaveTimer.Start();
                    }
                }
            }

        }
        public void SaveGame()
        {
            // if the string is not null or void
            if (!string.IsNullOrEmpty(saveFilePath))
            {
                // save the game state

                try
                {
                    var gameStateToSave = new GameState
                    {
                        resource1 = resource1,
                        resource2 = resource2,
                        resource3 = resource3,
                        resource4 = resource4,
                        currentWorld = TextUpdater.currentWorld
                    };
                    saveManager.SaveGameState(gameStateToSave, saveFilePath);
                    autoSaveTextBox.Text = "Game saved";
                }
                catch (Exception ex)
                {
                    // Handle exceptions that might occur during the save process
                    Console.WriteLine("Error saving the game: " + ex.Message);
                }
            }
        }




        // tool tips for the buttons
        private void saveGameButton_MouseHover(object sender, EventArgs e)
        {
            saveGameToolTip.SetToolTip(saveGameButton, "Save Game");
        }

        private void loadGameButton_MouseHover(object sender, EventArgs e)
        {
            loadGameToolTip.SetToolTip(loadGameButton, "Load Game");
        }
    }
}
