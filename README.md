# Change grayScale image depth
By this project you can convert a gray scale image depth to `1`,`4` and `8` bit.

### Usage
Enter your image path on `Program.cs` prepared code
```csharp
Bitmap originalImage = new("INPUT_PATH");
```
Then you can use your prepared object using `GetInDepth` method.

To convert image you can use a enum named `Step` with following values
```csharp
enum Step
{
    Depth1 = 1,
    Depth4 = 4,
    Depth8 = 8,
}
```


### Example
```csharp
Bitmap originalImage = new("mainGrayScaleImage.png");
GetInDepth(originalImage, Step.Depth1, "1_bitDepth.jpg");
```
<hr>

# Make a bitmap
To make a bit map i have prepared a method named `MakeBitmap`
### Example
```csharp
int[,] grid = new int[,]
{
    { 0, 3, 8, 5, 7 },
    { 5, 11, 9, 0, 8 },
    { 0, 7, 3, 4, 0 },
    { 5, 8, 2, 6, 5 },
    { 7, 3, 6, 0, 2 }
};
Bitmap bitmap = Converter.MakeBitmap(grid);
```

<hr>


# Image rotator 45 degree
I have made a method to rotate a image 45 degree. I know the code could have more object oriented design but now it's out of context.

### Example

```csharp
Bitmap originalImage = new("INPUT_PATH");
Converter.RotateImage45Degrees(bitmap, "OUTPUT");
```

<hr>

# Convert RGB to Grayscale
In the last but not least I had prepared a method to convert a RGB image to Grayscale named `ConvertToGrayscale`.

### Example

```csharp
Converter.ConvertToGrayscale(originalImage);
```

It will return a bitmap and you can use that output
