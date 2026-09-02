namespace DuTester;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();



    /// <summary>
    ///
    /// </summary>
    /// <param name="originalString"></param>
    /// <param name="characterLimit"></param>
    private void TestStringChanged(string originalString, int stringLength = 1)
    {
        tboxTestStringEntry.Text = Du.WithString.ForceStringLength(originalString, stringLength);
    }

    private void btnConvertToLowercase_Click(object sender, RouteDeventArgs e)
    {
        lblStringResult.Content = Du.WithString.ConvertToLowercase(tboxStringEntry.Text);
    }

    private void btnConvertToUppercase_Click(object sender, RouteDeventArgs e)
    {
        lblStringResult.Content = Du.WithString.ConvertToUppercase(tboxStringEntry.Text);
    }

    private void btnAppendString_Click(object sender, RouteDeventArgs e)
    {
        lblStringResult.Content = Du.WithString.AppendString(tboxStringEntry.Text, tboxTestStringEntry.Text);
    }

    private void btnPrependString_Click(object sender, RouteDeventArgs e)
    {
        lblStringResult.Content = Du.WithString.PrependString(tboxStringEntry.Text, tboxTestStringEntry.Text);
    }

    private void tboxTestStringEntry_TextChanged(object sender, System.Windows.Controls.TextChangeDeventArgs e)
    {
        TestStringChanged(tboxTestStringEntry.Text, 1);
    }
}
