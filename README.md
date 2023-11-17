## Change grayScale image depth
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