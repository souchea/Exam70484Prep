using System;
using System.Collections.Generic;
using System.Text;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Exam484Prep.Common;
using Windows.ApplicationModel.Contacts;

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

	    public async void ShowContact()
	    {
		    var contactPicker = new ContactPicker();
		    contactPicker.CommitButtonText = "choose a contact";

		    ContactInformation contact = await contactPicker.PickSingleContactAsync();
	    }
    }
}
