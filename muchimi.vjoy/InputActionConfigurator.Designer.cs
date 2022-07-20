using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using GregsStack.InputSimulatorStandard.Native;
using GregsStack.InputSimulatorStandard;

namespace muchimi_vjoy
{
    public partial class InputActionConfigurator : ActionConfigControl
    {
        public InputActionConfigurator(InputAction pluginAction, ActionConfigurator actionConfigurator)
        {
            InitializeComponent();

            this.inputAction = pluginAction;
            this.LoadConfig();
        }

        private Label label1;
        private Panel panel1;
        private RadioButton rb_ctrl_none;
        private RadioButton rb_ctrl_left;
        private RadioButton rb_ctrl_right;
        private Label label2;
        private Panel panel2;

        private Label lbl_message;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_ctrl_none = new System.Windows.Forms.RadioButton();
            this.rb_ctrl_left = new System.Windows.Forms.RadioButton();
            this.rb_ctrl_right = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rb_shift_none = new System.Windows.Forms.RadioButton();
            this.rb_shift_left = new System.Windows.Forms.RadioButton();
            this.rb_shift_right = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_interval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rb_key_normal = new System.Windows.Forms.RadioButton();
            this.rb_keydown = new System.Windows.Forms.RadioButton();
            this.rb_keyup = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.rb_alt_none = new System.Windows.Forms.RadioButton();
            this.rb_alt_left = new System.Windows.Forms.RadioButton();
            this.rb_alt_right = new System.Windows.Forms.RadioButton();
            this.cb_key = new System.Windows.Forms.ComboBox();
            this.chk_keyboard_enabled = new System.Windows.Forms.CheckBox();
            this.cb_combo_key = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chk_combo_key = new System.Windows.Forms.CheckBox();
            this.lbl_message = new System.Windows.Forms.Label();
            this.tb_target_application = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_ctrl_none);
            this.panel1.Controls.Add(this.rb_ctrl_left);
            this.panel1.Controls.Add(this.rb_ctrl_right);
            this.panel1.Location = new System.Drawing.Point(13, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 109);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rb_ctrl_none
            // 
            this.rb_ctrl_none.AutoSize = true;
            this.rb_ctrl_none.Location = new System.Drawing.Point(0, 0);
            this.rb_ctrl_none.Name = "rb_ctrl_none";
            this.rb_ctrl_none.Size = new System.Drawing.Size(72, 27);
            this.rb_ctrl_none.TabIndex = 3;
            this.rb_ctrl_none.TabStop = true;
            this.rb_ctrl_none.Text = "None";
            this.rb_ctrl_none.UseVisualStyleBackColor = true;
            this.rb_ctrl_none.CheckedChanged += new System.EventHandler(this.rb_ctrl_none_CheckedChanged);
            // 
            // rb_ctrl_left
            // 
            this.rb_ctrl_left.AutoSize = true;
            this.rb_ctrl_left.Location = new System.Drawing.Point(0, 33);
            this.rb_ctrl_left.Name = "rb_ctrl_left";
            this.rb_ctrl_left.Size = new System.Drawing.Size(93, 27);
            this.rb_ctrl_left.TabIndex = 1;
            this.rb_ctrl_left.TabStop = true;
            this.rb_ctrl_left.Text = "Left Ctrl";
            this.rb_ctrl_left.UseVisualStyleBackColor = true;
            // 
            // rb_ctrl_right
            // 
            this.rb_ctrl_right.AutoSize = true;
            this.rb_ctrl_right.Location = new System.Drawing.Point(0, 66);
            this.rb_ctrl_right.Name = "rb_ctrl_right";
            this.rb_ctrl_right.Size = new System.Drawing.Size(106, 27);
            this.rb_ctrl_right.TabIndex = 0;
            this.rb_ctrl_right.TabStop = true;
            this.rb_ctrl_right.Text = "Right Ctrl";
            this.rb_ctrl_right.UseVisualStyleBackColor = true;
            this.rb_ctrl_right.CheckedChanged += new System.EventHandler(this.rb_ctrl_right_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ctrl Modifier";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(385, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 181);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(217, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 181);
            this.panel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Shift Modifier";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rb_shift_none);
            this.panel4.Controls.Add(this.rb_shift_left);
            this.panel4.Controls.Add(this.rb_shift_right);
            this.panel4.Location = new System.Drawing.Point(13, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 109);
            this.panel4.TabIndex = 2;
            // 
            // rb_shift_none
            // 
            this.rb_shift_none.AutoSize = true;
            this.rb_shift_none.Location = new System.Drawing.Point(0, 0);
            this.rb_shift_none.Name = "rb_shift_none";
            this.rb_shift_none.Size = new System.Drawing.Size(72, 27);
            this.rb_shift_none.TabIndex = 3;
            this.rb_shift_none.TabStop = true;
            this.rb_shift_none.Text = "None";
            this.rb_shift_none.UseVisualStyleBackColor = true;
            this.rb_shift_none.CheckedChanged += new System.EventHandler(this.rb_shift_none_CheckedChanged);
            // 
            // rb_shift_left
            // 
            this.rb_shift_left.AutoSize = true;
            this.rb_shift_left.Location = new System.Drawing.Point(0, 33);
            this.rb_shift_left.Name = "rb_shift_left";
            this.rb_shift_left.Size = new System.Drawing.Size(103, 27);
            this.rb_shift_left.TabIndex = 1;
            this.rb_shift_left.TabStop = true;
            this.rb_shift_left.Text = "Left Shift";
            this.rb_shift_left.UseVisualStyleBackColor = true;
            this.rb_shift_left.CheckedChanged += new System.EventHandler(this.rb_shift_left_CheckedChanged);
            // 
            // rb_shift_right
            // 
            this.rb_shift_right.AutoSize = true;
            this.rb_shift_right.Location = new System.Drawing.Point(0, 66);
            this.rb_shift_right.Name = "rb_shift_right";
            this.rb_shift_right.Size = new System.Drawing.Size(116, 27);
            this.rb_shift_right.TabIndex = 0;
            this.rb_shift_right.TabStop = true;
            this.rb_shift_right.Text = "Right Shift";
            this.rb_shift_right.UseVisualStyleBackColor = true;
            this.rb_shift_right.CheckedChanged += new System.EventHandler(this.rb_shift_right_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tb_interval);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(7, 95);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(204, 253);
            this.panel5.TabIndex = 5;
            // 
            // tb_interval
            // 
            this.tb_interval.Location = new System.Drawing.Point(13, 195);
            this.tb_interval.Name = "tb_interval";
            this.tb_interval.Size = new System.Drawing.Size(100, 30);
            this.tb_interval.TabIndex = 5;
            this.tb_interval.TextChanged += new System.EventHandler(this.tb_interval_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Interval (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Action";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rb_key_normal);
            this.panel6.Controls.Add(this.rb_keydown);
            this.panel6.Controls.Add(this.rb_keyup);
            this.panel6.Location = new System.Drawing.Point(13, 45);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(188, 109);
            this.panel6.TabIndex = 2;
            // 
            // rb_key_normal
            // 
            this.rb_key_normal.AutoSize = true;
            this.rb_key_normal.Location = new System.Drawing.Point(0, 0);
            this.rb_key_normal.Name = "rb_key_normal";
            this.rb_key_normal.Size = new System.Drawing.Size(142, 27);
            this.rb_key_normal.TabIndex = 3;
            this.rb_key_normal.TabStop = true;
            this.rb_key_normal.Text = "Press/Release";
            this.rb_key_normal.UseVisualStyleBackColor = true;
            this.rb_key_normal.CheckedChanged += new System.EventHandler(this.rb_key_normal_CheckedChanged);
            // 
            // rb_keydown
            // 
            this.rb_keydown.AutoSize = true;
            this.rb_keydown.Location = new System.Drawing.Point(0, 33);
            this.rb_keydown.Name = "rb_keydown";
            this.rb_keydown.Size = new System.Drawing.Size(167, 27);
            this.rb_keydown.TabIndex = 1;
            this.rb_keydown.TabStop = true;
            this.rb_keydown.Text = "Press (Keydown)";
            this.rb_keydown.UseVisualStyleBackColor = true;
            this.rb_keydown.CheckedChanged += new System.EventHandler(this.rb_keydown_CheckedChanged);
            // 
            // rb_keyup
            // 
            this.rb_keyup.AutoSize = true;
            this.rb_keyup.Location = new System.Drawing.Point(0, 66);
            this.rb_keyup.Name = "rb_keyup";
            this.rb_keyup.Size = new System.Drawing.Size(164, 27);
            this.rb_keyup.TabIndex = 0;
            this.rb_keyup.TabStop = true;
            this.rb_keyup.Text = "Release (Keyup)";
            this.rb_keyup.UseVisualStyleBackColor = true;
            this.rb_keyup.CheckedChanged += new System.EventHandler(this.rb_keyup_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(557, 92);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(166, 181);
            this.panel7.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Alt Modifier";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rb_alt_none);
            this.panel8.Controls.Add(this.rb_alt_left);
            this.panel8.Controls.Add(this.rb_alt_right);
            this.panel8.Location = new System.Drawing.Point(13, 45);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(128, 109);
            this.panel8.TabIndex = 2;
            // 
            // rb_alt_none
            // 
            this.rb_alt_none.AutoSize = true;
            this.rb_alt_none.Location = new System.Drawing.Point(0, 0);
            this.rb_alt_none.Name = "rb_alt_none";
            this.rb_alt_none.Size = new System.Drawing.Size(72, 27);
            this.rb_alt_none.TabIndex = 3;
            this.rb_alt_none.TabStop = true;
            this.rb_alt_none.Text = "None";
            this.rb_alt_none.UseVisualStyleBackColor = true;
            this.rb_alt_none.CheckedChanged += new System.EventHandler(this.rb_alt_none_CheckedChanged);
            // 
            // rb_alt_left
            // 
            this.rb_alt_left.AutoSize = true;
            this.rb_alt_left.Location = new System.Drawing.Point(0, 33);
            this.rb_alt_left.Name = "rb_alt_left";
            this.rb_alt_left.Size = new System.Drawing.Size(86, 27);
            this.rb_alt_left.TabIndex = 1;
            this.rb_alt_left.TabStop = true;
            this.rb_alt_left.Text = "Left Alt";
            this.rb_alt_left.UseVisualStyleBackColor = true;
            this.rb_alt_left.CheckedChanged += new System.EventHandler(this.rb_alt_left_CheckedChanged);
            // 
            // rb_alt_right
            // 
            this.rb_alt_right.AutoSize = true;
            this.rb_alt_right.Location = new System.Drawing.Point(0, 66);
            this.rb_alt_right.Name = "rb_alt_right";
            this.rb_alt_right.Size = new System.Drawing.Size(99, 27);
            this.rb_alt_right.TabIndex = 0;
            this.rb_alt_right.TabStop = true;
            this.rb_alt_right.Text = "Right Alt";
            this.rb_alt_right.UseVisualStyleBackColor = true;
            this.rb_alt_right.CheckedChanged += new System.EventHandler(this.rb_alt_right_CheckedChanged);
            // 
            // cb_key
            // 
            this.cb_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_key.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_key.FormattingEnabled = true;
            this.cb_key.Location = new System.Drawing.Point(60, 44);
            this.cb_key.Name = "cb_key";
            this.cb_key.Size = new System.Drawing.Size(217, 27);
            this.cb_key.TabIndex = 7;
            this.cb_key.SelectedIndexChanged += new System.EventHandler(this.cb_key_SelectedIndexChanged);
            // 
            // chk_keyboard_enabled
            // 
            this.chk_keyboard_enabled.AutoSize = true;
            this.chk_keyboard_enabled.Location = new System.Drawing.Point(7, 1);
            this.chk_keyboard_enabled.Name = "chk_keyboard_enabled";
            this.chk_keyboard_enabled.Size = new System.Drawing.Size(108, 27);
            this.chk_keyboard_enabled.TabIndex = 8;
            this.chk_keyboard_enabled.Text = "Keyboard";
            this.chk_keyboard_enabled.UseVisualStyleBackColor = true;
            this.chk_keyboard_enabled.CheckedChanged += new System.EventHandler(this.chk_keyboard_enabled_CheckedChanged);
            // 
            // cb_combo_key
            // 
            this.cb_combo_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_combo_key.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_combo_key.FormattingEnabled = true;
            this.cb_combo_key.Location = new System.Drawing.Point(486, 44);
            this.cb_combo_key.Name = "cb_combo_key";
            this.cb_combo_key.Size = new System.Drawing.Size(217, 27);
            this.cb_combo_key.TabIndex = 9;
            this.cb_combo_key.SelectedIndexChanged += new System.EventHandler(this.cb_combo_key_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(426, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Key";
            // 
            // chk_combo_key
            // 
            this.chk_combo_key.AutoSize = true;
            this.chk_combo_key.Location = new System.Drawing.Point(297, 46);
            this.chk_combo_key.Name = "chk_combo_key";
            this.chk_combo_key.Size = new System.Drawing.Size(123, 27);
            this.chk_combo_key.TabIndex = 11;
            this.chk_combo_key.Text = "Combo Key";
            this.chk_combo_key.UseVisualStyleBackColor = true;
            this.chk_combo_key.CheckedChanged += new System.EventHandler(this.chk_combo_key_CheckedChanged);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(24, 370);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(82, 23);
            this.lbl_message.TabIndex = 12;
            this.lbl_message.Text = "Message";
            // 
            // tb_target_application
            // 
            this.tb_target_application.Location = new System.Drawing.Point(221, 318);
            this.tb_target_application.Name = "tb_target_application";
            this.tb_target_application.Size = new System.Drawing.Size(245, 30);
            this.tb_target_application.TabIndex = 13;
            this.tb_target_application.TextChanged += new System.EventHandler(this.tb_target_application_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Target Application:";
            // 
            // InputActionConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_target_application);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.chk_combo_key);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_combo_key);
            this.Controls.Add(this.chk_keyboard_enabled);
            this.Controls.Add(this.cb_key);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Name = "InputActionConfigurator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel panel3;
        private Label label3;
        private Panel panel4;
        private RadioButton rb_shift_none;
        private RadioButton rb_shift_left;
        private RadioButton rb_shift_right;
        private Panel panel5;
        private TextBox tb_interval;
        private Label label5;
        private Label label4;
        private Panel panel6;
        private RadioButton rb_key_normal;
        private RadioButton rb_keydown;
        private RadioButton rb_keyup;
        private Panel panel7;
        private Label label6;
        private Panel panel8;
        private RadioButton rb_alt_none;
        private RadioButton rb_alt_left;
        private RadioButton rb_alt_right;


        private System.Windows.Forms.ComboBox cb_key;
        private CheckBox chk_keyboard_enabled;

        private void chk_keyboard_enabled_CheckedChanged(object sender, EventArgs e)
        {
            data.KeyboardEnabled = chk_keyboard_enabled.Checked;
        }

        private void cb_key_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.KeyCode = Enum.Parse<VirtualKeyCode>(cb_key.SelectedItem.ToString());
        }

        private System.Windows.Forms.ComboBox cb_combo_key;
        private Label label7;
        private CheckBox chk_combo_key;


   

        private TextBox tb_target_application;
        private Label label8;
    }
}
