using MvvmHelpers;
using System;
using System.Drawing;
using Xamarin.Essentials;

namespace GloboChat.Apresentacao.Aplicativo.Model
{
    public class ChatMessage : ObservableObject
    {
        static Random Random = new Random();
        string user;
        public string User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        string firstLetter;
        public string FirstLetter
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(firstLetter))
                    return firstLetter;

                firstLetter = User?.Length > 0 ? User[0].ToString() : "?";
                return firstLetter;
            }
            set => firstLetter = value;
        }

        Color color;
        public Color Color
        {
            get
            {
                if (color != null && color.A != 0)
                    return color;

                color = Color.FromArgb(Random.Next(0, 255), Random.Next(0, 255), Random.Next(0, 255)).MultiplyAlpha(0.9f);
                return color;
            }
            set => color = value;
        }

        Color backgroundColor;
        public Color BackgroundColor
        {
            get
            {
                if (backgroundColor != null && backgroundColor.A != 0)
                    return backgroundColor;

                backgroundColor = Color.MultiplyAlpha(0.6f);
                return backgroundColor;
            }
            set => backgroundColor = value;
        }
    }
}
