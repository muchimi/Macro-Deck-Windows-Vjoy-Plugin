namespace muchimi.vjoy
{
    partial class KeyboardCapture
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmd_ok = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.tb_key = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmd_cancel = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.cmd_clear = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lbl_extended = new System.Windows.Forms.Label();
            this.lbl_modifiers = new System.Windows.Forms.Label();
            this.lbl_key = new System.Windows.Forms.Label();
            this.lbl_scancode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmd_ok
            // 
            this.cmd_ok.BorderRadius = 8;
            this.cmd_ok.FlatAppearance.BorderSize = 0;
            this.cmd_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_ok.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_ok.ForeColor = System.Drawing.Color.White;
            this.cmd_ok.HoverColor = System.Drawing.Color.Empty;
            this.cmd_ok.Icon = null;
            this.cmd_ok.Location = new System.Drawing.Point(764, 191);
            this.cmd_ok.Name = "cmd_ok";
            this.cmd_ok.Progress = 0;
            this.cmd_ok.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_ok.Size = new System.Drawing.Size(90, 29);
            this.cmd_ok.TabIndex = 2;
            this.cmd_ok.Text = "Ok";
            this.cmd_ok.UseVisualStyleBackColor = true;
            this.cmd_ok.UseWindowsAccentColor = true;
            this.cmd_ok.Click += new System.EventHandler(this.cmd_ok_Click);
            // 
            // tb_key
            // 
            this.tb_key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_key.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_key.Icon = null;
            this.tb_key.Location = new System.Drawing.Point(4, 31);
            this.tb_key.MaxCharacters = 32767;
            this.tb_key.Multiline = false;
            this.tb_key.Name = "tb_key";
            this.tb_key.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_key.PasswordChar = false;
            this.tb_key.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_key.PlaceHolderText = "";
            this.tb_key.ReadOnly = true;
            this.tb_key.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_key.SelectionStart = 0;
            this.tb_key.Size = new System.Drawing.Size(250, 25);
            this.tb_key.TabIndex = 3;
            this.tb_key.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Keyboard Capture: Ctrl,Shift and Alt keys will toggle state. ";
            // 
            // cmd_cancel
            // 
            this.cmd_cancel.BorderRadius = 8;
            this.cmd_cancel.FlatAppearance.BorderSize = 0;
            this.cmd_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_cancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_cancel.ForeColor = System.Drawing.Color.White;
            this.cmd_cancel.HoverColor = System.Drawing.Color.Empty;
            this.cmd_cancel.Icon = null;
            this.cmd_cancel.Location = new System.Drawing.Point(860, 191);
            this.cmd_cancel.Name = "cmd_cancel";
            this.cmd_cancel.Progress = 0;
            this.cmd_cancel.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_cancel.Size = new System.Drawing.Size(90, 29);
            this.cmd_cancel.TabIndex = 5;
            this.cmd_cancel.Text = "Cancel";
            this.cmd_cancel.UseVisualStyleBackColor = true;
            this.cmd_cancel.UseWindowsAccentColor = true;
            this.cmd_cancel.Click += new System.EventHandler(this.cmd_cancel_Click);
            // 
            // cmd_clear
            // 
            this.cmd_clear.BorderRadius = 8;
            this.cmd_clear.FlatAppearance.BorderSize = 0;
            this.cmd_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_clear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_clear.ForeColor = System.Drawing.Color.White;
            this.cmd_clear.HoverColor = System.Drawing.Color.Empty;
            this.cmd_clear.Icon = null;
            this.cmd_clear.Location = new System.Drawing.Point(271, 31);
            this.cmd_clear.Name = "cmd_clear";
            this.cmd_clear.Progress = 0;
            this.cmd_clear.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_clear.Size = new System.Drawing.Size(90, 29);
            this.cmd_clear.TabIndex = 6;
            this.cmd_clear.Text = "Reset";
            this.cmd_clear.UseVisualStyleBackColor = true;
            this.cmd_clear.UseWindowsAccentColor = true;
            this.cmd_clear.Click += new System.EventHandler(this.cmd_clear_Click);
            // 
            // lbl_extended
            // 
            this.lbl_extended.AutoSize = true;
            this.lbl_extended.Location = new System.Drawing.Point(103, 129);
            this.lbl_extended.Name = "lbl_extended";
            this.lbl_extended.Size = new System.Drawing.Size(59, 16);
            this.lbl_extended.TabIndex = 7;
            this.lbl_extended.Text = "extended";
            // 
            // lbl_modifiers
            // 
            this.lbl_modifiers.AutoSize = true;
            this.lbl_modifiers.Location = new System.Drawing.Point(103, 102);
            this.lbl_modifiers.Name = "lbl_modifiers";
            this.lbl_modifiers.Size = new System.Drawing.Size(60, 16);
            this.lbl_modifiers.TabIndex = 8;
            this.lbl_modifiers.Text = "modifiers";
            // 
            // lbl_key
            // 
            this.lbl_key.AutoSize = true;
            this.lbl_key.Location = new System.Drawing.Point(103, 77);
            this.lbl_key.Name = "lbl_key";
            this.lbl_key.Size = new System.Drawing.Size(26, 16);
            this.lbl_key.TabIndex = 9;
            this.lbl_key.Text = "key";
            // 
            // lbl_scancode
            // 
            this.lbl_scancode.AutoSize = true;
            this.lbl_scancode.Location = new System.Drawing.Point(103, 158);
            this.lbl_scancode.Name = "lbl_scancode";
            this.lbl_scancode.Size = new System.Drawing.Size(60, 16);
            this.lbl_scancode.TabIndex = 10;
            this.lbl_scancode.Text = "scancode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Modifiers:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Extended:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Scan Code:";
            // 
            // KeyboardCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 250);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_scancode);
            this.Controls.Add(this.lbl_key);
            this.Controls.Add(this.lbl_modifiers);
            this.Controls.Add(this.lbl_extended);
            this.Controls.Add(this.cmd_clear);
            this.Controls.Add(this.cmd_cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.cmd_ok);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "KeyboardCapture";
            this.Controls.SetChildIndex(this.cmd_ok, 0);
            this.Controls.SetChildIndex(this.tb_key, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmd_cancel, 0);
            this.Controls.SetChildIndex(this.cmd_clear, 0);
            this.Controls.SetChildIndex(this.lbl_extended, 0);
            this.Controls.SetChildIndex(this.lbl_modifiers, 0);
            this.Controls.SetChildIndex(this.lbl_key, 0);
            this.Controls.SetChildIndex(this.lbl_scancode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary cmd_ok;
        private SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox tb_key;
        private System.Windows.Forms.Label label1;
        private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary cmd_cancel;
        private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary cmd_clear;
        private System.Windows.Forms.Label lbl_extended;
        private System.Windows.Forms.Label lbl_modifiers;
        private System.Windows.Forms.Label lbl_key;
        private System.Windows.Forms.Label lbl_scancode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
