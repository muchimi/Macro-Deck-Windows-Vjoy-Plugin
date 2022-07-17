using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Windows.Navigation;
using Windows.ApplicationModel.Calls.Background;
using HidSharp.Reports.Units;
using muchimi_vjoy;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Variables.Plugin.GUI;
using vJoy.Wrapper;
using Timer = System.Timers.Timer;

namespace muchimi.vjoy
{
    internal class RunAction
    {
        private ConfigData _data;

        private Timer _button_timer;
        private GCHandle _buttonTimerHandle;

        private Timer _axis_timer;
        private GCHandle _axisTimerHandle;


        public RunAction(ConfigData data)
        {
            this._data = data;
            CancellationTokenSource cts = new CancellationTokenSource();
        }

       

       


    }
}
