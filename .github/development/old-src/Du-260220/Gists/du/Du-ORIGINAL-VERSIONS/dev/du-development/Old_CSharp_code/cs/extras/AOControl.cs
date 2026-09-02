/* A class for AO.cs that does various things with controls.
 * v00.53.02.161218
 * http://aprettycoolprogram.com/ao
 */

/* This class is somewhat complex, and pretty long. I've used nested classes and regions to help with the organization
 * and readability, but it's definatly not "best practice" code!
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AO
{
    /// <summary>
    /// Does various things with controls.
    /// </summary>
    public partial class AOControl
    {
        /// <summary>
        /// Main controls
        /// </summary>
        /// <remarks>
        /// [*] There are three list of controls:
        ///         allowAllChanges  - all allowed changes can be applied to these controls
        ///         allowStateChange - only state changes can be applied to these controls, just add controls to the list
        ///         allowPaintChange - only paint changes can be applied to these controls, just add controls to the list
        /// </remarks>

        private static List<string> allowAllChanges = new List<string>() { "Button", "CheckBox", "ComboBox", "Label", "TabControl" };
        private static List<string> allowStateChange = allowAllChanges;
        private static List<string> allowPaintChange = allowAllChanges;

        /// <summary>
        /// Change a state of all of a single control type on a form.
        /// </summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="controlType">Type of control ("Button","TextBox").</param>
        /// <param name="excludedControls">Controls that are excluded.</param>
        /// <param name="stateToChange">The state to change ("Enabled","Visible").</param>
        /// <param name="state">State of the property ("true","false").</param>
        /// <remarks>
        /// [1] Loop through each control in the form, and if the control is the type we want to change, but it's not
        ///     in the excluded list, set the state of the control.
        /// </remarks>
        public static void ChangeState(Form formName, Control controlType, List<Control> excludedControls, string stateToChange, bool state)
        {
            var controlTypeName = controlType.GetType().Name.ToString();

            foreach (Control control in formName.Controls)                                                              // [1]
            {
                if (allowStateChange.Contains(controlTypeName) && !excludedControls.Contains(control))
                {
                    SetState(controlType, stateToChange, state);
                }
            }
        }

        /// <summary>
        /// Change a state of all of a single control type in another control.
        /// </summary>
        /// <param name="controlName">Name of the form. (i.e. "pnlContainerForStuff").</param>
        /// <param name="controlType">Type of control ("Button","TextBox").</param>
        /// <param name="excludedControls">Controls that are excluded.</param>
        /// <param name="stateToChange">The state to change ("Enabled","Visible").</param>
        /// <param name="state">State of the property ("true","false").</param>
        /// <remarks>
        /// [1] Loop through each control in the control, and if the control is the type we want to change, but it's not in the excluded list,
        ///     set the state of the control.
        /// </remarks>
        public static void ChangeState(Control controlName, Control controlType, List<Control> excludedControls, string stateToChange, bool state)
        {
            var controlTypeName = controlType.GetType().Name.ToString();

            foreach (Control control in controlName.Controls)                                                           // [1]
            {
                if ((allowStateChange.Contains(controlTypeName)) && (!excludedControls.Contains(control)))
                {
                    SetState(controlType, stateToChange, state);
                }
            }
        }

        /// <summary>
        /// Change a state of a a list of controls.
        /// </summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="controlType">Type of control ("Button","TextBox").</param>
        /// <param name="stateToChange">The state to change ("Enabled","Visible").</param>
        /// <param name="state">State of the property ("true","false").</param>
        public static void ChangeState(Form formName, List<Control> controlList, string stateToChange, bool state)
        {
            foreach (Control control in controlList)
            {
                if (allowStateChange.Contains(control.GetType().Name.ToString()))
                {
                    SetState(control, stateToChange, state);
                }
            }
        }

        /// <summary>
        /// Swap the state of two controls on a form.
        /// </summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="firstControl">Name of the first control.</param>
        /// <param name="secondControl">Name of the second control.</param>
        /// <param name="stateToSwap">The state to swap ("Enabled","Visible").</param>
        /// <remarks>
        /// [*] In order for this to work at all, we need to store the value of each controls state. In order for this
        ///     to work correctly, the state values must be set prior to calling this method.The easiest way to do this
        ///     is to make sure the states are set when the form is initialized.
        /// </remarks>
        public static void SwapState(Form formName, Control firstControl, Control secondControl, string stateToSwap)
        {
            var firstControlOriginalState = Convert.ToBoolean(firstControl.GetType().GetProperty(stateToSwap).GetValue(firstControl));
            var secondControlOriginalState = Convert.ToBoolean(secondControl.GetType().GetProperty(stateToSwap).GetValue(secondControl));

            SetState(firstControl, stateToSwap, secondControlOriginalState);
            SetState(secondControl, stateToSwap, firstControlOriginalState);
        }

        /// <summary>
        /// Toggle the state of a control.
        /// </summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="controlName">NAme of control.</param>
        /// <param name="stateToChange">The state to change ("Enabled","Visible").</param>
        /// <remarks>
        /// PUT SOME HERE!
        /// </remarks>
        public static void ToggleState(Form formName, Control controlName, string stateToChange)
        {
            SetState(controlName, stateToChange, !Convert.ToBoolean(controlName.GetType().GetProperty(stateToChange).GetValue(controlName)));
        }

        /// <summary>
        /// Does the actual changing of the control property.
        /// </summary>
        /// <param name="controlName">NAme of control.</param>
        /// <param name="stateToChange">The state to change ("Enabled","Visible").</param>
        /// <param name="state"></param>
        /// <remarks>
        /// PUT SOME HERE!
        /// </remarks>
        private static void SetState(Control controlName, string stateToChange, bool state)
        {
            controlName.GetType().GetProperty(stateToChange).SetValue(controlName, state);
        }

        /// <summary>
        /// Paint a control on a form.
        /// </summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="controlNameOrType">Either the name or type of the control (i.e. "Button","btnThisButton").</param>
        /// <param name="backgroundColor">Background color (i.e. "Red").</param>
        /// <param name="foregroundColor">Foreground color (i.e. "White").</param>
        /// <remarks>
        /// PUT SOME HERE!
        /// </remarks>
        public static void Paint(Form formName, Control controlNameOrType, string foregroundColor, string backgroundColor)
        {
            if (formName.Contains(controlNameOrType))
            {
                SetPaint(formName, controlNameOrType, foregroundColor, backgroundColor);
            }
            else
            {
                foreach (Control control in formName.Controls)
                {
                    if (allowPaintChange.Contains(controlNameOrType.GetType().ToString()))  // Does this even work?
                    {
                        SetPaint(formName, controlNameOrType, foregroundColor, backgroundColor);
                    }
                }
            }
        }

        /// <summary>
        /// Applies a color scheme to single Button on a form.
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="controlName"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        /// <remarks>
        /// [*] USE AOCONTROL.PAINT
        /// </remarks>
        public static void SetPaint(Form formName, Control controlName, string foregroundColor, string backgroundColor)
        {
            controlName.ForeColor = Color.FromName(foregroundColor);
            controlName.BackColor = Color.FromName(backgroundColor);
        }
    }
}