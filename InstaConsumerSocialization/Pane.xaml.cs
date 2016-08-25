using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace InstaConsumerSocialization
{
    public sealed partial class Pane
    {
        private void Pane_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {

        }

        private void PaneToggler_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void PaneToggler_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void RootSplitView_PaneClosed(Windows.UI.Xaml.Controls.SplitView sender, object args)
        {

        }

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

        private void PaneList_ItemInvoked(object sender, ListViewItem e)
        {

        }

        private void Frame_Navigating(object sender, Windows.UI.Xaml.Navigation.NavigatingCancelEventArgs e)
        {

        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs args)
        {

        }
    }
}
