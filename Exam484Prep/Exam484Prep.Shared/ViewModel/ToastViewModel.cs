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

        private RelayCommand _showLongDurationToastCommand;

        public RelayCommand ShowLongDurationToastCommand
        {
            get
            {
                if (_showLongDurationToastCommand == null)
                {
                    _showLongDurationToastCommand = new RelayCommand(
                        ShowLongDurationToast,
                        () => true);
                }
                return _showLongDurationToastCommand;
            }
            set
            {
                _showLongDurationToastCommand = value;
            }
        }

        private RelayCommand _showDifferentSoundToastCommand;

        public RelayCommand ShowDifferentSoundToastCommand
        {
            get
            {
                if (_showDifferentSoundToastCommand == null)
                {
                    _showDifferentSoundToastCommand = new RelayCommand(
                        ShowDifferentSoundToast,
                        () => true);
                }
                return _showDifferentSoundToastCommand;
            }
            set
            {
                _showDifferentSoundToastCommand = value;
            }
        }

        public void ShowDifferentSoundToast()
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(
                 "Hello! I am an awesome cat… Awesome cats make Windows 8 awesomer!!"));
            XmlElement tileImage = toastXml.GetElementsByTagName("image")[0] as XmlElement;
            tileImage.SetAttribute("src",
                       "http://placekitten.com/256/256");
            tileImage.SetAttribute("alt", "awesome cat");
            // Display the toast for 25 seconds
            XmlElement toastNode = (XmlElement)toastXml.SelectSingleNode("/toast");
            toastNode.SetAttribute("duration", "long");
            // Add a looping sound
            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.Looping.Call");
            audio.SetAttribute("loop", "true");
            toastNode.AppendChild(audio);
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowToast()
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(
                 "Hello! I am an awesome cat… awesome cats make Windows 8 awesomer!!"));
            //XmlElement tileImage = toastXml.GetElementsByTagName("image")[0] as XmlElement;
            //tileImage.SetAttribute("src", "ms-appx:///Assets/Cat-2.JPG");
            //tileImage.SetAttribute("alt", "awesome cat");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void ShowLongDurationToast()
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(
                 "Hello! I am an awesome cat… Awesome cats make Windows 8 awesomer!!"));
            XmlElement tileImage = toastXml.GetElementsByTagName("image")[0] as XmlElement;
            tileImage.SetAttribute("src",
                       "http://placekitten.com/256/256");
            tileImage.SetAttribute("alt", "awesome cat");
            // Display the toast for 25 seconds. If you want the toast to be displayed for
            // 7 seconds, do not set the duration attribute to any value. The default value is
            // 'short' and the duration will be 7 seconds.
            var toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
