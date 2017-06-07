using System;
using FastttCameraLib;
using UIKit;
using Masonry;
using Foundation;

namespace FastttCameraQs
{
    public partial class ViewController : UIViewController, IFastttCameraDelegate
    {
        FastttCamera camera;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            camera = new FastttCamera();
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
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        // @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishCapturingImageData:(NSData *)rawJPEGData;
        [Export("cameraController:didFinishCapturingImageData:")]
        void DidFinishCapturingImageData(IFastttCameraInterface cameraController, NSData rawJPEGData)
        {
            System.Diagnostics.Debug.WriteLine("cameraController:didFinishCapturingImageData:");
        }

        // @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishCapturingImage:(FastttCapturedImage *)capturedImage;
        [Export("cameraController:didFinishCapturingImage:")]
        void DidFinishCapturingImage(IFastttCameraInterface cameraController, FastttCapturedImage capturedImage)
        {
            System.Diagnostics.Debug.WriteLine("cameraController:didFinishCapturingImage:");
        }

        // @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishScalingCapturedImage:(FastttCapturedImage *)capturedImage;
        [Export("cameraController:didFinishScalingCapturedImage:")]
        void DidFinishScalingCapturedImage(IFastttCameraInterface cameraController, FastttCapturedImage capturedImage)
        {
            System.Diagnostics.Debug.WriteLine("cameraController:didFinishScalingCapturedImage:");
        }

        // @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishNormalizingCapturedImage:(FastttCapturedImage *)capturedImage;
        [Export("cameraController:didFinishNormalizingCapturedImage:")]
        void DidFinishNormalizingCapturedImage(IFastttCameraInterface cameraController, FastttCapturedImage capturedImage)
        {
            System.Diagnostics.Debug.WriteLine("cameraController:DidFinishNormalizingCapturedImage:");
        }

        // @optional -(void)userDeniedCameraPermissionsForCameraController:(id<FastttCameraInterface>)cameraController;
        [Export("userDeniedCameraPermissionsForCameraController:")]
        void UserDeniedCameraPermissionsForCameraController(IFastttCameraInterface cameraController)
        {
            System.Diagnostics.Debug.WriteLine("cameraController:didFinishCapturingImageData:");
        }
    }
}
