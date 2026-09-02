/* A class for AO.cs that does various things with controls.
 * v00.52.160927
 * http://aprettycoolprogram.com/ao
 */

/* This class is somewhat complex, and pretty long. I've used nested classes and regions to help with the organization
 * and readability, but it's definatly not "best practice" code!
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AO
{
    public class AOControl
    {
        // This is a base level of controls that will allow all changes
        private static List<string> allowAllChanges = new List<string>() { "Button",
                                                                            "CheckBox",
                                                                            "ComboBox",
                                                                            "Label",
                                                                            "TabControl"};

        // These control types can have property state changes. Add controls to this.
        private static List<string> allowStateChange = allowAllChanges;

        // These controls can be painted. Add controls to this.
        private static List<string> allowPaintChange = allowAllChanges;

        /// <summary>Change a property of all of a single control type on a form.</summary>
        /// <param name="formName">Name of the form (generally "this").</param>
        /// <param name="controlType">The name or type of the control (i.e. "btnTest").</param>
        /// <param name="excludedControls">A list of controls names to exclude from the state change.</param>
        /// <param name="propertyToChange">The property to change [i.e. "Enabled", "Visible".</param>
        /// <param name="state">The state of the property [true, false]</param>
        public static void ChangeState(Form formName, Control controlType, List<Control> excludedControls, string propertyToChange, bool state)
        {
            foreach (Control control in formName.Controls)
            {
                if ((allowStateChange.Contains(controlType.GetType().Name.ToString())) && (!excludedControls.Contains(control)))
                {
                    SetState(controlType, propertyToChange, state);
                }
            }
        }

        /// <summary>Change a property of all of a single control type on in a control.</summary>
        /// <param name="ControlName">Name of the form (generally "this").</param>
        /// <param name="controlType">The name or type of the control (i.e. "btnTest").</param>
        /// <param name="excludedControls">A list of controls names to exclude from the state change.</param>
        /// <param name="propertyToChange">The property to change [i.e. "Enabled", "Visible".</param>
        /// <param name="state">The state of the property [true, false]</param>
        public static void ChangeState(Control controlName, Control controlType, List<Control> excludedControls, string propertyToChange, bool state)
        {
            foreach (Control control in controlName.Controls)
            {
                if ((allowStateChange.Contains(controlType.GetType().Name.ToString())) && (!excludedControls.Contains(control)))
                {
                    SetState(controlType, propertyToChange, state);
                }
            }
        }

        /// <summary>Change a property of a a list of controls.</summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="controlNameOrType">The name or type of the control.</param>
        /// <param name="propertyToChange">The property to change [enabled, visible].</param>
        /// <param name="state">The state of the property [true, false]</param>
        public static void ChangeState(Form formName, List<Control> controlList, string propertyToChange, bool state)
        {
            foreach (Control control in controlList)
            {
                var test = control.GetType().ToString();

                if (allowStateChange.Contains(control.GetType().Name.ToString()))
                {
                    SetState(control, propertyToChange, state);
                }
            }
        }

        /// <summary>Swap the state of two controls.</summary>
        /// <param name="formName"></param>
        /// <param name="controlName1"></param>
        /// <param name="controlName2"></param>
        /// <param name="propertyToChange"></param>
        /// <remarks>In order for this to work, the form needs to start with different controls visible/enabled/etc.</remarks>
        public static void SwapState(Form formName, Control controlName1, Control controlName2, string propertyToChange)
        {
            // These need to be set, othewise the swap won't work.
            var controlState1 = Convert.ToBoolean(controlName1.GetType().GetProperty(propertyToChange).GetValue(controlName1));
            var controlState2 = Convert.ToBoolean(controlName2.GetType().GetProperty(propertyToChange).GetValue(controlName2));

            SetState(controlName1, propertyToChange, controlState2);
            SetState(controlName2, propertyToChange, controlState1);
        }

        /// <summary>Toggle the state of a control.</summary>
        /// <param name="formName"></param>
        /// <param name="controlName"></param>
        /// <param name="propertyToChange"></param>
        public static void ToggleState(Form formName, Control controlName, string propertyToChange)
        {
            SetState(controlName, propertyToChange, !Convert.ToBoolean(controlName.GetType().GetProperty(propertyToChange).GetValue(controlName)));
        }

        /// <summary>Does the actual changing of the control property.</summary>
        /// <param name="controlName">The name of the control property to change.</param>
        /// <param name="propertyToChange">The name of the property to change.</param>
        /// <param name="state">The state to cha</param>
        ///
        private static void SetState(Control controlName, string propertyToChange, bool state)
        {
            controlName.GetType().GetProperty(propertyToChange).SetValue(controlName, state);
        }

        /// <summary>Change a property of a control on a form.</summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="controlNameOrType">The name or type of the control.</param>
        /// <param name="propertyToChange">The property to change [enabled, visible].</param>
        /// <param name="state">The state of the property [true, false]</param>
        public static void Paint(Form formName, Control controlNameOrType, string backgroundColor, string foregroundColor)
        {
            if (formName.Controls.Contains(controlNameOrType))
            {
                SetPaint(formName, controlNameOrType, backgroundColor, foregroundColor);
            }
            else
            {
                foreach (Control control in formName.Controls)
                {
                    if (allowPaintChange.Contains(controlNameOrType.GetType().ToString()))
                    {
                        SetPaint(formName, controlNameOrType, backgroundColor, foregroundColor);
                    }
                }
            }
        }

        /// <summary>Applies a color scheme to single Button on a form.</summary>
        /// <param name="formName">Name of the passed form.</param>
        /// <param name="controlName">The name of the passed Button.</param>
        /// <param name="bg">Background color.</param>
        /// <param name="fg">Foreground color.</param>
        public static void SetPaint(Form formName, Control controlName, string backgroundColor, string foregroundColor)
        {
            controlName.BackColor = Color.FromName(backgroundColor);
            controlName.ForeColor = Color.FromName(foregroundColor);
        }

        public class Btn
        {
            /// <summary>Creates an array of Button controls.</summary>
            /// <param name="buttonList"></param>
            /// <param name="yPos"></param>
            /// <param name="xPos"></param>
            /// <param name="xInc"></param>
            /// <param name="yInc"></param>
            /// <param name="ctrlPrefix"></param>
            /// <param name="mv"></param>
            /// <returns>An array of Buttons.</returns>
            public static Button[] BuildArray(List<string> buttonList, int xPos, int yPos, int xInc, int yInc, string ctrlPrefix, string mv)
            {
                var element = 0;
                var noSpacName = string.Empty;
                Button[] buttonArray = new Button[buttonList.Count];

                foreach (var button in buttonList)
                {
                    noSpacName = AOString.Remove(button, "space", null);
                    buttonArray[element] = new Button();
                    buttonArray[element].Text = button;
                    buttonArray[element].Name = ctrlPrefix + noSpacName;
                    buttonArray[element].Location = new Point(xPos, yPos);
                    element++;

                    if (mv == "vert")
                    {
                        yPos += yInc;
                    }
                    else if (mv == "horz")
                    {
                        xPos += yInc;
                    }
                }

                return buttonArray;
            }

            /// <summary>Create a single button control.</summary>
            /// <param name="name">Button name.</param>
            /// <param name="buttonHeight">Button height.</param>
            /// <param name="buttonWidth">Button width.</param>
            /// <param name="xPos">Button x-axis location.</param>
            /// <param name="yPos">Button y-axis location.</param>
            /// <param name="border">Button borderstyle [?].</param>
            /// <returns>A Button control.</returns>
            public static Button Create(string buttonName, int buttonHeight, int buttonWidth, int yPos, int xPos, string border)
            {
                Button wrkButton = new Button();
                wrkButton.Name = buttonName;
                wrkButton.Height = buttonHeight;
                wrkButton.Width = buttonWidth;
                wrkButton.Location = new Point(xPos, yPos);

                switch (border)
                {
                    default:
                        break;
                }

                return wrkButton;
            }
        }

        public class Cbx
        {
            /// <summary>Creates an array of CheckBox controls.</summary>
            /// <param name="checkboxList"></param>
            /// <param name="startX"></param>
            /// <param name="yPos"></param>
            /// <param name="xPos"></param>
            /// <param name="yInc"></param>
            /// <param name="ctrlPrefix"></param>
            /// <param name="mv"></param>
            /// <returns>An array of CheckBoxes.</returns>
            public static System.Windows.Forms.CheckBox[] BuildArray(List<string> checkboxList, int xPos, int yPos, int xInc, int yInc, string ctrlPrefix, string mv)
            {
                var element = 0;
                var noSpaceName = string.Empty;
                CheckBox[] checkboxArray = new CheckBox[checkboxList.Count];

                foreach (var checkbox in checkboxList)
                {
                    noSpaceName = AOString.Remove(checkbox, "spc", null);
                    checkboxArray[element] = new System.Windows.Forms.CheckBox();
                    checkboxArray[element].Text = checkbox;
                    checkboxArray[element].Name = ctrlPrefix + noSpaceName;
                    checkboxArray[element].Location = new Point(xPos, yPos);
                    element++;

                    if (mv == "vert")
                    {
                        yPos += yInc;
                    }
                    else if (mv == "horz")
                    {
                        xPos += yInc;
                    }
                }

                return checkboxArray;
            }
        }

        public class Flp
        {
            /// <summary>Create a FlowLayoutPanel.</summary>
            /// <param name="flpName">Panel name.</param>
            /// <param name="hgt">Panel height.</param>
            /// <param name="wdth">Panel width.</param>
            /// <param name="xLoc">Panel x-axis location.</param>
            /// <param name="yLoc">Panel y-axis location.</param>
            /// <param name="border">Panel borderstyle ["fixed3D", "fixedSingle", "none"]</param>
            /// <returns>A panel.</returns>
            public static FlowLayoutPanel Create(string flpName, int hgt, int wdth, int xLoc, int yLoc, string border)
            {
                FlowLayoutPanel wrkFlp = new FlowLayoutPanel();
                wrkFlp.Name = flpName;
                wrkFlp.Height = hgt;
                wrkFlp.Width = wdth;
                wrkFlp.Location = new Point(xLoc, yLoc);

                switch (border)
                {
                    case "3D":
                        wrkFlp.BorderStyle = BorderStyle.Fixed3D;
                        break;

                    case "single":
                        wrkFlp.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case "none":
                        wrkFlp.BorderStyle = BorderStyle.None;
                        break;

                    default:
                        break;
                }

                return wrkFlp;
            }
        }

        public class Lbl
        {
            /// <summary>Creates an array of checkbox controls.</summary>
            /// <param name="labelList"></param>
            /// <param name="startX"></param>
            /// <param name="yPos"></param>
            /// <param name="xPos"></param>
            /// <param name="yInc"></param>
            /// <param name="ctrlPrefix"></param>
            /// <param name="mv"></param>
            /// <returns>An array of checkboxes.</returns>
            public static System.Windows.Forms.Label[] BuildArray(List<string> labelList, int yPos, int xPos, int yInc, int xInc, string ctrlPrefix, string mv, int cWdth, int cHght)
            {
                var ele = 0;
                var noSpcNm = string.Empty;
                var yPosReset = yPos;
                Label[] labelArray = new Label[labelList.Count];

                foreach (var lbl in labelList)
                {
                    noSpcNm = AOString.Remove(lbl, "spc", null);
                    labelArray[ele] = new System.Windows.Forms.Label();
                    labelArray[ele].Text = lbl;
                    labelArray[ele].Name = ctrlPrefix + noSpcNm;

                    if (cWdth != 0)
                    {
                        if (yPos + yInc > cHght)
                        {
                            yPos = yPosReset;
                            xPos += cWdth;
                        }
                    }

                    labelArray[ele].Location = new Point(xPos, yPos);
                    ele++;

                    if (mv == "vert")
                    {
                        yPos += yInc;
                    }
                    else if (mv == "horz")
                    {
                        xPos += xInc;
                    }
                }
                return labelArray;
            }

            /// <summary>Applies a color scheme to all labels on a form.</summary>
            /// <param name="formName">Name of form.</param>
            /// <param name="backgroundColor">Background color.</param>
            /// <param name="foregroundColor">Foreground color.</param>
            public static void PaintAll(Form formName, string backgroundColor, string foregroundColor)
            {
                foreach (Control control in formName.Controls.OfType<System.Windows.Forms.Label>())
                {
                    control.BackColor = Color.FromName(backgroundColor);
                    control.ForeColor = Color.FromName(foregroundColor);
                }
            }
        }

        /// <summary>Do things with panels.</summary>
        public class Pnl
        {
            /// <summary>Create a panel.</summary>
            /// <param name="panelName">Panel name.</param>
            /// <param name="pnlHght">Panel height.</param>
            /// <param name="pnlWdth">Panel width.</param>
            /// <param name="xPos">Panel x-axis location.</param>
            /// <param name="yPos">Panel y-axis location.</param>
            /// <param name="border">Panel borderstyle ("fixed3D", "fixedSingle", "none")</param>
            /// <returns>A panel.</returns>
            public static Panel Create(string panelName, int pnlHght, int pnlWdth, int yPos, int xPos, string border)
            {
                Panel wrkPanel = new Panel();
                wrkPanel.Name = panelName;
                wrkPanel.Height = pnlHght;
                wrkPanel.Width = pnlWdth;
                wrkPanel.Location = new Point(xPos, yPos);

                switch (border)
                {
                    case "fixed3D":
                        wrkPanel.BorderStyle = BorderStyle.Fixed3D;
                        break;

                    case "fixedSingle":
                        wrkPanel.BorderStyle = BorderStyle.FixedSingle;
                        break;

                    case "none":
                        wrkPanel.BorderStyle = BorderStyle.None;
                        break;

                    default:
                        break;
                }

                return wrkPanel;
            }
        }

        public class PictureBox
        {
        }

        public class Tbx
        {
            /// <summary>Create a single button control.</summary>
            /// <param name="textboxName">Button name.</param>
            /// <param name="height">Button height.</param>
            /// <param name="width">Button width.</param>
            /// <param name="xPos">Button x-axis location.</param>
            /// <param name="yPos">Button y-axis location.</param>
            /// <param name="border">Button borderstyle [?].</param>
            /// <returns>A Button control.</returns>
            public static TextBox Create(string textboxName, int height, int width, int yPos, int xPos, string border)
            {
                TextBox wrkTextBox = new TextBox();
                wrkTextBox.Name = textboxName;
                wrkTextBox.Height = height;
                wrkTextBox.Width = width;
                wrkTextBox.Location = new Point(xPos, yPos);

                switch (border)
                {
                    default:
                        break;
                }

                return wrkTextBox;
            }
        }
    }
}