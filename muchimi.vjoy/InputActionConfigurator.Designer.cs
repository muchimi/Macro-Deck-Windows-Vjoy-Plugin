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
            data.LoadInputConfig(pluginAction);
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
            this.tb_interval = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
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
            this.chk_keyboard_enabled = new System.Windows.Forms.CheckBox();
            this.cb_combo_key = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chk_combo_key = new System.Windows.Forms.CheckBox();
            this.lbl_message = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_applications = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
            this.cmd_remove = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_add = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cb_key = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
            this.cmd_copy = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_paste = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_capture = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_test = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lbl_key_extended = new System.Windows.Forms.Label();
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
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_ctrl_none);
            this.panel1.Controls.Add(this.rb_ctrl_left);
            this.panel1.Controls.Add(this.rb_ctrl_right);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(13, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 109);
            this.panel1.TabIndex = 2;
            // 
            // rb_ctrl_none
            // 
            this.rb_ctrl_none.AutoSize = true;
            this.rb_ctrl_none.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_ctrl_none.Location = new System.Drawing.Point(0, 0);
            this.rb_ctrl_none.Name = "rb_ctrl_none";
            this.rb_ctrl_none.Size = new System.Drawing.Size(54, 20);
            this.rb_ctrl_none.TabIndex = 3;
            this.rb_ctrl_none.TabStop = true;
            this.rb_ctrl_none.Text = "None";
            this.rb_ctrl_none.UseVisualStyleBackColor = true;
            this.rb_ctrl_none.CheckedChanged += new System.EventHandler(this.rb_ctrl_none_CheckedChanged);
            // 
            // rb_ctrl_left
            // 
            this.rb_ctrl_left.AutoSize = true;
            this.rb_ctrl_left.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_ctrl_left.Location = new System.Drawing.Point(0, 33);
            this.rb_ctrl_left.Name = "rb_ctrl_left";
            this.rb_ctrl_left.Size = new System.Drawing.Size(70, 20);
            this.rb_ctrl_left.TabIndex = 1;
            this.rb_ctrl_left.TabStop = true;
            this.rb_ctrl_left.Text = "Left Ctrl";
            this.rb_ctrl_left.UseVisualStyleBackColor = true;
            this.rb_ctrl_left.CheckedChanged += new System.EventHandler(this.rb_ctrl_left_CheckedChanged);
            // 
            // rb_ctrl_right
            // 
            this.rb_ctrl_right.AutoSize = true;
            this.rb_ctrl_right.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_ctrl_right.Location = new System.Drawing.Point(0, 66);
            this.rb_ctrl_right.Name = "rb_ctrl_right";
            this.rb_ctrl_right.Size = new System.Drawing.Size(78, 20);
            this.rb_ctrl_right.TabIndex = 0;
            this.rb_ctrl_right.TabStop = true;
            this.rb_ctrl_right.Text = "Right Ctrl";
            this.rb_ctrl_right.UseVisualStyleBackColor = true;
            this.rb_ctrl_right.CheckedChanged += new System.EventHandler(this.rb_ctrl_right_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ctrl Modifier";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(385, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 181);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(217, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 181);
            this.panel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Shift Modifier";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rb_shift_none);
            this.panel4.Controls.Add(this.rb_shift_left);
            this.panel4.Controls.Add(this.rb_shift_right);
            this.panel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel4.Location = new System.Drawing.Point(13, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 109);
            this.panel4.TabIndex = 2;
            // 
            // rb_shift_none
            // 
            this.rb_shift_none.AutoSize = true;
            this.rb_shift_none.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_shift_none.Location = new System.Drawing.Point(0, 0);
            this.rb_shift_none.Name = "rb_shift_none";
            this.rb_shift_none.Size = new System.Drawing.Size(54, 20);
            this.rb_shift_none.TabIndex = 3;
            this.rb_shift_none.TabStop = true;
            this.rb_shift_none.Text = "None";
            this.rb_shift_none.UseVisualStyleBackColor = true;
            this.rb_shift_none.CheckedChanged += new System.EventHandler(this.rb_shift_none_CheckedChanged);
            // 
            // rb_shift_left
            // 
            this.rb_shift_left.AutoSize = true;
            this.rb_shift_left.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_shift_left.Location = new System.Drawing.Point(0, 33);
            this.rb_shift_left.Name = "rb_shift_left";
            this.rb_shift_left.Size = new System.Drawing.Size(76, 20);
            this.rb_shift_left.TabIndex = 1;
            this.rb_shift_left.TabStop = true;
            this.rb_shift_left.Text = "Left Shift";
            this.rb_shift_left.UseVisualStyleBackColor = true;
            this.rb_shift_left.CheckedChanged += new System.EventHandler(this.rb_shift_left_CheckedChanged);
            // 
            // rb_shift_right
            // 
            this.rb_shift_right.AutoSize = true;
            this.rb_shift_right.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_shift_right.Location = new System.Drawing.Point(0, 66);
            this.rb_shift_right.Name = "rb_shift_right";
            this.rb_shift_right.Size = new System.Drawing.Size(84, 20);
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
            this.panel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel5.Location = new System.Drawing.Point(7, 95);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(204, 253);
            this.panel5.TabIndex = 5;
            // 
            // tb_interval
            // 
            this.tb_interval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_interval.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_interval.Icon = null;
            this.tb_interval.Location = new System.Drawing.Point(110, 169);
            this.tb_interval.MaxCharacters = 32767;
            this.tb_interval.Multiline = false;
            this.tb_interval.Name = "tb_interval";
            this.tb_interval.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_interval.PasswordChar = false;
            this.tb_interval.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_interval.PlaceHolderText = "";
            this.tb_interval.ReadOnly = false;
            this.tb_interval.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_interval.SelectionStart = 0;
            this.tb_interval.Size = new System.Drawing.Size(77, 25);
            this.tb_interval.TabIndex = 22;
            this.tb_interval.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_interval.TextChanged += new System.EventHandler(this.tb_interval_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Interval (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Action";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rb_key_normal);
            this.panel6.Controls.Add(this.rb_keydown);
            this.panel6.Controls.Add(this.rb_keyup);
            this.panel6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel6.Location = new System.Drawing.Point(13, 45);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(188, 109);
            this.panel6.TabIndex = 2;
            // 
            // rb_key_normal
            // 
            this.rb_key_normal.AutoSize = true;
            this.rb_key_normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_key_normal.Location = new System.Drawing.Point(0, 0);
            this.rb_key_normal.Name = "rb_key_normal";
            this.rb_key_normal.Size = new System.Drawing.Size(106, 20);
            this.rb_key_normal.TabIndex = 3;
            this.rb_key_normal.TabStop = true;
            this.rb_key_normal.Text = "Press/Release";
            this.rb_key_normal.UseVisualStyleBackColor = true;
            this.rb_key_normal.CheckedChanged += new System.EventHandler(this.rb_key_normal_CheckedChanged);
            // 
            // rb_keydown
            // 
            this.rb_keydown.AutoSize = true;
            this.rb_keydown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_keydown.Location = new System.Drawing.Point(0, 33);
            this.rb_keydown.Name = "rb_keydown";
            this.rb_keydown.Size = new System.Drawing.Size(121, 20);
            this.rb_keydown.TabIndex = 1;
            this.rb_keydown.TabStop = true;
            this.rb_keydown.Text = "Press (Keydown)";
            this.rb_keydown.UseVisualStyleBackColor = true;
            this.rb_keydown.CheckedChanged += new System.EventHandler(this.rb_keydown_CheckedChanged);
            // 
            // rb_keyup
            // 
            this.rb_keyup.AutoSize = true;
            this.rb_keyup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_keyup.Location = new System.Drawing.Point(0, 66);
            this.rb_keyup.Name = "rb_keyup";
            this.rb_keyup.Size = new System.Drawing.Size(118, 20);
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
            this.panel7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel7.Location = new System.Drawing.Point(557, 92);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(166, 181);
            this.panel7.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Alt Modifier";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.rb_alt_none);
            this.panel8.Controls.Add(this.rb_alt_left);
            this.panel8.Controls.Add(this.rb_alt_right);
            this.panel8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel8.Location = new System.Drawing.Point(13, 45);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(128, 109);
            this.panel8.TabIndex = 2;
            // 
            // rb_alt_none
            // 
            this.rb_alt_none.AutoSize = true;
            this.rb_alt_none.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_alt_none.Location = new System.Drawing.Point(0, 0);
            this.rb_alt_none.Name = "rb_alt_none";
            this.rb_alt_none.Size = new System.Drawing.Size(54, 20);
            this.rb_alt_none.TabIndex = 3;
            this.rb_alt_none.TabStop = true;
            this.rb_alt_none.Text = "None";
            this.rb_alt_none.UseVisualStyleBackColor = true;
            this.rb_alt_none.CheckedChanged += new System.EventHandler(this.rb_alt_none_CheckedChanged);
            // 
            // rb_alt_left
            // 
            this.rb_alt_left.AutoSize = true;
            this.rb_alt_left.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_alt_left.Location = new System.Drawing.Point(0, 33);
            this.rb_alt_left.Name = "rb_alt_left";
            this.rb_alt_left.Size = new System.Drawing.Size(65, 20);
            this.rb_alt_left.TabIndex = 1;
            this.rb_alt_left.TabStop = true;
            this.rb_alt_left.Text = "Left Alt";
            this.rb_alt_left.UseVisualStyleBackColor = true;
            this.rb_alt_left.CheckedChanged += new System.EventHandler(this.rb_alt_left_CheckedChanged);
            // 
            // rb_alt_right
            // 
            this.rb_alt_right.AutoSize = true;
            this.rb_alt_right.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_alt_right.Location = new System.Drawing.Point(0, 66);
            this.rb_alt_right.Name = "rb_alt_right";
            this.rb_alt_right.Size = new System.Drawing.Size(73, 20);
            this.rb_alt_right.TabIndex = 0;
            this.rb_alt_right.TabStop = true;
            this.rb_alt_right.Text = "Right Alt";
            this.rb_alt_right.UseVisualStyleBackColor = true;
            this.rb_alt_right.CheckedChanged += new System.EventHandler(this.rb_alt_right_CheckedChanged);
            // 
            // chk_keyboard_enabled
            // 
            this.chk_keyboard_enabled.AutoSize = true;
            this.chk_keyboard_enabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chk_keyboard_enabled.Location = new System.Drawing.Point(7, 1);
            this.chk_keyboard_enabled.Name = "chk_keyboard_enabled";
            this.chk_keyboard_enabled.Size = new System.Drawing.Size(71, 20);
            this.chk_keyboard_enabled.TabIndex = 8;
            this.chk_keyboard_enabled.Text = "Enabled";
            this.chk_keyboard_enabled.UseVisualStyleBackColor = true;
            this.chk_keyboard_enabled.CheckedChanged += new System.EventHandler(this.chk_keyboard_enabled_CheckedChanged);
            // 
            // cb_combo_key
            // 
            this.cb_combo_key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cb_combo_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_combo_key.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_combo_key.Icon = null;
            this.cb_combo_key.Location = new System.Drawing.Point(557, 38);
            this.cb_combo_key.Name = "cb_combo_key";
            this.cb_combo_key.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.cb_combo_key.SelectedIndex = -1;
            this.cb_combo_key.SelectedItem = null;
            this.cb_combo_key.Size = new System.Drawing.Size(217, 28);
            this.cb_combo_key.TabIndex = 9;
            this.cb_combo_key.SelectedIndexChanged += new System.EventHandler(this.cb_combo_key_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(524, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Key";
            // 
            // chk_combo_key
            // 
            this.chk_combo_key.AutoSize = true;
            this.chk_combo_key.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chk_combo_key.Location = new System.Drawing.Point(436, 45);
            this.chk_combo_key.Name = "chk_combo_key";
            this.chk_combo_key.Size = new System.Drawing.Size(90, 20);
            this.chk_combo_key.TabIndex = 11;
            this.chk_combo_key.Text = "Combo Key";
            this.chk_combo_key.UseVisualStyleBackColor = true;
            this.chk_combo_key.CheckedChanged += new System.EventHandler(this.chk_combo_key_CheckedChanged);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_message.Location = new System.Drawing.Point(21, 363);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(57, 16);
            this.lbl_message.TabIndex = 12;
            this.lbl_message.Text = "Message";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(218, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Target Application:";
            // 
            // cb_applications
            // 
            this.cb_applications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cb_applications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_applications.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_applications.Icon = null;
            this.cb_applications.Location = new System.Drawing.Point(217, 322);
            this.cb_applications.Name = "cb_applications";
            this.cb_applications.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.cb_applications.SelectedIndex = -1;
            this.cb_applications.SelectedItem = null;
            this.cb_applications.Size = new System.Drawing.Size(250, 28);
            this.cb_applications.TabIndex = 17;
            this.cb_applications.SelectedIndexChanged += new System.EventHandler(this.cb_applications_SelectedIndexChanged);
            // 
            // cmd_remove
            // 
            this.cmd_remove.BorderRadius = 8;
            this.cmd_remove.FlatAppearance.BorderSize = 0;
            this.cmd_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_remove.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_remove.ForeColor = System.Drawing.Color.White;
            this.cmd_remove.HoverColor = System.Drawing.Color.Empty;
            this.cmd_remove.Icon = null;
            this.cmd_remove.Location = new System.Drawing.Point(553, 324);
            this.cmd_remove.Name = "cmd_remove";
            this.cmd_remove.Progress = 0;
            this.cmd_remove.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_remove.Size = new System.Drawing.Size(74, 26);
            this.cmd_remove.TabIndex = 18;
            this.cmd_remove.Text = "Delete";
            this.cmd_remove.UseVisualStyleBackColor = true;
            this.cmd_remove.UseWindowsAccentColor = true;
            this.cmd_remove.Click += new System.EventHandler(this.cmd_remove_Click);
            // 
            // cmd_add
            // 
            this.cmd_add.BorderRadius = 8;
            this.cmd_add.FlatAppearance.BorderSize = 0;
            this.cmd_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_add.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_add.ForeColor = System.Drawing.Color.White;
            this.cmd_add.HoverColor = System.Drawing.Color.Empty;
            this.cmd_add.Icon = null;
            this.cmd_add.Location = new System.Drawing.Point(473, 323);
            this.cmd_add.Name = "cmd_add";
            this.cmd_add.Progress = 0;
            this.cmd_add.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_add.Size = new System.Drawing.Size(74, 26);
            this.cmd_add.TabIndex = 20;
            this.cmd_add.Text = "Add...";
            this.cmd_add.UseVisualStyleBackColor = true;
            this.cmd_add.UseWindowsAccentColor = true;
            this.cmd_add.Click += new System.EventHandler(this.cmd_add_Click);
            // 
            // cb_key
            // 
            this.cb_key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cb_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_key.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_key.Icon = null;
            this.cb_key.Location = new System.Drawing.Point(34, 38);
            this.cb_key.Name = "cb_key";
            this.cb_key.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.cb_key.SelectedIndex = -1;
            this.cb_key.SelectedItem = null;
            this.cb_key.Size = new System.Drawing.Size(234, 28);
            this.cb_key.TabIndex = 21;
            this.cb_key.SelectedIndexChanged += new System.EventHandler(this.cb_key_SelectedIndexChanged);
            // 
            // cmd_copy
            // 
            this.cmd_copy.BorderRadius = 8;
            this.cmd_copy.FlatAppearance.BorderSize = 0;
            this.cmd_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_copy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_copy.ForeColor = System.Drawing.Color.White;
            this.cmd_copy.HoverColor = System.Drawing.Color.Empty;
            this.cmd_copy.Icon = null;
            this.cmd_copy.Location = new System.Drawing.Point(473, -3);
            this.cmd_copy.Name = "cmd_copy";
            this.cmd_copy.Progress = 0;
            this.cmd_copy.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_copy.Size = new System.Drawing.Size(74, 26);
            this.cmd_copy.TabIndex = 22;
            this.cmd_copy.Text = "Copy";
            this.cmd_copy.UseVisualStyleBackColor = true;
            this.cmd_copy.UseWindowsAccentColor = true;
            this.cmd_copy.Click += new System.EventHandler(this.cmd_copy_Click);
            // 
            // cmd_paste
            // 
            this.cmd_paste.BorderRadius = 8;
            this.cmd_paste.FlatAppearance.BorderSize = 0;
            this.cmd_paste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_paste.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_paste.ForeColor = System.Drawing.Color.White;
            this.cmd_paste.HoverColor = System.Drawing.Color.Empty;
            this.cmd_paste.Icon = null;
            this.cmd_paste.Location = new System.Drawing.Point(553, -3);
            this.cmd_paste.Name = "cmd_paste";
            this.cmd_paste.Progress = 0;
            this.cmd_paste.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_paste.Size = new System.Drawing.Size(74, 26);
            this.cmd_paste.TabIndex = 23;
            this.cmd_paste.Text = "Paste";
            this.cmd_paste.UseVisualStyleBackColor = true;
            this.cmd_paste.UseWindowsAccentColor = true;
            this.cmd_paste.Click += new System.EventHandler(this.cmd_paste_Click);
            // 
            // cmd_capture
            // 
            this.cmd_capture.BorderRadius = 8;
            this.cmd_capture.FlatAppearance.BorderSize = 0;
            this.cmd_capture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_capture.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_capture.ForeColor = System.Drawing.Color.White;
            this.cmd_capture.HoverColor = System.Drawing.Color.Empty;
            this.cmd_capture.Icon = null;
            this.cmd_capture.Location = new System.Drawing.Point(274, 38);
            this.cmd_capture.Name = "cmd_capture";
            this.cmd_capture.Progress = 0;
            this.cmd_capture.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_capture.Size = new System.Drawing.Size(74, 26);
            this.cmd_capture.TabIndex = 24;
            this.cmd_capture.Text = "Capture";
            this.cmd_capture.UseVisualStyleBackColor = true;
            this.cmd_capture.UseWindowsAccentColor = true;
            this.cmd_capture.Click += new System.EventHandler(this.cmd_capture_Click);
            // 
            // cmd_test
            // 
            this.cmd_test.BorderRadius = 8;
            this.cmd_test.FlatAppearance.BorderSize = 0;
            this.cmd_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_test.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_test.ForeColor = System.Drawing.Color.White;
            this.cmd_test.HoverColor = System.Drawing.Color.Empty;
            this.cmd_test.Icon = null;
            this.cmd_test.Location = new System.Drawing.Point(354, 38);
            this.cmd_test.Name = "cmd_test";
            this.cmd_test.Progress = 0;
            this.cmd_test.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_test.Size = new System.Drawing.Size(74, 26);
            this.cmd_test.TabIndex = 25;
            this.cmd_test.Text = "Test";
            this.cmd_test.UseVisualStyleBackColor = true;
            this.cmd_test.UseWindowsAccentColor = true;
            this.cmd_test.Click += new System.EventHandler(this.cmd_test_Click);
            // 
            // lbl_key_extended
            // 
            this.lbl_key_extended.AutoSize = true;
            this.lbl_key_extended.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_key_extended.Location = new System.Drawing.Point(42, 69);
            this.lbl_key_extended.Name = "lbl_key_extended";
            this.lbl_key_extended.Size = new System.Drawing.Size(61, 13);
            this.lbl_key_extended.TabIndex = 26;
            this.lbl_key_extended.Text = "(extended)";
            // 
            // InputActionConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.Controls.Add(this.lbl_key_extended);
            this.Controls.Add(this.cmd_test);
            this.Controls.Add(this.cmd_capture);
            this.Controls.Add(this.cmd_paste);
            this.Controls.Add(this.cmd_copy);
            this.Controls.Add(this.cb_key);
            this.Controls.Add(this.cmd_add);
            this.Controls.Add(this.cmd_remove);
            this.Controls.Add(this.cb_applications);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.chk_combo_key);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_combo_key);
            this.Controls.Add(this.chk_keyboard_enabled);
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

        private CheckBox chk_keyboard_enabled;

        private void chk_keyboard_enabled_CheckedChanged(object sender, EventArgs e)
        {
            data.KeyboardEnabled = chk_keyboard_enabled.Checked;
        }

        private void cb_key_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.KeyCode = Enum.Parse<VirtualKeyCode>(cb_key.SelectedItem.ToString());
        }

        
        private SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox cb_combo_key;
        private Label label7;
        private CheckBox chk_combo_key;


   
        private Label label8;
        private RoundedComboBox cb_applications;
        private ButtonPrimary cmd_remove;
        private ButtonPrimary cmd_add;
        private RoundedTextBox tb_interval;
        private RoundedComboBox cb_key;
        private ButtonPrimary cmd_copy;
        private ButtonPrimary cmd_paste;
        private ButtonPrimary cmd_capture;
        private ButtonPrimary cmd_test;
        private Label lbl_key_extended;
    }
}
