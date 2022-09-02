﻿using FluentAssertions;
using System;
using System.Runtime.InteropServices;
using Xunit;
using Xunit.Abstractions;

namespace IronSoftware.Drawing.Common.Tests.UnitTests
{
    public class FontFunctionality : TestsBase
    {
        public FontFunctionality(ITestOutputHelper output) : base(output)
        {
        }

        [FactWithAutomaticDisplayName]
        public void Create_new_Font()
        {

            Font font = new Font("Roboto Serif");
            font.FamilyName.Should().Be("Roboto Serif");
            font.Style.Should().Be(FontStyle.Regular);
            font.Size.Should().Be(12);
            font.Bold.Should().BeFalse();
            font.Italic.Should().BeFalse();

            font = new Font("Roboto", 20);
            font.FamilyName.Should().Be("Roboto");
            font.Style.Should().Be(FontStyle.Regular);
            font.Size.Should().Be(20);
            font.Bold.Should().BeFalse();
            font.Italic.Should().BeFalse();

            font = new Font("Roboto Mono", FontStyle.Bold | FontStyle.Strikeout);
            font.FamilyName.Should().Be("Roboto Mono");
            font.Style.Should().Be(FontStyle.Bold | FontStyle.Strikeout);
            font.Size.Should().Be(12);
            font.Bold.Should().BeTrue();
            font.Strikeout.Should().BeTrue();

            font = new Font("Roboto Flex", FontStyle.Italic | FontStyle.Underline, 30);
            font.FamilyName.Should().Be("Roboto Flex");
            font.Style.Should().Be(FontStyle.Italic | FontStyle.Underline);
            font.Size.Should().Be(30);
            font.Italic.Should().BeTrue();
            font.Underline.Should().BeTrue();

        }

        [FactWithAutomaticDisplayName]
        public void CastSKFont_to_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                SkiaSharp.SKFont skFont = SkiaSharp.SKTypeface.FromFamilyName("Liberation Mono", SkiaSharp.SKFontStyleWeight.Normal, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Upright).ToFont(30);
                Font font = skFont;
                font.FamilyName.Should().Be("Liberation Mono");
                font.Size.Should().Be(30);
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                skFont = new SkiaSharp.SKFont(SkiaSharp.SKTypeface.FromFamilyName("Liberation Serif", SkiaSharp.SKFontStyleWeight.Bold, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Italic), 20);
                font = skFont;
                font.FamilyName.Should().Be("Liberation Serif");
                font.Size.Should().Be(20);
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
            else
            {
                SkiaSharp.SKFont skFont = SkiaSharp.SKTypeface.FromFamilyName("Courier New", SkiaSharp.SKFontStyleWeight.Normal, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Upright).ToFont(30);
                Font font = skFont;
                font.FamilyName.Should().Be("Courier New");
                font.Size.Should().Be(30);
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                skFont = new SkiaSharp.SKFont(SkiaSharp.SKTypeface.FromFamilyName("Times New Roman", SkiaSharp.SKFontStyleWeight.Bold, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Italic), 20);
                font = skFont;
                font.FamilyName.Should().Be("Times New Roman");
                font.Size.Should().Be(20);
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastSKFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Font font = new Font("Courier New", 30);
                SkiaSharp.SKFont skFont = font;
                skFont.Typeface.FamilyName.Should().Be("Liberation Mono");
                skFont.Size.Should().Be(30);
                skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Upright);
                skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Normal);
                skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                skFont.Typeface.IsBold.Should().BeFalse();
                skFont.Typeface.IsItalic.Should().BeFalse();

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                skFont = font;
                skFont.Typeface.FamilyName.Should().Be("Liberation Serif");
                skFont.Size.Should().Be(20);
                skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Italic);
                skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Bold);
                skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                skFont.Typeface.IsBold.Should().BeTrue();
                skFont.Typeface.IsItalic.Should().BeTrue();
            }
            else
            {
                Font font = new Font("Courier New", 30);
                SkiaSharp.SKFont skFont = font;
                skFont.Typeface.FamilyName.Should().Be("Courier New");
                skFont.Size.Should().Be(30);
                skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Upright);
                skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Normal);
                skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                skFont.Typeface.IsBold.Should().BeFalse();
                skFont.Typeface.IsItalic.Should().BeFalse();

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                skFont = font;
                skFont.Typeface.FamilyName.Should().Be("Times New Roman");
                skFont.Size.Should().Be(20);
                skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Italic);
                skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Bold);
                skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                skFont.Typeface.IsBold.Should().BeTrue();
                skFont.Typeface.IsItalic.Should().BeTrue();
            }            
        }

        [FactWithAutomaticDisplayName]
        public void CastSystemDrawingFont_to_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                System.Drawing.Font drawingFont = new System.Drawing.Font("Liberation Mono", 30);
                Font font = drawingFont;
                font.FamilyName.Should().Be("Liberation Mono");
                font.Size.Should().Be(30);
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                drawingFont = new System.Drawing.Font("Liberation Serif", 20, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                font = drawingFont;
                font.FamilyName.Should().Be("Liberation Serif");
                font.Size.Should().Be(20);
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
            else
            {
                System.Drawing.Font drawingFont = new System.Drawing.Font("Courier New", 30);
                Font font = drawingFont;
                font.FamilyName.Should().Be("Courier New");
                font.Size.Should().Be(30);
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                drawingFont = new System.Drawing.Font("Times New Roman", 20, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                font = drawingFont;
                font.FamilyName.Should().Be("Times New Roman");
                font.Size.Should().Be(20);
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastSystemDrawingFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Font font = new Font("Liberation Mono", 30);
                System.Drawing.Font drawingFont = font;
                drawingFont.FontFamily.Name.Should().Be("Liberation Mono");
                drawingFont.Size.Should().Be(30);
                drawingFont.Style.Should().Be(System.Drawing.FontStyle.Regular);
                drawingFont.Bold.Should().BeFalse();
                drawingFont.Italic.Should().BeFalse();

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                drawingFont = font;
                drawingFont.FontFamily.Name.Should().Be("Liberation Serif");
                drawingFont.Size.Should().Be(20);
                drawingFont.Style.Should().Be(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                drawingFont.Bold.Should().BeTrue();
                drawingFont.Italic.Should().BeTrue();
            }
            else
            {
                Font font = new Font("Courier New", 30);
                System.Drawing.Font drawingFont = font;
                drawingFont.FontFamily.Name.Should().Be("Courier New");
                drawingFont.Size.Should().Be(30);
                drawingFont.Style.Should().Be(System.Drawing.FontStyle.Regular);
                drawingFont.Bold.Should().BeFalse();
                drawingFont.Italic.Should().BeFalse();

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                drawingFont = font;
                drawingFont.FontFamily.Name.Should().Be("Times New Roman");
                drawingFont.Size.Should().Be(20);
                drawingFont.Style.Should().Be(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                drawingFont.Bold.Should().BeTrue();
                drawingFont.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastSixLaborsFont_to_Font()
        {
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                SixLabors.Fonts.Font sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Liberation Mono", 30);
                Font font = sixLaborsFont;
                font.FamilyName.Should().Be("Liberation Mono");
                font.Size.Should().Be(30);
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Liberation Serif", 20, SixLabors.Fonts.FontStyle.BoldItalic);
                font = sixLaborsFont;
                font.FamilyName.Should().Be("Liberation Serif");
                font.Size.Should().Be(20);
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
            else
            {
                SixLabors.Fonts.Font sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Courier New", 30);
                Font font = sixLaborsFont;
                font.FamilyName.Should().Be("Courier New");
                font.Size.Should().Be(30);
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Times New Roman", 20, SixLabors.Fonts.FontStyle.BoldItalic);
                font = sixLaborsFont;
                font.FamilyName.Should().Be("Times New Roman");
                font.Size.Should().Be(20);
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastSixLaborsFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Font font = new Font("Liberation Mono", 30);
                SixLabors.Fonts.Font sixLaborsFont = font;
                sixLaborsFont.Family.Name.Should().Be("Liberation Mono");
                sixLaborsFont.Size.Should().Be(30);
                sixLaborsFont.IsBold.Should().BeFalse();
                sixLaborsFont.IsItalic.Should().BeFalse();

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                sixLaborsFont = font;
                sixLaborsFont.Family.Name.Should().Be("Liberation Serif");
                sixLaborsFont.Size.Should().Be(20);
                sixLaborsFont.IsBold.Should().BeTrue();
                sixLaborsFont.IsItalic.Should().BeTrue();
            }
            else
            {
                Font font = new Font("Courier New", 30);
                SixLabors.Fonts.Font sixLaborsFont = font;
                sixLaborsFont.Family.Name.Should().Be("Courier New");
                sixLaborsFont.Size.Should().Be(30);
                sixLaborsFont.IsBold.Should().BeFalse();
                sixLaborsFont.IsItalic.Should().BeFalse();

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                sixLaborsFont = font;
                sixLaborsFont.Family.Name.Should().Be("Times New Roman");
                sixLaborsFont.Size.Should().Be(20);
                sixLaborsFont.IsBold.Should().BeTrue();
                sixLaborsFont.IsItalic.Should().BeTrue();
            }
        }

#if !NET472


        [FactWithAutomaticDisplayName]
        public void CastMauiFont_to_Font()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Microsoft.Maui.Graphics.Font mFont = new Microsoft.Maui.Graphics.Font("Liberation Mono");
                Font font = mFont;
                font.FamilyName.Should().Be("Liberation Mono");
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                mFont = new Microsoft.Maui.Graphics.Font("Liberation Serif", 800, Microsoft.Maui.Graphics.FontStyleType.Italic);
                font = mFont;
                font.FamilyName.Should().Be("Liberation Serif");
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
            else
            {
                Microsoft.Maui.Graphics.Font mFont = new Microsoft.Maui.Graphics.Font("Courier New");
                Font font = mFont;
                font.FamilyName.Should().Be("Courier New");
                font.Style.Should().Be(FontStyle.Regular);
                font.Bold.Should().BeFalse();
                font.Italic.Should().BeFalse();

                mFont = new Microsoft.Maui.Graphics.Font("Times New Roman", 800, Microsoft.Maui.Graphics.FontStyleType.Italic);
                font = mFont;
                font.FamilyName.Should().Be("Times New Roman");
                font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                font.Bold.Should().BeTrue();
                font.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastMauiFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Font font = new Font("Liberation Mono", 30);
                Microsoft.Maui.Graphics.Font mFont = font;
                mFont.Name.Should().Be("Liberation Mono");
                mFont.Weight.Should().Be(400);
                mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Normal);

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                mFont = font;
                mFont.Name.Should().Be("Liberation Serif");
                mFont.Weight.Should().Be(700);
                mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Italic);
            }
            else
            {
                Font font = new Font("Courier New", 30);
                Microsoft.Maui.Graphics.Font mFont = font;
                mFont.Name.Should().Be("Courier New");
                mFont.Weight.Should().Be(400);
                mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Normal);

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                mFont = font;
                mFont.Name.Should().Be("Times New Roman");
                mFont.Weight.Should().Be(700);
                mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Italic);
            }
        }
#endif
    }
}
