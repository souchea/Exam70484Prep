using System;
using System.Collections.Generic;
using System.Text;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Exam484Prep.Common;

namespace Exam484Prep.ViewModel
{
    public class ToastViewModel : BaseViewModel
    {
        private RelayCommand _showToastCommand;

        public RelayCommand ShowToastCommand
        {
            get
            {
                if (_showToastCommand == null)
                {
                    _showToastCommand = new RelayCommand(
                        ShowToast,
                        () => true);
                }
                return _showToastCommand;
            }
            set
            {
                _showToastCommand = value;
            }
        }

        public void ShowToast()
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(
                 "Hello! I am an awesome cat… awesome cats make Windows 8 awesomer!!"));
            XmlElement tileImage = toastXml.GetElementsByTagName("image")[0] as XmlElement;
            //tileImage.SetAttribute("src", "ms-appx:///Assets/Cat-2.JPG");
            tileImage.SetAttribute("alt", "awesome cat");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
