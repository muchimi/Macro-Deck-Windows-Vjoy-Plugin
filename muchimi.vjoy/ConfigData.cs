using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using GregsStack.InputSimulatorStandard.Native;
using Newtonsoft.Json.Linq;

namespace muchimi_vjoy
{

    public enum EButtonMode
    {
        none,
        pulse,
        on,
        off,
    }


    public enum EAxisMode
    {
        none,
        absolute,
        relative,
        pulse,
    }

    public enum EModifierMode
    {
        none,  // no modifier
        left,  // left modifier (or default)
        right, // right modifier
    }

    public enum EKeyAction
    {
        normal, // press and release 
        press, // press only (keydown)
        release // release only (keyup)
    }

    public partial class ConfigData
    {

        // common items
        public const string ACTION_ID = "action_id";

        // vjoy action config data 
        public const string BUTTON_NUMBER = "button_number";
        public const string DEVICE_NUMBER = "device_number";
        public const string BUTTON_MODE = "button_mode";
        public const string BUTTON_PULSE_INTERVAL = "pulse_interval";
        public const string BUTTON_ENABLED = "button_enabled";

        public const string AXIS_MODE = "axis_mode";
        public const string AXIS_NAME = "axis_name";
        public const string AXIS_VALUE = "axis_value";
        public const string AXIS_HATVALUE = "axis_hat_value";
        public const string AXIS_ENABLED = "axis_enabled";
        public const string AXIS_PULSE_INTERVAL = "axis_pulse_interval";
        
        public const string TRACK_STATE = "track_state";


        // keyboard/mouse config data
        public const string KEYBOARD_ENABLED = "keyboard_enabled";
        public const string MOUSE_ENABLED = "mouse_enabled";
        public const string VIRTUAL_KEY = "virtual_key";
        public const string KEY_ACTION = "key_action";
        public const string SHIFT_MODE = "shift_mode";
        public const string CTRL_MODE = "ctrl_mode";
        public const string ALT_MODE = "alt_mode";
        public const string KEY_INTERVAL = "key_interval";
        public const string MOUSE_BUTTON = "mouse_button";
        public const string MOUSE_X = "mouse_x";
        public const string MOUSE_Y = "mouse_x";
        public const string MOUSE_BUTTON_ENABLED = "mouse_button_enabled";
        public const string MOUSE_MOVE_ENABLED = "mouse_move_enabled";
        public const string COMBO_VIRTUAL_KEY = "combo_key";
        public const string USE_COMBO = "use_combo";
        public const string TARGET_PROCESS = "target_process";



        /// <summary>
        /// the target process to send a key to - if not specified sends to the last active process
        /// </summary>
        public string TargetProcess { get; set; }


        public string ActionId { get; set; }


        public bool TrackState { get; set; }

        public EButtonMode ButtonMode { get; set; }

        public EAxisMode AxisMode { get; set; }


        public uint ButtonNumber { get; set; }

        public uint DeviceNumber { get; set; }

        public int ButtonPulseInterval { get; set; }

        public int AxisPulseInterval { get; set; }

        public VJoyAxis Axis { get; set; }

        public string AxisName => Axis.ToString();

        public double AxisValue { get; set; }   // range is 0x1-0x8000  (1 to 32768) mapped to -1.0 to +1.0 as with Gremlin

        public int AxisHatValue { get; set; }

        public bool ButtonEnabled { get; set; }
        public bool AxisEnabled { get; set; }


        // keyboard/mouse properties

        public VirtualKeyCode KeyCode { get; set; }
        public VirtualKeyCode ComboKeyCode { get; set; }

        public bool UseCombo { get; set; }

        public bool KeyboardEnabled { get; set;}
        public bool MouseEnabled { get; set;}
        public EModifierMode ShiftMode { get; set;}
        public EModifierMode CtrlMode { get; set; }
        public EModifierMode AltMode { get; set; }
        public int KeyInterval { get; set;}
        public EKeyAction KeyAction { get; set; }

        public MouseButtons MouseButton { get; set; }
        public int MouseX { get; set; }
        public int MouseY { get; set; }
        public bool MouseButtonEnabled { get; set; }
        public bool MouseMoveEnabled { get; set; }

        /// <summary>
        ///  true if key has modifiers
        /// </summary>
        public bool HasModifiers => (CtrlMode != EModifierMode.none || ShiftMode != EModifierMode.none || AltMode != EModifierMode.none);

        public List<VirtualKeyCode> Modifiers
        {
            get
            {
                List<VirtualKeyCode> modifiers = new List<VirtualKeyCode>();
                switch (CtrlMode)
                {
                    case EModifierMode.left:
                        modifiers.Add(VirtualKeyCode.LCONTROL);
                        break;
                    case EModifierMode.right:
                        modifiers.Add(VirtualKeyCode.RCONTROL);
                        break;
                }

                switch (ShiftMode)
                {
                    case EModifierMode.left:
                        modifiers.Add(VirtualKeyCode.LSHIFT);
                        break;
                    case EModifierMode.right:
                        modifiers.Add(VirtualKeyCode.RSHIFT);
                        break;
                }

                switch (AltMode)
                {
                    case EModifierMode.left:
                        modifiers.Add(VirtualKeyCode.LMENU);
                        break;
                    case EModifierMode.right:
                        modifiers.Add(VirtualKeyCode.RMENU);
                        break;
                }

                return modifiers;
            }
        }

        /// <summary>
        /// returns the complete list of virtual keys for this key
        /// </summary>
        public List<VirtualKeyCode> Sequence
        {
            get
            {
                var vlist = Modifiers;
                vlist.Add(KeyCode);
                return vlist;
            }
        }

        /// <summary>
        /// reads a json object into the configuration 
        /// </summary>
        /// <param name="action">the action object</param>
        /// <returns>true on success</returns>
        public bool LoadVjoyConfig(VjoyAction action)
        {
            if (action != null && !string.IsNullOrEmpty(action.Configuration))
            {
                JObject jObject = JObject.Parse(action.Configuration);


                var buttonModeText = "pulse";
                var value = jObject[ConfigData.BUTTON_MODE];
                if (value != null)
                {
                    buttonModeText = value.ToString();
                }


                string buttonNumberText = "1";
                value = jObject[ConfigData.BUTTON_NUMBER];
                if (value != null)
                    buttonNumberText = value.ToString();

                string deviceNumberText = "1";
                value = jObject[ConfigData.DEVICE_NUMBER];
                if (value != null)
                    deviceNumberText = value.ToString();


                string buttonPulseIntervalText = "600";
                value = jObject[ConfigData.BUTTON_PULSE_INTERVAL];
                if (value != null)
                    buttonPulseIntervalText = value.ToString();

                string axisPulseIntervalText = "600";
                value = jObject[ConfigData.AXIS_PULSE_INTERVAL];
                if (value != null)
                    axisPulseIntervalText = value.ToString();



                value = jObject[ConfigData.DEVICE_NUMBER];
                if (value != null)
                    deviceNumberText = value.ToString();

                string buttonEnabledText = "false";
                value = jObject[ConfigData.BUTTON_ENABLED];
                if (value != null)
                    buttonEnabledText = value.ToString();

                var axisModeText = "absolute";
                value = jObject[ConfigData.AXIS_MODE];
                if (value != null)
                {
                    axisModeText = value.ToString();
                }


                string axisEnabledText = "false";
                value = jObject[ConfigData.AXIS_ENABLED];
                if (value != null)
                    axisEnabledText = value.ToString();


                var axisValueText = "0.0";
                value = jObject[ConfigData.AXIS_VALUE];
                if (value != null)
                    axisValueText = value.ToString();

                var axisHatValueText = "-1";
                value = jObject[ConfigData.AXIS_HATVALUE];
                if (value != null)
                    axisHatValueText = value.ToString();

                var axisNameText = "AXIS_X";
                value = jObject[ConfigData.AXIS_NAME];
                if (value != null)
                    axisNameText = value.ToString();

                var idText = Guid.NewGuid().ToString();
                value = jObject[ConfigData.ACTION_ID];
                if (value != null)
                    idText = value.ToString();

                var trackStateText = "false";
                value = jObject[ConfigData.TRACK_STATE];
                if (value != null)
                {
                    trackStateText = value.ToString();
                }



                ButtonNumber = uint.Parse(buttonNumberText);
                DeviceNumber = uint.Parse(deviceNumberText);
                ButtonMode = Enum.TryParse(buttonModeText, out EButtonMode buttonMode) ? buttonMode : EButtonMode.pulse;
                ActionId = idText;
                TrackState = bool.Parse(trackStateText);

                

                ButtonPulseInterval = int.Parse(buttonPulseIntervalText);
                AxisPulseInterval = int.Parse(axisPulseIntervalText);

                ButtonEnabled = bool.Parse(buttonEnabledText);

                AxisEnabled = bool.Parse(axisEnabledText);
                AxisValue = double.Parse(axisValueText);
                AxisHatValue = int.Parse(axisHatValueText);
                Axis = Enum.TryParse(axisNameText, out VJoyAxis axis) ? axis : VJoyAxis.AXIS_X;
                AxisMode = Enum.TryParse(axisModeText, out EAxisMode axisMode) ? axisMode : EAxisMode.absolute;


            }
            else
            {
                // default values
                ButtonNumber = 1;
                DeviceNumber = 1;
                ButtonMode = EButtonMode.pulse;
                ButtonPulseInterval = 600;
                AxisEnabled = false;
                ButtonEnabled = false;
                ActionId = Guid.NewGuid().ToString();
                TrackState = false;

                AxisMode = EAxisMode.absolute;
                AxisValue = 0.0; // center
                Axis = VJoyAxis.AXIS_X;
                AxisHatValue = -1; // center
                TargetProcess = "";


            }

            return true;
        }

        public bool LoadInputConfig(InputAction action)
        {
            if (action != null && !string.IsNullOrEmpty(action.Configuration))
            {
                JObject jObject = JObject.Parse(action.Configuration);

                var keyCodeText = "";
                var value = jObject[ConfigData.VIRTUAL_KEY];
                if (value != null)
                {
                    keyCodeText = value.ToString();
                }

                var keyActionText = "normal";
                value = jObject[ConfigData.KEYBOARD_ENABLED];
                if (value != null)
                {
                    keyActionText = value.ToString();
                }


                var keyboardEnabledText = "false";
                value = jObject[ConfigData.KEYBOARD_ENABLED];
                if (value != null)
                {
                    keyboardEnabledText = value.ToString();
                }

                var mouseEnabledText = "false";
                value = jObject[ConfigData.MOUSE_ENABLED];
                if (value != null)
                {
                    mouseEnabledText = value.ToString();
                }

                var shiftModeText = "none";
                value = jObject[ConfigData.SHIFT_MODE];
                if (value != null)
                {
                    shiftModeText = value.ToString();
                }

                var ctrlModeText = "none";
                value = jObject[ConfigData.CTRL_MODE];
                if (value != null)
                {
                    ctrlModeText = value.ToString();
                }

                var altModeText = "none";
                value = jObject[ConfigData.ALT_MODE];
                if (value != null)
                {
                    altModeText = value.ToString();
                }

                var intervalText = "500";
                value = jObject[ConfigData.KEY_INTERVAL];
                if (value != null)
                {
                    intervalText = value.ToString();
                }

                var mouseButtonEnabledText = "false";
                value = jObject[ConfigData.MOUSE_BUTTON_ENABLED];
                if (value != null)
                {
                    mouseButtonEnabledText = value.ToString();
                }


                var mouseMoveEnabledText = "false";
                value = jObject[ConfigData.MOUSE_MOVE_ENABLED];
                if (value != null)
                {
                    mouseMoveEnabledText = value.ToString();
                }

                var mouseButtonText = "left";
                value = jObject[ConfigData.MOUSE_BUTTON];
                if (value != null)
                {
                    mouseButtonText = value.ToString();
                }

                var mouseXText = "0";
                value = jObject[ConfigData.MOUSE_X];
                if (value != null)
                {
                    mouseXText = value.ToString();
                }
                var mouseYText = "0";
                value = jObject[ConfigData.MOUSE_Y];
                if (value != null)
                {
                    mouseYText = value.ToString();
                }

                var useComboText = "false";
                value = jObject[ConfigData.USE_COMBO];
                if (value != null)
                {
                    useComboText = value.ToString();
                }



                var comboKeyCodeText = "VK_A";
                value = jObject[ConfigData.COMBO_VIRTUAL_KEY];
                if (value != null)
                {
                    comboKeyCodeText = value.ToString();
                }


                var targetProcessText = "";
                value = jObject[ConfigData.TARGET_PROCESS];
                if (value != null)
                {
                    targetProcessText = value.ToString();
                }

                KeyCode = Enum.TryParse(keyCodeText, out VirtualKeyCode keyCode) ? keyCode : VirtualKeyCode.VK_A;
                ComboKeyCode = Enum.TryParse(comboKeyCodeText, out VirtualKeyCode comboKeyCode) ? comboKeyCode : VirtualKeyCode.VK_A;
                UseCombo = bool.Parse(useComboText);

                KeyAction = Enum.TryParse(keyActionText, out EKeyAction key) ? key : EKeyAction.normal;

                KeyboardEnabled = bool.Parse(keyboardEnabledText);
                MouseEnabled = bool.Parse(mouseEnabledText);
                ShiftMode = Enum.TryParse(shiftModeText, out EModifierMode shft_mode) ? shft_mode : EModifierMode.none;
                AltMode = Enum.TryParse(altModeText, out EModifierMode alt_mode) ? alt_mode : EModifierMode.none;
                CtrlMode = Enum.TryParse(ctrlModeText, out EModifierMode ctrl_mode) ? ctrl_mode : EModifierMode.none;
                KeyInterval = int.Parse(intervalText);
                MouseMoveEnabled = bool.Parse(mouseMoveEnabledText);
                MouseButtonEnabled = bool.Parse(mouseButtonEnabledText);
                MouseButton = Enum.TryParse(mouseButtonText, out MouseButtons mouse_button)
                    ? mouse_button
                    : MouseButtons.Left;

                MouseX = int.Parse(mouseXText);
                MouseY = int.Parse(mouseYText);


                TargetProcess = targetProcessText;

                return true;
            }



            return false;
        }

        public bool SaveVjoyConfig(VjoyAction action)
        {
            if (action != null)
            {


                // saves the action's configuration
                JObject jObject = new JObject
                {
                    
                    [ConfigData.BUTTON_ENABLED] = ButtonEnabled.ToString(),
                    [ConfigData.BUTTON_NUMBER] = ButtonNumber.ToString(),
                    [ConfigData.DEVICE_NUMBER] = DeviceNumber.ToString(),
                    [ConfigData.BUTTON_MODE] = ButtonMode.ToString(),
                    [ConfigData.BUTTON_PULSE_INTERVAL] = ButtonPulseInterval.ToString(),
                    [ConfigData.TRACK_STATE] = TrackState.ToString(),
                    [ConfigData.ACTION_ID] = ActionId,

                    [ConfigData.AXIS_MODE] = AxisMode.ToString(),
                    [ConfigData.AXIS_NAME] = AxisName,
                    [ConfigData.AXIS_ENABLED] = AxisEnabled.ToString(),
                    [ConfigData.AXIS_VALUE] = AxisValue.ToString(),
                    [ConfigData.AXIS_HATVALUE] = AxisHatValue.ToString(),

                    

                };

                action.Configuration = jObject.ToString();

                return true;
            }
            return false;
        }

        public bool SaveInputConfig(InputAction action)
        {
            if (action != null)
            {
                // saves the action's configuration
                JObject jObject = new JObject
                {

                    [ConfigData.KEYBOARD_ENABLED] = KeyboardEnabled.ToString(),
                    [ConfigData.MOUSE_ENABLED] = MouseEnabled.ToString(),
                    [ConfigData.VIRTUAL_KEY] = KeyCode.ToString(),
                    [ConfigData.COMBO_VIRTUAL_KEY] = ComboKeyCode.ToString(),
                    [ConfigData.USE_COMBO] = UseCombo.ToString(),
                    [ConfigData.KEY_ACTION] = KeyAction.ToString(),
                    [ConfigData.SHIFT_MODE] = ShiftMode.ToString(),
                    [ConfigData.ALT_MODE] = AltMode.ToString(),
                    [ConfigData.CTRL_MODE] = CtrlMode.ToString(),
                    [ConfigData.KEY_INTERVAL] = KeyInterval.ToString(),
                    [ConfigData.MOUSE_BUTTON] = MouseButton.ToString(),
                    [ConfigData.MOUSE_BUTTON_ENABLED] = MouseButtonEnabled.ToString(),
                    [ConfigData.MOUSE_MOVE_ENABLED] = MouseMoveEnabled.ToString(),
                    [ConfigData.MOUSE_X] = MouseX.ToString(),
                    [ConfigData.MOUSE_Y] = MouseX.ToString(),
                    [ConfigData.TARGET_PROCESS] = TargetProcess,
                };

                action.Configuration = jObject.ToString();

                return true;
            }
            return false;
        }

    }

    public class WorkerConfigData
    {
        public CancellationTokenSource Token { get; set; }

        public ConfigData data { get; set; }

        public WorkerConfigData(CancellationTokenSource token, ConfigData data)
        {
            Token = token;
            this.data = data;
        }
    }


}
