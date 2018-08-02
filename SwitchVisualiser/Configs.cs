using System.Drawing;
using static System.Drawing.Color;

namespace SwitchVisualiser
{
    class Configs
    {
        public class Themes
        {
            public class BasicBlack
            {
                public static Color Background = FromArgb(45, 45, 45);
                public static Color Buttons = FromArgb(80, 80, 80);
                public static Color UI = FromArgb(255, 255, 255);
            }
            public class BasicWhite
            {
                public static Color Background = FromArgb(234, 234, 234);
                public static Color Buttons = FromArgb(255, 255, 255);
                public static Color UI = FromArgb(45, 45, 45);
            }
        }
    }
}
