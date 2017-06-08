using System;
using FastttCameraLib;
using Foundation;
using Masonry;
using UIKit;

namespace FasttFiltersQs
{
    public partial class ViewController : UIViewController, IFastttCameraDelegate
    {
        ExampleFilter currentFilter;
        FastttFilterCamera camera;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            currentFilter = ExampleFilter.FilterWithType(FastttFilterType.Retro);
            camera = FastttFilterCamera.CameraWithFilterImage(currentFilter.FilterImage);
            camera.WeakDelegate = this;
            camera.MaxScaledDimension = 600f;

            this.FastttAddChildViewController(camera);
			camera.View.MakeConstraints(make =>
			{
				make.Center.EqualTo(View);
				make.Height.And.Width.LessThanOrEqualTo(View.Width()).With.PriorityHigh();
				make.Height.And.Width.LessThanOrEqualTo(View.Height()).With.PriorityHigh();
				make.Height.And.Width.EqualTo(View.Width()).With.PriorityLow();
				make.Height.And.Width.EqualTo(View.Height()).With.PriorityLow();
			});

			camera.CameraFlashMode = FastttCameraFlashMode.Off;
			camera.CameraTorchMode = FastttCameraTorchMode.Off;
			camera.CameraDevice = FastttCameraDevice.Front;

			var btnTakePicture = new UIButton(UIButtonType.System);
			btnTakePicture.SetTitle("Take Picture", UIControlState.Normal);
			btnTakePicture.TouchUpInside += delegate
			{
				camera.TakePicture();
			};
			View.AddSubview(btnTakePicture);

			btnTakePicture.MakeConstraints(maker =>
			{
				maker.CenterX.EqualTo(View.CenterX());
				maker.Bottom.EqualTo(View.Bottom()).Offset(-40f);
			});

			var btnSwitchCamera = new UIButton(UIButtonType.System);
			btnSwitchCamera.SetTitle("Switch Camera", UIControlState.Normal);
			btnSwitchCamera.TouchUpInside += delegate
			{
				switch (camera.CameraDevice)
				{
					case FastttCameraDevice.Front:
						camera.CameraDevice = FastttCameraDevice.Rear;
						break;
					default:
						camera.CameraDevice = FastttCameraDevice.Front;
						break;
				}
			};
			View.AddSubview(btnSwitchCamera);

			btnSwitchCamera.MakeConstraints(maker =>
			{
				maker.CenterY.EqualTo(btnTakePicture.CenterY());
				maker.Right.EqualTo(btnTakePicture.Left()).Offset(-16f);
			});

			var btnSwitchFlash = new UIButton(UIButtonType.System);
			btnSwitchFlash.SetTitle("Flash Off", UIControlState.Normal);
			btnSwitchFlash.TouchUpInside += delegate
			{
				if (camera.CameraDevice == FastttCameraDevice.Front) return;

				switch (camera.CameraFlashMode)
				{
					case FastttCameraFlashMode.Off:
						camera.CameraFlashMode = FastttCameraFlashMode.On;
						btnSwitchFlash.SetTitle("Flash On", UIControlState.Normal);
						break;
					case FastttCameraFlashMode.On:
						camera.CameraFlashMode = FastttCameraFlashMode.Auto;
						btnSwitchFlash.SetTitle("Flash Auto", UIControlState.Normal);
						break;
					default:
						camera.CameraFlashMode = FastttCameraFlashMode.Off;
						btnSwitchFlash.SetTitle("Flash Off", UIControlState.Normal);
						break;
				}
			};
			View.AddSubview(btnSwitchFlash);

			btnSwitchFlash.MakeConstraints(maker =>
			{
				maker.CenterY.EqualTo(btnTakePicture.CenterY());
				maker.Left.EqualTo(btnTakePicture.Right()).Offset(16f);
			});

			var btnSwitchTorch = new UIButton(UIButtonType.System);
			btnSwitchTorch.SetTitle("Torch Off", UIControlState.Normal);
			btnSwitchTorch.TouchUpInside += delegate
			{
				if (camera.CameraDevice == FastttCameraDevice.Front) return;

				switch (camera.CameraTorchMode)
				{
					case FastttCameraTorchMode.Off:
						camera.CameraTorchMode = FastttCameraTorchMode.On;
						btnSwitchFlash.SetTitle("Torch On", UIControlState.Normal);
						break;
					case FastttCameraTorchMode.On:
						camera.CameraTorchMode = FastttCameraTorchMode.Auto;
						btnSwitchFlash.SetTitle("Torch Auto", UIControlState.Normal);
						break;
					default:
						camera.CameraTorchMode = FastttCameraTorchMode.Off;
						btnSwitchFlash.SetTitle("Torch Off", UIControlState.Normal);
						break;
				}
			};
			View.AddSubview(btnSwitchTorch);

			btnSwitchTorch.MakeConstraints(maker =>
			{
				maker.CenterX.EqualTo(View.CenterX());
				maker.Top.EqualTo(View.Top()).Offset(40f);
			});

			var btnSwitchFilter = new UIButton(UIButtonType.System);
			btnSwitchFilter.SetTitle("Retro filter", UIControlState.Normal);
			btnSwitchFilter.TouchUpInside += delegate
			{
                currentFilter = currentFilter.NextFilter();
                btnSwitchFilter.SetTitle($"{currentFilter.FilterName} filter", UIControlState.Normal);
                camera.FilterImage = currentFilter.FilterImage;
			};
			View.AddSubview(btnSwitchFilter);

			btnSwitchFilter.MakeConstraints(maker =>
			{
				maker.CenterY.EqualTo(btnSwitchTorch.CenterY());
                maker.Left.EqualTo(btnSwitchTorch.Right()).Offset(16f);
			});
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }


    class ExampleFilter : NSObject
    {
        public FastttFilterType FilterType { get; set; }

        public string FilterName { get; set; }

        public UIImage FilterImage { get; set; }

        public static ExampleFilter FilterWithType(FastttFilterType filterType)
        {
            return new ExampleFilter
            {
                FilterType = filterType,
                FilterImage = ImageForFilterType(filterType),
                FilterName = NameForFilterType(filterType)
            };
        }

        public ExampleFilter NextFilter()
        {
            return FilterWithType(NextFilterType());
        }

        public FastttFilterType NextFilterType()
        {
            FastttFilterType xfilterType;

            switch (FilterType)
            {
                case FastttFilterType.None:
                    xfilterType = FastttFilterType.Retro;
                    break;
                case FastttFilterType.Retro:
                    xfilterType = FastttFilterType.HighContrast;
                    break;
                case FastttFilterType.HighContrast:
                    xfilterType = FastttFilterType.Sepia;
                    break;
                case FastttFilterType.Sepia:
                    xfilterType = FastttFilterType.BW;
                    break;
                default:
                    xfilterType = FastttFilterType.None;
                    break;
            }

            return xfilterType;
        }

        public static UIImage ImageForFilterType(FastttFilterType filterType)
        {
            string lookupImageName = null;

            switch (filterType)
            {
                case FastttFilterType.Retro:
                    lookupImageName = "RetroFilter";
                    break;
                case FastttFilterType.HighContrast:
                    lookupImageName = "HighContrastFilter";
                    break;
                case FastttFilterType.Sepia:
                    lookupImageName = "SepiaFilter";
                    break;
                case FastttFilterType.BW:
                    lookupImageName = "BWFilter";
                    break;
                default:
                    return null;
            }

            return UIImage.FromBundle(lookupImageName);
        }

        public static string NameForFilterType(FastttFilterType filterType)
        {
            string filterName;

            switch (filterType)
            {
                case FastttFilterType.Retro:
                    filterName = @"Retro";
                    break;
                case FastttFilterType.HighContrast:
                    filterName = @"High Contrast";
                    break;
                case FastttFilterType.Sepia:
                    filterName = @"Sepia";
                    break;
                case FastttFilterType.BW:
                    filterName = @"Black + White";
                    break;
                default:
                    filterName = @"None";
                    break;
            }

            return filterName;
        }
    }

    enum FastttFilterType
    {
        None,
        Retro,
        HighContrast,
        BW,
        Sepia
    }
}
