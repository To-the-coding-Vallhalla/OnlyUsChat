using System;
using System.Net;
using System.Windows.Forms;

namespace OnlyUsChat
{
    public partial class TypeNickName : Form
    {
        private bool connected = false;

        // 서버 정보
        private IPAddress serverAddress = null;
        private int server_port = 52589;

        public TypeNickName()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(ShowSelectForm);
        }

        private void ShowSelectForm(object sender, FormClosedEventArgs e)
        {
            if (!connected)
                Program.Mode.Visible = true;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(nickNameTxtBox.Text) || string.IsNullOrEmpty(addressTxtBox.Text))
            {
                return;
            }

            try
            {
                serverAddress = IPAddress.Parse(addressTxtBox.Text);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                MessageBox.Show("아이피가 바르지 않습니다.", "아이피를 확인하세요...");
                return;
            }

            connected = true;
            MainChatForm mainChat = new MainChatForm(
                nickNameTxtBox.Text,
                serverAddress,
                server_port);
            try
            {
                this.Visible = false;
                mainChat.ShowDialog();
            }
            catch 
            {
                connected = false;
            }
        }
    }
}