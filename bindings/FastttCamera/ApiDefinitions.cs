using System;
using AVFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FastttCameraLib
{
	// @interface FastttCamera (AVCaptureDevice)
	[Category]
	[BaseType (typeof(AVCaptureDevice))]
	interface AVCaptureDevice_FastttCamera
	{
		// +(BOOL)isPointFocusAvailableForCameraDevice:(FastttCameraDevice)cameraDevice;
		[Static]
		[Export ("isPointFocusAvailableForCameraDevice:")]
		bool IsPointFocusAvailableForCameraDevice (FastttCameraDevice cameraDevice);

		// -(CGFloat)videoMaxZoomFactor;
		[Export ("videoMaxZoomFactor")]
		[Verify (MethodToProperty)]
		nfloat VideoMaxZoomFactor { get; }

		// -(BOOL)zoomToScale:(CGFloat)zoomScale;
		[Export ("zoomToScale:")]
		bool ZoomToScale (nfloat zoomScale);

		// +(BOOL)isFlashAvailableForCameraDevice:(FastttCameraDevice)cameraDevice;
		[Static]
		[Export ("isFlashAvailableForCameraDevice:")]
		bool IsFlashAvailableForCameraDevice (FastttCameraDevice cameraDevice);

		// +(BOOL)isTorchAvailableForCameraDevice:(FastttCameraDevice)cameraDevice;
		[Static]
		[Export ("isTorchAvailableForCameraDevice:")]
		bool IsTorchAvailableForCameraDevice (FastttCameraDevice cameraDevice);

		// +(AVCaptureDevice *)cameraDevice:(FastttCameraDevice)cameraDevice;
		[Static]
		[Export ("cameraDevice:")]
		AVCaptureDevice CameraDevice (FastttCameraDevice cameraDevice);

		// +(AVCaptureDevicePosition)positionForCameraDevice:(FastttCameraDevice)cameraDevice;
		[Static]
		[Export ("positionForCameraDevice:")]
		AVCaptureDevicePosition PositionForCameraDevice (FastttCameraDevice cameraDevice);

		// -(BOOL)focusAtPointOfInterest:(CGPoint)pointOfInterest;
		[Export ("focusAtPointOfInterest:")]
		bool FocusAtPointOfInterest (CGPoint pointOfInterest);

		// -(BOOL)setCameraFlashMode:(FastttCameraFlashMode)cameraFlashMode;
		[Export ("setCameraFlashMode:")]
		bool SetCameraFlashMode (FastttCameraFlashMode cameraFlashMode);

		// -(BOOL)setCameraTorchMode:(FastttCameraTorchMode)cameraTorchMode;
		[Export ("setCameraTorchMode:")]
		bool SetCameraTorchMode (FastttCameraTorchMode cameraTorchMode);
	}

	// @interface FastttCapturedImage : NSObject
	[BaseType (typeof(NSObject))]
	interface FastttCapturedImage
	{
		// +(instancetype)fastttCapturedFullImage:(UIImage *)fullImage;
		[Static]
		[Export ("fastttCapturedFullImage:")]
		FastttCapturedImage FastttCapturedFullImage (UIImage fullImage);

		// @property (nonatomic, strong) id userInfo;
		[Export ("userInfo", ArgumentSemantic.Strong)]
		NSObject UserInfo { get; set; }

		// @property (nonatomic, strong) UIImage * fullImage;
		[Export ("fullImage", ArgumentSemantic.Strong)]
		UIImage FullImage { get; set; }

		// @property (nonatomic, strong) UIImage * scaledImage;
		[Export ("scaledImage", ArgumentSemantic.Strong)]
		UIImage ScaledImage { get; set; }

		// @property (nonatomic, strong) UIImage * rotatedPreviewImage;
		[Export ("rotatedPreviewImage", ArgumentSemantic.Strong)]
		UIImage RotatedPreviewImage { get; set; }

		// @property (assign, nonatomic) BOOL isNormalized;
		[Export ("isNormalized")]
		bool IsNormalized { get; set; }

		// @property (assign, nonatomic) UIImageOrientation capturedImageOrientation;
		[Export ("capturedImageOrientation", ArgumentSemantic.Assign)]
		UIImageOrientation CapturedImageOrientation { get; set; }
	}

	// @interface FastttCamera (UIViewController)
	[Category]
	[BaseType (typeof(UIViewController))]
	interface UIViewController_FastttCamera
	{
		// -(void)fastttAddChildViewController:(UIViewController *)childViewController;
		[Export ("fastttAddChildViewController:")]
		void FastttAddChildViewController (UIViewController childViewController);

		// -(void)fastttAddChildViewController:(UIViewController *)childViewController belowSubview:(UIView *)siblingSubview;
		[Export ("fastttAddChildViewController:belowSubview:")]
		void FastttAddChildViewController (UIViewController childViewController, UIView siblingSubview);

		// -(void)fastttRemoveChildViewController:(UIViewController *)childViewController;
		[Export ("fastttRemoveChildViewController:")]
		void FastttRemoveChildViewController (UIViewController childViewController);
	}

	// @protocol FastttCameraInterface <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface FastttCameraInterface
	{
		[Wrap ("WeakDelegate"), Abstract]
		FastttCameraDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<FastttCameraDelegate> delegate;
		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required @property (assign, nonatomic) BOOL handlesTapFocus;
		[Abstract]
		[Export ("handlesTapFocus")]
		bool HandlesTapFocus { get; set; }

		// @required @property (assign, nonatomic) BOOL showsFocusView;
		[Abstract]
		[Export ("showsFocusView")]
		bool ShowsFocusView { get; set; }

		// @required @property (assign, nonatomic) BOOL handlesZoom;
		[Abstract]
		[Export ("handlesZoom")]
		bool HandlesZoom { get; set; }

		// @required @property (assign, nonatomic) BOOL showsZoomView;
		[Abstract]
		[Export ("showsZoomView")]
		bool ShowsZoomView { get; set; }

		// @required @property (assign, nonatomic) CGFloat maxZoomFactor;
		[Abstract]
		[Export ("maxZoomFactor")]
		nfloat MaxZoomFactor { get; set; }

		[Wrap ("WeakGestureDelegate"), Abstract]
		UIGestureRecognizerDelegate GestureDelegate { get; set; }

		// @required @property (nonatomic, weak) id<UIGestureRecognizerDelegate> gestureDelegate;
		[Abstract]
		[NullAllowed, Export ("gestureDelegate", ArgumentSemantic.Weak)]
		NSObject WeakGestureDelegate { get; set; }

		// @required @property (nonatomic, strong) UIView * gestureView;
		[Abstract]
		[Export ("gestureView", ArgumentSemantic.Strong)]
		UIView GestureView { get; set; }

		// @required @property (assign, nonatomic) BOOL cropsImageToVisibleAspectRatio;
		[Abstract]
		[Export ("cropsImageToVisibleAspectRatio")]
		bool CropsImageToVisibleAspectRatio { get; set; }

		// @required @property (assign, nonatomic) BOOL scalesImage;
		[Abstract]
		[Export ("scalesImage")]
		bool ScalesImage { get; set; }

		// @required @property (assign, nonatomic) CGFloat maxScaledDimension;
		[Abstract]
		[Export ("maxScaledDimension")]
		nfloat MaxScaledDimension { get; set; }

		// @required @property (assign, nonatomic) BOOL normalizesImageOrientations;
		[Abstract]
		[Export ("normalizesImageOrientations")]
		bool NormalizesImageOrientations { get; set; }

		// @required @property (assign, nonatomic) BOOL returnsRotatedPreview;
		[Abstract]
		[Export ("returnsRotatedPreview")]
		bool ReturnsRotatedPreview { get; set; }

		// @required @property (assign, nonatomic) BOOL interfaceRotatesWithOrientation;
		[Abstract]
		[Export ("interfaceRotatesWithOrientation")]
		bool InterfaceRotatesWithOrientation { get; set; }

		// @required @property (assign, nonatomic) UIDeviceOrientation fixedInterfaceOrientation;
		[Abstract]
		[Export ("fixedInterfaceOrientation", ArgumentSemantic.Assign)]
		UIDeviceOrientation FixedInterfaceOrientation { get; set; }

		// @required @property (assign, nonatomic) FastttCameraDevice cameraDevice;
		[Abstract]
		[Export ("cameraDevice", ArgumentSemantic.Assign)]
		FastttCameraDevice CameraDevice { get; set; }

		// @required @property (assign, nonatomic) FastttCameraFlashMode cameraFlashMode;
		[Abstract]
		[Export ("cameraFlashMode", ArgumentSemantic.Assign)]
		FastttCameraFlashMode CameraFlashMode { get; set; }

		// @required @property (assign, nonatomic) FastttCameraTorchMode cameraTorchMode;
		[Abstract]
		[Export ("cameraTorchMode", ArgumentSemantic.Assign)]
		FastttCameraTorchMode CameraTorchMode { get; set; }

		// @required -(BOOL)isFlashAvailableForCurrentDevice;
		[Abstract]
		[Export ("isFlashAvailableForCurrentDevice")]
		[Verify (MethodToProperty)]
		bool IsFlashAvailableForCurrentDevice { get; }

		// @required +(BOOL)isFlashAvailableForCameraDevice:(FastttCameraDevice)cameraDevice;
		[Static, Abstract]
		[Export ("isFlashAvailableForCameraDevice:")]
		bool IsFlashAvailableForCameraDevice (FastttCameraDevice cameraDevice);

		// @required -(BOOL)isTorchAvailableForCurrentDevice;
		[Abstract]
		[Export ("isTorchAvailableForCurrentDevice")]
		[Verify (MethodToProperty)]
		bool IsTorchAvailableForCurrentDevice { get; }

		// @required +(BOOL)isTorchAvailableForCameraDevice:(FastttCameraDevice)cameraDevice;
		[Static, Abstract]
		[Export ("isTorchAvailableForCameraDevice:")]
		bool IsTorchAvailableForCameraDevice (FastttCameraDevice cameraDevice);

		// @required +(BOOL)isPointFocusAvailableForCameraDevice:(FastttCameraDevice)cameraDevice;
		[Static, Abstract]
		[Export ("isPointFocusAvailableForCameraDevice:")]
		bool IsPointFocusAvailableForCameraDevice (FastttCameraDevice cameraDevice);

		// @required +(BOOL)isCameraDeviceAvailable:(FastttCameraDevice)cameraDevice;
		[Static, Abstract]
		[Export ("isCameraDeviceAvailable:")]
		bool IsCameraDeviceAvailable (FastttCameraDevice cameraDevice);

		// @required -(BOOL)focusAtPoint:(CGPoint)touchPoint;
		[Abstract]
		[Export ("focusAtPoint:")]
		bool FocusAtPoint (CGPoint touchPoint);

		// @required -(BOOL)zoomToScale:(CGFloat)scale;
		[Abstract]
		[Export ("zoomToScale:")]
		bool ZoomToScale (nfloat scale);

		// @required -(BOOL)isReadyToCapturePhoto;
		[Abstract]
		[Export ("isReadyToCapturePhoto")]
		[Verify (MethodToProperty)]
		bool IsReadyToCapturePhoto { get; }

		// @required -(void)takePicture;
		[Abstract]
		[Export ("takePicture")]
		void TakePicture ();

		// @required -(void)processImage:(UIImage *)image withMaxDimension:(CGFloat)maxDimension;
		[Abstract]
		[Export ("processImage:withMaxDimension:")]
		void ProcessImage (UIImage image, nfloat maxDimension);

		// @required -(void)processImage:(UIImage *)image withCropRect:(CGRect)cropRect;
		[Abstract]
		[Export ("processImage:withCropRect:")]
		void ProcessImage (UIImage image, CGRect cropRect);

		// @required -(void)processImage:(UIImage *)image withCropRect:(CGRect)cropRect maxDimension:(CGFloat)maxDimension;
		[Abstract]
		[Export ("processImage:withCropRect:maxDimension:")]
		void ProcessImage (UIImage image, CGRect cropRect, nfloat maxDimension);

		// @required -(void)cancelImageProcessing;
		[Abstract]
		[Export ("cancelImageProcessing")]
		void CancelImageProcessing ();

		// @required -(void)startRunning;
		[Abstract]
		[Export ("startRunning")]
		void StartRunning ();

		// @required -(void)stopRunning;
		[Abstract]
		[Export ("stopRunning")]
		void StopRunning ();
	}

	// @protocol FastttCameraDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface FastttCameraDelegate
	{
		// @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishCapturingImageData:(NSData *)rawJPEGData;
		[Export ("cameraController:didFinishCapturingImageData:")]
		void CameraController (FastttCameraInterface cameraController, NSData rawJPEGData);

		// @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishCapturingImage:(FastttCapturedImage *)capturedImage;
		[Export ("cameraController:didFinishCapturingImage:")]
		void CameraController (FastttCameraInterface cameraController, FastttCapturedImage capturedImage);

		// @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishScalingCapturedImage:(FastttCapturedImage *)capturedImage;
		[Export ("cameraController:didFinishScalingCapturedImage:")]
		void CameraController (FastttCameraInterface cameraController, FastttCapturedImage capturedImage);

		// @optional -(void)cameraController:(id<FastttCameraInterface>)cameraController didFinishNormalizingCapturedImage:(FastttCapturedImage *)capturedImage;
		[Export ("cameraController:didFinishNormalizingCapturedImage:")]
		void CameraController (FastttCameraInterface cameraController, FastttCapturedImage capturedImage);

		// @optional -(void)userDeniedCameraPermissionsForCameraController:(id<FastttCameraInterface>)cameraController;
		[Export ("userDeniedCameraPermissionsForCameraController:")]
		void UserDeniedCameraPermissionsForCameraController (FastttCameraInterface cameraController);
	}

	// @interface FastttCamera : UIViewController <FastttCameraInterface>
	[BaseType (typeof(UIViewController))]
	interface FastttCamera : IFastttCameraInterface
	{
	}

	// @interface Process (FastttCapturedImage)
	[Category]
	[BaseType (typeof(FastttCapturedImage))]
	interface FastttCapturedImage_Process
	{
		// -(void)cropToRect:(CGRect)cropRect returnsPreview:(BOOL)returnsPreview needsPreviewRotation:(BOOL)needsPreviewRotation withPreviewOrientation:(UIDeviceOrientation)previewOrientation withCallback:(void (^)(FastttCapturedImage *))callback;
		[Export ("cropToRect:returnsPreview:needsPreviewRotation:withPreviewOrientation:withCallback:")]
		void CropToRect (CGRect cropRect, bool returnsPreview, bool needsPreviewRotation, UIDeviceOrientation previewOrientation, Action<FastttCapturedImage> callback);

		// -(void)scaleToMaxDimension:(CGFloat)maxDimension withCallback:(void (^)(FastttCapturedImage *))callback;
		[Export ("scaleToMaxDimension:withCallback:")]
		void ScaleToMaxDimension (nfloat maxDimension, Action<FastttCapturedImage> callback);

		// -(void)scaleToSize:(CGSize)size withCallback:(void (^)(FastttCapturedImage *))callback;
		[Export ("scaleToSize:withCallback:")]
		void ScaleToSize (CGSize size, Action<FastttCapturedImage> callback);

		// -(void)normalizeWithCallback:(void (^)(FastttCapturedImage *))callback;
		[Export ("normalizeWithCallback:")]
		void NormalizeWithCallback (Action<FastttCapturedImage> callback);
	}

	// @interface FastttFocus : NSObject
	[BaseType (typeof(NSObject))]
	interface FastttFocus
	{
		[Wrap ("WeakDelegate")]
		FastttFocusDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<FastttFocusDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL detectsTaps;
		[Export ("detectsTaps")]
		bool DetectsTaps { get; set; }

		[Wrap ("WeakGestureDelegate")]
		UIGestureRecognizerDelegate GestureDelegate { get; set; }

		// @property (nonatomic, weak) id<UIGestureRecognizerDelegate> gestureDelegate;
		[NullAllowed, Export ("gestureDelegate", ArgumentSemantic.Weak)]
		NSObject WeakGestureDelegate { get; set; }

		// +(instancetype)fastttFocusWithView:(UIView *)view gestureDelegate:(id<UIGestureRecognizerDelegate>)gestureDelegate;
		[Static]
		[Export ("fastttFocusWithView:gestureDelegate:")]
		FastttFocus FastttFocusWithView (UIView view, UIGestureRecognizerDelegate gestureDelegate);

		// -(void)showFocusViewAtPoint:(CGPoint)location;
		[Export ("showFocusViewAtPoint:")]
		void ShowFocusViewAtPoint (CGPoint location);
	}

	// @protocol FastttFocusDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface FastttFocusDelegate
	{
		// @required -(BOOL)handleTapFocusAtPoint:(CGPoint)touchPoint;
		[Abstract]
		[Export ("handleTapFocusAtPoint:")]
		bool HandleTapFocusAtPoint (CGPoint touchPoint);
	}

	// @interface FastttZoom : NSObject
	[BaseType (typeof(NSObject))]
	interface FastttZoom
	{
		[Wrap ("WeakDelegate")]
		FastttZoomDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<FastttZoomDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL detectsPinch;
		[Export ("detectsPinch")]
		bool DetectsPinch { get; set; }

		// @property (assign, nonatomic) CGFloat maxScale;
		[Export ("maxScale")]
		nfloat MaxScale { get; set; }

		[Wrap ("WeakGestureDelegate")]
		UIGestureRecognizerDelegate GestureDelegate { get; set; }

		// @property (nonatomic, weak) id<UIGestureRecognizerDelegate> gestureDelegate;
		[NullAllowed, Export ("gestureDelegate", ArgumentSemantic.Weak)]
		NSObject WeakGestureDelegate { get; set; }

		// +(instancetype)fastttZoomWithView:(UIView *)view gestureDelegate:(id<UIGestureRecognizerDelegate>)gestureDelegate;
		[Static]
		[Export ("fastttZoomWithView:gestureDelegate:")]
		FastttZoom FastttZoomWithView (UIView view, UIGestureRecognizerDelegate gestureDelegate);

		// -(void)showZoomViewWithScale:(CGFloat)zoomScale;
		[Export ("showZoomViewWithScale:")]
		void ShowZoomViewWithScale (nfloat zoomScale);

		// -(void)resetZoom;
		[Export ("resetZoom")]
		void ResetZoom ();
	}

	// @protocol FastttZoomDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface FastttZoomDelegate
	{
		// @required -(BOOL)handlePinchZoomWithScale:(CGFloat)zoomScale;
		[Abstract]
		[Export ("handlePinchZoomWithScale:")]
		bool HandlePinchZoomWithScale (nfloat zoomScale);
	}

	// @interface IFTTTDeviceOrientation : NSObject
	[BaseType (typeof(NSObject))]
	interface IFTTTDeviceOrientation
	{
		// -(UIDeviceOrientation)orientation;
		[Export ("orientation")]
		[Verify (MethodToProperty)]
		UIDeviceOrientation Orientation { get; }

		// -(BOOL)deviceOrientationMatchesInterfaceOrientation;
		[Export ("deviceOrientationMatchesInterfaceOrientation")]
		[Verify (MethodToProperty)]
		bool DeviceOrientationMatchesInterfaceOrientation { get; }
	}

	// @interface FastttCamera (UIImage)
	[Category]
	[BaseType (typeof(UIImage))]
	interface UIImage_FastttCamera
	{
		// +(CGRect)fastttCropRectFromPreviewBounds:(CGRect)previewBounds apertureBounds:(CGRect)apertureBounds;
		[Static]
		[Export ("fastttCropRectFromPreviewBounds:apertureBounds:")]
		CGRect FastttCropRectFromPreviewBounds (CGRect previewBounds, CGRect apertureBounds);

		// -(CGRect)fastttCropRectFromPreviewLayer:(AVCaptureVideoPreviewLayer *)previewLayer;
		[Export ("fastttCropRectFromPreviewLayer:")]
		CGRect FastttCropRectFromPreviewLayer (AVCaptureVideoPreviewLayer previewLayer);

		// -(CGRect)fastttCropRectFromPreviewBounds:(CGRect)previewBounds;
		[Export ("fastttCropRectFromPreviewBounds:")]
		CGRect FastttCropRectFromPreviewBounds (CGRect previewBounds);

		// -(CGRect)fastttCropRectFromOutputRect:(CGRect)outputRect;
		[Export ("fastttCropRectFromOutputRect:")]
		CGRect FastttCropRectFromOutputRect (CGRect outputRect);

		// -(UIImage *)fastttCroppedImageFromOutputRect:(CGRect)outputRect;
		[Export ("fastttCroppedImageFromOutputRect:")]
		UIImage FastttCroppedImageFromOutputRect (CGRect outputRect);

		// -(UIImage *)fastttCroppedImageFromCropRect:(CGRect)cropRect;
		[Export ("fastttCroppedImageFromCropRect:")]
		UIImage FastttCroppedImageFromCropRect (CGRect cropRect);

		// -(UIImage *)fastttScaledImageOfSize:(CGSize)size;
		[Export ("fastttScaledImageOfSize:")]
		UIImage FastttScaledImageOfSize (CGSize size);

		// -(UIImage *)fastttScaledImageWithMaxDimension:(CGFloat)maxDimension;
		[Export ("fastttScaledImageWithMaxDimension:")]
		UIImage FastttScaledImageWithMaxDimension (nfloat maxDimension);

		// -(UIImage *)fastttScaledImageWithScale:(CGFloat)newScale;
		[Export ("fastttScaledImageWithScale:")]
		UIImage FastttScaledImageWithScale (nfloat newScale);

		// -(UIImage *)fastttImageWithNormalizedOrientation;
		[Export ("fastttImageWithNormalizedOrientation")]
		[Verify (MethodToProperty)]
		UIImage FastttImageWithNormalizedOrientation { get; }

		// -(UIImage *)fastttRotatedImageMatchingCameraViewWithOrientation:(UIDeviceOrientation)deviceOrientation;
		[Export ("fastttRotatedImageMatchingCameraViewWithOrientation:")]
		UIImage FastttRotatedImageMatchingCameraViewWithOrientation (UIDeviceOrientation deviceOrientation);

		// -(UIImage *)fastttRotatedImageMatchingOrientation:(UIImageOrientation)orientation;
		[Export ("fastttRotatedImageMatchingOrientation:")]
		UIImage FastttRotatedImageMatchingOrientation (UIImageOrientation orientation);

		// +(UIImage *)fastttFakeTestImage;
		[Static]
		[Export ("fastttFakeTestImage")]
		[Verify (MethodToProperty)]
		UIImage FastttFakeTestImage { get; }
	}
}
