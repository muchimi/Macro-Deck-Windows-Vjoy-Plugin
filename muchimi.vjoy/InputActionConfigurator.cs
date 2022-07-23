using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Interop;
using GregsStack.InputSimulatorStandard.Native;
using muchimi.vjoy;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;

namespace muchimi_vjoy
{

    
    public partial class InputActionConfigurator : ActionConfigControl
    {



        private InputAction inputAction;
        private ConfigData data = new ConfigData();


        public override bool OnActionSave()
        {
            Main.Instance.Config.SaveConfig();
            return data.SaveInputConfig(this.inputAction);
        }

        private void LoadConfig()
        {
            // loads the configuration for this action


           

            chk_keyboard_enabled.Checked = data.KeyboardEnabled;

            tb_interval.Text = data.KeyInterval.ToString();
            cb_key.Items.Clear();
            cb_key.Items.AddRange(Enum.GetNames(typeof(VirtualKeyCode)));
            cb_key.SelectedItem = data.KeyCode.ToString();
            lbl_key_extended.Text = data.IsExtended ? "(extended)" : "";

            cb_combo_key.Items.Clear();
            cb_combo_key.Items.AddRange(Enum.GetNames(typeof(VirtualKeyCode)));
            cb_combo_key.SelectedItem = data.ComboKeyCode.ToString();

            Main.Instance.Config.ApplicationListChanged += ApplicationListChanged;


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
            MacroDeckLogger.Info(Main.Instance,$"Loaded key interval: {data.KeyInterval} {data.ActionId}");

            lbl_message.Text = "";

            LoadApplicationList();

            cmd_paste.Enabled = Main.Instance.Config.InputClipboard != null;

            lbl_key_extended.Text = data.IsExtended ? $"(extended key) 0xE0 0x{data.ScanCode:X2}"  : $"(normal key) [0x{data.ScanCode:x2}]";

        }

        void LoadApplicationList()
        {
            var config = Main.Instance.Config;
            cb_applications.Items.Clear();
            if (config.ApplicationList.Count > 0)
            {
                foreach (var app in config.ApplicationList)
                {
                    cb_applications.Items.Add(app);
                }
            }

            var name = config.LastApplication;
            if (!string.IsNullOrEmpty(name) && config.ApplicationList.Contains(name))
                cb_applications.SelectedIndex = cb_applications.FindStringExact(name);


        }

        private void ApplicationListChanged(object sender, EventArgs e)
        {
            // called when the list is changed
            LoadApplicationList();
        }




        private void rb_shift_none_CheckedChanged(object sender, EventArgs e)
        {
            data.ShiftMode = EModifierMode.none;
        }

        private void rb_shift_left_CheckedChanged(object sender, EventArgs e)
        {
            data.ShiftMode = EModifierMode.left;
        }

        private void rb_shift_right_CheckedChanged(object sender, EventArgs e)
        {
            data.ShiftMode = EModifierMode.right;
        }

        private void rb_ctrl_none_CheckedChanged(object sender, EventArgs e)
        {
            data.CtrlMode = EModifierMode.none;
        }

        private void rb_ctrl_left_CheckedChanged(object sender, EventArgs e)
        {
            data.CtrlMode = EModifierMode.left;
        }

        private void rb_ctrl_right_CheckedChanged(object sender, EventArgs e)
        {
            data.CtrlMode = EModifierMode.right;
        }

        private void rb_alt_none_CheckedChanged(object sender, EventArgs e)
        {
            data.AltMode = EModifierMode.none;
        }

        private void rb_alt_left_CheckedChanged(object sender, EventArgs e)
        {
            data.AltMode = EModifierMode.left;
        }

        private void rb_alt_right_CheckedChanged(object sender, EventArgs e)
        {
            data.AltMode = EModifierMode.right;
        }


        private void cb_combo_key_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.KeyCode = Enum.Parse<VirtualKeyCode>(cb_combo_key.SelectedItem.ToString());
        }

        private void chk_combo_key_CheckedChanged(object sender, EventArgs e)
        {
            data.UseCombo = chk_combo_key.Checked;
        }

        private void rb_key_normal_CheckedChanged(object sender, EventArgs e)
        {
            data.KeyAction = EKeyAction.normal;
        }

        private void rb_keydown_CheckedChanged(object sender, EventArgs e)
        {
            data.KeyAction = EKeyAction.press;
        }

        private void rb_keyup_CheckedChanged(object sender, EventArgs e)
        {
            data.KeyAction = EKeyAction.release;
        }



        //private void cmd_select_application_Click(object sender, EventArgs e)
        //{
        //    var ofd = new OpenFileDialog();
        //    ofd.Filter = "Applications (*.exe)|*.exe;All Files (*.*)|*.*";
        //    ofd.CheckFileExists = true;
        //    ofd.Multiselect=false;
        //    var result = ofd.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        var config = Main.Instance.Config;
        //        var name = config.FixedName(Path.GetFileNameWithoutExtension(ofd.FileName));
        //        config.AddApplication(name);
        //        cb_applications.SelectedItem = name;


        //    }

        //}

 

        private void cmd_remove_Click(object sender, EventArgs e)
        {
            var config = Main.Instance.Config;
            config.RemoveApplication(cb_applications.SelectedItem.ToString());
        }

        private void cb_applications_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cb_applications.SelectedItem.ToString();
            cmd_remove.Enabled = ! string.IsNullOrEmpty(name);
            var config = Main.Instance.Config;
            config.LastApplication = name;
            data.TargetProcess = name;
        }

        private void cmd_add_Click(object sender, EventArgs e)
        {
            var dialog = new AddApplication();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var name = dialog.ApplicationName;

                var config = Main.Instance.Config;
                config.AddApplication(name);
                config.LastApplication = name;
                cb_applications.Items.Add(name);
                cb_applications.SelectedIndex = cb_applications.FindStringExact(name);
            }
        }

        private void cmd_copy_Click(object sender, EventArgs e)
        {
            MacroDeckLogger.Info(Main.Instance,$"Copy data {data.KeyInterval} {data.ActionId} ");
            Main.Instance.Config.InputCopy(data);
            cmd_paste.Enabled = Main.Instance.Config.InputClipboard != null;
        }

        private void cmd_paste_Click(object sender, EventArgs e)
        {
            var config = Main.Instance.Config;
            if (config.InputClipboard != null)
            {
                // update the data
                config.InputPaste(ref data);
                MacroDeckLogger.Info(Main.Instance, $"Pasting data {data.KeyInterval} {data.ActionId} ");
                // reload controls with new data
                LoadConfig();
            }
        }

        private void tb_interval_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(tb_interval.Text, out value))
            {
                lbl_message.Text = "Please enter a valid interval in milliseconds";
                return;
            }

            if (value <= 0)
            {
                value = 0;
                lbl_message.Text = "Interval must be >= 0";
            }

            data.KeyInterval = value;
            MacroDeckLogger.Info(Main.Instance, $"Change key interval {data.KeyInterval} {data.ActionId}");
        }

        private void cmd_capture_Click(object sender, EventArgs e)
        {
            var dialog = new KeyboardCapture();
            dialog.SetVirtualKey(data.KeyCode, data.ScanCode, data.IsExtended, data.ShiftMode,data.CtrlMode,data.AltMode);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                data.KeyCode = dialog.VirtualKey;
                data.ShiftMode = dialog.ShiftMode;
                data.AltMode = dialog.AltMode;
                data.CtrlMode = dialog.CtrlMode;
                data.ScanCode = dialog.ScanCode;
                data.IsExtended = dialog.IsExtended;
                LoadConfig();
            }
        }

        /// <summary>
        /// test button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_test_Click(object sender, EventArgs e)
        {
            var target_process = data.TargetProcess;
            var found = Main.FindApp(target_process);
            if (!found)
            {
                target_process = "Keyboard Key Info";
                found = Main.FindApp(target_process);
                if (!found)
                {
                    target_process = "Event Tester";
                    found = Main.FindApp(target_process);
                }
            }
            if (found)    // look for our event tester
            {
                Main.ActivateApp(target_process);
                var sim = Main.Instance.InputSim;
                sim.Keyboard.KeyPress(data.KeyCode, data.IsExtended);
                lbl_message.Text = "Test ok";
            }
            else
            {
                lbl_message.Text = $"Unable to switch focus to target application {data.TargetProcess}";
            }
            
        }
    }
}
