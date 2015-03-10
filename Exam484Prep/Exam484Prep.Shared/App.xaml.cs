using Exam484Prep.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Exam484Prep.Common;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace Exam484Prep
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
#if WINDOWS_PHONE_APP
        private TransitionCollection transitions;
#endif

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            base.OnWindowCreated(args);
	        SettingsPane.GetForCurrentView().CommandsRequested += OnCommandRequested;
            SearchPane.GetForCurrentView().QuerySubmitted += OnQuerySubmitted;
            SearchPane.GetForCurrentView().QueryChanged += OnQueryChanged;
        }

        private void OnQueryChanged(SearchPane sender, SearchPaneQueryChangedEventArgs args)
        {

        }

        private void OnQuerySubmitted(SearchPane sender, SearchPaneQuerySubmittedEventArgs args)
        {
            var previousContent = Window.Current.Content;
            var frame = previousContent as Frame;

            if (frame != null)
            {
                frame.Navigate(typeof(SearchResultsPage), args.QueryText);

                Window.Current.Content = frame;
                Window.Current.Activate();
            }
        }

        void OnCommandRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs e)
	    {
		    e.Request.ApplicationCommands.Add(new SettingsCommand(1, "Test", OnTestCommand));
	    }

	    void OnTestCommand(IUICommand command)
	    {
		    
	    }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                    try
                    {
	                    await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        
                        throw;
                    }
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

	        SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

            if (rootFrame.Content == null)
            {
#if WINDOWS_PHONE_APP
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;
#endif

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage2), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

#if WINDOWS_PHONE_APP
        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }
#endif

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

	        await SuspensionManager.SaveAsync();

            deferral.Complete();
        }
    }
}