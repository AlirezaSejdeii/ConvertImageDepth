using System.Drawing;
using ImageProcessing;
using Color = System.Drawing.Color;

// change depth
Bitmap originalImage = new("mainGrayScaleImage.png");
ConvertDepth.GetInDepth(originalImage, Step.Depth1, "1_bitDepth.jpg");
ConvertDepth.GetInDepth(originalImage, Step.Depth4, "4_bitDepth.jpg");
ConvertDepth.GetInDepth(originalImage, Step.Depth8, "8_bitDepth.jpg");