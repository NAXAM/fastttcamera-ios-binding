﻿using System;
using Foundation;
using GPUImage.Filters;
using GPUImage.Sources;
using ObjCRuntime;
using UIKit;

namespace FastttCameraLib
{
	// @interface FastttCameraFilters : NSObject
	[BaseType (typeof(NSObject))]
	interface FastttCameraFilters
	{
	}

	// @interface FastttEmptyFilter
	[BaseType (typeof(GPUImageFilter))]
	interface FastttEmptyFilter
	{
	}

	// @interface FastttFilter : NSObject
	[BaseType (typeof(NSObject))]
	interface FastttFilter
	{
		//@property (readonly, nonatomic, strong) GPUImageOutput<GPUImageInput> *filter;
		[Export("filter")]
		GPUImageOutput Filter {get;}

		// +(instancetype)filterWithLookupImage:(UIImage *)lookupImage;
		[Static]
		[Export ("filterWithLookupImage:")]
		FastttFilter FilterWithLookupImage (UIImage lookupImage);

		// +(instancetype)plainFilter;
		[Static]
		[Export ("plainFilter")]
		FastttFilter PlainFilter ();
	}

	// [Static]
	// [Verify (ConstantsInterfaceAssociation)]
	// partial interface Constants
	// {
	// 	// extern id * filter;
	// 	[Field ("filter", "__Internal")]
	// 	unsafe NSObject* filter { get; }
	// }

	// @interface FastttFilterCamera : UIViewController
	[BaseType (typeof(UIViewController))]
	interface FastttFilterCamera : IFastttCameraInterface
	{
		// @property (nonatomic, strong) UIImage * filterImage;
		[Export ("filterImage", ArgumentSemantic.Strong), NullAllowed]
		UIImage FilterImage { get; set; }

		// +(instancetype)cameraWithFilterImage:(UIImage *)filterImage;
		[Static]
		[Export ("cameraWithFilterImage:")]
		FastttFilterCamera CameraWithFilterImage (UIImage filterImage);
	}

	// @interface FastttLookupFilter
	[BaseType (typeof(GPUImageFilterGroup))]
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
