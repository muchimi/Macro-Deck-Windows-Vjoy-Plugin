using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using muchimi_vjoy;
using SuchByte.MacroDeck.GUI.CustomControls;

namespace muchimi_vjoy
{
    public partial class AddApplication : DialogForm
    {
        public AddApplication()
        {
            InitializeComponent();
        }


        public string ApplicationName { get; set; }

        private void dialog_closing(object sender, CancelEventArgs e)
        {
            var config = Main.Instance.Config;
            var name = config.FixedName(tb_application.Text);
            if (string.IsNullOrWhiteSpace(name))
            {
                this.DialogResult = DialogResult.Cancel;
            }

            ApplicationName = name;
            this.DialogResult = DialogResult.OK;

        }

        private void cmd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
