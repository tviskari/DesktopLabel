using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLabel
{
    public partial class Label : Form
    {
        public Label()
        {
            InitializeComponent();
        }

        private void Label_Load(object sender, EventArgs e)
        {
            ResetPosition();

            lblName.Height = this.Size.Height;
            lblName.Width = this.Size.Height;
            lblName.TextAlign = ContentAlignment.MiddleCenter;

            lblName.Hide();

            txtName.KeyPress += txtLocal_KeyPress;
            lblName.Click += lblName_Click;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new EventHandler(DisplaySettingsChanged);
            //lblName.MouseHover += HideForm;
        }

        private void DisplaySettingsChanged(object sender, System.EventArgs e)
        {
            ResetPosition();
        }

        private void ResetPosition()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        private void HideForm(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(3000);
            this.Show();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            lblName.Hide();
            txtName.Show();
            btnChangeName.Show();
            txtName.Text = "";
        }

        private string _desktopName = "";

        private void txtLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Enter{
            {
                e.Handled = true;
                ChangeName();
            }
        }
    

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            ChangeName();
        }

        private void ChangeName()
        {
            _desktopName = txtName.Text;
            lblName.Text = _desktopName;

            txtName.Hide();
            btnChangeName.Hide();
            lblName.Show();
        }

        private void DesktopLabel_Click(object sender, EventArgs e)
        {
            txtName.Show();
            btnChangeName.Show();
            lblName.Hide();
        }
    }
}
