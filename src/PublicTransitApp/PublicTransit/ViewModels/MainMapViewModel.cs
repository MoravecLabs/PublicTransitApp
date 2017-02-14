// <copyright file="MainMapViewModel.cs" company="Moravec Labs, LLC">
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

namespace PublicTransit
{
    using System;
    using Esri.ArcGISRuntime.Mapping;
    using MoravecLabs.Atom;
    using MoravecLabs.Infrastructure;

    /// <summary>
    /// Main map view model.
    /// </summary>
    public class MainMapViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PublicTransit.MainMapViewModel"/> class.
        /// </summary>
        public MainMapViewModel()
        {
            this.Map = new Atom<Map>(null, this, "Map");
        }

        /// <summary>
        /// Gets the map.
        /// </summary>
        /// <value>The map.</value>
        public Atom<Map> Map { get; private set; }

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public void Initialize()
        {
            this.Map.Value = MapUtilities.CreateStandardMap();
        }
    }
}
