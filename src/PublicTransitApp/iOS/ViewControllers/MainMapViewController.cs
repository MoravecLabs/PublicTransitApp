// <copyright file="MainMapViewController.cs" company="Moravec Labs, LLC">
//     MIT License
//
//     Copyright (c) Moravec Labs, LLC.
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </copyright>

namespace PublicTransit.iOS
{
    using System;
    using Foundation;
    using MoravecLabs.Extensions;
    using UIKit;

    /// <summary>
    /// Main map view controller.
    /// </summary>
    public partial class MainMapViewController : UIViewController
    {
        /// <summary>
        /// The view model.
        /// </summary>
        private MainMapViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PublicTransit.iOS.MainMapViewController"/> class.
        /// </summary>
        /// <param name="handle">Handle from iOS.</param>
        public MainMapViewController(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// View did load implementation
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Configure the button
            this.LocateMeButton.Type = 2;
            this.LocateMeButton.RippleColor = UIColor.Clear.FromHex(0x2962ff);
            this.LocateMeButton.BackgroundColor = UIColor.Clear.FromHex(0x1976d2);
            this.LocateMeButton.TouchUpInside += this.LocateMeButton_TouchUpInside;

            // Create any objects and binding events.
            this.viewModel = new MainMapViewModel();
            this.viewModel.Map.SubscribePropertyChanged((oldVal, newVal) =>
            {
                this.MapView.Map = newVal;
            });

            // Initialize objects.
            this.viewModel.Initialize();
        }

        /// <summary>
        /// Event for the LocateMe button on the map.
        /// </summary>
        /// <param name="sender">Event Sender.</param>
        /// <param name="e">Event Arguments.</param>
        private void LocateMeButton_TouchUpInside(object sender, EventArgs e)
        {
            if (!this.MapView.LocationDisplay.IsEnabled)
            {
                this.MapView.LocationDisplay.AutoPanMode = Esri.ArcGISRuntime.UI.LocationDisplayAutoPanMode.Recenter;
                this.MapView.LocationDisplay.IsEnabled = true;
            }
            else
            {
                // If it is already enabled, resetting the AutoPanMode causes it to zoom to the current location
                // This way if the user has panned the map, it will always go back to the user's location
                // When the button is pressed.
                this.MapView.LocationDisplay.AutoPanMode = Esri.ArcGISRuntime.UI.LocationDisplayAutoPanMode.Recenter;
            }
        }
    }
}