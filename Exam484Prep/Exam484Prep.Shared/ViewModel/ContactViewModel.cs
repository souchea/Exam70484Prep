using System;
using System.Collections.Generic;
using System.Text;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Exam484Prep.Common;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Popups;

namespace Exam484Prep.ViewModel
{
    public class ContactViewModel : BaseViewModel
    {
        private RelayCommand _showContactCommand;

        public RelayCommand ShowContactCommand
        {
            get
            {
                if (_showContactCommand == null)
                {
                    _showContactCommand = new RelayCommand(
                        ShowContact,
                        () => true);
                }
                return _showContactCommand;
            }
            set
            {
                _showContactCommand = value;
            }
        }

        private RelayCommand _showMultipleContactCommand;

        public RelayCommand ShowMultipleContactCommand
        {
            get
            {
                if (_showMultipleContactCommand == null)
                {
                    _showMultipleContactCommand = new RelayCommand(
                        ShowMultipleContact,
                        () => true);
                }
                return _showMultipleContactCommand;
            }
            set
            {
                _showMultipleContactCommand = value;
            }
        }

        public async void ShowContact()
        {
            var contactPicker = new ContactPicker();
            contactPicker.CommitButtonText = "choose a contact";

            // PickSingleContact will be obsolete
            // ContactInformation contact = await contactPicker.PickSingleContactAsync();

            Contact contact = await contactPicker.PickContactAsync();

            if (contact != null)
            {
                MessageDialog choosenContact = new MessageDialog(String.Format("Contact chosen: {0} {1}", contact.FirstName, contact.LastName));
                await choosenContact.ShowAsync();
            }
            else
            {
                MessageDialog noContact = new MessageDialog("No contact chosen");
                await noContact.ShowAsync();
            }
        }

        public async void ShowMultipleContact()
        {
            var contactPicker = new ContactPicker();
            contactPicker.CommitButtonText = "choose contacts";

            // PickMultipleContact will be obsolete
            //IEnumerable<ContactInformation> contacts = await contactPicker.PickMultipleContactsAsync();

            var sb = new StringBuilder();

            IEnumerable<Contact> contacts = await contactPicker.PickContactsAsync();

            if (contacts != null)
            {
                sb.AppendFormat("Contacts chosen: ");
                foreach (var contact in contacts)
                {
                    sb.AppendFormat("{0} {1} / ", contact.FirstName, contact.LastName);
                }
                MessageDialog noContact = new MessageDialog(sb.ToString());
                await noContact.ShowAsync();
            }
        }
    }
}
