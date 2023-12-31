﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xama
{
    public partial class PressAndReleaseButtonPage : ContentPage
    {
        bool animationInProgress = false;
        Stopwatch stopwatch = new Stopwatch();

        public PressAndReleaseButtonPage()
        {
            InitializeComponent();
        }

        void OnButtonPressed(object sender, EventArgs args)
        {
            stopwatch.Start();
            animationInProgress = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(16), () =>
            {
                label.Rotation = 360 * (stopwatch.Elapsed.TotalSeconds % 1);

                return animationInProgress;
            });
        }

        void OnButtonReleased(object sender, EventArgs args)
        {
            animationInProgress = false;
            stopwatch.Stop();
        }
    }
}