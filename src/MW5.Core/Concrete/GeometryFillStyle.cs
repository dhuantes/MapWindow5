﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class GeometryFillStyle: IGeometryFillStyle
    {
        private readonly ShapeDrawingOptions _style;

        internal GeometryFillStyle(ShapeDrawingOptions style)
        {
            if (style == null)
            {
                throw new NullReferenceException("Internal style reference is null.");
            }
            _style = style;
        }

        public GradientBounds GradientBounds
        {
            get { return (GradientBounds)_style.FillGradientBounds; }
            set { _style.FillGradientBounds = (tkGradientBounds)value; }
        }

        public GradientType GradientType
        {
            get { return (GradientType)_style.FillGradientType; }
            set { _style.FillGradientType = (tkGradientType)value; }
        }

        public FillType FillType
        {
            get { return (FillType)_style.FillType; }
            set { _style.FillType = (tkFillType)value; }
        }

        public double Rotation
        {
            get { return _style.FillRotation; }
            set { _style.FillRotation = value; }
        }

        public byte AlphaTransparency
        {
            get { return Convert.ToByte(_style.FillTransparency); }
            set { _style.FillTransparency = value; }
        }

        public Color Color
        {
            get { return ColorHelper.UintToColor(_style.FillColor); }
            set { _style.FillColor = ColorHelper.ColorToUInt(value); }
        }

        public Color Color2
        {
            get { return ColorHelper.UintToColor(_style.FillColor2); }
            set { _style.FillColor2 = ColorHelper.ColorToUInt(value); }
        }

        public Color BackgroundHatchColor
        {
            get { return ColorHelper.UintToColor(_style.FillBgColor); }
            set { _style.FillBgColor = ColorHelper.ColorToUInt(value); }
        }

        public bool BackgroundHatchTransparent
        {
            get { return _style.FillBgTransparent; }
            set { _style.FillBgTransparent = value; }
        }

        public bool Visible
        {
            get { return _style.Visible; }
            set { _style.Visible = value; }
        }

        public HatchStyle HatchStyle
        {
            get { return (HatchStyle)_style.FillHatchStyle; }
            set { _style.FillHatchStyle = (tkGDIPlusHatchStyle)value; }
        }

        // TODO: wrap
        public MapWinGIS.Image Texture
        {
            get { return _style.Picture; }
            set { _style.Picture = value; }
        }

        public void SetGradient(Color color, byte range)
        {
            _style.SetGradientFill(ColorHelper.ColorToUInt(color), range);
        }
    }
}