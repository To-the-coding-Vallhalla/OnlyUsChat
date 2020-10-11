using OnlyUsChat_SERVER;

using System;
using System.Windows.Forms;

namespace OnlyUsChat
{
    public partial class SelectModeForm : Form
    {
        public SelectModeForm()
        {
            InitializeComponent();
        }

        private void ServerMode_Click(object sender, EventArgs e)
        {
            Program.Mode.Visible = false;
            ServerForm server = new ServerForm();
            server.ShowDialog();
        }

        private void ClientMode_Click(object sender, EventArgs e)
        {
            Program.Mode.Visible = false;
            TypeNickName nickNameForm = new TypeNickName();
            nickNameForm.ShowDialog();
        }
    }
}