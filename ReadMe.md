# Essentials of Developing Windows Store Apps Using C# #

----------

## A sample Windows stop app to show some examples of the things we need to review before passing 70-484 Exam. ##


**It does not give any answer to exam questions nor example questions**. Just give code examples based on the objective domain given by Microsoft at this address : [https://www.microsoft.com/learning/en-us/exam-70-484.aspx ](https://www.microsoft.com/learning/en-us/exam-70-484.aspx "70-484 Exam")


## Objective domain: ##

Design Windows Store apps (20-25%)

        Design the UI layout and structure

            Evaluate the conceptual design and decide how the UI will be composed; design for the inheritance and re-use of visual elements (e.g., styles, resources); design for accessibility; decide when custom controls are needed; use the Hub App template

        Design for separation of concerns (SOC)

            Plan the logical layers of your solution to meet app requirements; design loosely coupled layers; incorporate WinMD components

        Apply the MVVM pattern to your app design

            Design and implement the appropriate data model to support business entities; design your viewmodel to support your view based on your model; develop a view to meet data-binding requirements; create view models using INotifyPropertyChanged, ObservableCollection, and CollectionViewSource

        Design and implement Process Lifetime Management (PLM)

            Choose a state management strategy; handle the suspend event; prepare for app termination; handle the Resume event; handle the OnActivated event; check the ActivationKind and previous state

        Plan for an app deployment

            Plan a deployment based on Windows Store app certification requirements; prepare an app manifest (capabilities and declarations); sign an app; plan the requirements for an enterprise deployment

    Preparation resources

        Controls (XAML with C# or C++)
        Windows Store
        Windows App Certification Kit 3.0

Develop Windows Store apps (15-20%)

        Access and display contacts

            Call the ContactsPicker class; filter which contacts to display; display a set number of contacts; create and modify contact information; select specific contact data

        Design for charms and contracts

            Choose the appropriate charm based on app requirements; design your app in a charm- and contract-aware manner; configure app manifest for correct permissions

        Implement search

            Provide search suggestions using the SearchPane class and SearchBox control; search for and launch other apps; provide and constrain search within an app, including inside and outside of Search charm; provide search result previews; implement activation from within search; configure search contracts

        Implement Share in an app

            Use the DataTransferManager class to share data with other apps; accept sharing requests by implementing activation from within Share; limit the scope of sharing using the DataPackage object; implement in-app Share outside of Share charm; use web links and application links

        Manage app settings and preferences

            Choose which app features are accessed in AppSettings; add entry points for AppSettings in the Settings window; create settings flyouts; store and retrieve settings from the roaming app data store

        Integrate media features

            Support DDS images; implement video playback; implement XVP and DXVA; implement Text to Speech (TTS)

    Preparation resources

        UX/UI
        Security
        Multimedia

Create the user interface (20-25%)

        Create layout aware apps to handle windowing modes

            Respond to changes in orientation; adapt to new windowing modes by using the ViewManagement namespace; manage settings for an apps view

        Implement layout controls

            Implement the Grid control to structure your layout; set the number of rows/columns and size; enable zoom and scroll capabilities in layout controls; manage text flow and presentation

        Design and implement the app/nav bar

            Determine what to put on the app/nav bar based on app requirements; style and position app/nav bar items; design the placement of controls on the app/nav bar; handle app/nav bar events; design the placement of controls on the app/nav bar

        Design and implement data presentation

            Choose and implement data controls and properties to meet app requirements (e.g., ListView, GridView, FlipView, DatePicker, TimePicker, Hyperlink, PlaceholderText, menu flyouts, and CommandBar); create data templates to meet app requirements

        Create and manage XAML styles and templates

            Implement and extend styles and templates; implement gradients; modify styles based on event and property triggers; create shared resources and themes

    Preparation resources

        Controls (XAML with C# or C++)
        Tile Updates
        XAML AppBar control sample

Program the user interaction (20-25%)

        Create and manage tiles

            Create and update tiles and tile contents; create and update badges (TileUpdateManager class); respond to notification requests; choose an appropriate tile update schedule based on app requirements

        Notify users by using toast

            Enable an app for toast notifications; populate toast notifications with images and text using the ToastUpdateManager class; play sounds with toast notifications; respond to toast events; control toast duration; configure and use Azure Mobile Services for push notifications

        Manage input devices

            Capture Gesture library events; create custom gesture recognizers; listen to mouse events or touch gestures; manage Stylus input and inking

        Design and implement navigation in an app

            Handle navigation events, check navigation properties, and call navigation functions by using the Navigation framework; design navigation to meet app requirements; Semantic Zoom

    Preparation resources

        Tile and tile notification overview (Windows Store apps)
        Toast notification overview (Windows Store apps)
        Navigation model (using C#/VB/C++ and XAML)

Manage security and data (20-25%)

        Choose an appropriate data access strategy

            Choose the appropriate data access strategy (file based, web service, remote storage, including Microsoft Azure storage and Azure Mobile Services) based on requirements

        Retrieve data remotely

            Use HttpClient to retrieve web services; set the appropriate HTTP verb for REST; consume SOAP/WCF services; use WebSockets for bi-directional communication; handle the progress of data requests

        Implement data binding

            Choose and implement data-bound controls; bind collections to items controls; implement the IValueConverter interface; create and set dependency properties; validate user input; enable filtering, grouping, and sorting data in the user interface

        Manage Windows Authentication and Authorization

            Retrieve a user's roles or claims; store and retrieve credentials by using the PasswordVault class; implement the CredentialPicker class; verify credential existence by using credential locker; store account credentials in app settings

        Manage Web Authentication

            Use the Windows.Security.Authentication.Web namespace; set up oAuth2 for authentication; implement the CredentialPicker class; set up single sign-on (SSO); implement credential roaming; implement the WebAuthenticationBroker class; support proxy authentication for enterprises