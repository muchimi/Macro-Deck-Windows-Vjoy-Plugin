using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using Windows.UI.Notifications;
using GregsStack.InputSimulatorStandard.Native;
using Microsoft.VisualBasic;
using muchimi_vjoy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.Logging;


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
        none, // no modifier
        left, // left modifier (or default)
        right, // right modifier
    }

    public enum EKeyAction
    {
        normal, // press and release 
        press, // press only (keydown)
        release // release only (keyup)
    }

    public enum EScanCodes : int
    {
        Esc = 0x01,
        N1 = 0x02,
        N2 = 0x03,
        N3 = 0x04,
        N4 = 0x05,
        N5 = 0x06,
        N6 = 0x07,
        N7 = 0x08,
        N8 = 0x09,
        N9 = 0x0a,
        N0 = 0x0b,
        Minus = 0x0c,
        Equal = 0x0d,
        Backspace = 0x0e,
        Tab = 0x0f,
        Q = 0x10,
        W = 0x11,
        E = 0x12,
        R = 0x13,
        T = 0x14,
        Y = 0x15,
        U = 0x16,
        I = 0x17,
        O = 0x18,
        P = 0x19,
        OpenBrackets = 0x1a,
        CloseBrackets = 0x1b,
        Enter = 0x1c,
        LCtrl = 0x1d,
        RCtrl = 0xe01d,
        A = 0x1e,
        S = 0x1f,
        D = 0x20,
        F = 0x21,
        G = 0x22,
        H = 0x23,
        J = 0x24,
        K = 0x25,
        L = 0x26,
        Semicolon = 0x27,
        Apostrophe = 0x28,
        Backtick = 0x29,
        LShift = 0x2a,
        Backslash = 0x2b,
        Z = 0x2c,
        X = 0x2d,
        C = 0x2e,
        V = 0x2f,
        B = 0x30,
        N = 0x31,
        M = 0x32,
        Comma = 0x33,
        Period = 0x34,
        Slash = 0x35,
        RShift = 0x36,
        KeypadAsterisk = 0x37,
        LAlt = 0x38,
        RAlt = 0xe038,
        Space = 0x39,
        CapsLock = 0x3a,
        F1 = 0x3b,
        F2 = 0x3c,
        F3 = 0x3d,
        F4 = 0x3e,
        F5 = 0x3f,
        F6 = 0x40,
        F7 = 0x41,
        F8 = 0x42,
        F9 = 0x43,
        F10 = 0x44,
        NumLock = 0x45,
        ScrollLock = 0x46,
        Numpad_7_Home = 0x47,
        Numpad_8_Up = 0x48,
        Numpad_9_PgUp = 0x49,
        Numpad_Minus = 0x4a,
        Numpad_4_Left = 0x4b,
        Numpad_5 = 0x4c,
        Numpad_Right = 0x4d,
        Numpad_Plus = 0x4e,
        Numpad_1_End = 0x4f,
        Numpad_2_Down = 0x50,
        Numpad_3_PgDn = 0x51,
        Numpad_0_Ins = 0x52,
        Numpad_Period_Del = 0x53,
        Fn = 0x56,
        F11 = 0x57,
        F12 = 0x58,
        EscapeCode = 0xe0,
        LWin = 0x5b,
        RWin = 0x5c,
        Menu = 0x5d,

/*
 * gray delete 0xD3 211
gray home 0xc7 199
gray pgup 0xc9 201
gray pgdn 0xd1 209
gray end 0xcf 207
gray ins 0xd2 210
left arrow 0xcb 203
up arrow 0xc8 200
down arrow 0xd0 208
right arrow 0xcd 205
printscreen 0xb7 183
numpad slash 0xb5 181
numpad enter 0x9c 156

 */
        ExtIns = 0xd2,
        ExtPgUp = 0xc9,
        ExtPgDn = 0xd1,
        ExtHome = 0xc7,
        ExtEnd = 0xcf,
        ExtLeft = 0xcb,
        ExtUp = 0xc8,
        ExtDown = 0xd0,
        ExtRight = 0xcd,
        ExtPrtScn = 0xb7,
        ExtNumpad_Slash = 0xb5,
        ExtNumpad_Enter = 0x9c,
    }

    public class KeyPair
    {
        public VirtualKeyCode key;
        public ushort scancode;
        public bool is_extended;

        public KeyPair()
        {
            key = VirtualKeyCode.NONAME;
            scancode = 0x0;
            is_extended = false;
        }

        public KeyPair(VirtualKeyCode key, ushort scancode = 0x0, bool is_extended = false)
        {
            this.key = key;
            this.scancode = scancode;
            this.is_extended = is_extended;
        }

    }

    public static class KeyboardMapper
    {
        /// <summary>
        /// converts scancode and virtual key to US keyboard names
        /// </summary>
        /// <param name="vkey">virtual key</param>
        /// <param name="scancode">key scancode</param>
        /// <param name="is_extended">true if the key is an extended keyboard key</param>
        /// <param name="is_simple">true to generate simple output</param>
        /// <returns></returns>
        public static string Map(VirtualKeyCode vkey, int scancode, bool is_extended, bool is_simple = false)
        {

            if (is_simple)
            {
                if (is_extended)
                    return $"{vkey} (ext)";
                return vkey.ToString();
            }

        string s_code = $"{vkey} ({scancode:X}/{scancode}/{(EScanCodes)scancode}) [ext:{is_extended}]";
            string suffix = "";

            if (is_extended)
            {
                switch (vkey)
                {
                    case VirtualKeyCode.NUMPAD_RETURN:
                        suffix = "EXT NUMPAD_ENTER";
                        break;
                    case VirtualKeyCode.MENU:
                        suffix = "EXT LALT";
                        break;
                    case VirtualKeyCode.RMENU:
                        suffix = "EXT RALT";
                        break;
                    case VirtualKeyCode.CONTROL:
                        suffix = "EXT LCTRL";
                        break;
                    case VirtualKeyCode.RCONTROL:
                        suffix = "EXT RCTRL";
                        break;
                    case VirtualKeyCode.INSERT:
                        suffix = "EXT INSERT";
                        break;
                    case VirtualKeyCode.DELETE:
                        suffix = "EXT DELETE";
                        break;
                    case VirtualKeyCode.HOME:
                        suffix = "EXT HOME";
                        break;
                    case VirtualKeyCode.END:
                        suffix = "EXT END";
                        break;
                    case VirtualKeyCode.PRIOR:
                        suffix = "EXT PGUP";
                        break;
                    case VirtualKeyCode.NEXT:
                        suffix = "EXT PGDN";
                        break;
                    case VirtualKeyCode.RIGHT:
                        suffix = "EXT RARROW";
                        break;
                    case VirtualKeyCode.UP:
                        suffix = "EXT UARROW";
                        break;
                    case VirtualKeyCode.LEFT:
                        suffix = "EXT LARROW";
                        break;
                    case VirtualKeyCode.DOWN:
                        suffix = "EXT DARROW";
                        break;
                    case VirtualKeyCode.NUMLOCK:
                        suffix = "EXT NUMLOCK";
                        break;
                    case VirtualKeyCode.SNAPSHOT:
                        suffix = "EXT PRTSCRN";
                        break;
                    case VirtualKeyCode.DIVIDE:
                        suffix = "EXT NUMPAD_SLASH";
                        break;
                }
            }
            switch (vkey)
            {
                case VirtualKeyCode.OEM_5:
                    suffix = "BACKSLASH";
                    break;
                case VirtualKeyCode.OEM_4:
                    suffix = "LSQUAREBRACKET";
                    break;
                case VirtualKeyCode.OEM_6:
                    suffix = "RSQUAREBRACKET";
                    break;
                case VirtualKeyCode.ADD:
                    suffix = "NUMPAD+";
                    break;
                case VirtualKeyCode.OEM_PLUS:
                    suffix = "EQUAL";
                    break;
                case VirtualKeyCode.DIVIDE:
                    suffix = "NUMPAD_SLASH";
                    break;

                case VirtualKeyCode.MULTIPLY:
                    suffix = "NUMPAD_STAR";
                    break;

                case VirtualKeyCode.SUBTRACT:
                    suffix = "NUMPAD_MINUS";
                    break;
                case VirtualKeyCode.RETURN:
                    suffix = "NUMPAD_ENTER";
                    break;

            }

            return !string.IsNullOrEmpty(suffix) ? $"{s_code} [{suffix}]" : s_code;
        }

        public static string Map(KeyPair kp)
        {
            return Map(kp.key, kp.scancode, kp.is_extended);

        }


        public static readonly List<VirtualKeyCode> ExtendedKeys = new List<VirtualKeyCode>
        {
            VirtualKeyCode.NUMPAD_RETURN,
            VirtualKeyCode.MENU,
            VirtualKeyCode.RMENU,
            VirtualKeyCode.CONTROL,
            VirtualKeyCode.RCONTROL,
            VirtualKeyCode.INSERT,
            VirtualKeyCode.DELETE,
            VirtualKeyCode.HOME,
            VirtualKeyCode.END,
            VirtualKeyCode.PRIOR,
            VirtualKeyCode.NEXT,
            VirtualKeyCode.RIGHT,
            VirtualKeyCode.UP,
            VirtualKeyCode.LEFT,
            VirtualKeyCode.DOWN,
            VirtualKeyCode.NUMLOCK,
            VirtualKeyCode.CANCEL,
            VirtualKeyCode.SNAPSHOT,
            VirtualKeyCode.DIVIDE
        };

        public static VirtualKeyCode MapHookToSim(KeyboardHook.VKeys key, bool isExtended)
        {
            if (isExtended)
            {
                switch (key)
                {
                    case KeyboardHook.VKeys.RETURN:
                        return VirtualKeyCode.NUMPAD_RETURN;
                    case KeyboardHook.VKeys.MENU:
                        return VirtualKeyCode.MENU;
                    case KeyboardHook.VKeys.RMENU:
                        return VirtualKeyCode.RMENU;
                    case KeyboardHook.VKeys.CONTROL:
                        return VirtualKeyCode.CONTROL;
                    case KeyboardHook.VKeys.RCONTROL:
                        return VirtualKeyCode.RCONTROL;
                    case KeyboardHook.VKeys.INSERT:
                        return VirtualKeyCode.INSERT;
                    case KeyboardHook.VKeys.DELETE:
                        return VirtualKeyCode.DELETE;
                    case KeyboardHook.VKeys.HOME:
                        return VirtualKeyCode.HOME;
                    case KeyboardHook.VKeys.END:
                        return VirtualKeyCode.END;
                    case KeyboardHook.VKeys.PRIOR:
                        return VirtualKeyCode.PRIOR;
                    case KeyboardHook.VKeys.NEXT:
                        return VirtualKeyCode.NEXT;
                    case KeyboardHook.VKeys.RIGHT:
                        return VirtualKeyCode.RIGHT;
                    case KeyboardHook.VKeys.UP:
                        return VirtualKeyCode.UP;
                    case KeyboardHook.VKeys.LEFT:
                        return VirtualKeyCode.LEFT;
                    case KeyboardHook.VKeys.DOWN:
                        return VirtualKeyCode.DOWN;
                    case KeyboardHook.VKeys.NUMLOCK:
                        return VirtualKeyCode.NUMLOCK;
                    case KeyboardHook.VKeys.CANCEL:
                        return VirtualKeyCode.CANCEL;
                    case KeyboardHook.VKeys.SNAPSHOT:
                        return VirtualKeyCode.SNAPSHOT;
                    case KeyboardHook.VKeys.DIVIDE:
                        return VirtualKeyCode.DIVIDE;

                }
            }
            return (VirtualKeyCode)key;
        }

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
        public const string SCAN_CODE = "scan_code";
        public const string IS_EXTENDED = "is_extended";
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

        public double
            AxisValue
        { get; set; } // range is 0x1-0x8000  (1 to 32768) mapped to -1.0 to +1.0 as with Gremlin

        public int AxisHatValue { get; set; }

        public bool ButtonEnabled { get; set; }
        public bool AxisEnabled { get; set; }


        // keyboard/mouse properties

        public VirtualKeyCode KeyCode { get; set; }

        public int ScanCode { get; set; }

        public bool IsExtended { get; set; }

        public VirtualKeyCode ComboKeyCode { get; set; }

        public bool UseCombo { get; set; }

        public bool KeyboardEnabled { get; set; }
        public bool MouseEnabled { get; set; }
        public EModifierMode ShiftMode { get; set; }
        public EModifierMode CtrlMode { get; set; }
        public EModifierMode AltMode { get; set; }
        public int KeyInterval { get; set; }
        public EKeyAction KeyAction { get; set; }

        public MouseButtons MouseButton { get; set; }
        public int MouseX { get; set; }
        public int MouseY { get; set; }
        public bool MouseButtonEnabled { get; set; }
        public bool MouseMoveEnabled { get; set; }

        /// <summary>
        ///  true if key has modifiers
        /// </summary>
        public bool HasModifiers => (CtrlMode != EModifierMode.none || ShiftMode != EModifierMode.none ||
                                     AltMode != EModifierMode.none);

        public List<KeyPair> Modifiers
        {
            get
            {
                List<KeyPair> modifiers = new List<KeyPair>();
                switch (CtrlMode)
                {
                    case EModifierMode.left:
                        modifiers.Add(new KeyPair(VirtualKeyCode.LCONTROL));
                        break;
                    case EModifierMode.right:
                        modifiers.Add(new KeyPair(VirtualKeyCode.RCONTROL));
                        break;
                }

                switch (ShiftMode)
                {
                    case EModifierMode.left:
                        modifiers.Add(new KeyPair(VirtualKeyCode.LSHIFT));
                        break;
                    case EModifierMode.right:
                        modifiers.Add(new KeyPair(VirtualKeyCode.RSHIFT));
                        break;
                }

                switch (AltMode)
                {
                    case EModifierMode.left:
                        modifiers.Add(new KeyPair(VirtualKeyCode.LMENU));
                        break;
                    case EModifierMode.right:
                        modifiers.Add(new KeyPair(VirtualKeyCode.RMENU));
                        break;
                }

                return modifiers;
            }
        }



        /// <summary>
        /// returns the complete list of virtual keys for this key
        /// </summary>
        public List<KeyPair> Sequence
        {
            get
            {
                var vlist = Modifiers;
                vlist.Add(new KeyPair(this.KeyCode, (ushort)this.ScanCode));
                return vlist;
            }
        }

        public bool LoadVjoyConfig(VjoyAction action)
        {
            if (action != null && !string.IsNullOrEmpty(action.Configuration))
            {
                return VjoyConfigFromJson(action.Configuration);
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
                TargetProcess = Main.Instance.Config.LastApplication;
            }

            return false;
        }


        /// <summary>
        /// reads a json object into the configuration 
        /// </summary>
        /// <param name="action">the action object</param>
        /// <returns>true on success</returns>
        public bool VjoyConfigFromJson(string json)
        {

            JObject jObject;
            try
            {
                jObject = JObject.Parse(json);
            }
            catch
            {
                jObject = null;
            }

            if (jObject != null)
            {
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


                var targetProcessText = "";
                value = jObject[ConfigData.TARGET_PROCESS];
                if (value != null)
                {
                    targetProcessText = value.ToString();
                    if (string.IsNullOrWhiteSpace(targetProcessText))
                    {
                        // default to the focused app entry
                        targetProcessText = VjoyPluginConfiguration.FOCUSED_APP;
                    }
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


                TargetProcess = targetProcessText;
            }


            return true;
        }

        public bool LoadInputConfig(InputAction action)
        {
            if (action != null && !string.IsNullOrEmpty(action.Configuration))
            {
                return InputConfigFromJson(action.Configuration);
            }

            return false;
        }

        public bool InputConfigFromJson(string json)
        {
            var config = Main.Instance.Config;
            JObject jObject;

            try
            {
                jObject = JObject.Parse(json);
            }
            catch
            {
                jObject = null;
            }

            if (jObject != null)
            {

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


                var keyboardEnabledText = "true";
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
                    if (string.IsNullOrWhiteSpace(intervalText))
                        intervalText = config.LastKeyInterval.ToString();
                    else if (int.TryParse(intervalText, out var int_value))
                    {
                        if (int_value < 0)
                        {
                            intervalText = "0";
                        }
                    }
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
                    if (string.IsNullOrWhiteSpace(targetProcessText))
                    {
                        // default to the focused app entry
                        targetProcessText = VjoyPluginConfiguration.FOCUSED_APP;
                    }
                }

                var scanCodeText = "0";
                value = jObject[ConfigData.SCAN_CODE];
                if (value != null)
                {
                    scanCodeText = value.ToString();
                }

                var isExtendedText = "false";
                value = jObject[ConfigData.IS_EXTENDED];
                if (value != null)
                {
                    isExtendedText = value.ToString();
                }

                KeyCode = Enum.TryParse(keyCodeText, out VirtualKeyCode keyCode) ? keyCode : VirtualKeyCode.VK_A;
                ScanCode = int.Parse(scanCodeText);
                IsExtended = bool.Parse(isExtendedText);
                ComboKeyCode = Enum.TryParse(comboKeyCodeText, out VirtualKeyCode comboKeyCode)
                    ? comboKeyCode
                    : VirtualKeyCode.VK_A;
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
            else
            {
                // load default config
                KeyInterval = config.LastKeyInterval;
                TargetProcess = config.LastApplication;
                KeyboardEnabled = true;

            }


            return false;
        }

        public string VJoyConfigToJson()
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
                [ConfigData.AXIS_PULSE_INTERVAL] = AxisPulseInterval.ToString(),

                [ConfigData.TARGET_PROCESS] = TargetProcess,
            };
            return jObject.ToString();
        }

        public bool SaveVjoyConfig(VjoyAction action)
        {
            if (action != null)
            {
                action.Configuration = VJoyConfigToJson();
                return true;
            }

            return false;
        }

        public string InputConfigToJson()
        {
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
                [ConfigData.SCAN_CODE] = ScanCode.ToString(),
                [ConfigData.IS_EXTENDED] = IsExtended.ToString(),
            };

            return jObject.ToString();

        }

        public bool SaveInputConfig(InputAction action)
        {
            if (action != null)
            {
                action.Configuration = InputConfigToJson();
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




    public class PluginConfigData
    {

        [JsonProperty("Vjoy.LastApplication")] public string _lastApplication;


        [JsonProperty("Vjoy.LastKeyInterval")] public int _lastKeyInterval;

        [JsonProperty("Vjoy.Applications")] public List<string> _applications;
    }


    public class VjoyPluginConfiguration
    {
        const string CONFIG_NAME = "VjoyConfig.json";
        public const string FOCUSED_APP = "[focused app]";

        public EventHandler ApplicationListChanged;


        private bool _modified = false;

        string ConfigFile => AssemblyDirectory + "\\" + CONFIG_NAME;


        private PluginConfigData _config;

        public ConfigData VjoyClipboard { get; set; }
        public ConfigData InputClipboard { get; set; }

        public VjoyPluginConfiguration()
        {
            _config = new PluginConfigData();
            VjoyClipboard = null;
            InputClipboard = null;
            MacroDeckLogger.Info(Main.Instance, $"Loading new plugin configuration data");
        }



        /// <summary>
        /// clone values 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        void Clone(ConfigData source, ref ConfigData dest)
        {
            // vjoy properties
            dest.ButtonEnabled = source.ButtonEnabled;
            dest.ButtonNumber = source.ButtonNumber;
            dest.DeviceNumber = source.DeviceNumber;
            dest.ButtonMode = source.ButtonMode;
            dest.ButtonPulseInterval = source.ButtonPulseInterval;
            dest.TrackState = source.TrackState;
            dest.AxisMode = source.AxisMode;
            dest.AxisEnabled = source.AxisEnabled;
            dest.Axis = source.Axis;
            dest.AxisValue = source.AxisValue;
            dest.AxisHatValue = source.AxisHatValue;
            dest.AxisPulseInterval = source.AxisPulseInterval;




            // input properties
            dest.KeyboardEnabled = source.KeyboardEnabled;
            dest.MouseEnabled = source.MouseEnabled;
            dest.KeyCode = source.KeyCode;
            dest.UseCombo = source.UseCombo;
            dest.ComboKeyCode = source.ComboKeyCode;
            dest.ShiftMode = source.ShiftMode;
            dest.AltMode = source.AltMode;
            dest.CtrlMode = source.CtrlMode;
            dest.KeyInterval = source.KeyInterval;
            dest.MouseButton = source.MouseButton;
            dest.MouseButtonEnabled = source.MouseButtonEnabled;
            dest.MouseMoveEnabled = source.MouseMoveEnabled;
            dest.MouseX = source.MouseX;
            dest.MouseY = source.MouseY;
            dest.TargetProcess = source.TargetProcess;


        }


        /// <summary>
        ///  saves a copy of the config data
        /// </summary>
        /// <param name="data"></param>
        public void VjoyCopy(ConfigData data)
        {
            var ndata = new ConfigData();
            Clone(data, ref ndata);
            VjoyClipboard = ndata;

        }

        public void InputCopy(ConfigData data)
        {
            var ndata = new ConfigData();
            Clone(data, ref ndata);
            InputClipboard = ndata;

        }



        /// <summary>
        /// copies saved data to this new config
        /// </summary>
        /// <param name="data"></param>
        public void VjoyPaste(ref ConfigData data)
        {
            if (VjoyClipboard != null)
            {
                Clone(VjoyClipboard, ref data);
            }
        }

        public void InputPaste(ref ConfigData data)
        {
            if (InputClipboard != null)
            {
                MacroDeckLogger.Info(Main.Instance, $"Pasting data from config: {InputClipboard.KeyInterval} {InputClipboard.ActionId} ");
                Clone(InputClipboard, ref data);
                MacroDeckLogger.Info(Main.Instance, $"After pasting data from config: {data.KeyInterval} {data.ActionId} ");
            }
        }

        private string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// last application selected by the user
        /// </summary>
        public string LastApplication
        {
            get => _config._lastApplication;
            set
            {
                if (_config._lastApplication != value)
                {
                    _config._lastApplication = value;
                    _modified = true;
                }
            }
        }

        /// <summary>
        /// list of applications currently in the plugin list
        /// </summary>
        public List<string> ApplicationList
        {
            get => _config._applications;
            internal set => _config._applications = value;
        }

        /// <summary>
        /// last used key interval in milliseconds
        /// </summary>
        public int LastKeyInterval
        {
            get => _config._lastKeyInterval;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _config._lastKeyInterval = value;
            }
        }

        public void SaveConfig()
        {
            if (!_modified)
                return;


            string json = JsonConvert.SerializeObject(_config);
            try
            {
                var configFile = ConfigFile;
                if (File.Exists(configFile))
                    File.Delete(configFile);
                File.WriteAllText(configFile, json);
                _modified = false;
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(Main.Instance,
                    $"Error reading configuration file: {ConfigFile}:  {e.ToString()}");
            }


        }

        void LoadDefaultConfig()
        {

            _config = new PluginConfigData
            {
                _applications = new List<string>()
            };
            _config._applications.Add(FOCUSED_APP);
            _config._lastApplication = FOCUSED_APP;
            _config._lastKeyInterval = 600;
        }

        public void LoadConfig()
        {
            try
            {
                var configFile = ConfigFile;
                if (File.Exists(configFile))
                {
                    string json = File.ReadAllText(ConfigFile);
                    PluginConfigData data = null;
                    var obj = JsonConvert.DeserializeObject<PluginConfigData>(json);
                    if (obj != null)
                    {
                        data = obj;
                    }


                    if (data != null)
                    {
                        _config = data;
                        // check the focused entry exists in old configs
                        if (!_config._applications.Contains(FOCUSED_APP))
                        {
                            _config._applications.Add(FOCUSED_APP);
                            _modified = true;
                        }

                        if (string.IsNullOrWhiteSpace(_config._lastApplication))
                        {
                            _config._lastApplication = FOCUSED_APP;
                            _modified = true;
                        }

                    }
                    else
                    { LoadDefaultConfig(); }

                }
                else
                {
                    // default config
                    LoadDefaultConfig();

                }
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(Main.Instance,
                    $"Error reading configuration file: {ConfigFile}:  {e.ToString()}");
            }
        }


        public string FixedName(string name)
        {
            if (name == null)
                return null;

            return name.ToLower().Trim();
        }

        /// <summary>
        /// adds an application to the configuration
        /// </summary>
        /// <param name="name"></param>
        public bool AddApplication(string name)
        {
            if (name == null)
                return false;

            var fixedName = FixedName(name);

            if (!ApplicationList.Contains(fixedName))
            {
                ApplicationList.Add(fixedName);
                _modified = true;
                if (ApplicationListChanged != null)
                {
                    ApplicationListChanged(fixedName, null);
                }
                return true;
            }

            return false;
        }

        public bool RemoveApplication(string name)
        {
            if (name == null)
                return false;

            var fixedName = FixedName(name);

            if (ApplicationList.Contains(fixedName))
            {
                ApplicationList.Remove(fixedName);
                if (ApplicationListChanged != null)
                {
                    ApplicationListChanged(fixedName, null);
                }
                _modified = true;
                return true;
            }

            return false;
        }
    }

}
