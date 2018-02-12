using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        private double _stepValue;

        public FirstPage()
        {
            InitializeComponent();

            _stepValue = 0.1;

            // slider.ValueChanged += Slider_ValueChanged;

        }

        public void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / _stepValue);

            // slider.Value = newStep * _stepValue;

            // label.Text = slider.Value.ToString();
        }
    }
}
