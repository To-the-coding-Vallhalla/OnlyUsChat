using OnlyUsChat;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OnlyUsChat_SERVER
{
    public partial class ServerForm : Form
    {
        private TcpListener server = null; // 서버
        private TcpClient clientSocket = null; // 클라이언트 소켓
        private static int user_count = 0; // 유저 수
        private string date; // 표시할 날짜
        private string time; // 표시할 시간

        // 클라이언트가 추가될 리스트
        public Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();

        int server_port = 52589;

        public ServerForm()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ServerStop);
            this.FormClosed += new FormClosedEventHandler(ShowSelectForm);

            portTxtBox.Text = $"{server_port}";
            exAddressTxtBox.Text = GetExternalIP().ToString();
            inAddressTxtBox.Text = GetInternalIP().ToString();

            // 쓰레드 생성
            Thread t = new Thread(InitSocket);
            t.IsBackground = true; // 백그라운드 동작 쓰레드
            t.Start();
        }

        private void ServerStop(object sender, FormClosingEventArgs e)
        {
            DisplayText("Server Stopped");
        }

        private void ShowSelectForm(object sender, FormClosedEventArgs e)
        {
            CloseServer();
            Application.ExitThread();
            Environment.Exit(0);
            Program.Mode.Visible = true; // 뜨면 잘못된것
        }

        // 소켓 초기화
        private void InitSocket()
        {
            IPAddress serverIP = IPAddress.Any;
            // 서버 접속 IP, 포트
            server = new TcpListener(serverIP, server_port);
            clientSocket = default(TcpClient); // TcpClient의 기본값을 소켓에 설정
            server.Start(); // 서버 시작
            DisplayText("Server Started");

            // 아래 while 문에서 서버가 동작
            while (true)
            {
                try
                {
                    user_count++; // Client 수 증가
                    clientSocket = server.AcceptTcpClient(); // client 소켓 접속 허용

                    NetworkStream stream = clientSocket.GetStream();
                    byte[] buffer = new byte[1024]; // 버퍼
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string user_name = Encoding.Unicode.GetString(buffer, 0, bytes);
                    // client 사용자 명
                    user_name = user_name.Substring(0, user_name.IndexOf("$"));
                    clientList.Add(clientSocket, user_name); // client 리스트에 추가

                    DisplayText($"Accept connection from {user_name}");
                    DisplayText($"Now User Count : {user_count}");

                    SendMessageAll(user_name + " 님이 입장하셨습니다.", "", false);

                    handleClient h_client = new handleClient(); // 클라이언트 추가
                    h_client.OnReceived += new handleClient.MessageDisplayHandler(OnReceived);
                    h_client.OnDisconnected += new handleClient.DisconnectedHandler(h_client_OnDisconnected);
                    h_client.startClient(clientSocket, clientList);
                }
                catch (SocketException se)
                {
                    // 소켓에 의한 에러
                    break;
                }
                catch (Exception e)
                {
                    // 일반적인 에러
                    break;
                }
            }
            CloseServer();
        }

        private void CloseServer()
        {
            if (clientSocket != null)
            {
                clientSocket.Close(); // client 소켓 닫기
            }
            server.Stop(); // 서버 종료
        }

        // client 접속 해제 핸들러
        private void h_client_OnDisconnected(TcpClient clientSocket)
        {
            // 클라 목록에서 나간 클라를 제거
            if (clientList.ContainsKey(clientSocket))
                clientList.Remove(clientSocket);
        }

        // 클라이언트로 부터 받은 데이터
        private void OnReceived(string message, string user_name)
        {
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");

            if (message.Equals("leaveChat"))
            {
                string displayMessage = "leave user : " + user_name;
                DisplayText(displayMessage);
                SendMessageAll("leaveChat", user_name, true);
            }
            else
            {
                string displayMessage = "From client : " + user_name
                    + " : " + message;
                DisplayText(displayMessage); // 서버에 출력
                SendMessageAll(message, user_name, true); // 모든 클라에게 전송
            }
        }

        public void SendMessageAll(string message, string user_name, bool flag)
        {
            foreach (var pair in clientList)
            {
                // 현재 시간 받아오기
                time = DateTime.Now.ToString("HH:mm:ss");

                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;
                if (flag)
                {
                    if (message.Equals("leaveChat"))
                    {
                        buffer = Encoding.Unicode.GetBytes(user_name + " 님이 대화방을 나갔습니다.");
                    }
                    else
                    {
                        buffer = Encoding.Unicode.GetBytes("[" + time + "] " + user_name + " : " + message);
                    }
                }
                else
                {
                    buffer = Encoding.Unicode.GetBytes(message);
                }

                stream.Write(buffer, 0, buffer.Length); // 버퍼 쓰기
                stream.Flush();
            }
        }

        private void DisplayText(string text) // Sever 콘솔화면에 출력
        {
            date = $"[{DateTime.Now:yyyy.MM.dd HH:mm:ss}] ";

            // Server 화면에 출력시킬것.
            if (consoleTextBox.InvokeRequired)
            {
                consoleTextBox.BeginInvoke(new MethodInvoker(delegate
                {
                    consoleTextBox.AppendText(date + text + Environment.NewLine);
                }
                ));
            }
            else
            {
                consoleTextBox.AppendText(date + text + Environment.NewLine);
            }
        }

        private IPAddress GetExternalIP()
        {
            string ip_document = new WebClient().DownloadString("http://checkip.dyndns.org");
            string ip = ip_document.Substring(ip_document.IndexOf(":") + 1).Split('<')[0].Replace(" ", string.Empty);
            return IPAddress.Parse(ip);
        }

        private IPAddress GetInternalIP()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())[1];
        }
    }
}