using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging.Effects;
using System.IO;
using System.Text.RegularExpressions;

namespace FruitTrackerZ2 {
    public class IconManager {
        private static readonly GrayScaleEffect GRAYSCALE = new();
        private static readonly BrightnessContrastEffect DARKEN = new(70, 0);
        private static readonly BrightnessContrastEffect WHITEN = new(255, 0);
        private static readonly BlurEffect BLUR = new(10, false);

        private static readonly Regex REGEX = new(@"([^#]+)(?:#(\w+))?", RegexOptions.Compiled);
        private static IconManager? instance;

        private readonly Dictionary<string, Image> images = new();

        public static IconManager Instance {
            get {
                instance ??= new();
                return instance;
            }
        }

        public Image GetImage(string name) {
            if (!images.ContainsKey(name)) {
                try {
                    var match = REGEX.Match(name);
                    var baseImg = new Bitmap(Image.FromFile(Path.Join("wwwroot", "icons", $"{match.Groups[1].Value}.png")));
                    if (match.Groups[2].Success) {
                        this.ApplyEffect(baseImg, match.Groups[2].Value);
                    }
                    images[name] = baseImg;
                } catch (FileNotFoundException) {
                    return new Bitmap(24, 24);
                }
            }
            return images[name];
        }

        public Image? this[string name] => GetImage(name);

        private void ApplyEffect(Bitmap image, string name) {
            switch (name) {
                case "gray":
                    image.ApplyEffect(GRAYSCALE);
                    return;
                case "inactive":
                    image.ApplyEffect(GRAYSCALE);
                    image.ApplyEffect(DARKEN);
                    return;
                case "outline":
                    image.ApplyEffect(WHITEN);
                    image.ApplyEffect(BLUR);
                    return;
            }
        }
    }
}
