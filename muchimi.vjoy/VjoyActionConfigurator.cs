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
        private TextBox tb_button_number;
        private Label lbl_message;
        private Panel panel2;
        private TextBox tb_device_number;
        private Label label2;
        private TextBox tb_pulse_interval;
        private Button cmd_test;
        private System.Windows.Forms.ComboBox cb_axis_selector;
        private Label label3;
        private CheckBox cb_axis;
        private CheckBox cb_button;
        private TextBox tb_axis_value;
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
        private Button cmd_axis_center;
        private Button cmd_axis_max;
        private Button cmd_axis_min;
        private Label label6;
        private TextBox tb_axis_interval;
        private ToolTip tp_info;


        public VjoyActionConfigurator(VjoyAction pluginAction, ActionConfigurator actionConfigurator)
        {
            this.vjoyAction = pluginAction;
            this.tp_info = new ToolTip();


            InitializeComponent();

            this.LoadConfig();


            this.tp_info.SetToolTip(this.tb_axis_value,"Use the range -1.0 to +1.0");

        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pan_axis = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_axis_interval = new System.Windows.Forms.TextBox();
            this.cmd_axis_center = new System.Windows.Forms.Button();
            this.cmd_axis_max = new System.Windows.Forms.Button();
            this.cmd_axis_min = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rb_relative = new System.Windows.Forms.RadioButton();
            this.rb_absolute = new System.Windows.Forms.RadioButton();
            this.tb_axis_value = new System.Windows.Forms.TextBox();
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
            this.cb_axis_selector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_pulse_interval = new System.Windows.Forms.TextBox();
            this.tb_button_number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmd_test = new System.Windows.Forms.Button();
            this.lbl_message = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_device_number = new System.Windows.Forms.TextBox();
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
            this.panel1.Controls.Add(this.pan_axis);
            this.panel1.Controls.Add(this.pan_hat);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cb_axis);
            this.panel1.Controls.Add(this.cb_button);
            this.panel1.Controls.Add(this.cb_axis_selector);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_pulse_interval);
            this.panel1.Controls.Add(this.tb_button_number);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(209, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 372);
            this.panel1.TabIndex = 0;
            // 
            // pan_axis
            // 
            this.pan_axis.Controls.Add(this.label6);
            this.pan_axis.Controls.Add(this.tb_axis_interval);
            this.pan_axis.Controls.Add(this.cmd_axis_center);
            this.pan_axis.Controls.Add(this.cmd_axis_max);
            this.pan_axis.Controls.Add(this.cmd_axis_min);
            this.pan_axis.Controls.Add(this.panel3);
            this.pan_axis.Controls.Add(this.tb_axis_value);
            this.pan_axis.Controls.Add(this.label4);
            this.pan_axis.Location = new System.Drawing.Point(262, 208);
            this.pan_axis.Name = "pan_axis";
            this.pan_axis.Size = new System.Drawing.Size(371, 145);
            this.pan_axis.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Interval";
            // 
            // tb_axis_interval
            // 
            this.tb_axis_interval.Location = new System.Drawing.Point(264, 57);
            this.tb_axis_interval.Name = "tb_axis_interval";
            this.tb_axis_interval.Size = new System.Drawing.Size(100, 30);
            this.tb_axis_interval.TabIndex = 19;
            this.tb_axis_interval.TextChanged += new System.EventHandler(this.tb_axis_interval_TextChanged);
            // 
            // cmd_axis_center
            // 
            this.cmd_axis_center.BackColor = System.Drawing.Color.Black;
            this.cmd_axis_center.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_axis_center.Location = new System.Drawing.Point(40, 73);
            this.cmd_axis_center.Name = "cmd_axis_center";
            this.cmd_axis_center.Size = new System.Drawing.Size(32, 23);
            this.cmd_axis_center.TabIndex = 18;
            this.cmd_axis_center.Text = "";
            this.cmd_axis_center.UseVisualStyleBackColor = false;
            this.cmd_axis_center.Click += new System.EventHandler(this.cmd_axis_center_Click);
            // 
            // cmd_axis_max
            // 
            this.cmd_axis_max.BackColor = System.Drawing.Color.Black;
            this.cmd_axis_max.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_axis_max.Location = new System.Drawing.Point(73, 73);
            this.cmd_axis_max.Name = "cmd_axis_max";
            this.cmd_axis_max.Size = new System.Drawing.Size(32, 23);
            this.cmd_axis_max.TabIndex = 17;
            this.cmd_axis_max.Text = "";
            this.cmd_axis_max.UseVisualStyleBackColor = false;
            this.cmd_axis_max.Click += new System.EventHandler(this.cmd_axis_max_Click);
            // 
            // cmd_axis_min
            // 
            this.cmd_axis_min.BackColor = System.Drawing.Color.Black;
            this.cmd_axis_min.Font = new System.Drawing.Font("Wingdings 2", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_axis_min.Location = new System.Drawing.Point(5, 73);
            this.cmd_axis_min.Name = "cmd_axis_min";
            this.cmd_axis_min.Size = new System.Drawing.Size(32, 23);
            this.cmd_axis_min.TabIndex = 16;
            this.cmd_axis_min.Text = "";
            this.cmd_axis_min.UseVisualStyleBackColor = false;
            this.cmd_axis_min.Click += new System.EventHandler(this.cmd_axis_min_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rb_relative);
            this.panel3.Controls.Add(this.rb_absolute);
            this.panel3.Location = new System.Drawing.Point(122, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 103);
            this.panel3.TabIndex = 15;
            // 
            // rb_relative
            // 
            this.rb_relative.AutoSize = true;
            this.rb_relative.Location = new System.Drawing.Point(3, 31);
            this.rb_relative.Name = "rb_relative";
            this.rb_relative.Size = new System.Drawing.Size(93, 27);
            this.rb_relative.TabIndex = 1;
            this.rb_relative.TabStop = true;
            this.rb_relative.Text = "Relative";
            this.rb_relative.UseVisualStyleBackColor = true;
            this.rb_relative.CheckedChanged += new System.EventHandler(this.rb_relative_CheckedChanged);
            // 
            // rb_absolute
            // 
            this.rb_absolute.AutoSize = true;
            this.rb_absolute.Location = new System.Drawing.Point(4, -2);
            this.rb_absolute.Name = "rb_absolute";
            this.rb_absolute.Size = new System.Drawing.Size(99, 27);
            this.rb_absolute.TabIndex = 0;
            this.rb_absolute.TabStop = true;
            this.rb_absolute.Text = "Absolute";
            this.rb_absolute.UseVisualStyleBackColor = true;
            this.rb_absolute.CheckedChanged += new System.EventHandler(this.rb_absolute_CheckedChanged);
            // 
            // tb_axis_value
            // 
            this.tb_axis_value.Location = new System.Drawing.Point(5, 37);
            this.tb_axis_value.Name = "tb_axis_value";
            this.tb_axis_value.Size = new System.Drawing.Size(100, 30);
            this.tb_axis_value.TabIndex = 14;
            this.tb_axis_value.TextChanged += new System.EventHandler(this.tb_axis_value_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
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
            this.pan_hat.Location = new System.Drawing.Point(452, 38);
            this.pan_hat.Name = "pan_hat";
            this.pan_hat.Size = new System.Drawing.Size(313, 151);
            this.pan_hat.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hat Position";
            // 
            // rb_0m1
            // 
            this.rb_0m1.AutoSize = true;
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
            this.panel4.Location = new System.Drawing.Point(156, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(121, 79);
            this.panel4.TabIndex = 16;
            // 
            // rb_button_pulse
            // 
            this.rb_button_pulse.AutoSize = true;
            this.rb_button_pulse.Location = new System.Drawing.Point(0, 0);
            this.rb_button_pulse.Name = "rb_button_pulse";
            this.rb_button_pulse.Size = new System.Drawing.Size(71, 27);
            this.rb_button_pulse.TabIndex = 1;
            this.rb_button_pulse.TabStop = true;
            this.rb_button_pulse.Text = "Pulse";
            this.rb_button_pulse.UseVisualStyleBackColor = true;
            this.rb_button_pulse.CheckedChanged += new System.EventHandler(this.rb_button_pulse_CheckedChanged);
            // 
            // rb_button_on
            // 
            this.rb_button_on.AutoSize = true;
            this.rb_button_on.Location = new System.Drawing.Point(0, 24);
            this.rb_button_on.Name = "rb_button_on";
            this.rb_button_on.Size = new System.Drawing.Size(52, 27);
            this.rb_button_on.TabIndex = 2;
            this.rb_button_on.TabStop = true;
            this.rb_button_on.Text = "On";
            this.rb_button_on.UseVisualStyleBackColor = true;
            this.rb_button_on.CheckedChanged += new System.EventHandler(this.rb_button_on_CheckedChanged);
            // 
            // rb_button_off
            // 
            this.rb_button_off.AutoSize = true;
            this.rb_button_off.Location = new System.Drawing.Point(-1, 48);
            this.rb_button_off.Name = "rb_button_off";
            this.rb_button_off.Size = new System.Drawing.Size(53, 27);
            this.rb_button_off.TabIndex = 3;
            this.rb_button_off.TabStop = true;
            this.rb_button_off.Text = "Off";
            this.rb_button_off.UseVisualStyleBackColor = true;
            this.rb_button_off.CheckedChanged += new System.EventHandler(this.rb_button_off_CheckedChanged);
            // 
            // cb_axis
            // 
            this.cb_axis.AutoSize = true;
            this.cb_axis.Location = new System.Drawing.Point(30, 176);
            this.cb_axis.Name = "cb_axis";
            this.cb_axis.Size = new System.Drawing.Size(125, 27);
            this.cb_axis.TabIndex = 12;
            this.cb_axis.Text = "Output Axis";
            this.cb_axis.UseVisualStyleBackColor = true;
            this.cb_axis.CheckedChanged += new System.EventHandler(this.cb_axis_CheckedChanged);
            // 
            // cb_button
            // 
            this.cb_button.AutoSize = true;
            this.cb_button.Location = new System.Drawing.Point(30, 7);
            this.cb_button.Name = "cb_button";
            this.cb_button.Size = new System.Drawing.Size(148, 27);
            this.cb_button.TabIndex = 11;
            this.cb_button.Text = "Output Button";
            this.cb_button.UseVisualStyleBackColor = true;
            this.cb_button.CheckedChanged += new System.EventHandler(this.cb_button_CheckedChanged);
            // 
            // cb_axis_selector
            // 
            this.cb_axis_selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_axis_selector.FormattingEnabled = true;
            this.cb_axis_selector.Location = new System.Drawing.Point(77, 244);
            this.cb_axis_selector.Name = "cb_axis_selector";
            this.cb_axis_selector.Size = new System.Drawing.Size(138, 31);
            this.cb_axis_selector.TabIndex = 10;
            this.cb_axis_selector.SelectedIndexChanged += new System.EventHandler(this.cb_axis_selector_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Interval";
            // 
            // tb_pulse_interval
            // 
            this.tb_pulse_interval.Location = new System.Drawing.Point(293, 70);
            this.tb_pulse_interval.Name = "tb_pulse_interval";
            this.tb_pulse_interval.Size = new System.Drawing.Size(100, 30);
            this.tb_pulse_interval.TabIndex = 6;
            this.tb_pulse_interval.TextChanged += new System.EventHandler(this.tb_pulse_interval_TextChanged);
            // 
            // tb_button_number
            // 
            this.tb_button_number.Location = new System.Drawing.Point(76, 70);
            this.tb_button_number.Name = "tb_button_number";
            this.tb_button_number.Size = new System.Drawing.Size(58, 30);
            this.tb_button_number.TabIndex = 5;
            this.tb_button_number.TextChanged += new System.EventHandler(this.tb_button_number_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Button";
            // 
            // cmd_test
            // 
            this.cmd_test.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmd_test.Location = new System.Drawing.Point(24, 107);
            this.cmd_test.Name = "cmd_test";
            this.cmd_test.Size = new System.Drawing.Size(121, 38);
            this.cmd_test.TabIndex = 8;
            this.cmd_test.Text = "Test";
            this.cmd_test.UseVisualStyleBackColor = false;
            this.cmd_test.Click += new System.EventHandler(this.cmd_test_Click);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(17, 378);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(82, 23);
            this.lbl_message.TabIndex = 1;
            this.lbl_message.Text = "Message";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_device_number);
            this.panel2.Controls.Add(this.lbl_device);
            this.panel2.Controls.Add(this.cmd_test);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 189);
            this.panel2.TabIndex = 2;
            // 
            // tb_device_number
            // 
            this.tb_device_number.Location = new System.Drawing.Point(24, 65);
            this.tb_device_number.Name = "tb_device_number";
            this.tb_device_number.Size = new System.Drawing.Size(121, 30);
            this.tb_device_number.TabIndex = 4;
            this.tb_device_number.TextChanged += new System.EventHandler(this.tb_device_number_TextChanged);
            // 
            // lbl_device
            // 
            this.lbl_device.AutoSize = true;
            this.lbl_device.Location = new System.Drawing.Point(24, 15);
            this.lbl_device.Name = "lbl_device";
            this.lbl_device.Size = new System.Drawing.Size(109, 23);
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


    }
}
