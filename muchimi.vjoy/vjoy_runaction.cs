using System.Runtime.InteropServices;
using System.Threading;
using muchimi_vjoy;
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
