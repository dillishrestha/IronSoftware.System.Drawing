﻿using System;
using System.Globalization;
using System.Linq;

namespace IronSoftware.Drawing
{
    // <summary>
    /// <para>A universally compatible Color for .NET 7, .NET 6, .NET 5, and .NET Core. As well as compatiblity with Windows, NanoServer, IIS, macOS, Mobile, Xamarin, iOS, Android, Google Compute, Azure, AWS, and Linux.</para>
    /// <para>Works nicely with popular Image Color such as <see cref="System.Drawing.Color"/>, <see cref="SkiaSharp.SKColor"/>, <see cref="SixLabors.ImageSharp.Color"/>, <see cref="Microsoft.Maui.Graphics.Color"/>.</para>
    /// <para>Implicit casting means that using this class to input and output Color from public APIs gives full compatibility to all Color-types fully supported by Microsoft.</para>
    /// </summary>
    public partial class Color
    {

        /// <summary>
        /// Gets the alpha component value of this IronSoftware.Drawing.Color structure.
        /// </summary>
        /// <return>The alpha component value of this IronSoftware.Drawing.Color.</return>
        public byte A { get; internal set; }

        /// <summary>
        /// Gets the green component value of this IronSoftware.Drawing.Color structure.
        /// </summary>
        /// <return>The green component value of this IronSoftware.Drawing.Color.</return>
        public byte G { get; internal set; }

        /// <summary>
        /// Gets the blue component value of this IronSoftware.Drawing.Color structure.
        /// </summary>
        /// <return>The blue component value of this IronSoftware.Drawing.Color.</return>
        public byte B { get; internal set; }

        /// <summary>
        /// Gets the red component value of this IronSoftware.Drawing.Color structure.
        /// </summary>
        /// <return>The red component value of this IronSoftware.Drawing.Color.</return>
        public byte R { get; internal set; }

        /// <summary>
        /// Construct a new Color.
        /// </summary>
        /// <param name="colorcode">The hexadecimal representation of the combined color components arranged in rgb, argb, rrggbb, or aarrggbb format to match web syntax.</param>
        public Color(string colorcode)
        {
            string trimmedColorcode = colorcode.TrimStart('#');

            if (trimmedColorcode.Length == 8)
            {
                this.A = ConvertToHexNumberByte(trimmedColorcode, 0, 2);
                this.R = ConvertToHexNumberByte(trimmedColorcode, 2, 2);
                this.G = ConvertToHexNumberByte(trimmedColorcode, 4, 2);
                this.B = ConvertToHexNumberByte(trimmedColorcode, 6, 2);
            }
            else if (trimmedColorcode.Length == 6)
            {
                this.A = 255;
                this.R = ConvertToHexNumberByte(trimmedColorcode, 0, 2);
                this.G = ConvertToHexNumberByte(trimmedColorcode, 2, 2);
                this.B = ConvertToHexNumberByte(trimmedColorcode, 4, 2);
            }
            else if (trimmedColorcode.Length == 3)
            {
                this.A = 255;
                this.R = ConvertToHexNumberByte(trimmedColorcode, 0, 1);
                this.G = ConvertToHexNumberByte(trimmedColorcode, 1, 1);
                this.B = ConvertToHexNumberByte(trimmedColorcode, 2, 1);
            }
            else
            {
                throw NoConverterException(colorcode, null);
            }
        }

        /// <summary>
        /// Construct a new Color.
        /// </summary>
        /// <param name="alpha">The alpha component. Valid values are 0 through 255.</param>
        /// <param name="red">The red component. Valid values are 0 through 255.</param>
        /// <param name="green">The green component. Valid values are 0 through 255.</param>
        /// <param name="blue">The blue component. Valid values are 0 through 255.</param>
        public Color(int alpha, int red, int green, int blue)
        {
            this.A = (byte)alpha;
            this.R = (byte)red;
            this.G = (byte)green;
            this.B = (byte)blue;
        }

        /// <summary>
        /// Construct a new Color.
        /// </summary>
        /// <param name="red">The red component. Valid values are 0 through 255.</param>
        /// <param name="green">The green component. Valid values are 0 through 255.</param>
        /// <param name="blue">The blue component. Valid values are 0 through 255.</param>
        public Color(int red, int green, int blue)
        {
            this.A = 255;
            this.R = (byte)red;
            this.G = (byte)green;
            this.B = (byte)blue;
        }

        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F0F8FF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color AliceBlue = new Color("#F0F8FF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FAEBD7.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color AntiqueWhite = new Color("#FAEBD7");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00FFFF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Aqua = new Color("#00FFFF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #7FFFD4.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Aquamarine = new Color("#7FFFD4");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F0FFFF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Azure = new Color("#F0FFFF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F5F5DC.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Beige = new Color("#F5F5DC");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFE4C4.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Bisque = new Color("#FFE4C4");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #000000.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Black = new Color("#000000");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFEBCD.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color BlanchedAlmond = new Color("#FFEBCD");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #0000FF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Blue = new Color("#0000FF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #8A2BE2.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color BlueViolet = new Color("#8A2BE2");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #A52A2A.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Brown = new Color("#A52A2A");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #DEB887.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color BurlyWood = new Color("#DEB887");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #5F9EA0.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color CadetBlue = new Color("#5F9EA0");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #7FFF00.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Chartreuse = new Color("#7FFF00");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #D2691E.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Chocolate = new Color("#D2691E");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF7F50.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Coral = new Color("#FF7F50");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #6495ED.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color CornflowerBlue = new Color("#6495ED");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFF8DC.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Cornsilk = new Color("#FFF8DC");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #DC143C.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Crimson = new Color("#DC143C");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00FFFF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Cyan = new Color("#00FFFF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00008B.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkBlue = new Color("#00008B");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #008B8B.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkCyan = new Color("#008B8B");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #B8860B.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkGoldenrod = new Color("#B8860B");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #A9A9A9.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkGray = new Color("#A9A9A9");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #006400.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkGreen = new Color("#006400");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #BDB76B.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkKhaki = new Color("#BDB76B");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #8B008B.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkMagenta = new Color("#8B008B");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #556B2F.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkOliveGreen = new Color("#556B2F");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF8C00.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkOrange = new Color("#FF8C00");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #9932CC.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkOrchid = new Color("#9932CC");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #8B0000.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkRed = new Color("#8B0000");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #E9967A.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkSalmon = new Color("#E9967A");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #8FBC8B.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkSeaGreen = new Color("#8FBC8B");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #483D8B.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkSlateBlue = new Color("#483D8B");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #2F4F4F.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkSlateGray = new Color("#2F4F4F");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00CED1.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkTurquoise = new Color("#00CED1");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #9400D3.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DarkViolet = new Color("#9400D3");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF1493.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DeepPink = new Color("#FF1493");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00BFFF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DeepSkyBlue = new Color("#00BFFF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #696969.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DimGray = new Color("#696969");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #1E90FF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color DodgerBlue = new Color("#1E90FF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #B22222.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Firebrick = new Color("#B22222");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFFAF0.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color FloralWhite = new Color("#FFFAF0");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #228B22.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color ForestGreen = new Color("#228B22");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF00FF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Fuchsia = new Color("#FF00FF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #DCDCDC.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Gainsboro = new Color("#DCDCDC");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F8F8FF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color GhostWhite = new Color("#F8F8FF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFD700.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Gold = new Color("#FFD700");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #DAA520.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Goldenrod = new Color("#DAA520");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #808080.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Gray = new Color("#808080");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #008000.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Green = new Color("#008000");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #ADFF2F.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color GreenYellow = new Color("#ADFF2F");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F0FFF0.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Honeydew = new Color("#F0FFF0");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF69B4.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color HotPink = new Color("#FF69B4");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #CD5C5C.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color IndianRed = new Color("#CD5C5C");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #4B0082.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Indigo = new Color("#4B0082");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFFFF0.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Ivory = new Color("#FFFFF0");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F0E68C.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Khaki = new Color("#F0E68C");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #E6E6FA.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Lavender = new Color("#E6E6FA");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFF0F5.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LavenderBlush = new Color("#FFF0F5");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #7CFC00.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LawnGreen = new Color("#7CFC00");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFFACD.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LemonChiffon = new Color("#FFFACD");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #ADD8E6.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightBlue = new Color("#ADD8E6");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F08080.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightCoral = new Color("#F08080");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #E0FFFF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightCyan = new Color("#E0FFFF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FAFAD2.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightGoldenrodYellow = new Color("#FAFAD2");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #D3D3D3.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightGray = new Color("#D3D3D3");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #90EE90.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightGreen = new Color("#90EE90");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFB6C1.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightPink = new Color("#FFB6C1");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFA07A.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightSalmon = new Color("#FFA07A");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #20B2AA.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightSeaGreen = new Color("#20B2AA");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #87CEFA.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightSkyBlue = new Color("#87CEFA");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #778899.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightSlateGray = new Color("#778899");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #B0C4DE.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightSteelBlue = new Color("#B0C4DE");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFFFE0.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LightYellow = new Color("#FFFFE0");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00FF00.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Lime = new Color("#00FF00");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #32CD32.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color LimeGreen = new Color("#32CD32");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FAF0E6.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Linen = new Color("#FAF0E6");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF00FF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Magenta = new Color("#FF00FF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #800000.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Maroon = new Color("#800000");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #66CDAA.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumAquamarine = new Color("#66CDAA");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #0000CD.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumBlue = new Color("#0000CD");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #BA55D3.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumOrchid = new Color("#BA55D3");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #9370DB.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumPurple = new Color("#9370DB");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #3CB371.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumSeaGreen = new Color("#3CB371");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #7B68EE.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumSlateBlue = new Color("#7B68EE");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00FA9A.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumSpringGreen = new Color("#00FA9A");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #48D1CC.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumTurquoise = new Color("#48D1CC");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #C71585.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MediumVioletRed = new Color("#C71585");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #191970.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MidnightBlue = new Color("#191970");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F5FFFA.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MintCream = new Color("#F5FFFA");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFE4E1.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color MistyRose = new Color("#FFE4E1");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFE4B5.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Moccasin = new Color("#FFE4B5");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFDEAD.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color NavajoWhite = new Color("#FFDEAD");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #000080.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Navy = new Color("#000080");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FDF5E6.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color OldLace = new Color("#FDF5E6");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #808000.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Olive = new Color("#808000");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #6B8E23.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color OliveDrab = new Color("#6B8E23");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFA500.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Orange = new Color("#FFA500");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF4500.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color OrangeRed = new Color("#FF4500");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #DA70D6.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Orchid = new Color("#DA70D6");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #EEE8AA.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color PaleGoldenrod = new Color("#EEE8AA");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #98FB98.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color PaleGreen = new Color("#98FB98");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #AFEEEE.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color PaleTurquoise = new Color("#AFEEEE");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #DB7093.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color PaleVioletRed = new Color("#DB7093");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFEFD5.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color PapayaWhip = new Color("#FFEFD5");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFDAB9.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color PeachPuff = new Color("#FFDAB9");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #CD853F.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Peru = new Color("#CD853F");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFC0CB.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Pink = new Color("#FFC0CB");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #DDA0DD.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Plum = new Color("#DDA0DD");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #B0E0E6.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color PowderBlue = new Color("#B0E0E6");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #800080.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Purple = new Color("#800080");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #663399.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color RebeccaPurple = new Color("#663399");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF0000.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Red = new Color("#FF0000");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #BC8F8F.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color RosyBrown = new Color("#BC8F8F");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #4169E1.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color RoyalBlue = new Color("#4169E1");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #8B4513.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SaddleBrown = new Color("#8B4513");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FA8072.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Salmon = new Color("#FA8072");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F4A460.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SandyBrown = new Color("#F4A460");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #2E8B57.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SeaGreen = new Color("#2E8B57");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFF5EE.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SeaShell = new Color("#FFF5EE");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #A0522D.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Sienna = new Color("#A0522D");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #C0C0C0.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Silver = new Color("#C0C0C0");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #87CEEB.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SkyBlue = new Color("#87CEEB");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #6A5ACD.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SlateBlue = new Color("#6A5ACD");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #708090.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SlateGray = new Color("#708090");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFFAFA.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Snow = new Color("#FFFAFA");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00FF7F.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SpringGreen = new Color("#00FF7F");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #4682B4.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color SteelBlue = new Color("#4682B4");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #D2B48C.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Tan = new Color("#D2B48C");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #008080.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Teal = new Color("#008080");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #D2B48C.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Thistle = new Color("#D8BFD8");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FF6347.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Tomato = new Color("#FF6347");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #00FFFFFF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Transparent = new Color("#00FFFFFF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #40E0D0.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Turquoise = new Color("#40E0D0");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #EE82EE.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Violet = new Color("#EE82EE");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F5DEB3.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Wheat = new Color("#F5DEB3");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFFFFF.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color White = new Color("#FFFFFF");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #F5F5F5.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color WhiteSmoke = new Color("#F5F5F5");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #FFFF00.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color Yellow = new Color("#FFFF00");
        /// <summary>
        /// Gets a system-defined color that has an ARGB value of #9ACD32.
        /// </summary>
        /// <return>A IronSoftware.Drawing.Color representing a system-defined color.</return>
        public static Color YellowGreen = new Color("#9ACD32");

        /// <summary>
        /// Creates a IronSoftware.Drawing.Color structure from the specified 8-bit color values
        /// (red, green, and blue). The alpha value is implicitly 255 (fully opaque). Although
        /// this method allows a 32-bit value to be passed for each color component, the
        /// value of each component is limited to 8 bits.
        /// </summary>
        /// <param name="red">The red component value for the new IronSoftware.Drawing.Color. Valid values are 0 through 255.</param>
        /// <param name="green">The green component value for the new IronSoftware.Drawing.Color. Valid values are 0 through 255.</param>
        /// <param name="blue">The blue component value for the new IronSoftware.Drawing.Color. Valid values are 0 through 255.</param>
        /// <returns><see cref="Color"/></returns>
        /// <seealso cref="FromArgb(int)"/>
        /// <seealso cref="FromArgb(int, Color)"/>
        /// <seealso cref="FromArgb(int, int, int, int)"/>
        public static Color FromArgb(int red, int green, int blue)
        {
            return new Color(red, green, blue);
        }

        /// <summary>
        /// Creates a <see cref="Color"/> structure from the specified 8-bit color values
        /// (alpha, red, green, and blue). Although this method allows a 32-bit value to be passed for each color component,
        /// the value of each component is limited to 8 bits.
        /// </summary>
        /// <param name="alpha">The alpha value for the new IronSoftware.Drawing.Color. Valid values are 0 through 255.</param>
        /// <param name="red">The red component value for the new IronSoftware.Drawing.Color. Valid values are 0 through 255.</param>
        /// <param name="green">The green component value for the new IronSoftware.Drawing.Color. Valid values are 0 through 255.</param>
        /// <param name="blue">The blue component value for the new IronSoftware.Drawing.Color. Valid values are 0 through 255.</param>
        /// <returns><see cref="Color"/></returns>
        /// <seealso cref="FromArgb(int)"/>
        /// <seealso cref="FromArgb(int, Color)"/>
        /// <seealso cref="FromArgb(int, int, int)"/>
        public static Color FromArgb(int alpha, int red, int green, int blue)
        {
            return new Color(alpha, red, green, blue);
        }

        /// <summary>
        /// Creates a <see cref="Color"/> structure from the specified <see cref="Color"/> structure, but with the new specified alpha value. 
        /// <para>Although this method allows a 32-bit value to be passed for the alpha value, the value is limited to 8 bits.</para>
        /// </summary>
        /// <param name="alpha">The alpha value for the new <see cref="Color"/>. Valid values are 0 through 255.</param>
        /// <param name="baseColor">The <see cref="Color"/> from which to create the new <see cref="Color"/>.</param>
        /// <returns><see cref="Color"/></returns>
        /// <seealso cref="FromArgb(int)"/>
        /// <seealso cref="FromArgb(int, int, int)"/>
        /// <seealso cref="FromArgb(int, int, int, int)"/>
        public static Color FromArgb(int alpha, Color baseColor)
        {
            return new Color(alpha, baseColor.R, baseColor.G, baseColor.B);
        }

        /// <summary>
        /// Creates a IronSoftware.Drawing.Color structure from a 32-bit ARGB value.
        /// </summary>
        /// <param name="argb">A value specifying the 32-bit ARGB value.</param>
        /// <returns><see cref="Color"/></returns>
        /// <seealso cref="FromArgb(int, Color)"/>
        /// <seealso cref="FromArgb(int, int, int)"/>
        /// <seealso cref="FromArgb(int, int, int, int)"/>
        public static Color FromArgb(int argb)
        {
            return new Color(argb.ToString("X"));
        }

        /// <summary>
        /// Returns the color as a string in the format: #AARRGGBB.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"#{this.A:X}{this.R:X}{this.G:X}{this.B:X}";
        }

        /// <summary>
        /// Luminance is a value from 0 (black) to 100 (white) where 50 is the perceptual "middle grey". 
        /// Luminance = 50 is the equivalent of Y = 18.4, or in other words a 18% grey card, representing the middle of a photographic exposure.
        /// </summary>
        /// <returns>Preceived Lightness</returns>
        public double GetLuminance()
        {
            return Math.Round(Percentage(255, CalculateLuminance()), MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Gets the 32-bit ARGB value of this Color structure.
        /// </summary>
        /// <returns>The 32-bit ARGB value of this Color.</returns>
        public int ToArgb()
        {
            return (this.A << 24) | (this.R << 16) | (this.G << 8) | this.B;
        }

        /// <summary>
        /// Implicitly casts System.Drawing.Color objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support System.Drawing.Color as well.</para>
        /// </summary>
        /// <param name="Color">System.Drawing.Color will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(System.Drawing.Color Color)
        {
            return new Color(Color.A, Color.R, Color.G, Color.B);
        }

        /// <summary>
        /// Implicitly casts to System.Drawing.Color objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support System.Drawing.Color as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a System.Drawing.Rectangle </param>
        static public implicit operator System.Drawing.Color(Color Color)
        {
            return System.Drawing.Color.FromArgb(Color.A, Color.R, Color.G, Color.B);
        }

        /// <summary>
        /// Implicitly casts SkiaSharp.SKColor objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SkiaSharp.SKColor as well.</para>
        /// </summary>
        /// <param name="Color">SkiaSharp.SKColor will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(SkiaSharp.SKColor Color)
        {
            return new Color(Color.Alpha, Color.Red, Color.Green, Color.Blue);
        }

        /// <summary>
        /// Implicitly casts to SkiaSharp.SKColor objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SkiaSharp.SKColor as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a SkiaSharp.SKColor </param>
        static public implicit operator SkiaSharp.SKColor(Color Color)
        {
            return new SkiaSharp.SKColor(Color.R, Color.G, Color.B, Color.A);
        }

        /// <summary>
        /// Implicitly casts SixLabors.ImageSharp.Color objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Color as well.</para>
        /// </summary>
        /// <param name="Color">SixLabors.ImageSharp.Color will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(SixLabors.ImageSharp.Color Color)
        {
            string hex = Color.ToHex();
            return new Color(ConvertToHexNumberByte(hex, 6, 2), ConvertToHexNumberByte(hex, 0, 2), ConvertToHexNumberByte(hex, 2, 2), ConvertToHexNumberByte(hex, 4, 2));
        }

        /// <summary>
        /// Implicitly casts to SixLabors.ImageSharp.Color objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Color as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a SixLabors.ImageSharp.Color </param>
        static public implicit operator SixLabors.ImageSharp.Color(Color Color)
        {
            return SixLabors.ImageSharp.Color.FromRgba(Color.R, Color.G, Color.B, Color.A);
        }

        /// <summary>
        /// Implicitly casts SixLabors.ImageSharp.Rgba32 objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgba32 as well.</para>
        /// </summary>
        /// <param name="Color">SixLabors.ImageSharp.Rgba32 will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(SixLabors.ImageSharp.PixelFormats.Rgba32 Color)
        {
            string hex = Color.ToHex(); // Rgba
            return new Color(ConvertToHexNumberByte(hex, 6, 2), ConvertToHexNumberByte(hex, 0, 2), ConvertToHexNumberByte(hex, 2, 2), ConvertToHexNumberByte(hex, 4, 2));
        }

        /// <summary>
        /// Implicitly casts to SixLabors.ImageSharp.Rgba32 objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgba32 as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a SixLabors.ImageSharp.Rgba32 </param>
        static public implicit operator SixLabors.ImageSharp.PixelFormats.Rgba32(Color Color)
        {
            return SixLabors.ImageSharp.Color.FromRgba(Color.R, Color.G, Color.B, Color.A);
        }

        /// <summary>
        /// Implicitly casts SixLabors.ImageSharp.Rgb24 objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgb24 as well.</para>
        /// </summary>
        /// <param name="Color">SixLabors.ImageSharp.Rgb24 will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(SixLabors.ImageSharp.PixelFormats.Rgb24 Color)
        {
            return new Color(Color.R, Color.G, Color.B);
        }

        /// <summary>
        /// Implicitly casts to SixLabors.ImageSharp.Rgb24 objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgb24 as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a SixLabors.ImageSharp.Rgb24 </param>
        static public implicit operator SixLabors.ImageSharp.PixelFormats.Rgb24(Color Color)
        {
            return SixLabors.ImageSharp.Color.FromRgb(Color.R, Color.G, Color.B);
        }

        /// <summary>
        /// Implicitly casts SixLabors.ImageSharp.Rgb48 objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgb48 as well.</para>
        /// </summary>
        /// <param name="Color">SixLabors.ImageSharp.Rgb48 will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(SixLabors.ImageSharp.PixelFormats.Rgb48 Color)
        {
            return new Color(Color.R, Color.G, Color.B);
        }

        /// <summary>
        /// Implicitly casts to SixLabors.ImageSharp.Rgb48 objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgb48 as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a SixLabors.ImageSharp.Rgb48 </param>
        static public implicit operator SixLabors.ImageSharp.PixelFormats.Rgb48(Color Color)
        {
            return new SixLabors.ImageSharp.PixelFormats.Rgb48(Color.R, Color.G, Color.B);
        }

        /// <summary>
        /// Implicitly casts SixLabors.ImageSharp.Rgba64 objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgba64 as well.</para>
        /// </summary>
        /// <param name="Color">SixLabors.ImageSharp.Rgba64 will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(SixLabors.ImageSharp.PixelFormats.Rgba64 Color)
        {
            return new Color(Color.A, Color.R, Color.G, Color.B);
        }

        /// <summary>
        /// Implicitly casts to SixLabors.ImageSharp.Rgba64 objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support SixLabors.ImageSharp.Rgba64 as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a SixLabors.ImageSharp.Rgba64 </param>
        static public implicit operator SixLabors.ImageSharp.PixelFormats.Rgba64(Color Color)
        {
            return SixLabors.ImageSharp.Color.FromRgba(Color.R, Color.G, Color.B, Color.A);
        }

        /// <summary>
        /// Implicitly casts Microsoft.Maui.Graphics.Color objects to <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support Microsoft.Maui.Graphics.Color as well.</para>
        /// </summary>
        /// <param name="Color">Microsoft.Maui.Graphics.Color will automatically be cast to <see cref="Color"/> </param>
        public static implicit operator Color(Microsoft.Maui.Graphics.Color Color)
        {
            Color.ToRgba(out byte r, out byte g, out byte b, out byte a);
            return new Color(a, r, g, b);
        }

        /// <summary>
        /// Implicitly casts to Microsoft.Maui.Graphics.Color objects from <see cref="Color"/>.  
        /// <para>When your .NET Class methods use <see cref="Color"/> as parameters or return types, you now automatically support Microsoft.Maui.Graphics.Color as well.</para>
        /// </summary>
        /// <param name="Color"><see cref="Color"/> is explicitly cast to a Microsoft.Maui.Graphics.Color </param>
        static public implicit operator Microsoft.Maui.Graphics.Color(Color Color)
        {
            return Microsoft.Maui.Graphics.Color.FromRgba(Color.R, Color.G, Color.B, Color.A);
        }

        #region Private Method

        private static InvalidOperationException NoConverterException(string color, Exception innerException)
        {
            return new InvalidOperationException($"{color} is unable to convert to {typeof(Color)} because it requires a suitable length of string.", innerException);
        }

        private double Percentage(int total, double value)
        {
            return (value * 100) / (double)total;
        }

        private static byte ConvertToHexNumberByte(string colorcode, int start, int length)
        {
            if (length == 2)
            {
                return (byte)int.Parse(colorcode.Substring(start, length), NumberStyles.HexNumber);
            }
            else if (length == 1)
            {
                return (byte)int.Parse(string.Join("", Enumerable.Repeat(colorcode.Substring(start, length), 2)), NumberStyles.HexNumber);
            }
            else
            {
                throw new InvalidOperationException($"{colorcode} is unable to convert to {typeof(byte)} because it requires 1 or 2 for length.");
            }
        }

        private double CalculateLuminance()
        {
            return 0.299 * R + 0.587 * G + 0.114 * B;
        }

        #endregion
    }
}
