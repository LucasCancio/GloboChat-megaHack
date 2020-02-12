using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GloboChat.Dominio.Models
{
    public class Cliente
    {
        private string NomeUsuario { get; set; }
        private StreamWriter stwEnviador { get; set; }
        private StreamReader strReceptor { get; set; }
        private TcpClient tcpServidor { get; set; }   
        private Thread mensagemThread { get; set; }
        private IPAddress enderecoIP { get; set; }
        private bool Conectado { get; set; }

        private delegate void AtualizaLogCallBack(string strMensagem);
        private delegate void FechaConexaoCallBack(string strMotivo);
    }
}
