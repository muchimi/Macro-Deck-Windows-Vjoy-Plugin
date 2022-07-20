using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Automation;
using GregsStack.InputSimulatorStandard;
using muchimi.vjoy;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Events;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Profiles;
using SuchByte.MacroDeck.Variables;
using SuchByte.MacroDeck.Variables.Plugin;
using Timer = System.Timers.Timer;

namespace muchimi_vjoy
{

    public enum VJoyAxis
    {
        AXIS_X,
        AXIS_Y,
        AXIS_Z,
        AXIS_RX,
        AXIS_RY,
        AXIS_RZ,
        AXIS_SL0,
        AXIS_SL1,
        AXIS_HAT0,
        AXIS_HAT1,
        AXIS_HAT2,
        AXIS_HAT3,
    }

    public static class PluginInstance
    {
        public static Main Main;
    }


    public enum EPulseType
    {
        Button,
        Axis,
    }

    public enum EActionType
    {
        None,
        Press,
        Release,
        LongPress,
        LongRelease,
    }


    internal class WorkTaskParams
    {
        public ConfigData data;
        public CancellationToken token;

    }



    public class Main : MacroDeckPlugin
    {

        public static Main Instance;
        public Dictionary<string, Timer> _Timers;


        Timer GetNewTimer(ConfigData data)
        {
        
            _Timers[data.ActionId] = new Timer();
            return _Timers[data.ActionId];
        }

        Timer GetTimer(ConfigData data)
        {
            if (!_Timers.ContainsKey(data.ActionId))
                return null;
            return _Timers[data.ActionId];
        }

        void RemoveTimer(ConfigData data)
        {
            if (!_Timers.ContainsKey(data.ActionId))
                return;
            _Timers[data.ActionId].Dispose();
            _Timers[data.ActionId] = null;
        }


        public Main()
        {

            Instance = this;
            PluginInstance.Main = this;

            this.Vjoy = new VjoyInstance();
            this.InputSim = new InputSimulator();

            _Timers = new Dictionary<string, Timer>();

        }



        // Optional; If your plugin can be configured, set to "true". It'll make the "Configure" button appear in the package manager.
        public override bool CanConfigure => false;

        // Gets called when the plugin is loaded
        public override void Enable()
        {
            this.Actions = new List<PluginAction>{
                // add the instances of your actions here
                new VjoyAction(),
                new InputAction(),
            };


        }
        

        public VjoyInstance Vjoy;

        public InputSimulator InputSim;

        //// Optional; Gets called when the user clicks on the "Configure" button in the package manager; If CanConfigure is not set to true, you don't need to add this
        //public override void OpenConfigurator()
        //{
        //    // Open your configuration form here
        //    using (var configurator = new Configurator())
        //    {
        //        configurator.ShowDialog();
        //    }
        //}




        public void RunAction(ConfigData data, ActionButton actionButton, EActionType actionType)
        {
            // determine what work we need to do
            if (data.ButtonEnabled)
                RunButtonAction(data, actionButton, actionType);
            if (data.AxisEnabled)
                RunAxisAction(data, actionButton, actionType);
        }

        void RunButtonAction(ConfigData data, ActionButton actionButton, EActionType actionType)
        {
            if (data.ButtonEnabled)
            {
                var vjoy = Main.Instance.Vjoy;
                var deviceId = data.DeviceNumber;
                var buttonNumber = data.ButtonNumber;
                var pulseInterval = data.ButtonPulseInterval;
                Timer timer;

                switch (data.ButtonMode)
                {
                    case EButtonMode.on:
                        vjoy.Press(deviceId, buttonNumber);
                        break;
                    case EButtonMode.off:
                        timer = GetTimer(data);
                        if (timer == null)
                        {
                            // only release if no existing pulsed timer in progress
                            vjoy.Release(deviceId, buttonNumber);
                        }

                        break;
                    case EButtonMode.pulse:

                        vjoy.Press(deviceId, buttonNumber);
                        timer = GetTimer(data);
                        if (timer != null)
                        {
                            timer.Stop();
                            RemoveTimer(data);
                        }

                        timer = GetNewTimer(data);
                        timer.Interval = data.ButtonPulseInterval;
                        timer.Elapsed += (s, e) =>
                        {
                            vjoy.Release(deviceId, buttonNumber);
                            RemoveTimer(data);
                        };
                        timer.Start();
                        
                        
                        break;
                }
            }
        }



        /// <summary>
        /// bumps a relative axis by a set interval
        /// </summary>
        /// <param name="data"></param>
        void BumpAxis(ConfigData data)
        {
            var vjoy = Main.Instance.Vjoy;

            //MacroDeckLogger.Info(Main.Instance,"BumpAxis()");
            
            vjoy.GetAxis(data.DeviceNumber, data.Axis, out var value, out _, out _);
            value += data.AxisValue;
            if (value < -1.0)
            {
                value = -1.0;
            }
            else if (value > 1.0)
            {
                value = 1.0;
            }

            vjoy.SetAxis(data.DeviceNumber, data.Axis, value);
        }


        /// <summary>
            /// runs an axis change request
            /// </summary>
            /// <param name="data"></param>
        void RunAxisAction(ConfigData data, ActionButton actionButton, EActionType actionType)
        {

            var vjoy = Main.Instance.Vjoy;
            var deviceId = data.DeviceNumber;
            
            // stop any active axis tasks for this action


            if (data.AxisMode == EAxisMode.absolute || vjoy.IsAxisHat(data.Axis))
            {
                // absolute set for axes if absolute set or the item is a hat
                vjoy.SetAxis(deviceId, data.Axis, data.AxisValue);
            }

            else
            {
                // pulse once only
                BumpAxis(data);
            }

        }



    }







    public class VjoyAction : PluginAction
    {
        // The name of the action
        public override string Name => "Set VJOY button action";

        // A short description what the action can do
        public override string Description => "Sets a VJOY button";

        // Optional; Add if this action can be configured. This will make the ActionConfigurator calling GetActionConfigurator();
        public override bool CanConfigure => true;




        // Optional; Add if you added CanConfigure; Gets called when the action can be configured and the action got selected in the ActionSelector. You need to return a user control with the "ActionConfigControl" class as base class
        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new VjoyActionConfigurator(this, actionConfigurator);
        }



        // Gets called when the action is triggered by a button press or an event
        public override void Trigger(string clientId, ActionButton actionButton)
        {
            MacroDeckLogger.Info(Main.Instance, "trigger received");
            var data = new ConfigData();
            data.LoadVjoyConfig(this);

            EActionType actionType = EActionType.None;

            if (actionButton != null)
            {
                if (actionButton.Actions.Contains(this))
                    actionType = EActionType.Press;
                else if (actionButton.ActionsRelease.Contains(this))
                    actionType = EActionType.Release;
                else if (actionButton.ActionsLongPress.Contains(this))
                    actionType = EActionType.LongPress;
                else if (actionButton.ActionsLongPressRelease.Contains(this))
                    actionType = EActionType.LongRelease;


                MacroDeckLogger.Info(Main.Instance, $"state: {actionButton.State}  derived action: {actionType.ToString()}");
                Main.Instance.RunAction(data, actionButton, actionType);
            }
            else
            {
                MacroDeckLogger.Info(Main.Instance, $"state: NO ACTION BUTTON");
                Main.Instance.RunAction(data, actionButton, actionType);
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
        
        
    }

    public partial class VjoyActionConfigurator 
    {
        private VjoyAction vjoyAction;
        private ConfigData data = new ConfigData();


        public override bool OnActionSave()
        {
            return data.SaveVjoyConfig(this.vjoyAction);
        }

        private void LoadConfig()
        {
            // loads the configuration for this action

            data.LoadVjoyConfig(this.vjoyAction);

            var vjoy = Main.Instance.Vjoy;

            cb_button.Checked = data.ButtonEnabled;
            cb_axis.Checked = data.AxisEnabled;

            tb_button_number.Text = data.ButtonNumber.ToString();
            tb_device_number.Text = data.DeviceNumber.ToString();
            tb_pulse_interval.Text = data.ButtonPulseInterval.ToString();


            switch (data.ButtonMode)
            {
                case EButtonMode.on:
                    rb_button_on.Checked = true;
                    break;
                case EButtonMode.off:
                    rb_button_off.Checked = true;
                    break;
                case EButtonMode.pulse:
                    rb_button_pulse.Checked = true;
                    break;

            }

            // setup axes
            cb_axis_selector.Items.Clear();
            cb_axis_selector.Items.AddRange(Enum.GetNames(typeof(VJoyAxis)));

            // move hat panel to axis panel to superimpose and hide one or the other depending on the axis selected
            var isHat = vjoy.IsAxisHat(data.Axis);
            pan_axis.Visible = !isHat;
            pan_hat.Visible = isHat;
            pan_hat.Left = pan_axis.Left;
            pan_hat.Top = pan_axis.Top;
            SetHatControls(data.AxisHatValue);


            cb_axis_selector.SelectedItem = data.AxisName;
            tb_axis_value.Text = data.AxisValue.ToString();

            switch(data.AxisMode)
            {
                
                case EAxisMode.absolute:
                    rb_absolute.Checked = true;
                    break;
                case EAxisMode.relative:
                    rb_relative.Checked = true;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            tb_axis_interval.Text = data.AxisPulseInterval.ToString();

            lbl_message.Text = "";
        }

        void SetHatControls(int value)
        {
            int x;
            int y;
            var vjoy = Main.Instance.Vjoy;
            vjoy.HatCoords(value,out x, out y);
            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 0:
                            rb_00.Checked = true;
                            break;
                        case 1:
                            rb_01.Checked = true;
                            break;
                        case -1:
                            rb_0m1.Checked = true;
                            break;
                    }

                    break;
                case -1:
                    switch (y)
                    {
                        case 0:
                            rb_m10.Checked = true;
                            break;
                        case 1:
                            rb_m11.Checked = true;
                            break;
                        case -1:
                            rb_m1m1.Checked = true;
                            break;
                    }

                    break;
                case 1:
                    switch (y)
                    {
                        case 0:
                            rb_10.Checked = true;
                            break;
                        case 1:
                            rb_11.Checked = true;
                            break;
                        case -1:
                            rb_1m1.Checked = true;
                            break;
                    }

                    break;
            }
        }



    }




}