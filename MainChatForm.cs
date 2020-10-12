using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OnlyUsChat
{
    public partial class MainChatForm : Form
    {
        // 소켓
        private TcpClient clientSocket = new TcpClient();

        private NetworkStream stream = default(NetworkStream);
        private string message = string.Empty;
        private string user_name = string.Empty;

        private Thread t_handler = null;

        // 서버 정보
        IPAddress serverIP;
        int serverPort;

        public MainChatForm(string nickName, IPAddress serverIP, int serverPort)
        {
            InitializeComponent();

            user_name = nickName;

            this.FormClosing += new FormClosingEventHandler(Disconnect);
            this.Shown += new EventHandler(shown);

            this.serverIP = serverIP;
            this.serverPort = serverPort;
        }

        private void shown(object sender, EventArgs e)
        {
            Connect_Server();
        }

        private void Disconnect(object sender, FormClosingEventArgs e)
        {
            if(stream != null)
            {
                byte[] buffer = Encoding.Unicode.GetBytes("leaveChat" + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }

            Application.ExitThread();
            Environment.Exit(0);
        }

        // 메시지 전송
        private void send_btn_Click(object sender, EventArgs e)
        {
            sendTextBox.Focus();
            byte[] buffer = Encoding.Unicode.GetBytes(this.sendTextBox.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            sendTextBox.Text = string.Empty;
        }

        // 메시지 수신
        private void GetMessage()
        {
            while (true)
            {
                stream = clientSocket.GetStream();
                int bufferSize = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[bufferSize];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                DisplayText(message);
            }
        }

        public void Connect_Server()
        {
            try
            {
                clientSocket.Connect(serverIP, serverPort);
                stream = clientSocket.GetStream();
            }
            catch (Exception e2)
            {
                MessageBox.Show("서버가 실행중이 아닙니다.", "연결실패!");
                this.Close();
                return;
            }
            message = "채팅 서버에 연결 되었습니다.";
            DisplayText(message);

            byte[] buffer = Encoding.Unicode.GetBytes(user_name + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            t_handler = new Thread(GetMessage);
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        private void DisplayText(string text) // Sever 콘솔화면에 출력
        {
            // 채팅 화면에 출력시킬것.
            if (chatTextBox.InvokeRequired)
            {
                chatTextBox.BeginInvoke(new MethodInvoker(delegate
                {
                    chatTextBox.AppendText(text + Environment.NewLine);
                    chatTextBox.ScrollToCaret(); // 스크롤 이동
                }
                ));
            }
            else
            {
                chatTextBox.AppendText(text + Environment.NewLine);
                chatTextBox.ScrollToCaret(); // 스크롤 이동
            }
        }

        private void sendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                send_btn_Click(this, e);
            }
        }

        private void sendTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                send_btn_Click(this, e);
            }
        }
    }
}