using System.Collections.Generic;
using muchimi_vjoy;
using SuchByte.MacroDeck.Logging;
using vJoy.Wrapper;

namespace muchimi.vjoy
{

    public class VjoyInstance
    {
        private uint _max_id = 0;
        private Dictionary<int, VirtualJoystick> _joyMap = new Dictionary<int, VirtualJoystick>();

        public uint max_id
        {
            get
            {
                return _max_id;
            }
        }

        public VirtualJoystick GetJoystick(uint deviceId)
        {
            VirtualJoystick joy;
            int id = (int)deviceId;
            if (!_joyMap.TryGetValue(id, out joy))
            {
                joy = new VirtualJoystick(deviceId);
                _joyMap[id] = joy;
            }


            return joy;
        }

        /// <summary>
        /// releases all used items
        /// </summary>
        public void Release()
        {
            foreach (var joy in _joyMap.Values)
            {
                if (joy.Aquired)
                    joy.Release();
            }

        }



        public void Press(uint deviceId, uint button)
        {
            var joy = GetJoystick(deviceId);
            if (!joy.Aquired)
                joy.Aquire();
            if (joy.Aquired)
            {
                joy.SetJoystickButton(true, button);
                joy.Release();
                MacroDeckLogger.Info(Main.Instance,$"Press {deviceId} button {button}");
            }


        }

        public void Release(uint deviceId, uint button)
        {
            var joy = GetJoystick(deviceId);
            if (!joy.Aquired)
                joy.Aquire();
            if (joy.Aquired)
            {
                joy.SetJoystickButton(false, button);
                MacroDeckLogger.Info(Main.Instance, $"Release {deviceId} button {button}");
                joy.Release();
            }

        }



        /// <summary>
        /// converts a hat position to a vjoy hat value
        /// </summary>
        /// <param name="x">0 center, 1 = right, -1 = left</param>
        /// <param name="y">0 center, 1 = up, -1 = down</param>
        /// <returns></returns>
        public int HatValue(int x, int y)
        {
            switch (x)
            {
                case 0:
                    switch (y)
                    {
                        case 0:
                            return -1; // 0,0
                        case 1:
                            return 0; // 0,1
                        case -1:
                            return 18000; // 0, -1
                    }

                    break;
                case -1:
                    switch (y)
                    {
                        case 0:
                            return 27000; // -1,0
                        case 1:
                            return 31500; // -1,1
                        case -1:
                            return 22500; // -1, -1
                    }
                    break;
                case 1:
                    switch (y)
                    {
                        case 0:
                            return 9000; // 1,0
                        case 1:
                            return 4500; // 1,1
                        case -1:
                            return 13500; // 1, -1
                    }
                    break;
            }

            return -1;

        }

        /// <summary>
        /// converts a hat axis value to x/y coordinates
        /// </summary>
        /// <param name="value"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void HatCoords(int value, out int x, out int y)
        {
            x = 0;
            y = 0;
            switch (value)
            {
                //    -1: (0, 0),
                case -1:
                    x = 0;
                    y = 0;
                    break;
                //    0: (0, 1),
                case 0:
                    x = 0;
                    y = 1;
                    break;
                //    4500: (1, 1),
                case 4500:
                    x = 1;
                    y = 1;
                    break;
                //    9000: (1, 0),
                case 9000:
                    x = 1;
                    y = 0;
                    break;
                //    13500: (1, -1)
                case 13500:
                    x = 1;
                    y = -1;
                    break;
                //    18000: (0, -1),
                case 18000:
                    x = 0;
                    y = -1;
                    break;
                //    22500: (-1, -1),
                case 22500:
                    x = -1;
                    y = -1;
                    break;
                //    27000: (-1, 0),
                case 27000:
                    x = -1;
                    y = 0;
                    break;
                //    31500: (-1, 1)
                case 31500:
                    x = -1;
                    y = 1;
                    break;
                    //}
            }

        }

        //dill_hat_lookup = {
        //    -1: (0, 0),
        //    0: (0, 1),
        //    4500: (1, 1),
        //    9000: (1, 0),
        //    13500: (1, -1),
        //    18000: (0, -1),
        //    22500: (-1, -1),
        //    27000: (-1, 0),
        //    31500: (-1, 1)
        //}


        /// <summary>
        /// converts a float value like in Gremlin from -1 to 1 into a value VJOY understands
        /// </summary>
        /// <param name="value">an axis value between -1.0 and +1.0 with 0.0 being the center of the axis</param>
        /// <returns>a vjoy axis value</returns>
        public int ToVjoyRange(double value)
        {
            int vv = (int)((value + 1.0) * 0x4000);
            return vv;
        }

        /// <summary>
        /// converts a vjoy axis value to a -1.0, 1.0 range
        /// </summary>
        /// <param name="value"></param>
        /// <returns>a value between the range of -1.0 and 1.0 with 0.0 being the center</returns>
        public double RangeFromVjoy(int value)
        {
            double vv = (double)(value) / (double)(0x4000) - 1.0;
            return vv;

        }

        /// <summary>
        /// returns a wrapper axis from a plugin axis
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public vJoy.Wrapper.Axis WrapperAxisFromAxis(VJoyAxis axis)
        {
            switch (axis)

            {
                case VJoyAxis.AXIS_X:
                    return Axis.HID_USAGE_X;

                case VJoyAxis.AXIS_Y:
                    return Axis.HID_USAGE_Y;

                case VJoyAxis.AXIS_Z:
                    return Axis.HID_USAGE_Z;

                case VJoyAxis.AXIS_RX:
                    return Axis.HID_USAGE_RX;

                case VJoyAxis.AXIS_RY:
                    return Axis.HID_USAGE_RX;

                case VJoyAxis.AXIS_RZ:
                    return Axis.HID_USAGE_RX;

                case VJoyAxis.AXIS_SL0:
                    return Axis.HID_USAGE_RX;

                case VJoyAxis.AXIS_SL1:
                    return Axis.HID_USAGE_RX;
            }

            return Axis.HID_USAGE_X;
        }

        /// <summary>
        /// returns a wrapper hat from a plugin axis
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public Hats WrapperHatFromAxis(VJoyAxis axis)
        {
            switch (axis)
            {
                case VJoyAxis.AXIS_HAT0:
                    return Hats.Hat;
                case VJoyAxis.AXIS_HAT1:
                    return Hats.HatExt1;
                case VJoyAxis.AXIS_HAT2:
                    return Hats.HatExt2;
                case VJoyAxis.AXIS_HAT3:
                    return Hats.HatExt3;
            }

            return Hats.Hat;

        }

        /// <summary>
        ///  gets the current axis value as a range -1.0 to 1.0
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public bool GetAxis(uint deviceId, VJoyAxis axis, out double value, out int x, out int y)
        {

            var joy = GetJoystick(deviceId);
            x = 0;
            y = 0;
            value = 0;
            try
            {
            
                if (!joy.Aquired)
                    joy.Aquire();

                if (joy.Aquired)
                {
                    if (IsAxisHat(axis))
                    {


                        // read hat value
                        Hats hat = WrapperHatFromAxis(axis);

                        // convert to x/y values
                        var hat_value = joy.GetJoystickHat(hat);
                        this.HatCoords(hat_value, out x, out y);
                        value = hat_value;
                        return true;
                    }

                    // read regular axis
                    var wrapper_axis = WrapperAxisFromAxis(axis);
                    var axis_value = joy.GetJoystickAxis(wrapper_axis);
                    value = RangeFromVjoy(axis_value);
                    return true;

                }

                return false;
            }
            finally
            {
                joy.Release();
            }
        }


        /// <summary>
        /// converts from an axis enum to a vjoy HID axis number
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public void SetAxis(uint deviceId, VJoyAxis axis, double value, int x = 0, int y = 0)
        {

            var joy = GetJoystick(deviceId);
            if (!joy.Aquired)
                joy.Aquire();
            if (joy.Aquired)
            {

                bool isHat = IsAxisHat(axis);

                if (isHat)
                {
                    Hats hat = WrapperHatFromAxis(axis);
                    var hat_value = HatValue(x, y);
                    joy.SetJoystickHat(hat_value, hat);
                    //MacroDeckLogger.Info(Main.Instance,$"Set hat: {deviceId} {hat} {x} {y} {hat_value}");

                }
                else
                {
                    Axis vax = WrapperAxisFromAxis(axis);
                    int axis_value = ToVjoyRange(value);
                    joy.SetJoystickAxis(axis_value, vax);
                    //MacroDeckLogger.Info(Main.Instance, $"Set axis: {deviceId} {axis} {value}");

                }
                joy.Release();
            }

        }


        public VJoyAxis AxisFromName(string name)
        {
            switch (name)
            {
                case "X":
                case "AXIS_X":
                    return VJoyAxis.AXIS_X;
                case "Y":
                case "AXIS_Y":
                    return VJoyAxis.AXIS_Y;
                case "Z":
                case "AXIS_Z":
                    return VJoyAxis.AXIS_Z;
                case "Rx":
                case "AXIS_RX":
                    return VJoyAxis.AXIS_RX;
                case "Ry":
                case "AXIS_RY":
                    return VJoyAxis.AXIS_RY;
                case "Rz":
                case "AXIS_RZ":
                    return VJoyAxis.AXIS_RZ;
                case "sl0":
                case "AXIS_SL0":
                    return VJoyAxis.AXIS_SL0;
                case "sl1":
                case "AXIS_SL1":
                    return VJoyAxis.AXIS_SL1;
                case "hat0":
                case "AXIS_HAT0":
                    return VJoyAxis.AXIS_HAT0;
                case "hat1":
                case "AXIS_HAT1":
                    return VJoyAxis.AXIS_HAT1;
                case "hat2":
                case "AXIS_HAT2":
                    return VJoyAxis.AXIS_HAT2;
                case "hat3":
                case "AXIS_HAT3":
                    return VJoyAxis.AXIS_HAT3;

            }

            return VJoyAxis.AXIS_X;

        }

        /// <summary>
        /// checks if the given axis is a hat axis
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public bool IsAxisHat(VJoyAxis axis)
        {
            switch (axis)
            {
                case VJoyAxis.AXIS_HAT0:
                case VJoyAxis.AXIS_HAT1:
                case VJoyAxis.AXIS_HAT2:
                case VJoyAxis.AXIS_HAT3:
                    return true;
            }
            return false;
        }

        

    }

}
