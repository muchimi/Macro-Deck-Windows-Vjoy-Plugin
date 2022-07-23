namespace muchimi_vjoy
{
    partial class AddApplication
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_application = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.cmd_close = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.SuspendLayout();
            // 
            // tb_application
            // 
            this.tb_application.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.tb_application.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_application.Icon = null;
            this.tb_application.Location = new System.Drawing.Point(4, 4);
            this.tb_application.MaxCharacters = 32767;
            this.tb_application.Multiline = false;
            this.tb_application.Name = "tb_application";
            this.tb_application.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.tb_application.PasswordChar = false;
            this.tb_application.PlaceHolderColor = System.Drawing.Color.Gray;
            this.tb_application.PlaceHolderText = "";
            this.tb_application.ReadOnly = false;
            this.tb_application.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_application.SelectionStart = 0;
            this.tb_application.Size = new System.Drawing.Size(250, 25);
            this.tb_application.TabIndex = 2;
            this.tb_application.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cmd_close
            // 
            this.cmd_close.BorderRadius = 8;
            this.cmd_close.FlatAppearance.BorderSize = 0;
            this.cmd_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_close.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmd_close.ForeColor = System.Drawing.Color.White;
            this.cmd_close.HoverColor = System.Drawing.Color.Empty;
            this.cmd_close.Icon = null;
            this.cmd_close.Location = new System.Drawing.Point(911, 207);
            this.cmd_close.Name = "cmd_close";
            this.cmd_close.Progress = 0;
            this.cmd_close.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.cmd_close.Size = new System.Drawing.Size(102, 26);
            this.cmd_close.TabIndex = 19;
            this.cmd_close.Text = "Close";
            this.cmd_close.UseVisualStyleBackColor = true;
            this.cmd_close.UseWindowsAccentColor = true;
            this.cmd_close.Click += new System.EventHandler(this.cmd_close_Click);
            // 
            // AddApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(1045, 250);
            this.Controls.Add(this.cmd_close);
            this.Controls.Add(this.tb_application);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AddApplication";
            this.Controls.SetChildIndex(this.tb_application, 0);
            this.Controls.SetChildIndex(this.cmd_close, 0);
            this.ResumeLayout(false);

            this.Closing += dialog_closing;
        }

        #endregion



        private SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox tb_application;
        private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary cmd_close;
    }
}