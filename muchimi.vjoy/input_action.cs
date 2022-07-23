using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using GregsStack.InputSimulatorStandard.Native;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;

using SuchByte.MacroDeck.Variables;
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

            var app_name = data.TargetProcess; //"Star Citizen";


            if (data.KeyboardEnabled)
            {
                var sim = Main.Instance.InputSim;

                var sequence = data.Sequence;
                var reversedSequence = new List<KeyPair>(sequence);
                reversedSequence.Reverse();

                if (string.IsNullOrEmpty(app_name))
                {
                    MacroDeckLogger.Info(Main.Instance, "error: unable to set focus");
                    return;
                }

                Main.ActivateApp(app_name);

                switch (data.KeyAction)
                {
                    case EKeyAction.normal:
                        foreach (KeyPair kp in sequence)
                        {
                            sim.Keyboard.KeyDown(kp.key, kp.is_extended);
                        }

                        Timer timer = new Timer(data.KeyInterval);
                        timer.Elapsed += (sender, args) =>
                        {
                            foreach (KeyPair kp in reversedSequence)
                            {
                                sim.Keyboard.KeyUp(kp.key, kp.is_extended);
                            }

                            timer.Dispose();
                        };
                        timer.Start();

                        break;
                    case EKeyAction.press:
                        // key press only
                        foreach (var kp in sequence)
                        {
                            sim.Keyboard.KeyDown(kp.key, kp.is_extended);
                        }

                        break;
                    case EKeyAction.release:
                        // key release only
                        foreach (var kp in reversedSequence)
                        {
                            sim.Keyboard.KeyUp(kp.key, kp.is_extended);
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }


        }
    }





}


