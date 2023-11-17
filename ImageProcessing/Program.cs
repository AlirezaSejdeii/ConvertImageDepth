using System.Drawing;
using ImageProcessing;

// change depth
// Bitmap originalImage = new("mainGrayScaleImage.jpg");
// Converter.GetInDepth(originalImage, Step.Depth1, "1_bitDepth.jpg");
// Converter.GetInDepth(originalImage, Step.Depth4, "4_bitDepth.jpg");
// Converter.GetInDepth(originalImage, Step.Depth8, "8_bitDepth.jpg");


// convert rgb image to grayscale with 4 depth
// Bitmap originalImage = new("Picture1.jpg");
// Converter.GetInDepth(Converter.ConvertToGrayscale(originalImage), Step.Depth4, "Picture1-d4.jpg");

// Bitmap originalImage = new("mainGrayScaleImage.png");
// Converter.RotateImage45Degrees(originalImage, "imageRotated45d.jpg");


// Rotate the bitmap by 45 degrees

// int[,] grid = new int[,]
// {
//     { 0, 3, 8, 5, 7 },
//     { 5, 11, 9, 0, 8 },
//     { 0, 7, 3, 4, 0 },
//     { 5, 8, 2, 6, 5 },
//     { 7, 3, 6, 0, 2 }
// };


int[,] grid = new int[,]
{
    { 0, 3, 8, 5, 7 },
    { 5, 11, 9, 0, 8 },
    { 0, 7, 3, 4, 0 },
    { 5, 8, 2, 6, 5 },
    { 7, 3, 6, 0, 2 }
};
Bitmap bitmap = Converter.MakeBitmap(grid);
bitmap.Save("newImage.png");
Converter.RotateImage45Degrees(bitmap, "newImage_rotated45d.png");