using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XYWPF.CoreLib.Helper
{
    public class ImageHelper
    {
        /// <summary>
        /// 裁剪图片
        /// </summary>
        public static System.Drawing.Bitmap ClipBitmap(System.Drawing.Image image, System.Drawing.Rectangle rect)
        {
            if (image == null)
                return null;
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(rect.Width, rect.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(image, new System.Drawing.Rectangle(0, 0, rect.Width, rect.Height), rect, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }

        /// <summary>
        /// ImageSource转Bitmap
        /// </summary>
        public static System.Drawing.Bitmap ImageSourceToBitmap(ImageSource imageSource)
        {
            BitmapSource m = (BitmapSource)imageSource;
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m.PixelWidth, m.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(
            new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            m.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride); bmp.UnlockBits(data);
            return bmp;
        }

        /// <summary>
        /// Bitmap转换为BitmapImage
        /// </summary>
        public static BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap tempMap, System.Drawing.Imaging.ImageFormat imgFormat)
        {
            try
            {
                BitmapImage resultImage = new BitmapImage();
                using (MemoryStream ms = new MemoryStream())
                {
                    tempMap.Save(ms, imgFormat);
                    resultImage.BeginInit();
                    resultImage.StreamSource = ms;
                    resultImage.CacheOption = BitmapCacheOption.OnLoad;
                    resultImage.EndInit();
                    resultImage.Freeze();
                }
                return resultImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // <summary>
        /// 获取当前用户的图片文件夹中的图片路径列表(不包含子文件夹)
        /// </summary>
        public static List<string> GetUserImages(string path)
        {
            List<string> images = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = GetPicFiles(path, "*.jpg,*.png,*.bmp,", SearchOption.TopDirectoryOnly);

            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    images.Add(file.FullName);
                }
            }
            return images;
        }

        public static FileInfo[] GetPicFiles(string picPath, string searchPattern, SearchOption searchOption)
        {
            List<FileInfo> ltList = new List<FileInfo>();
            DirectoryInfo dir = new DirectoryInfo(picPath);
            string[] sPattern = searchPattern.Replace(';', ',').Split(',');
            for (int i = 0; i < sPattern.Length; i++)
            {
                FileInfo[] files = null;
                try
                {
                    files = dir.GetFiles(sPattern[i], searchOption);
                }
                catch (System.Exception ex)
                {
                    files = new FileInfo[] { };
                }

                ltList.AddRange(files);
            }
            return ltList.ToArray();
        }

        public static BitmapSource GetPartImage(BitmapImage img, int XCoordinate, int YCoordinate, int Width, int Height)
        {
            return new CroppedBitmap(img, new Int32Rect(XCoordinate, YCoordinate, Width, Height));
        }
    }
}
