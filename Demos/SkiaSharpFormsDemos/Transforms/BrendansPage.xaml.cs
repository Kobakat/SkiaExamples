using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpFormsDemos.Transforms
{
    public partial class BrendansPage : ContentPage
    {
        public BrendansPage()
        {
            InitializeComponent();

            xScaleSlider.Value = 1;
            yScaleSlider.Value = 1;
        }

        void sliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (canvasView != null)
            {
                canvasView.InvalidateSurface();
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint textPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Blue,
                TextAlign = SKTextAlign.Center,
                TextSize = 100
            })
            {
                canvas.Scale((float)xScaleSlider.Value,
                             (float)yScaleSlider.Value);
                canvas.RotateDegrees((float)rotateSlider.Value, info.Width / 2, info.Height / 2);
                canvas.DrawText(Title, info.Width / 2, info.Height / 2, textPaint);
            }
        }
    }
}