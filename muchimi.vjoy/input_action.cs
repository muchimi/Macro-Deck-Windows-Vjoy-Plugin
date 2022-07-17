using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using Timer = System.Timers.Timer;

namespace muchimi_vjoy
{
    public class InputAction : PluginAction
    {
        // The name of the action
        public override string Name => "Input (keyboard and mouse) action";

        // A short description what the action can do
        public override string Description => "Sends keyboard or mouse output";

        // Optional; Add if this action can be configured. This will make the ActionConfigurator calling GetActionConfigurator();
        public override bool CanConfigure => true;


        // Optional; Add if you added CanConfigure; Gets called when the action can be configured and the action got selected in the ActionSelector. You need to return a user control with the "ActionConfigControl" class as base class
        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new InputActionConfigurator(this, actionConfigurator);
        }


        // Gets called when the action is triggered by a button press or an event
        public override void Trigger(string clientId, ActionButton actionButton)
        {
            MacroDeckLogger.Info(Main.Instance, "trigger received");
            var data = new ConfigData();
            data.LoadInputConfig(this);

            if (data.KeyboardEnabled)
            {
                var sim = Main.Instance.InputSim;

                var sequence = data.Sequence;
                var reversedSequence = new List<VirtualKeyCode>(sequence);
                reversedSequence.Reverse();

                switch (data.KeyAction)
                {
                    case EKeyAction.normal:
                        foreach (VirtualKeyCode vc in sequence)
                        {
                            sim.Keyboard.KeyDown(vc);
                        }

                        Timer timer = new Timer(data.KeyInterval);
                        timer.Elapsed += (sender, args) =>
                        {
                            foreach (VirtualKeyCode vc in reversedSequence)
                            {
                                sim.Keyboard.KeyUp(vc);
                            }

                            timer.Dispose();
                        };
                        timer.Start();

                        break;
                    case EKeyAction.press:
                        // key press only
                        foreach (VirtualKeyCode vc in sequence)
                        {
                            sim.Keyboard.KeyDown(vc);
                        }

                        break;
                    case EKeyAction.release:
                        // key release only
                        foreach (VirtualKeyCode vc in reversedSequence)
                        {
                            sim.Keyboard.KeyUp(vc);
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }


        }
        
    }



    //// Optional; Gets called when the action button gets deleted
        //public override void OnActionButtonDelete()
        //{

        //}

        //// Optional; Gets called when the action button is loaded
        //public override void OnActionButtonLoaded()
        //{

        //}

        public partial class InputActionConfigurator
        {

            private InputAction inputAction;
            private ConfigData data = new ConfigData();


            public override bool OnActionSave()
            {
                return data.SaveInputConfig(this.inputAction);
            }

            private void LoadConfig()
            {
                // loads the configuration for this action


                data.LoadInputConfig(this.inputAction);

                chk_keyboard_enabled.Checked = data.KeyboardEnabled;

                tb_interval.Text = data.KeyInterval.ToString();
                cb_key.Items.Clear();
                cb_key.Items.AddRange(Enum.GetNames(typeof(VirtualKeyCode)));
                cb_key.SelectedItem = data.KeyCode.ToString();


                cb_combo_key.Items.Clear();
                cb_combo_key.Items.AddRange(Enum.GetNames(typeof(VirtualKeyCode)));
                cb_combo_key.SelectedItem = data.ComboKeyCode.ToString();
                

                chk_combo_key.Checked = data.UseCombo;

                switch (data.ShiftMode)
                {
                    case EModifierMode.none:
                        rb_shift_none.Checked = true;
                        break;
                    case EModifierMode.left:
                        rb_shift_left.Checked = true;
                        break;
                    case EModifierMode.right:
                        rb_shift_right.Checked = true;
                        break;
                }

                switch (data.CtrlMode)
                {
                    case EModifierMode.none:
                        rb_ctrl_none.Checked = true;
                        break;
                    case EModifierMode.left:
                        rb_ctrl_left.Checked = true;
                        break;
                    case EModifierMode.right:
                        rb_ctrl_right.Checked = true;
                        break;
                }


                switch (data.AltMode)
                {
                    case EModifierMode.none:
                        rb_alt_none.Checked = true;
                        break;
                    case EModifierMode.left:
                        rb_alt_left.Checked = true;
                        break;
                    case EModifierMode.right:
                        rb_alt_right.Checked = true;
                        break;
                }

                switch (data.KeyAction)
                {
                    case EKeyAction.normal:
                        rb_key_normal.Checked = true;
                        break;
                    case EKeyAction.press:
                        rb_keydown.Checked = true;
                        break;
                    case EKeyAction.release:
                        rb_keyup.Checked = true;
                        break;

                }

                tb_interval.Text = data.KeyInterval.ToString();

                lbl_message.Text = "";

            }


        }

    }


