using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Exam484Prep.Common;

namespace Exam484Prep.ViewModel
{
    public class TileViewModel : BaseViewModel
    {

        private RelayCommand _sendNotificationCommand;

        public RelayCommand SendNotificationCommand
        {
            get
            {
                if (_sendNotificationCommand == null)
                {
                    _sendNotificationCommand = new RelayCommand(
                        SendLocalFileNotification,
                        () => true);
                }
                return _sendNotificationCommand;
            }
            set
            {
                _sendNotificationCommand = value;
            }
        }

        private RelayCommand _clearTileNotificationsCommand;

        public RelayCommand ClearTileNotificationsCommand
        {
            get
            {
                if (_clearTileNotificationsCommand == null)
                {
                    _clearTileNotificationsCommand = new RelayCommand(
                        ClearTileNotifications,
                        () => true);
                }
                return _clearTileNotificationsCommand;
            }
            set
            {
                _clearTileNotificationsCommand = value;
            }
        }

        private RelayCommand _createSecondaryTileCommand;

        public RelayCommand CreateSecondaryTileCommand
        {
            get
            {
                if (_createSecondaryTileCommand == null)
                {
                    _createSecondaryTileCommand = new RelayCommand(
                        CreateSecondaryTile,
                        () => true);
                }
                return _createSecondaryTileCommand;
            }
            set
            {
                _createSecondaryTileCommand = value;
            }
        }

        public void CreateSecondaryTile()
        {

        }

        public void ClearTileNotifications()
        {
            // Clear all notification and set the tile to display default content
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
        }

        public void SendLocalFileNotification()
        {
            // Create and populate the wide tile
            XmlDocument wideImageAndTextTileXml =
               TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideImageAndText01);
            XmlNodeList wideTileTextAttributes =
                     wideImageAndTextTileXml.GetElementsByTagName("text");
            wideTileTextAttributes[0].InnerText = "Awesome cats make Windows 8 awesomer!!";
            XmlElement tileImage = wideImageAndTextTileXml.GetElementsByTagName("image")[0]
                as XmlElement;
            //tileImage.SetAttribute("src", "ms-appx:///Assets/Cat-1.JPG");
            tileImage.SetAttribute("alt", "Awesome Cats");

            // Create and populate the square tile
            XmlDocument squareTileXml =
                       TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareText04);
            XmlNodeList squareTileTextAttributes = squareTileXml.GetElementsByTagName("text");
            squareTileTextAttributes[0].AppendChild(squareTileXml.CreateTextNode(
                             "Awesome cats make Windows 8 awesomer!"));

            // Import the XML template for the square tile into the wide tile
            IXmlNode node = wideImageAndTextTileXml.ImportNode(
                   squareTileXml.GetElementsByTagName("binding").Item(0), true);
            wideImageAndTextTileXml.GetElementsByTagName("visual").Item(0).AppendChild(node);
            TileNotification tileNotification = new TileNotification(wideImageAndTextTileXml);

            // Add an expiration time of 30 minutes
            tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(1800);

            // Send the local tile notification
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

    }
}
