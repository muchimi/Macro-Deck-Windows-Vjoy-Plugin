using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Windows.Input;
using Windows.ApplicationModel.Calls.Background;
using CefSharp.DevTools.Debugger;
using GregsStack.InputSimulatorStandard.Native;
using muchimi_vjoy;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;

namespace muchimi.vjoy
{
    public partial class KeyboardCapture : DialogForm
    {
        private long _scancode = 0;


        ///// <summary>
        ///// converts a win32 key to an input simulator virtual key
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //VirtualKeyCode toVirtualKeyCode(Key key)
        //{
        //    switch (key)
        //    {
        //        case Key.None:
        //            return VirtualKeyCode.NONAME;
        //        case Key.Cancel:
        //            return VirtualKeyCode.CANCEL;
        //        case Key.Back:
        //            return VirtualKeyCode.BACK;
        //        case Key.Tab:
        //            return VirtualKeyCode.TAB;
        //        case Key.LineFeed:
        //            break;
        //        case Key.Clear:
        //            break;
        //        case Key.Enter:
        //            return VirtualKeyCode.RETURN;
        //        case Key.Pause:
        //            return VirtualKeyCode.PAUSE;
        //        case Key.Capital:
        //            return VirtualKeyCode.CAPITAL;
        //        case Key.HangulMode:
        //            break;
        //        case Key.JunjaMode:
        //            break;
        //        case Key.FinalMode:
        //            break;
        //        case Key.HanjaMode:
        //            break;
        //        case Key.Escape:
        //            return VirtualKeyCode.ESCAPE;
        //            break;
        //        case Key.ImeConvert:
        //            break;
        //        case Key.ImeNonConvert:
        //            break;
        //        case Key.ImeAccept:
        //            break;
        //        case Key.ImeModeChange:
        //            break;
        //        case Key.Space:
        //            return VirtualKeyCode.SPACE;
        //        case Key.PageUp:
        //            return VirtualKeyCode.PRIOR;
        //        case Key.Next:
        //            return VirtualKeyCode.NEXT;

        //        case Key.End:
        //            return VirtualKeyCode.END;
        //        case Key.Home:
        //            return VirtualKeyCode.HOME;
        //        case Key.Left:
        //            return VirtualKeyCode.LEFT;
        //        case Key.Up:
        //            return VirtualKeyCode.UP;
        //        case Key.Right:
        //            return VirtualKeyCode.RIGHT;
        //        case Key.Down:
        //            return VirtualKeyCode.DOWN;
        //        case Key.Select:
        //            break;
        //        case Key.Print:
        //            break;
        //        case Key.Execute:
        //            break;
        //        case Key.PrintScreen:
        //            break;
        //        case Key.Insert:
        //            return VirtualKeyCode.INSERT;
        //            break;
        //        case Key.Delete:
        //            return VirtualKeyCode.DELETE;
        //        case Key.Help:
        //            break;
        //        case Key.D0:
        //            return VirtualKeyCode.VK_0;

        //        case Key.D1:
        //            return VirtualKeyCode.VK_1;

        //        case Key.D2:
        //            return VirtualKeyCode.VK_2;
        //        case Key.D3:
        //            return VirtualKeyCode.VK_3;
        //        case Key.D4:
        //            return VirtualKeyCode.VK_4;
        //        case Key.D5:
        //            return VirtualKeyCode.VK_5;
        //        case Key.D6:
        //            return VirtualKeyCode.VK_6;
        //        case Key.D7:
        //            return VirtualKeyCode.VK_7;
        //        case Key.D8:
        //            return VirtualKeyCode.VK_8;
        //        case Key.D9:
        //            return VirtualKeyCode.VK_9;
        //        case Key.A:
        //            return VirtualKeyCode.VK_A;
        //        case Key.B:
        //            return VirtualKeyCode.VK_B;
        //        case Key.C:
        //            return VirtualKeyCode.VK_C;
        //        case Key.D:
        //            return VirtualKeyCode.VK_D;
        //        case Key.E:
        //            return VirtualKeyCode.VK_E;
        //        case Key.F:
        //            return VirtualKeyCode.VK_F;
        //        case Key.G:
        //            return VirtualKeyCode.VK_G;
        //        case Key.H:
        //            return VirtualKeyCode.VK_H;
        //        case Key.I:
        //            return VirtualKeyCode.VK_I;
        //        case Key.J:
        //            return VirtualKeyCode.VK_J;
        //        case Key.K:
        //            return VirtualKeyCode.VK_K;
        //        case Key.L:
        //            return VirtualKeyCode.VK_L;
        //        case Key.M:
        //            return VirtualKeyCode.VK_M;
        //        case Key.N:
        //            return VirtualKeyCode.VK_N;
        //        case Key.O:
        //            return VirtualKeyCode.VK_O;
        //        case Key.P:
        //            return VirtualKeyCode.VK_P;
        //        case Key.Q:
        //            return VirtualKeyCode.VK_Q;
        //        case Key.R:
        //            return VirtualKeyCode.VK_R;
        //        case Key.S:
        //            return VirtualKeyCode.VK_S;
        //        case Key.T:
        //            return VirtualKeyCode.VK_T;
        //        case Key.U:
        //            return VirtualKeyCode.VK_U;
        //        case Key.V:
        //            return VirtualKeyCode.VK_V;
        //        case Key.W:
        //            return VirtualKeyCode.VK_W;
        //        case Key.X:
        //            return VirtualKeyCode.VK_X;
        //        case Key.Y:
        //            return VirtualKeyCode.VK_Y;
        //        case Key.Z:
        //            return VirtualKeyCode.VK_Z;
        //        case Key.LWin:
        //            return VirtualKeyCode.LWIN;

        //        case Key.RWin:
        //            return VirtualKeyCode.RWIN;
        //        case Key.Apps:
        //            break;
        //        case Key.Sleep:
        //            break;
        //        case Key.NumPad0:
        //            return VirtualKeyCode.NUMPAD0;
        //        case Key.NumPad1:
        //            return VirtualKeyCode.NUMPAD1;
        //        case Key.NumPad2:
        //            return VirtualKeyCode.NUMPAD2;
        //        case Key.NumPad3:
        //            return VirtualKeyCode.NUMPAD3;
        //        case Key.NumPad4:
        //            return VirtualKeyCode.NUMPAD4;
        //        case Key.NumPad5:
        //            return VirtualKeyCode.NUMPAD5;
        //        case Key.NumPad6:
        //            return VirtualKeyCode.NUMPAD6;
        //        case Key.NumPad7:
        //            return VirtualKeyCode.NUMPAD7;
        //        case Key.NumPad8:
        //            return VirtualKeyCode.NUMPAD8;
        //        case Key.NumPad9:
        //            return VirtualKeyCode.NUMPAD9;
        //        case Key.Multiply:
        //            return VirtualKeyCode.MULTIPLY;
        //        case Key.Add:
        //            return VirtualKeyCode.ADD;
        //        case Key.Separator:
        //            return VirtualKeyCode.SEPARATOR;
        //        case Key.Subtract:
        //            return VirtualKeyCode.SUBTRACT;
        //        case Key.Decimal:
        //            return VirtualKeyCode.DECIMAL;
        //        case Key.Divide:
        //            return VirtualKeyCode.DIVIDE;
        //        case Key.F1:
        //            return VirtualKeyCode.F1;
        //        case Key.F2:
        //            return VirtualKeyCode.F2;
        //        case Key.F3:
        //            return VirtualKeyCode.F3;
        //        case Key.F4:
        //            return VirtualKeyCode.F4;
        //        case Key.F5:
        //            return VirtualKeyCode.F5;
        //        case Key.F6:
        //            return VirtualKeyCode.F6;
        //        case Key.F7:
        //            return VirtualKeyCode.F7;
        //        case Key.F8:
        //            return VirtualKeyCode.F8;
        //        case Key.F9:
        //            return VirtualKeyCode.F9;
        //        case Key.F10:
        //            return VirtualKeyCode.F10;
        //        case Key.F11:
        //            return VirtualKeyCode.F11;
        //        case Key.F12:
        //            return VirtualKeyCode.F12;
        //        case Key.F13:
        //            return VirtualKeyCode.F13;
        //        case Key.F14:
        //            return VirtualKeyCode.F14;
        //        case Key.F15:
        //            return VirtualKeyCode.F15;
        //        case Key.F16:
        //            return VirtualKeyCode.F16;
        //        case Key.F17:
        //            return VirtualKeyCode.F17;
        //        case Key.F18:
        //            return VirtualKeyCode.F18;
        //        case Key.F19:
        //            return VirtualKeyCode.F19;
        //        case Key.F20:
        //            return VirtualKeyCode.F20;
        //        case Key.F21:
        //            return VirtualKeyCode.F21;
        //        case Key.F22:
        //            return VirtualKeyCode.F22;
        //        case Key.F23:
        //            return VirtualKeyCode.F23;
        //        case Key.F24:
        //            return VirtualKeyCode.F24;
        //        case Key.NumLock:
        //            return VirtualKeyCode.NUMLOCK;
        //        case Key.Scroll:
        //            return VirtualKeyCode.SCROLL;
        //        case Key.LeftShift:
        //            return VirtualKeyCode.LSHIFT;
        //        case Key.RightShift:
        //            return VirtualKeyCode.RSHIFT;
        //        case Key.LeftCtrl:
        //            return VirtualKeyCode.LCONTROL;
        //        case Key.RightCtrl:
        //            return VirtualKeyCode.RCONTROL;
        //        case Key.LeftAlt:
        //            return VirtualKeyCode.LMENU;
        //        case Key.RightAlt:
        //            return VirtualKeyCode.RMENU;
        //        case Key.BrowserBack:
        //            return VirtualKeyCode.BROWSER_BACK;
        //        case Key.BrowserForward:
        //            return VirtualKeyCode.BROWSER_FORWARD;
        //        case Key.BrowserRefresh:
        //            return VirtualKeyCode.BROWSER_REFRESH;
        //        case Key.BrowserStop:
        //            return VirtualKeyCode.BROWSER_STOP;
        //        case Key.BrowserSearch:
        //            return VirtualKeyCode.BROWSER_SEARCH;
        //        case Key.BrowserFavorites:
        //            return VirtualKeyCode.BROWSER_FAVORITES;
        //        case Key.BrowserHome:
        //            return VirtualKeyCode.BROWSER_HOME;
        //        case Key.VolumeMute:
        //            return VirtualKeyCode.VOLUME_MUTE;
        //        case Key.VolumeDown:
        //            return VirtualKeyCode.VOLUME_DOWN;
        //        case Key.VolumeUp:
        //            return VirtualKeyCode.VOLUME_UP;
        //        case Key.MediaNextTrack:
        //            return VirtualKeyCode.MEDIA_NEXT_TRACK;
        //        case Key.MediaPreviousTrack:
        //            return VirtualKeyCode.MEDIA_PREV_TRACK;
        //        case Key.MediaStop:
        //            return VirtualKeyCode.MEDIA_STOP;
        //        case Key.MediaPlayPause:
        //            return VirtualKeyCode.MEDIA_PLAY_PAUSE;
        //        case Key.LaunchMail:
        //            return VirtualKeyCode.LAUNCH_MAIL;
        //        case Key.SelectMedia:
        //            return VirtualKeyCode.LAUNCH_MEDIA_SELECT;
        //        case Key.LaunchApplication1:
        //            return VirtualKeyCode.LAUNCH_APP1;
        //        case Key.LaunchApplication2:
        //            return VirtualKeyCode.LAUNCH_APP2;
        //        case Key.Oem1:
        //            return VirtualKeyCode.OEM_1;
        //        case Key.OemPlus:
        //            return VirtualKeyCode.OEM_PLUS;
        //        case Key.OemComma:
        //            return VirtualKeyCode.OEM_COMMA;
        //        case Key.OemMinus:
        //            return VirtualKeyCode.OEM_MINUS;
        //        case Key.OemPeriod:
        //            return VirtualKeyCode.OEM_PERIOD;
        //        case Key.Oem2:
        //            return VirtualKeyCode.OEM_2;
        //        case Key.Oem3:
        //            return VirtualKeyCode.OEM_3;
        //        case Key.AbntC1:
        //            break;
        //        case Key.AbntC2:
        //            break;
        //        case Key.Oem4:
        //            break;
        //        case Key.Oem5:
        //            break;
        //        case Key.Oem6:
        //            break;
        //        case Key.Oem7:
        //            break;
        //        case Key.Oem8:
        //            break;
        //        case Key.Oem102:
        //            break;
        //        case Key.ImeProcessed:
        //            break;
        //        case Key.System:
        //            break;
        //        case Key.DbeAlphanumeric:
        //            break;
        //        case Key.DbeKatakana:
        //            break;
        //        case Key.DbeHiragana:
        //            break;
        //        case Key.DbeSbcsChar:
        //            break;
        //        case Key.DbeDbcsChar:
        //            break;
        //        case Key.DbeRoman:
        //            break;
        //        case Key.Attn:
        //            break;
        //        case Key.CrSel:
        //            break;
        //        case Key.DbeEnterImeConfigureMode:
        //            break;
        //        case Key.DbeFlushString:
        //            break;
        //        case Key.DbeCodeInput:
        //            break;
        //        case Key.DbeNoCodeInput:
        //            break;
        //        case Key.DbeDetermineString:
        //            break;
        //        case Key.DbeEnterDialogConversionMode:
        //            break;
        //        case Key.OemClear:
        //            return VirtualKeyCode.OEM_CLEAR;
        //        case Key.DeadCharProcessed:
        //            break;
        //    }

        //    return VirtualKeyCode.NONAME;
        //}


        class KeyEventArgs : EventArgs
        {
            public Key key;
            public long scancode;

        }

        EventHandler<KeyEventArgs> keyEventHandler;

        public VirtualKeyCode VirtualKey { get; private set; }

        public bool IsExtended { get; private set; }

        public int ScanCode { get; private set; }

        public bool LCtrl { get; private set; }
        public bool RCtrl { get; private set; }

        public bool LShift { get; private set; }
        public bool RShift { get; private set; }

        public bool LAlt { get; private set; }
        public bool RAlt { get; private set; }

        public void SetVirtualKey(VirtualKeyCode key, int scanCode, bool is_extended,EModifierMode shiftMode, EModifierMode ctrlMode, EModifierMode altMode)
        {
            VirtualKey = key;
            ScanCode = scanCode;

            LCtrl = false;
            RCtrl = false;
            LShift = false;
            RShift = false;
            LAlt = false;
            RAlt = false;

            switch (shiftMode)
            {
                case EModifierMode.left:
                    LShift = true;
                    break;
                case EModifierMode.right:
                    RShift = true;
                    break;
            }
            switch (ctrlMode)
            {

                case EModifierMode.left:
                    LCtrl = true;
                    break;
                case EModifierMode.right:
                    RCtrl = true;
                    break;
            }

            switch (altMode)
            {
                case EModifierMode.left:
                    LAlt = true;
                    break;
                case EModifierMode.right:
                    RAlt = true;
                    break;
            }

            updateKeyDisplay(key, scanCode, is_extended, false);
        }

        public EModifierMode ShiftMode
        {
            get
            {
                if (LShift)
                    return EModifierMode.left;
                if (RShift)
                    return EModifierMode.right;
                return EModifierMode.none;
            }
        }


        public EModifierMode CtrlMode
        {
            get
            {
                if (LCtrl)
                    return EModifierMode.left;
                if (RCtrl)
                    return EModifierMode.right;
                return EModifierMode.none;
            }
        }



        public EModifierMode AltMode
        {
            get
            {
                if (LAlt)
                    return EModifierMode.left;
                if (RAlt)
                    return EModifierMode.right;
                return EModifierMode.none;
            }
        }



        KeyboardHook keyboardListener;

        private Int32 lastKey = 0x0;




        public KeyboardCapture()
        {
            InitializeComponent();

            keyboardListener = new KeyboardHook();
            keyboardListener.KeyDown += KeyboardListenerOnKeyDown;
            keyboardListener.KeyUp += KeyboardListenerOnKeyUp;
            keyboardListener.Install();
            this.Closing += KeyboardCapture_Closing;
            updateKeyDisplay(VirtualKey, ScanCode, IsExtended, false);
        }

        private void KeyboardCapture_Closing(object sender, CancelEventArgs e)
        {
            keyboardListener.Uninstall();
        }

        void updateKeyDisplay(VirtualKeyCode key, int scanCode, bool is_extended, bool isUp)
        {

            lbl_extended.Text = is_extended ? "Extended key" : "Regular key";
            string modifiers = "";
            modifiers += LShift ? "+LSHIFT " : "";
            modifiers += RShift ? "+RSHIFT " : "";
            modifiers += LCtrl ?  "+LCTRL " : "";
            modifiers += RCtrl ? "+RCTRL " : "";
            modifiers += LAlt ?  "+LALT " : "";
            modifiers += RAlt ? "+RALT " : "";

            lbl_modifiers.Text = modifiers;
            lbl_key.Text = (key == VirtualKeyCode.NONAME) ? "n/a" : KeyboardMapper.Map(key, scanCode, is_extended, true);
            tb_key.Text = (key == VirtualKeyCode.NONAME) ? "[Press a key]" : key.ToString();
            lbl_scancode.Text = is_extended ? $"0xE0 0x{scanCode:X2}" :  $"0x{scanCode:X2}";

        }

        /// <summary>
        /// occurs when a key is pressed
        /// </summary>
        /// <param name="key"></param>
        private void KeyboardListenerOnKeyDown(KeyboardHook.VKeys key, int scanCode, bool is_extended)
        {



            var vk = KeyboardMapper.MapHookToSim(key, is_extended);
            if (scanCode == lastKey)
            
            {
                // ignore repeated keys (autorepeat) unless a modifier
                switch (vk)
                {
                    case VirtualKeyCode.LSHIFT:
                    case VirtualKeyCode.RSHIFT:
                    case VirtualKeyCode.LMENU:
                    case VirtualKeyCode.RMENU:
                    case VirtualKeyCode.LCONTROL:
                    case VirtualKeyCode.RCONTROL:
                        break;
                    default:
                        return;
                        
                }
            }

            lastKey = scanCode;

            MacroDeckLogger.Info(Main.Instance, $"vk down {vk}/{(int)vk:X} scancode: {scanCode:X} ext: {is_extended}  -128 {scanCode-128:X}");

            // the modifier keys in this case act as a toggle every time they are pressed to make it easier to select a keystroke

            
            switch (vk)
            {
                case VirtualKeyCode.LSHIFT:
                    LShift = !LShift;
                    RShift = false;
                    break;
                case VirtualKeyCode.RSHIFT:
                    RShift = !RShift;
                    LShift = false;
                    break;
                case VirtualKeyCode.LMENU:
                    LAlt = !LAlt;
                    RAlt = false;
                    break;
                case VirtualKeyCode.RMENU:
                    RAlt = !RAlt;
                    LAlt = false;
                    break;
                case VirtualKeyCode.LCONTROL:
                    LCtrl = !LCtrl;
                    RCtrl = false;
                    break;
                case VirtualKeyCode.RCONTROL:
                    RCtrl = !RCtrl;
                    LCtrl = false;
                    break;
                default:
                    VirtualKey = vk;
                    ScanCode = scanCode;
                    IsExtended = is_extended;
                    break;
            }

            
            

            updateKeyDisplay(VirtualKey, ScanCode, IsExtended, false);

        }

        /// <summary>
        /// occurs when a key is released
        /// </summary>
        /// <param name="key"></param>
        private void KeyboardListenerOnKeyUp(KeyboardHook.VKeys key, int scanCode, bool is_extended)
        {

            //var vk = (VirtualKeyCode)(int)key;

            //MacroDeckLogger.Info(Main.Instance, $"vk up {vk}");


            //updateKeyDisplay(vk, scanCode, is_extended, true);
        }


        private void cmd_ok_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmd_clear_Click(object sender, EventArgs e)
        {
            LAlt = false;
            RAlt = false;
            LShift = false;
            RShift = false;
            RCtrl = false;
            LCtrl = false;
            VirtualKey = VirtualKeyCode.NONAME;
            ScanCode = 0;
            IsExtended = false;
            updateKeyDisplay(VirtualKey, ScanCode, IsExtended, false);
        }
    }
}
