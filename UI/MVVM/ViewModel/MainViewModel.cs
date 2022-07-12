using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;
using UI.MVVM.Model;

namespace UI.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }

        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */

        public RelayCommand SendCommad { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value;
                onPropertyChanged();
            }
            
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }



        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommad = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false,
                });

                Message = "";
            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Alison",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = true
                });
            }

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                    FirstMessage = true
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Bunny",
                UsernameColor = "#409aff",
                ImageSource = "https://i.imgur.com/yMWvLXd.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
                FirstMessage = true
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Alison {i}",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Messages = Messages
                });
            }
        }
    }
}
