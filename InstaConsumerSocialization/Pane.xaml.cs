using InstaConsumerSocialization.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace InstaConsumerSocialization
{
    /// <summary>
    /// The chrome layer of the app.
    /// </summary>
    public sealed partial class Pane : Page
    {
        private bool isPaddingAdded = false;

        private List<PaneItem> paneList = new List<PaneItem>(
            new[]
            {
                new PaneItem()
                {
                    Symbol = Symbol.Home,
                    Label = "Home",
                    DestPage = typeof(MainPage)
                },
                new PaneItem()
                {
                    Symbol = Symbol.Find,
                    Label = "Search",
                    DestPage = typeof(MainPage)
                },
                new PaneItem()
                {
                    Symbol = Symbol.Like,
                    Label = "Favorites",
                    DestPage = typeof(MainPage)
                },
                new PaneItem()
                {
                    Symbol = Symbol.Contact,
                    Label = "Profile",
                    DestPage = typeof(MainPage)
                },
                new PaneItem()
                {
                    Symbol = Symbol.Message,
                    Label = "Messages",
                    DestPage = typeof(MainPage)
                },
            });

        public static Pane Current = null;

        /// <summary>
        /// Initializes a new instance of the AppShell, sets the static 'Current' reference,
        /// adds callbacks for Back requests and changes in the SplitView's DisplayMode, and
        /// provide the nav menu list with the data to display.
        /// </summary>
        public Pane()
        {
            this.InitializeComponent();

            this.Loaded += (sender, args) =>
            {
                Current = this;

                this.CheckPaneTogglerSizeChanged();

                var titleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
                titleBar.IsVisibleChanged += TitleBar_IsVisibleChanged;
            };

            this.RootSplitView.RegisterPropertyChangedCallback(
                SplitView.DisplayModeProperty,
                (s, a) =>
                {
                    // Ensure that we update the reported size of the PaneToggler when the SplitView's
                    // DisplayMode changes.
                    this.CheckPaneTogglerSizeChanged();
                });

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;


            PaneList.ItemsSource = paneList;
        }

        public Frame AppFrame { get { return this.frame; } }

        /// <summary>
        /// Invoked when window title bar visibility changes, such as after loading or in tablet 
        /// Ensures correct padding at window top, between title bar and app 
        /// </summary
        /// <param name="sender"></param
        /// <param name="args"></param>
        private void TitleBar_IsVisibleChanged(Windows.ApplicationModel.Core.CoreApplicationViewTitleBar sender, object args)
        {
            if (!this.isPaddingAdded && sender.IsVisible)
            {
                //add extra padding between window title bar and app content
                double extraPadding = (Double)App.Current.Resources["DesktopWindowTopPadding"];
                this.isPaddingAdded = true;

                Thickness margin = PaneList.Margin;
                PaneList.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
                margin = AppFrame.Margin;
                AppFrame.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
                margin = PaneToggler.Margin;
                PaneToggler.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
            }
        }


        /// <summary>
        /// Default keyboard focus movement for any unhandled keyboarding
        /// </summary>
        /// <param name="sender"></param
        /// <param name="e"></param>
        private void Pane_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            FocusNavigationDirection direction = FocusNavigationDirection.None;
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.GamepadDPadLeft:
                case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
                case Windows.System.VirtualKey.NavigationLeft:
                    direction = FocusNavigationDirection.Left;
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.GamepadDPadRight:
                case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                case Windows.System.VirtualKey.NavigationRight:
                    direction = FocusNavigationDirection.Right;
                    break;

                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.GamepadDPadUp:
                case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
                case Windows.System.VirtualKey.NavigationUp:
                    direction = FocusNavigationDirection.Up;
                    break;

                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.GamepadDPadDown:
                case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
                case Windows.System.VirtualKey.NavigationDown:
                    direction = FocusNavigationDirection.Down;
                    break;
            }

            if (direction != FocusNavigationDirection.None)
            {
                var control = FocusManager.FindNextFocusableElement(direction) as Control;
                if (control != null)
                {
                    control.Focus(FocusState.Keyboard);
                    e.Handled = true;
                }
            }
        }

        #region BackRequested Handlers

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            bool handled = e.Handled;
            this.BackRequested(ref handled);
            e.Handled = handled;
        }

        private void BackRequested(ref bool handled)
        {
            // Get a hold of the current frame so that we can inspect the app back stack.

            if (this.AppFrame == null)
                return;

            // Check to see if this is the top-most page on the app back stack.
            if (this.AppFrame.CanGoBack && !handled)
            {
                // If not, set the event to handled and go back to the previous page in the app.
                handled = true;
                this.AppFrame.GoBack();
            }
        }

        #endregion

        #region Navigation

        /// <summary>
        /// Navigate to the Page for the selected <paramref name="listViewItem"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="listViewItem"></param>
        private void PaneList_ItemInvoked(object sender, ListViewItem listViewItem)
        {
            foreach (var i in paneList)
            {
                i.IsSelected = false;
            }

            var item = (PaneItem)((PaneListView)sender).ItemFromContainer(listViewItem);

            if (item != null)
            {
                item.IsSelected = true;
                if (item.DestPage != null &&
                    item.DestPage != this.AppFrame.CurrentSourcePageType)
                {
                    this.AppFrame.Navigate(item.DestPage, item.Arguments);
                }
            }
        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                var item = (from p in this.paneList where p.DestPage == e.SourcePageType select p).SingleOrDefault();
                if (item == null && this.AppFrame.BackStackDepth > 0)
                {
                    // In cases where a page drills into sub-pages then we'll highlight the most recent
                    // navigation menu item that appears in the BackStack
                    foreach (var entry in this.AppFrame.BackStack.Reverse())
                    {
                        item = (from p in this.paneList where p.DestPage == entry.SourcePageType select p).SingleOrDefault();
                        if (item != null)
                            break;
                    }
                }

                foreach (var i in paneList)
                {
                    i.IsSelected = false;
                }
                if (item != null)
                {
                    item.IsSelected = true;
                }

                var container = (ListViewItem)PaneList.ContainerFromItem(item);

                // While updating the selection state of the item prevent it from taking keyboard focus.  If a
                // user is invoking the back button via the keyboard causing the selected nav menu item to change
                // then focus will remain on the back button.
                if (container != null) container.IsTabStop = false;
                PaneList.SetSelectedItem(container);
                if (container != null) container.IsTabStop = true;
            }
        }

        #endregion

        public Rect PaneTogglerRect
        {
            get;
            private set;
        }

        /// <summary>
        /// An event to notify listeners when the hamburger button may occlude other content in the app.
        /// The custom "PageHeader" user control is using this.
        /// </summary>
        public event TypedEventHandler<Pane, Rect> PaneTogglerRectChanged;

        /// <summary>
        /// Public method to allow pages to open SplitView's pane.
        /// Used for custom app shortcuts like navigating left from page's left-most item
        /// </summary>
        public void OpenPane()
        {
            PaneToggler.IsChecked = true;
            PaneDivider.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hides divider when nav pane is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RootSplitView_PaneClosed(SplitView sender, object args)
        {
            PaneDivider.Visibility = Visibility.Collapsed;

            // Prevent focus from moving to elements when they're not visible on screen
            FeedbackButton.IsTabStop = false;
            SettingsButton.IsTabStop = false;
        }

        /// <summary>
        /// Callback when the SplitView's Pane is toggled closed.  When the Pane is not visible
        /// then the floating hamburger may be occluding other content in the app unless it is aware.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaneToggler_Unchecked(object sender, RoutedEventArgs e)
        {
            this.CheckPaneTogglerSizeChanged();
        }

        /// <summary>
        /// Callback when the SplitView's Pane is toggled closed.  When the Pane is not visible
        /// then the floating hamburger may be occluding other content in the app unless it is aware.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaneToggler_Checked(object sender, RoutedEventArgs e)
        {
            PaneDivider.Visibility = Visibility.Visible;
            this.CheckPaneTogglerSizeChanged();

            FeedbackButton.IsTabStop = true;
            SettingsButton.IsTabStop = true;
        }

        private void CheckPaneTogglerSizeChanged()
        {
            if (this.RootSplitView.DisplayMode == SplitViewDisplayMode.Inline ||
                this.RootSplitView.DisplayMode == SplitViewDisplayMode.Overlay)
            {
                var transform = this.PaneToggler.TransformToVisual(this);
                var rect = transform.TransformBounds(new Rect(0, 0, this.PaneToggler.ActualWidth, this.PaneToggler.ActualHeight));
                this.PaneTogglerRect = rect;
            }
            else
            {
                this.PaneTogglerRect = new Rect();
            }

            var handler = this.PaneTogglerRectChanged;
            if (handler != null)
            {
                // handler(this, this.PaneTogglerRect);
                handler.DynamicInvoke(this, this.PaneTogglerRect);
            }
        }


        /// <summary>
        /// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
        /// using the associated Label of each item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void PaneItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (!args.InRecycleQueue && args.Item != null && args.Item is PaneItem)
            {
                args.ItemContainer.SetValue(AutomationProperties.NameProperty, ((PaneItem)args.Item).Label);
            }
            else
            {
                args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
            }
        }
    }
}
