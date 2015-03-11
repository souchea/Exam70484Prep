using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Exam484Prep.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Exam484Prep.Model;

namespace Exam484Prep.View
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class MainPage2 : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableCollection<Chapter> defaultViewModel = new ObservableCollection<Chapter>();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableCollection<Chapter> DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get
            {
                return this.navigationHelper;
            }
        }

        public MainPage2()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            DefaultViewModel.Add(new Chapter
            {
                Title = "1 Design Windows Store apps",
                Items = new List<Item>
                {

                }
            });

            DefaultViewModel.Add(new Chapter
            {
                Title = "2. Develop Windows Store apps",
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Contact",
                        Page = typeof(ContactPage)
                    },
                    new Item
                    {
                        Name = "Search",
                        Page = typeof(SearchPage)
                    }
                }
            });

            DefaultViewModel.Add(new Chapter
            {
                Title = "3. Create the user interface",
                Items = new List<Item>
                {

                }
            });

            DefaultViewModel.Add(new Chapter
            {
                Title = "4. Program the user interaction",
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Toast",
                        Page = typeof(ToastPage)
                    },
                    new Item
                    {
                        Name = "Tile",
                        Page = typeof(TilePage)
                    }
                }
            });

            DefaultViewModel.Add(new Chapter
            {
                Title = "5. Manage security and data",
                Items = new List<Item>
                {

                }
            });

        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void ItemGridView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = e.AddedItems[0] as Item;
            if (selected != null)
            {
                Frame.Navigate(selected.Page);
            }
        }
    }
}
