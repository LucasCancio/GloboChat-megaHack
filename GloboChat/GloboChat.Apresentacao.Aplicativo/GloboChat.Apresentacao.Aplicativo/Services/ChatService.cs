using GloboChat.Apresentacao.Aplicativo.EventHandlers;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GloboChat.Apresentacao.Aplicativo.Services
{
    public class ChatService
    {
        public event EventHandler<MessageEventArgs> OnReceivedMessage;
        public event EventHandler<MessageEventArgs> OnEnteredOrExited;
        public event EventHandler<MessageEventArgs> OnConnectionClosed;

        HubConnection hubConnection;
        Random random;

        bool IsConnected { get; set; }
        Dictionary<string, string> ActiveChannels { get; } = new Dictionary<string, string>();


        public void Init(string urlRoot, bool useHttps)
        {
            random = new Random();

            var port = (urlRoot == "localhost" || urlRoot == "10.0.2.2") ?
                (useHttps ? ":5001" : ":5000") :
                string.Empty;

            var url = $"http{(useHttps ? "s" : string.Empty)}://{urlRoot}{port}/hubs/chat";
            hubConnection = new HubConnectionBuilder()
            .WithUrl(url)
            .Build();

            hubConnection.Closed += async (error) =>
            {
                OnConnectionClosed?.Invoke(this, new MessageEventArgs("Connection closed...", string.Empty));
                IsConnected = false;
                await Task.Delay(random.Next(0, 5) * 1000);
                try
                {
                    await ConnectAsync();
                }
                catch (Exception ex)
                {
                    // Exception!
                    Debug.WriteLine(ex);
                }
            };

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnReceivedMessage?.Invoke(this, new MessageEventArgs(message, user));
            });

            hubConnection.On<string>("Entered", (user) =>
            {
                OnEnteredOrExited?.Invoke(this, new MessageEventArgs($"{user} entered.", user));
            });


            hubConnection.On<string>("Left", (user) =>
            {
                OnEnteredOrExited?.Invoke(this, new MessageEventArgs($"{user} left.", user));
            });


            hubConnection.On<string>("EnteredOrLeft", (message) =>
            {
                OnEnteredOrExited?.Invoke(this, new MessageEventArgs(message, message));
            });
        }

        public async Task ConnectAsync()
        {
            if (IsConnected)
                return;

            await hubConnection.StartAsync();
            IsConnected = true;
        }

        public async Task DisconnectAsync()
        {
            if (!IsConnected)
                return;

            try
            {
                await hubConnection.DisposeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            ActiveChannels.Clear();
            IsConnected = false;
        }

        public async Task LeaveChannelAsync(string group, string userName)
        {
            if (!IsConnected || !ActiveChannels.ContainsKey(group))
                return;

            await hubConnection.SendAsync("RemoveFromGroup", group, userName);

            ActiveChannels.Remove(group);
        }

        public async Task JoinChannelAsync(string group, string userName)
        {
            if (!IsConnected || ActiveChannels.ContainsKey(group))
                return;

            await hubConnection.SendAsync("AddToGroup", group, userName);
            ActiveChannels.Add(group, userName);

        }

        public async Task SendMessageAsync(string group, string userName, string message)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected");

            await hubConnection.InvokeAsync("SendMessageGroup",
                    group,
                    userName,
                    message);
        }

        public List<string> GetRooms()
        {
            return new List<string>
                        {
                                ".NET",
                                "ASP.NET",
                                "Xamarin"
                        };
        }
    


    #region codigo server
    //// O tratador de evento para a saida da aplicação
    //public void OnApplicationExit(object sender, EventArgs e)
    //{
    //    if (Conectado == true)
    //    {
    //        // Fecha as conexões, streams, etc...
    //        Conectado = false;
    //        stwEnviador.Close();
    //        strReceptor.Close();
    //        tcpServidor.Close();
    //    }
    //}

    //// Trata o nome do usuário
    //private string NomeUsuario = "Desconhecido";
    //private StreamWriter stwEnviador;
    //private StreamReader strReceptor;
    //private TcpClient tcpServidor;
    //// Necessário para atualizar o formulário com mensagens da outra thread
    //private delegate void AtualizaLogCallBack(string strMensagem);
    //// Necessário para definir o formulário para o estado "disconnected" de outra thread
    //private delegate void FechaConexaoCallBack(string strMotivo);
    //private Thread mensagemThread;
    //private IPAddress enderecoIP;
    //private bool Conectado;


    //private void InicializaConexao()
    //{
    //    try
    //    {
    //        var ip = "";
    //        // Trata o endereço IP informado em um objeto IPAdress
    //        enderecoIP = IPAddress.Parse(ip);
    //        // Inicia uma nova conexão TCP com o servidor chat
    //        tcpServidor = new TcpClient();
    //        tcpServidor.Connect(enderecoIP, 2502);

    //        // AJuda a verificar se estamos conectados ou não
    //        Conectado = true;

    //        // Prepara o formulário
    //        //NomeUsuario = txtUsuario.Text;

    //        // Envia o nome do usuário ao servidor
    //        stwEnviador = new StreamWriter(tcpServidor.GetStream());
    //        //stwEnviador.WriteLine(txtUsuario.Text);
    //        stwEnviador.Flush();

    //        //Inicia a thread para receber mensagens e nova comunicação
    //        mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
    //        mensagemThread.Start();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Erro na conexão com servidor : " + ex.Message);
    //    }
    //}

    //private void RecebeMensagens()
    //{
    //    // recebe a resposta do servidor
    //    strReceptor = new StreamReader(tcpServidor.GetStream());
    //    string ConResposta = strReceptor.ReadLine();
    //    // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
    //    if (ConResposta[0] == '1')
    //    {
    //        // Atualiza o formulário para informar que esta conectado
    //        //this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
    //    }
    //    else // Se o primeiro caractere não for 1 a conexão falhou
    //    {
    //        string Motivo = "Não Conectado: ";
    //        // Extrai o motivo da mensagem resposta. O motivo começa no 3o caractere
    //        Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
    //        // Atualiza o formulário como o motivo da falha na conexão
    //        //this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
    //        // Sai do método
    //        return;
    //    }

    //    // Enquanto estiver conectado le as linhas que estão chegando do servidor
    //    while (Conectado)
    //    {
    //        // exibe mensagems no Textbox
    //        //this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
    //    }
    //}

    //private void AtualizaLog(string strMensagem)
    //{
    //    // Anexa texto ao final de cada linha
    //    //txtLog.AppendText(strMensagem + "\r\n");
    //}



    //// Envia a mensagem para o servidor
    //private void EnviaMensagem(string msg)
    //{
    //    if (msg.Length >= 1)
    //    {
    //        stwEnviador.WriteLine(msg);
    //        stwEnviador.Flush();
    //    }
    //}

    //// Fecha a conexão com o servidor
    //private void FechaConexao(string Motivo)
    //{
    //    // Fecha os objetos
    //    Conectado = false;
    //    stwEnviador.Close();
    //    strReceptor.Close();
    //    tcpServidor.Close();
    //}
    #endregion

}
}
