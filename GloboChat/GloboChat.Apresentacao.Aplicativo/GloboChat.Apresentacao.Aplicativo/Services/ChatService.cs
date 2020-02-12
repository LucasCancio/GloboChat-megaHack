using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GloboChat.Apresentacao.Aplicativo.Services
{
    public class ChatService
    {
        // Trata o nome do usuário
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado;


        public void AtualizaLog(string strMensagem)
        {
            throw new NotImplementedException();
        }

        public void EnviaMensagem(string msg)
        {
            stwEnviador.WriteLine(msg);
            stwEnviador.Flush();
        }

        public void FechaConexao(string Motivo)
        {
            // Fecha os objetos
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
        }

        public void InicializaConexao(string ipServidor, string nomeUsuario)
        {

            // Trata o endereço IP informado em um objeto IPAdress
            enderecoIP = IPAddress.Parse(ipServidor);
            // Inicia uma nova conexão TCP com o servidor chat
            tcpServidor = new TcpClient();
            tcpServidor.Connect(enderecoIP, 2502);

            // AJuda a verificar se estamos conectados ou não
            Conectado = true;

            // Prepara o formulário
            NomeUsuario = nomeUsuario;

            // Envia o nome do usuário ao servidor
            stwEnviador = new StreamWriter(tcpServidor.GetStream());
            stwEnviador.WriteLine(nomeUsuario);
            stwEnviador.Flush();

            //Inicia a thread para receber mensagens e nova comunicação
            mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
            mensagemThread.Start();

        }

        public void RecebeMensagens()
        {
            // recebe a resposta do servidor
            var strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();
            // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                //this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else // Se o primeiro caractere não for 1 a conexão falhou
            {
                string Motivo = "Não Conectado: ";
                // Extrai o motivo da mensagem resposta. O motivo começa no 3o caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário como o motivo da falha na conexão
                //this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            // Enquanto estiver conectado le as linhas que estão chegando do servidor
            while (Conectado)
            {
                // exibe mensagems no Textbox
                //this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }
    }
}
