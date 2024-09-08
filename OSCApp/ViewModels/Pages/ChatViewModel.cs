using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSCApp.Models;
using R3;

namespace OSCApp.ViewModels.Pages
{
    public class ChatViewModel
    {
        private readonly OscChatModel _model;
        public BindableReactiveProperty<string> Message { get; } = new();
        public ReactiveCommand<Unit> SendMessageCommand { get; } = new();

        public ChatViewModel(OscChatModel oscChatModel)
        {
            _model = oscChatModel;
            SendMessageCommand
                .Where(_ => !string.IsNullOrEmpty(Message.Value))
                .Subscribe(_ => SendMessage());
        }
        private void SendMessage()
        {
            _model.SendMessage(Message.Value);
            Message.Value = string.Empty;
        }

    }
}
