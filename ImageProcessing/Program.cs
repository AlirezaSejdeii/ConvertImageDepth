using System.Drawing;
using Color = System.Drawing.Color;

Bitmap originalImage = new("mainGrayScaleImage.png");
GetInDepth(originalImage, Step.Depth1, "1_bitDepth.jpg");
GetInDepth(originalImage, Step.Depth4, "4_bitDepth.jpg");
GetInDepth(originalImage, Step.Depth8, "8_bitDepth.jpg");

void GetInDepth(Bitmap image, Step depth, string outPutPath)
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

enum Step
{
    Depth1 = 1,
    Depth4 = 4,
    Depth8 = 8,
}