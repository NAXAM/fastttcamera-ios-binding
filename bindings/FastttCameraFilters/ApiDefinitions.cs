using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FastttFiltersLib
{
	// @interface FastttCameraFilters : NSObject
	[BaseType (typeof(NSObject))]
	interface FastttCameraFilters
	{
	}

	// @interface FastttEmptyFilter
	interface FastttEmptyFilter
	{
	}

	// @interface FastttFilter : NSObject
	[BaseType (typeof(NSObject))]
	interface FastttFilter
	{
		// +(instancetype)filterWithLookupImage:(UIImage *)lookupImage;
		[Static]
		[Export ("filterWithLookupImage:")]
		FastttFilter FilterWithLookupImage (UIImage lookupImage);

		// +(instancetype)plainFilter;
		[Static]
		[Export ("plainFilter")]
		FastttFilter PlainFilter ();
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern id * filter;
		[Field ("filter", "__Internal")]
		unsafe NSObject* filter { get; }
	}

	// @interface FastttFilterCamera : UIViewController
	[BaseType (typeof(UIViewController))]
	interface FastttFilterCamera
	{
		// @property (nonatomic, strong) UIImage * filterImage;
		[Export ("filterImage", ArgumentSemantic.Strong)]
		UIImage FilterImage { get; set; }

		// +(instancetype)cameraWithFilterImage:(UIImage *)filterImage;
		[Static]
		[Export ("cameraWithFilterImage:")]
		FastttFilterCamera CameraWithFilterImage (UIImage filterImage);
	}

	// @interface FastttLookupFilter
	interface FastttLookupFilter
	{
		// -(instancetype)initWithLookupImage:(UIImage *)lookupImage;
		[Export ("initWithLookupImage:")]
		IntPtr Constructor (UIImage lookupImage);
	}

	// @interface FastttFilters (UIImage)
	[Category]
	[BaseType (typeof(UIImage))]
	interface UIImage_FastttFilters
	{
		// -(UIImage *)fastttFilteredImageWithFilter:(UIImage *)filterImage;
		[Export ("fastttFilteredImageWithFilter:")]
		UIImage FastttFilteredImageWithFilter (UIImage filterImage);
	}
}
