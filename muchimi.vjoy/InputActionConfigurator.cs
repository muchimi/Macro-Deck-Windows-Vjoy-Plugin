using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GregsStack.InputSimulatorStandard.Native;
using SuchByte.MacroDeck.GUI.CustomControls;

namespace muchimi_vjoy
{
    
    public partial class InputActionConfigurator : ActionConfigControl
    {
        private void tb_target_application_TextChanged(object sender, EventArgs e)
        {
            data.TargetProcess = tb_target_application.Text;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void tb_interval_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(tb_interval.Text, out value))
            {
                lbl_message.Text = "Please enter a valid interval number";
                return;
            }
            if (value < 0)
            {
                lbl_message.Text = "Interval number must be >= 0";
                return;
            }

            data.KeyInterval = value;
        }
    }
}
