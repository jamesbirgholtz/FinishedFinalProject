using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace resourceCollecter
{
    internal class FormControls
    {
        // Fields
        private readonly Form form; // reference to the form object that contains the controls
        private Rectangle originalFormSize; // stores the original size of the form
        private readonly Dictionary<Control, Rectangle> originalControlRectangles; // stores the original location and size of each control
        private readonly Dictionary<Control, Size> originalControlSizes; // stores the original size of each control
        private readonly mainGameScreen _mainForm; // reference to the main game screen object

        // Method to update the original form size
        public void UpdateOriginalFormSize(Size size)
        {
            originalFormSize = new Rectangle(0, 0, size.Width, size.Height);
        }

        // Constructor
        public FormControls(mainGameScreen mainForm)
        {
            _mainForm = mainForm;
            form = mainForm;
            originalFormSize = new Rectangle(0, 0, form.Size.Width, form.Size.Height); // set the original form size to the current size of the form
            originalControlRectangles = new Dictionary<Control, Rectangle>(); // create a new dictionary to store the original location and size of each control
            originalControlSizes = new Dictionary<Control, Size>(); // create a new dictionary to store the original size of each control

            // Loop through each control on the form
            foreach (Control control in form.Controls)
            {
                // Add the control and its original location and size to the originalControlRectangles dictionary
                originalControlRectangles.Add(control, new Rectangle(control.Location, control.Size));

                // Add the control and its original size to the originalControlSizes dictionary
                originalControlSizes.Add(control, control.Size);
            }
        }


        public void ApplyResize(Form form)
        {
            // Calculate the ratio of the current form size to the original form size
            float xRatio = (float)form.Width / originalFormSize.Width;
            float yRatio = (float)form.Height / originalFormSize.Height;

            // Create a new SizeF object to store the scale factors
            _ = new SizeF(xRatio, yRatio);

            // Iterate through each control and its original rectangle stored in the originalControlRectangles dictionary
            foreach (KeyValuePair<Control, Rectangle> entry in originalControlRectangles)
            {
                Control control = entry.Key; // Get the control from the KeyValuePair
                Rectangle r = entry.Value; // Get the original rectangle (position and size) from the KeyValuePair

                // Get the control's original size from the originalControlSizes dictionary
                Size originalSize = originalControlSizes[control];

                // Scale the control's size and position using the scaleFactor
                int newWidth = (int)(originalSize.Width * xRatio);
                int newHeight = (int)(originalSize.Height * yRatio);
                int newX = (int)(r.X * xRatio);
                int newY = (int)(r.Y * yRatio);

                // Set the control's bounds to the new position and size
                control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
            }
        }
        //method to hide the upgrade trees
        public void hideSubMenu()
        {
            if (_mainForm._tool1Upgrades.Visible == true)
            {
                _mainForm._tool1Upgrades.Visible = false;
            }
            if (_mainForm._tool2Upgrades.Visible == true)
            {
                _mainForm._tool2Upgrades.Visible = false;
            }
            if (_mainForm._tool3Upgrades.Visible == true)
            {
                _mainForm._tool3Upgrades.Visible = false;
            }

        }
        //method to show the upgrade trees
        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
    }

}
