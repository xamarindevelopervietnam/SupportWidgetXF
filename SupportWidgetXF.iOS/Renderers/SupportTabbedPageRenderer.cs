﻿using System;
using System.Threading.Tasks;
using CoreGraphics;
using SupportWidgetXF.iOS.Renderers;
using SupportWidgetXF.Widgets;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportTabbedPage), typeof(SupportTabbedPageRenderer))]
namespace SupportWidgetXF.iOS.Renderers
{
    public class SupportTabbedPageRenderer : TabbedRenderer
    {
        protected SupportTabbedPage supportTabbedPage;

        public SupportTabbedPageRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if(supportTabbedPage!=null)
            {
                if (supportTabbedPage.TitleAndIconLayout == TabbedIconTitleArrange.Full)
                {

                }
                else if (supportTabbedPage.TitleAndIconLayout == TabbedIconTitleArrange.OnlyIcon)
                {
                    if (TabBar.Items != null)
                    {
                        foreach (var item in TabBar.Items)
                        {
                            item.Title = null;
                            item.ImageInsets = new UIEdgeInsets(7, 0, -7, 0);
                        }
                    }
                }
            }

        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportTabbedPage)
                {
                    supportTabbedPage = Element as SupportTabbedPage;
                    InitializeShadow();
                }
            }
        }

        protected virtual void InitializeShadow()
        {
            if(TabBar!=null && supportTabbedPage.IsShadow)
            {
                TabBar.Layer.MasksToBounds = false;
                TabBar.Layer.ShadowOpacity = 0.3f;
                TabBar.Layer.ShadowOffset = new CGSize(0, -2);
                TabBar.Layer.ShadowColor = UIColor.Gray.CGColor;
                TabBar.Layer.CornerRadius = 0;
            }
        }
    }
}