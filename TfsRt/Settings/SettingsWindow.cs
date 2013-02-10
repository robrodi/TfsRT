namespace TfsRt.Settings
{
    using System;
    using Windows.Foundation;
    using Windows.UI.ApplicationSettings;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;

    /// <summary>
    /// A setting window wrapper.
    /// </summary>
    public class SettingsWindow
    {
        Popup _settingsPopup;
        
        /// <summary>
        /// Creates a new instance of <see cref="SettingsWindow"/>
        /// </summary>
        /// <param name="applicationBoundingRectangle">The bounding rectangle of the parent application.</param>
        /// <param name="settingsElement">The element that will be wrapped by the <see cref="SettingsWindow"/>.</param>
        /// <param name="settingWidth">The width of the settings pane.  Defaults to 346px.</param>
        private SettingsWindow(Rect applicationBoundingRectangle, FrameworkElement settingsElement, double settingWidth = 346)
        {
            _settingsPopup = new Popup();
            _settingsPopup.Closed += (s, e) => Window.Current.Activated -= OnWindowActivated;
            Window.Current.Activated += OnWindowActivated;
            _settingsPopup.IsLightDismissEnabled = true;
            _settingsPopup.Width = settingWidth;
            _settingsPopup.Height = applicationBoundingRectangle.Height;

            settingsElement.Width = settingWidth;
            settingsElement.Height = applicationBoundingRectangle.Height;

            _settingsPopup.Child = settingsElement;
            _settingsPopup.SetValue(Canvas.LeftProperty, applicationBoundingRectangle.Width - settingWidth);
            _settingsPopup.SetValue(Canvas.TopProperty, 0);
            _settingsPopup.IsOpen = true;
        }

        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                _settingsPopup.IsOpen = false;
            }
        }

        /// <summary>
        /// Creates a <see cref="SettingsCommand"/> with the given <paramref name="commandId"/>, <paramref name="label"/> to contain <paramref name="child"/> within a <see cref="SettingsWindow"/>.
        /// </summary>
        /// <param name="commandId">The command Id.  Not entirely sure what this does.  Passed through to <see cref="SettingsCommand.Id"/>.</param>
        /// <param name="label">The name displayed in the Win8 settings bit on the right.</param>
        /// <param name="child">The actual UI Element enclosed by the <see cref="SettingsWindow"/>.</param>
        /// <returns>The settings command.</returns>
        public static SettingsCommand Create(string commandId, string label, FrameworkElement child) 
        {
            return new SettingsCommand(commandId, label, x => new SettingsWindow(Window.Current.Bounds, child));
        }

        internal static void GoBack(UserControl control)
        {
            if (control == null) throw new ArgumentNullException("control");

            if (control.Parent.GetType() == typeof(Popup))
            {
                ((Popup)control.Parent).IsOpen = false;
            }

            SettingsPane.Show();
        }
    }
}
