using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace InstaConsumerSocialization.Controls
{
    public class PaneListView : ListView
    {
        private SplitView splitViewHost;

        public PaneListView()
        {
            this.SelectionMode = ListViewSelectionMode.Single;
            this.SingleSelectionFollowsFocus = false;
            this.IsItemClickEnabled = true;
            this.ItemClick += ItemClickedHandler;

            this.Loaded += (s, a) =>
            {
                var parent = VisualTreeHelper.GetParent(this);

                while (parent != null && !(parent is SplitView))
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }

                if (parent != null)
                {
                    this.splitViewHost = parent as SplitView;

                    splitViewHost.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, (sender, args) =>
                    {
                        this.OnPaneToggled();
                    });

                    splitViewHost.RegisterPropertyChangedCallback(SplitView.DisplayModeProperty, (sender, args) =>
                    {
                        this.OnPaneToggled();
                    });

                    this.OnPaneToggled();
                }
            };
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // rm entrance animation on the item containers
            for (int i = 0; i < this.ItemContainerTransitions.Count; i++)
            {
                if (this.ItemContainerTransitions[i] is EntranceThemeTransition)
                {
                    this.ItemContainerTransitions.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Mark the <paramref name="item"/> as selected and ensures everything else is not.
        /// If the <paramref name="item"/> is null then everything is unselected.
        /// </summary>
        /// <param name="item"></param>
        public void SetSelectedItem(ListViewItem item)
        {
            int index = -1;
            if (item != null)
            {
                index = this.IndexFromContainer(item);
            }
            for (int i = 0; i < this.Items.Count; i++)
            {
                var lvi = (ListViewItem)this.ContainerFromIndex(i);
                if (i != index)
                {
                    lvi.IsSelected = false;
                }
                else if (i == index)
                {
                    lvi.IsSelected = true;
                }
            }
        }

        /// <summary>
        /// Occurs when an item has been selected
        /// </summary>
        public event EventHandler<ListViewItem> ItemInvoked;

        /// <summary>
        /// Custom keyboarding logic to enable movement via the arrow keys without triggering selection 
        /// until a 'Space' or 'Enter' key is pressed. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            var focusedItem = FocusManager.GetFocusedElement();
            switch (e.Key)
            {
                case VirtualKey.Up:
                    this.TryMoveFocus(FocusNavigationDirection.Up);
                    e.Handled = true;
                    break;
                case VirtualKey.Down:
                    this.TryMoveFocus(FocusNavigationDirection.Down);
                    e.Handled = true;
                    break;
                case VirtualKey.Space:
                case VirtualKey.Enter:
                    this.InvokeItem(focusedItem);
                    e.Handled = true;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        /// <summary>
        /// This method is a work-around until the bug in FocusManager.TryMoveFocus is fixed.
        /// </summary>
        /// <param name="direction"></param>
        private void TryMoveFocus(FocusNavigationDirection direction)
        {
            if (direction == FocusNavigationDirection.Next || direction == FocusNavigationDirection.Previous)
            {
                FocusManager.TryMoveFocus(direction);
            }
            else
            {
                var control = FocusManager.FindNextFocusableElement(direction) as Control;
                if (control != null)
                {
                    control.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                }
            }
        }

        private void ItemClickedHandler(object sender, ItemClickEventArgs e)
        {
            var item = this.ContainerFromItem(e.ClickedItem);
            this.InvokeItem(item);
        }

        private void InvokeItem(object item)
        {
            this.SetSelectedItem(item as ListViewItem);
            this.ItemInvoked?.Invoke(this, item as ListViewItem);
            if (this.splitViewHost.IsPaneOpen && (
                this.splitViewHost.DisplayMode == SplitViewDisplayMode.CompactOverlay ||
                this.splitViewHost.DisplayMode == SplitViewDisplayMode.Overlay))
            {
                this.splitViewHost.IsPaneOpen = false;
            }

            if (item is ListViewItem)
            {
                ((ListViewItem)item).Focus(FocusState.Programmatic);
            }
        }

        /// <summary>
        /// Re-size the ListView's Panel when the SplitView is compact so the items
        /// will fit within the visible space and correctly display a keyboard focus rect.
        /// </summary>
        private void OnPaneToggled()
        {
            if (this.splitViewHost.IsPaneOpen)
            {
                this.ItemsPanelRoot.ClearValue(FrameworkElement.WidthProperty);
                this.ItemsPanelRoot.ClearValue(FrameworkElement.HorizontalAlignmentProperty);
            }
            else if (this.splitViewHost.DisplayMode == SplitViewDisplayMode.CompactInline ||
                this.splitViewHost.DisplayMode == SplitViewDisplayMode.CompactOverlay)
            {
                this.ItemsPanelRoot.SetValue(FrameworkElement.WidthProperty, this.splitViewHost.CompactPaneLength);
                this.ItemsPanelRoot.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            }
        }
    }
}
