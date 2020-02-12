using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GloboChat.Apresentacao.Aplicativo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeitorQrCode : ContentPage
    {
        public LeitorQrCode()
        {
            InitializeComponent();
        }
    }
}