using HandyControl.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ScoreCalculator.Views.ExtendedMethods
{
    public static class SideMenuItemExtendedMethods
    {
        public static void SetIcon(this SideMenuItem sideMenuItem,string imagePath,int width,int height)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($"pack://application:,,,{imagePath}"));
            image.Width = width;
            image.Height = height;
            sideMenuItem.Icon = image;

        }

    }
}
