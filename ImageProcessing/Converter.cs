using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageProcessing;

public static class Converter
{
    public static Bitmap ConvertToGrayscale(Bitmap original)
    {
        Bitmap grayscale = new Bitmap(original.Width, original.Height);

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                // Get the pixel's color
                Color originalColor = original.GetPixel(x, y);

                // Calculate the grayscale value
                int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));

                // Create a new color with the grayscale value
                Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale);

                // Set the new color to the grayscale image
                grayscale.SetPixel(x, y, grayColor);
            }
        }

        return grayscale;
    }

    public static void GetInDepth(Bitmap image, Step depth, string outPutPath)
    {
        Bitmap grayscaleImage = new Bitmap(image.Width, image.Height);
        for (int i = 0; i < image.Width; i++)
        {
            for (int j = 0; j < image.Height; j++)
            {
                Color originalColor = image.GetPixel(i, j);
                int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));

                if (depth == Step.Depth1)
                {
                    Color newColor;
                    if (grayScale > 128)
                        newColor = Color.White;
                    else
                        newColor = Color.Black;
                    grayscaleImage.SetPixel(i, j, newColor);
                }
                else if (depth == Step.Depth4)
                {
                    // Map the 8-bit grayscale to 4-bit by dividing by 16 and multiplying back.
                    int gray4Bit = (grayScale / 16) * 16;

                    Color newColor = Color.FromArgb(gray4Bit, gray4Bit, gray4Bit);
                    grayscaleImage.SetPixel(i, j, newColor);
                }
                else if (depth == Step.Depth8)
                {
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    grayscaleImage.SetPixel(i, j, newColor);
                }
            }
        }

        grayscaleImage.Save(outPutPath);
    }

    public static Bitmap MakeBitmap(int[,] grid)
    {
        int width = grid.GetLength(1);
        int height = grid.GetLength(0);

        Bitmap bitmap = new Bitmap(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int brightness = grid[y, x];
                Color color = Color.FromArgb(brightness, brightness, brightness);
                bitmap.SetPixel(x, y, color);
            }
        }

        return bitmap;
    }

    public static void RotateImage45Degrees(Bitmap original, string outPutPath)
    {
        int maxDim = Math.Max(original.Width, original.Height);
        double sqrt2 = Math.Sqrt(2);
        int newWidth = (int)Math.Ceiling(maxDim * sqrt2);
        int newHeight = newWidth;

        Bitmap rotatedBitmap = new Bitmap(newWidth, newHeight);

        using (Graphics g = Graphics.FromImage(rotatedBitmap))
        {
            g.Clear(Color.White);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            g.TranslateTransform(newWidth / 2f, newHeight / 2f);

            g.RotateTransform(45);

            g.TranslateTransform(-original.Width / 2f, -original.Height / 2f);

            g.DrawImage(original, 0, 0);
        }

        rotatedBitmap.Save(outPutPath);
    }
}