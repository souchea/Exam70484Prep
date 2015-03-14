using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Exam484Prep.Common;
using Windows.UI.Notifications;
using Windows.ApplicationModel.Background;

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

        public async void CreateSecondaryTile()
        {
            //Uri logo = new Uri("ms-appx:///Assets/mcnext.png");
            //string tileActivationArguments = appbarTileId + " was pinned at " +
            //DateTime.Now.ToLocalTime().ToString();
            //SecondaryTile secondaryTile = new SecondaryTile(appbarTileId,
            //"70-484",
            //"Super Exam Win8",
            //tileActivationArguments,
            //TileOptions.ShowNameOnLogo | TileOptions.ShowNameOnWideLogo,
            //logo);
            //secondaryTile.ForegroundText = ForegroundText.Dark;
            //secondaryTile.SmallLogo =
            //new Uri("ms-appx:///Assets/Cat-Sec-2.JPG");
            //secondaryTile.WideLogo = new Uri("ms-appx:///Assets/mcnext.png");
            //bool isPinned = await secondaryTile.RequestCreateForSelectionAsync(
            //GetElementRect((FrameworkElement)sender),
            //Windows.UI.Popups.Placement.Above);


            string badgeXmlString = "<badge value='6'/>";
            Windows.Data.Xml.Dom.XmlDocument badgeDOM = new Windows.Data.Xml.Dom.XmlDocument();
            badgeDOM.LoadXml(badgeXmlString);
            BadgeNotification badge = new BadgeNotification(badgeDOM);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badge);
            //rootPage.NotifyUser("Badge notification sent", NotifyType.StatusMessage);
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
            wideTileTextAttributes[0].InnerText = "McNext 70-484";
            XmlElement tileImage = wideImageAndTextTileXml.GetElementsByTagName("image")[0]
                as XmlElement;
            tileImage.SetAttribute("src", "ms-appx:///Assets/mcnext.png");
            tileImage.SetAttribute("alt", "Awesome Cats");

            // Create and populate the square tile
            XmlDocument squareTileXml =
                       TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareText04);
            XmlNodeList squareTileTextAttributes = squareTileXml.GetElementsByTagName("text");
            squareTileTextAttributes[0].AppendChild(squareTileXml.CreateTextNode(
                             "test live Tile"));

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
