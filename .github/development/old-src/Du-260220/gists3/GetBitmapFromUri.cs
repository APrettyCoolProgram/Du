// Get a bitmap image from a URI - image has to be a Resource.
public static BitmapImage GetBitmap(string imagePath)
{
    return new BitmapImage(new Uri("pack://application:,,,/projectName;resourceDirectoryName/" + imagePath));
}