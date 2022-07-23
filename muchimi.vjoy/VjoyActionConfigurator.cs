using System;
using System.Windows.Forms;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;


namespace muchimi_vjoy
{

    public partial class VjoyActionConfigurator : ActionConfigControl
    {
        private RadioButton rb_device;
        private Panel panel1;
        private RadioButton rb_button_on;
        private RadioButton rb_button_pulse;
        private Label label1;
        private RadioButton rb_button_off;
        private Label lbl_message;
        private Panel panel2;
        private RoundedTextBox tb_device_number;
        private Label label2;
        private Label label3;
        private CheckBox cb_axis;
        private CheckBox cb_button;
        private Label label4;
        private Label lbl_device;
        private Panel panel3;
        private RadioButton rb_relative;
        private RadioButton rb_absolute;
        private Panel panel4;
        private Panel pan_hat;
        private RadioButton rb_m1m1;
        private RadioButton rb_m10;
        private RadioButton rb_1m1;
        private RadioButton rb_10;
        private RadioButton rb_11;
        private RadioButton rb_m11;
        private RadioButton rb_01;
        private RadioButton rb_00;
        private RadioButton rb_0m1;
        private Panel pan_axis;
        private Label label5;
        private ButtonPrimary cmd_axis_center;
        private ButtonPrimary cmd_axis_max;
        private ButtonPrimary cmd_axis_min;
        private Label label6;
        private RoundedComboBox cb_axis_selector;
        private RoundedTextBox tb_axis_interval;
        private RoundedTextBox tb_axis_value;
        private RoundedTextBox tb_pulse_interval;
        private RoundedTextBox tb_button_number;
        private ButtonPrimary cmd_test;
        private ButtonPrimary cmd_paste;
        private ButtonPrimary cmd_copy;
        private ButtonPrimary cmd_add;
        private ButtonPrimary cmd_remove;
        private RoundedComboBox cb_applications;
        private Label label8;
        private ToolTip tp_info;


        public VjoyActionConfigurator(VjoyAction pluginAction, ActionConfigurator actionConfigurator)
        {
            this.vjoyAction = pluginAction;
            this.tp_info = new ToolTip();


            InitializeComponent();

            data.LoadVjoyConfig(pluginAction);
            this.LoadConfig();


            this.tp_info.SetToolTip(this.tb_axis_value,"Use the range -1.0 to +1.0");

        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmd_add = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_remove = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cb_applications = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmd_paste = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_copy = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.tb_button_number = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.tb_pulse_interval = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.cb_axis_selector = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
            this.pan_axis = new System.Windows.Forms.Panel();
            this.tb_axis_interval = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.tb_axis_value = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmd_axis_center = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_axis_max = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_axis_min = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rb_relative = new System.Windows.Forms.RadioButton();
            this.rb_absolute = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pan_hat = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.rb_0m1 = new System.Windows.Forms.RadioButton();
            this.rb_m1m1 = new System.Windows.Forms.RadioButton();
            this.rb_m10 = new System.Windows.Forms.RadioButton();
            this.rb_1m1 = new System.Windows.Forms.RadioButton();
            this.rb_10 = new System.Windows.Forms.RadioButton();
            this.rb_11 = new System.Windows.Forms.RadioButton();
            this.rb_m11 = new System.Windows.Forms.RadioButton();
            this.rb_01 = new System.Windows.Forms.RadioButton();
            this.rb_00 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rb_button_pulse = new System.Windows.Forms.RadioButton();
            this.rb_button_on = new System.Windows.Forms.RadioButton();
            this.rb_button_off = new System.Windows.Forms.RadioButton();
            this.cb_axis = new System.Windows.Forms.CheckBox();
            this.cb_button = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_message = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmd_test = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.tb_device_number = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.lbl_device = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pan_axis.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pan_hat.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmd_add);
            this.panel1.Controls.Add(this.cmd_remove);
            this.panel1.Controls.Add(this.cb_applications);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmd_paste);
            this.panel1.Controls.Add(this.cmd_copy);
            this.panel1.Controls.Add(this.tb_button_number);
            this.panel1.Controls.Add(this.tb_pulse_interval);
            this.panel1.Controls.Add(this.cb_axis_selector);
            this.panel1.Controls.Add(this.pan_axis);
            this.panel1.Controls.Add(this.pan_hat);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cb_axis);
            this.panel1.Controls.Add(this.cb_button);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(171, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 372);
            this.panel1.TabIndex = 0;
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
            this.cmd_add.Location = new System.Drawing.Point(452, 321);
            this.cmd_add.Name = "cmd_add";
            this.cmd_add.Progress = 0;
            this.cmd_add.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_add.Size = new System.Drawing.Size(74, 26);
            this.cmd_add.TabIndex = 29;
            this.cmd_add.Text = "Add...";
            this.cmd_add.UseVisualStyleBackColor = true;
            this.cmd_add.UseWindowsAccentColor = true;
            this.cmd_add.Click += new System.EventHandler(this.cmd_add_Click);
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
            this.cmd_remove.Location = new System.Drawing.Point(532, 322);
            this.cmd_remove.Name = "cmd_remove";
            this.cmd_remove.Progress = 0;
            this.cmd_remove.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_remove.Size = new System.Drawing.Size(74, 26);
            this.cmd_remove.TabIndex = 28;
            this.cmd_remove.Text = "Delete";
            this.cmd_remove.UseVisualStyleBackColor = true;
            this.cmd_remove.UseWindowsAccentColor = true;
            this.cmd_remove.Click += new System.EventHandler(this.cmd_remove_Click);
            // 
            // cb_applications
            // 
            this.cb_applications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cb_applications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_applications.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_applications.Icon = null;
            this.cb_applications.Location = new System.Drawing.Point(196, 320);
            this.cb_applications.Name = "cb_applications";
            this.cb_applications.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.cb_applications.SelectedIndex = -1;
            this.cb_applications.SelectedItem = null;
            this.cb_applications.Size = new System.Drawing.Size(250, 28);
            this.cb_applications.TabIndex = 27;
            this.cb_applications.SelectedIndexChanged += new System.EventHandler(this.cb_applications_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(197, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Target Application:";
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
            this.cmd_paste.Location = new System.Drawing.Point(532, 1);
            this.cmd_paste.Name = "cmd_paste";
            this.cmd_paste.Progress = 0;
            this.cmd_paste.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_paste.Size = new System.Drawing.Size(74, 26);
            this.cmd_paste.TabIndex = 25;
            this.cmd_paste.Text = "Paste";
            this.cmd_paste.UseVisualStyleBackColor = true;
            this.cmd_paste.UseWindowsAccentColor = true;
            this.cmd_paste.Click += new System.EventHandler(this.cmd_paste_Click);
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
            this.cmd_copy.Location = new System.Drawing.Point(452, 3);
            this.cmd_copy.Name = "cmd_copy";
            this.cmd_copy.Progress = 0;
            this.cmd_copy.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_copy.Size = new System.Drawing.Size(74, 26);
            this.cmd_copy.TabIndex = 24;
            this.cmd_copy.Text = "Copy";
            this.cmd_copy.UseVisualStyleBackColor = true;
            this.cmd_copy.UseWindowsAccentColor = true;
            this.cmd_copy.Click += new System.EventHandler(this.cmd_copy_Click);
            // 
            // tb_button_number
            // 
            this.tb_button_number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_button_number.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_button_number.Icon = null;
            this.tb_button_number.Location = new System.Drawing.Point(49, 26);
            this.tb_button_number.MaxCharacters = 32767;
            this.tb_button_number.Multiline = false;
            this.tb_button_number.Name = "tb_button_number";
            this.tb_button_number.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_button_number.PasswordChar = false;
            this.tb_button_number.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_button_number.PlaceHolderText = "";
            this.tb_button_number.ReadOnly = false;
            this.tb_button_number.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_button_number.SelectionStart = 0;
            this.tb_button_number.Size = new System.Drawing.Size(58, 25);
            this.tb_button_number.TabIndex = 21;
            this.tb_button_number.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_button_number.TextChanged += new System.EventHandler(this.tb_button_number_TextChanged);
            // 
            // tb_pulse_interval
            // 
            this.tb_pulse_interval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_pulse_interval.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_pulse_interval.Icon = null;
            this.tb_pulse_interval.Location = new System.Drawing.Point(49, 85);
            this.tb_pulse_interval.MaxCharacters = 32767;
            this.tb_pulse_interval.Multiline = false;
            this.tb_pulse_interval.Name = "tb_pulse_interval";
            this.tb_pulse_interval.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_pulse_interval.PasswordChar = false;
            this.tb_pulse_interval.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_pulse_interval.PlaceHolderText = "";
            this.tb_pulse_interval.ReadOnly = false;
            this.tb_pulse_interval.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_pulse_interval.SelectionStart = 0;
            this.tb_pulse_interval.Size = new System.Drawing.Size(58, 25);
            this.tb_pulse_interval.TabIndex = 20;
            this.tb_pulse_interval.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pulse_interval.TextChanged += new System.EventHandler(this.tb_pulse_interval_TextChanged);
            // 
            // cb_axis_selector
            // 
            this.cb_axis_selector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cb_axis_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_axis_selector.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_axis_selector.Icon = null;
            this.cb_axis_selector.Location = new System.Drawing.Point(3, 167);
            this.cb_axis_selector.Name = "cb_axis_selector";
            this.cb_axis_selector.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.cb_axis_selector.SelectedIndex = -1;
            this.cb_axis_selector.SelectedItem = null;
            this.cb_axis_selector.Size = new System.Drawing.Size(180, 26);
            this.cb_axis_selector.TabIndex = 19;
            this.cb_axis_selector.SelectedIndexChanged += new System.EventHandler(this.cb_axis_selector_SelectedIndexChanged);
            // 
            // pan_axis
            // 
            this.pan_axis.Controls.Add(this.tb_axis_interval);
            this.pan_axis.Controls.Add(this.tb_axis_value);
            this.pan_axis.Controls.Add(this.label6);
            this.pan_axis.Controls.Add(this.cmd_axis_center);
            this.pan_axis.Controls.Add(this.cmd_axis_max);
            this.pan_axis.Controls.Add(this.cmd_axis_min);
            this.pan_axis.Controls.Add(this.panel3);
            this.pan_axis.Controls.Add(this.label4);
            this.pan_axis.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pan_axis.Location = new System.Drawing.Point(196, 134);
            this.pan_axis.Name = "pan_axis";
            this.pan_axis.Size = new System.Drawing.Size(371, 108);
            this.pan_axis.TabIndex = 18;
            // 
            // tb_axis_interval
            // 
            this.tb_axis_interval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_axis_interval.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_axis_interval.Icon = null;
            this.tb_axis_interval.Location = new System.Drawing.Point(256, 35);
            this.tb_axis_interval.MaxCharacters = 32767;
            this.tb_axis_interval.Multiline = false;
            this.tb_axis_interval.Name = "tb_axis_interval";
            this.tb_axis_interval.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_axis_interval.PasswordChar = false;
            this.tb_axis_interval.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_axis_interval.PlaceHolderText = "";
            this.tb_axis_interval.ReadOnly = false;
            this.tb_axis_interval.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_axis_interval.SelectionStart = 0;
            this.tb_axis_interval.Size = new System.Drawing.Size(92, 25);
            this.tb_axis_interval.TabIndex = 21;
            this.tb_axis_interval.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_axis_interval.TextChanged += new System.EventHandler(this.tb_axis_interval_TextChanged);
            // 
            // tb_axis_value
            // 
            this.tb_axis_value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_axis_value.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_axis_value.Icon = null;
            this.tb_axis_value.Location = new System.Drawing.Point(6, 34);
            this.tb_axis_value.MaxCharacters = 32767;
            this.tb_axis_value.Multiline = false;
            this.tb_axis_value.Name = "tb_axis_value";
            this.tb_axis_value.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_axis_value.PasswordChar = false;
            this.tb_axis_value.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_axis_value.PlaceHolderText = "";
            this.tb_axis_value.ReadOnly = false;
            this.tb_axis_value.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_axis_value.SelectionStart = 0;
            this.tb_axis_value.Size = new System.Drawing.Size(99, 25);
            this.tb_axis_value.TabIndex = 20;
            this.tb_axis_value.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_axis_value.TextChanged += new System.EventHandler(this.tb_axis_value_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(259, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Interval";
            // 
            // cmd_axis_center
            // 
            this.cmd_axis_center.BorderRadius = 8;
            this.cmd_axis_center.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_axis_center.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_axis_center.ForeColor = System.Drawing.Color.White;
            this.cmd_axis_center.HoverColor = System.Drawing.Color.Empty;
            this.cmd_axis_center.Icon = null;
            this.cmd_axis_center.Location = new System.Drawing.Point(40, 73);
            this.cmd_axis_center.Name = "cmd_axis_center";
            this.cmd_axis_center.Progress = 0;
            this.cmd_axis_center.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_axis_center.Size = new System.Drawing.Size(32, 23);
            this.cmd_axis_center.TabIndex = 18;
            this.cmd_axis_center.Text = "";
            this.cmd_axis_center.UseVisualStyleBackColor = false;
            this.cmd_axis_center.UseWindowsAccentColor = true;
            this.cmd_axis_center.Click += new System.EventHandler(this.cmd_axis_center_Click);
            // 
            // cmd_axis_max
            // 
            this.cmd_axis_max.BorderRadius = 8;
            this.cmd_axis_max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_axis_max.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_axis_max.ForeColor = System.Drawing.Color.White;
            this.cmd_axis_max.HoverColor = System.Drawing.Color.Empty;
            this.cmd_axis_max.Icon = null;
            this.cmd_axis_max.Location = new System.Drawing.Point(73, 73);
            this.cmd_axis_max.Name = "cmd_axis_max";
            this.cmd_axis_max.Progress = 0;
            this.cmd_axis_max.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_axis_max.Size = new System.Drawing.Size(32, 23);
            this.cmd_axis_max.TabIndex = 17;
            this.cmd_axis_max.Text = "";
            this.cmd_axis_max.UseVisualStyleBackColor = false;
            this.cmd_axis_max.UseWindowsAccentColor = true;
            this.cmd_axis_max.Click += new System.EventHandler(this.cmd_axis_max_Click);
            // 
            // cmd_axis_min
            // 
            this.cmd_axis_min.BorderRadius = 8;
            this.cmd_axis_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_axis_min.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_axis_min.ForeColor = System.Drawing.Color.White;
            this.cmd_axis_min.HoverColor = System.Drawing.Color.Empty;
            this.cmd_axis_min.Icon = null;
            this.cmd_axis_min.Location = new System.Drawing.Point(5, 73);
            this.cmd_axis_min.Name = "cmd_axis_min";
            this.cmd_axis_min.Progress = 0;
            this.cmd_axis_min.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_axis_min.Size = new System.Drawing.Size(32, 23);
            this.cmd_axis_min.TabIndex = 16;
            this.cmd_axis_min.Text = "";
            this.cmd_axis_min.UseVisualStyleBackColor = false;
            this.cmd_axis_min.UseWindowsAccentColor = true;
            this.cmd_axis_min.Click += new System.EventHandler(this.cmd_axis_min_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rb_relative);
            this.panel3.Controls.Add(this.rb_absolute);
            this.panel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(122, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 70);
            this.panel3.TabIndex = 15;
            // 
            // rb_relative
            // 
            this.rb_relative.AutoSize = true;
            this.rb_relative.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_relative.Location = new System.Drawing.Point(3, 31);
            this.rb_relative.Name = "rb_relative";
            this.rb_relative.Size = new System.Drawing.Size(70, 20);
            this.rb_relative.TabIndex = 1;
            this.rb_relative.TabStop = true;
            this.rb_relative.Text = "Relative";
            this.rb_relative.UseVisualStyleBackColor = true;
            this.rb_relative.CheckedChanged += new System.EventHandler(this.rb_relative_CheckedChanged);
            // 
            // rb_absolute
            // 
            this.rb_absolute.AutoSize = true;
            this.rb_absolute.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_absolute.Location = new System.Drawing.Point(4, -2);
            this.rb_absolute.Name = "rb_absolute";
            this.rb_absolute.Size = new System.Drawing.Size(74, 20);
            this.rb_absolute.TabIndex = 0;
            this.rb_absolute.TabStop = true;
            this.rb_absolute.Text = "Absolute";
            this.rb_absolute.UseVisualStyleBackColor = true;
            this.rb_absolute.CheckedChanged += new System.EventHandler(this.rb_absolute_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Value";
            // 
            // pan_hat
            // 
            this.pan_hat.Controls.Add(this.label5);
            this.pan_hat.Controls.Add(this.rb_0m1);
            this.pan_hat.Controls.Add(this.rb_m1m1);
            this.pan_hat.Controls.Add(this.rb_m10);
            this.pan_hat.Controls.Add(this.rb_1m1);
            this.pan_hat.Controls.Add(this.rb_10);
            this.pan_hat.Controls.Add(this.rb_11);
            this.pan_hat.Controls.Add(this.rb_m11);
            this.pan_hat.Controls.Add(this.rb_01);
            this.pan_hat.Controls.Add(this.rb_00);
            this.pan_hat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pan_hat.Location = new System.Drawing.Point(452, 38);
            this.pan_hat.Name = "pan_hat";
            this.pan_hat.Size = new System.Drawing.Size(313, 151);
            this.pan_hat.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hat Position";
            // 
            // rb_0m1
            // 
            this.rb_0m1.AutoSize = true;
            this.rb_0m1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_0m1.Location = new System.Drawing.Point(46, 101);
            this.rb_0m1.Name = "rb_0m1";
            this.rb_0m1.Size = new System.Drawing.Size(14, 13);
            this.rb_0m1.TabIndex = 5;
            this.rb_0m1.TabStop = true;
            this.rb_0m1.UseVisualStyleBackColor = true;
            // 
            // rb_m1m1
            // 
            this.rb_m1m1.AutoSize = true;
            this.rb_m1m1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_m1m1.Location = new System.Drawing.Point(25, 87);
            this.rb_m1m1.Name = "rb_m1m1";
            this.rb_m1m1.Size = new System.Drawing.Size(14, 13);
            this.rb_m1m1.TabIndex = 7;
            this.rb_m1m1.TabStop = true;
            this.rb_m1m1.UseVisualStyleBackColor = true;
            // 
            // rb_m10
            // 
            this.rb_m10.AutoSize = true;
            this.rb_m10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_m10.Location = new System.Drawing.Point(14, 65);
            this.rb_m10.Name = "rb_m10";
            this.rb_m10.Size = new System.Drawing.Size(14, 13);
            this.rb_m10.TabIndex = 6;
            this.rb_m10.TabStop = true;
            this.rb_m10.UseVisualStyleBackColor = true;
            // 
            // rb_1m1
            // 
            this.rb_1m1.AutoSize = true;
            this.rb_1m1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_1m1.Location = new System.Drawing.Point(69, 87);
            this.rb_1m1.Name = "rb_1m1";
            this.rb_1m1.Size = new System.Drawing.Size(14, 13);
            this.rb_1m1.TabIndex = 5;
            this.rb_1m1.TabStop = true;
            this.rb_1m1.UseVisualStyleBackColor = true;
            // 
            // rb_10
            // 
            this.rb_10.AutoSize = true;
            this.rb_10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_10.Location = new System.Drawing.Point(81, 65);
            this.rb_10.Name = "rb_10";
            this.rb_10.Size = new System.Drawing.Size(14, 13);
            this.rb_10.TabIndex = 4;
            this.rb_10.TabStop = true;
            this.rb_10.UseVisualStyleBackColor = true;
            // 
            // rb_11
            // 
            this.rb_11.AutoSize = true;
            this.rb_11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_11.Location = new System.Drawing.Point(69, 43);
            this.rb_11.Name = "rb_11";
            this.rb_11.Size = new System.Drawing.Size(14, 13);
            this.rb_11.TabIndex = 3;
            this.rb_11.TabStop = true;
            this.rb_11.UseVisualStyleBackColor = true;
            // 
            // rb_m11
            // 
            this.rb_m11.AutoSize = true;
            this.rb_m11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_m11.Location = new System.Drawing.Point(25, 44);
            this.rb_m11.Name = "rb_m11";
            this.rb_m11.Size = new System.Drawing.Size(14, 13);
            this.rb_m11.TabIndex = 2;
            this.rb_m11.TabStop = true;
            this.rb_m11.UseVisualStyleBackColor = true;
            // 
            // rb_01
            // 
            this.rb_01.AutoSize = true;
            this.rb_01.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_01.Location = new System.Drawing.Point(46, 32);
            this.rb_01.Name = "rb_01";
            this.rb_01.Size = new System.Drawing.Size(14, 13);
            this.rb_01.TabIndex = 1;
            this.rb_01.TabStop = true;
            this.rb_01.UseVisualStyleBackColor = true;
            // 
            // rb_00
            // 
            this.rb_00.AutoSize = true;
            this.rb_00.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_00.Location = new System.Drawing.Point(46, 65);
            this.rb_00.Name = "rb_00";
            this.rb_00.Size = new System.Drawing.Size(14, 13);
            this.rb_00.TabIndex = 0;
            this.rb_00.TabStop = true;
            this.rb_00.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rb_button_pulse);
            this.panel4.Controls.Add(this.rb_button_on);
            this.panel4.Controls.Add(this.rb_button_off);
            this.panel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel4.Location = new System.Drawing.Point(122, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(73, 79);
            this.panel4.TabIndex = 16;
            // 
            // rb_button_pulse
            // 
            this.rb_button_pulse.AutoSize = true;
            this.rb_button_pulse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_button_pulse.Location = new System.Drawing.Point(0, 0);
            this.rb_button_pulse.Name = "rb_button_pulse";
            this.rb_button_pulse.Size = new System.Drawing.Size(55, 20);
            this.rb_button_pulse.TabIndex = 1;
            this.rb_button_pulse.TabStop = true;
            this.rb_button_pulse.Text = "Pulse";
            this.rb_button_pulse.UseVisualStyleBackColor = true;
            this.rb_button_pulse.CheckedChanged += new System.EventHandler(this.rb_button_pulse_CheckedChanged);
            // 
            // rb_button_on
            // 
            this.rb_button_on.AutoSize = true;
            this.rb_button_on.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_button_on.Location = new System.Drawing.Point(0, 24);
            this.rb_button_on.Name = "rb_button_on";
            this.rb_button_on.Size = new System.Drawing.Size(41, 20);
            this.rb_button_on.TabIndex = 2;
            this.rb_button_on.TabStop = true;
            this.rb_button_on.Text = "On";
            this.rb_button_on.UseVisualStyleBackColor = true;
            this.rb_button_on.CheckedChanged += new System.EventHandler(this.rb_button_on_CheckedChanged);
            // 
            // rb_button_off
            // 
            this.rb_button_off.AutoSize = true;
            this.rb_button_off.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb_button_off.Location = new System.Drawing.Point(-1, 48);
            this.rb_button_off.Name = "rb_button_off";
            this.rb_button_off.Size = new System.Drawing.Size(42, 20);
            this.rb_button_off.TabIndex = 3;
            this.rb_button_off.TabStop = true;
            this.rb_button_off.Text = "Off";
            this.rb_button_off.UseVisualStyleBackColor = true;
            this.rb_button_off.CheckedChanged += new System.EventHandler(this.rb_button_off_CheckedChanged);
            // 
            // cb_axis
            // 
            this.cb_axis.AutoSize = true;
            this.cb_axis.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_axis.Location = new System.Drawing.Point(3, 125);
            this.cb_axis.Name = "cb_axis";
            this.cb_axis.Size = new System.Drawing.Size(91, 20);
            this.cb_axis.TabIndex = 12;
            this.cb_axis.Text = "Output Axis";
            this.cb_axis.UseVisualStyleBackColor = true;
            this.cb_axis.CheckedChanged += new System.EventHandler(this.cb_axis_CheckedChanged);
            // 
            // cb_button
            // 
            this.cb_button.AutoSize = true;
            this.cb_button.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_button.Location = new System.Drawing.Point(3, 3);
            this.cb_button.Name = "cb_button";
            this.cb_button.Size = new System.Drawing.Size(104, 20);
            this.cb_button.TabIndex = 11;
            this.cb_button.Text = "Output Button";
            this.cb_button.UseVisualStyleBackColor = true;
            this.cb_button.CheckedChanged += new System.EventHandler(this.cb_button_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Interval";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Button";
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_message.Location = new System.Drawing.Point(17, 378);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(57, 16);
            this.lbl_message.TabIndex = 1;
            this.lbl_message.Text = "Message";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmd_test);
            this.panel2.Controls.Add(this.tb_device_number);
            this.panel2.Controls.Add(this.lbl_device);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 84);
            this.panel2.TabIndex = 2;
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
            this.cmd_test.Location = new System.Drawing.Point(81, 33);
            this.cmd_test.Name = "cmd_test";
            this.cmd_test.Progress = 0;
            this.cmd_test.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_test.Size = new System.Drawing.Size(64, 31);
            this.cmd_test.TabIndex = 3;
            this.cmd_test.Text = "Test";
            this.cmd_test.UseVisualStyleBackColor = true;
            this.cmd_test.UseWindowsAccentColor = true;
            this.cmd_test.Click += new System.EventHandler(this.cmd_test_Click);
            // 
            // tb_device_number
            // 
            this.tb_device_number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_device_number.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_device_number.Icon = null;
            this.tb_device_number.Location = new System.Drawing.Point(81, 0);
            this.tb_device_number.MaxCharacters = 32767;
            this.tb_device_number.Multiline = false;
            this.tb_device_number.Name = "tb_device_number";
            this.tb_device_number.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_device_number.PasswordChar = false;
            this.tb_device_number.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_device_number.PlaceHolderText = "";
            this.tb_device_number.ReadOnly = false;
            this.tb_device_number.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_device_number.SelectionStart = 0;
            this.tb_device_number.Size = new System.Drawing.Size(64, 27);
            this.tb_device_number.TabIndex = 4;
            this.tb_device_number.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_device_number.TextChanged += new System.EventHandler(this.tb_device_number_TextChanged);
            // 
            // lbl_device
            // 
            this.lbl_device.AutoSize = true;
            this.lbl_device.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_device.Location = new System.Drawing.Point(0, 8);
            this.lbl_device.Name = "lbl_device";
            this.lbl_device.Size = new System.Drawing.Size(74, 16);
            this.lbl_device.TabIndex = 0;
            this.lbl_device.Text = "VJoy Device";
            // 
            // VjoyActionConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.panel1);
            this.Name = "VjoyActionConfigurator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pan_axis.ResumeLayout(false);
            this.pan_axis.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pan_hat.ResumeLayout(false);
            this.pan_hat.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void rb_button_pulse_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_button_pulse.Checked)
            {
                data.ButtonMode = EButtonMode.pulse;
                MacroDeckLogger.Info(Main.Instance, "Button mode pulse");
            }
        }

        private void rb_button_on_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_button_on.Checked)
            {
                data.ButtonMode = EButtonMode.on;
                MacroDeckLogger.Info(Main.Instance, "Button mode on");
            }
        }

        private void rb_button_off_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_button_off.Checked)
            {
                data.ButtonMode = EButtonMode.off;
                MacroDeckLogger.Info(Main.Instance,"Button mode off");
            }
        }

        private void tb_button_number_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(tb_button_number.Text, out value))
            {
                lbl_message.Text = "Please enter a valid button number starting 1..128";
                return;
            }

            if (value <= 0 || value > 128)
            {
                lbl_message.Text = "Buttom number must be between 1 and 128";
                return;
            }

            data.ButtonNumber = (uint)value;
            MacroDeckLogger.Info(Main.Instance, $"Button number {data.ButtonNumber}");

        }

        private void tb_pulse_interval_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(tb_pulse_interval.Text, out value))
            {
                lbl_message.Text = "Please enter a valid interval number";
                return;
            }
            if (value < 0)
            {
                lbl_message.Text = "Interval number must be >= 0";
                return;
            }

            data.ButtonPulseInterval = value;
            MacroDeckLogger.Info(Main.Instance, $"Pulse interval {data.ButtonPulseInterval}");

        }

        private void tb_device_number_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(tb_device_number.Text, out value))
            {
                lbl_message.Text = "Please enter a valid device number starting at 1..16";
                return;
            }

            if (value <= 0 || value > 16)
            {
                lbl_message.Text = "Device number must be between 1 and 16";
                return;
            }

            data.DeviceNumber = (uint)value;
        }

        private void cmd_test_Click(object sender, EventArgs e)
        {
       
            // simulate a press
            Main.Instance.RunAction(data, null, EActionType.Press);
            // simulate a release
            Main.Instance.RunAction(data, null, EActionType.Release);

        }

        private void cb_button_CheckedChanged(object sender, EventArgs e)
        {
            data.ButtonEnabled = cb_button.Checked;
        }


        private void cb_axis_CheckedChanged(object sender, EventArgs e)
        {
            data.AxisEnabled = cb_axis.Checked;
        }

        private void rb_absolute_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_absolute.Checked)
                data.AxisMode = EAxisMode.absolute;
        }


        private void rb_relative_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_relative.Checked)
                data.AxisMode = EAxisMode.relative;
        }


        private void tb_axis_value_TextChanged(object sender, EventArgs e)
        {
            double value;
            if (!double.TryParse(tb_axis_value.Text, out value) || value < -1.0 || value > 1.0)
            {
                lbl_message.Text = "Axix value must be between -1.0 and +1.0";
                return;
            }

            data.AxisValue = value;
        }

        private void UpdatePanel()
        {

            var vjoy = Main.Instance.Vjoy;
            var axis = vjoy.AxisFromName(cb_axis_selector.Text);
            pan_hat.Visible = vjoy.IsAxisHat(axis);
            pan_axis.Visible = !pan_hat.Visible;
            data.Axis = axis;
        }

        private void cb_axis_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePanel();
        }

        private void cmd_axis_min_Click(object sender, EventArgs e)
        {
            tb_axis_value.Text = "-1";
        }

        private void cmd_axis_center_Click(object sender, EventArgs e)
        {
            tb_axis_value.Text = "0";
        }

        private void cmd_axis_max_Click(object sender, EventArgs e)
        {
            tb_axis_value.Text = "1";
        }

        private void tb_axis_interval_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(tb_pulse_interval.Text, out value))
            {
                lbl_message.Text = "Please enter a valid interval number";
                return;
            }
            if (value < 0)
            {
                lbl_message.Text = "Interval number must be >= 0";
                return;
            }

            data.AxisPulseInterval = value;
            MacroDeckLogger.Info(Main.Instance, $"Axis Pulse interval {data.ButtonPulseInterval}");

        }

        private void cmd_copy_Click(object sender, EventArgs e)
        {
            Main.Instance.Config.VjoyCopy(data);
            cmd_paste.Enabled = Main.Instance.Config.VjoyClipboard != null;
        }

        private void cmd_paste_Click(object sender, EventArgs e)
        {
            var config = Main.Instance.Config;
            if (config.VjoyClipboard != null)
            {
                // update data
                config.VjoyPaste(ref data);
                // reload controls with new data
                LoadConfig();
            }
        }

        private void cmd_remove_Click(object sender, EventArgs e)
        {
            var config = Main.Instance.Config;
            config.RemoveApplication(cb_applications.SelectedItem.ToString());
        }

        private void cb_applications_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cb_applications.SelectedItem.ToString();
            cmd_remove.Enabled = !string.IsNullOrEmpty(name);
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


    }
}
