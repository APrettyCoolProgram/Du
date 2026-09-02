// Choose a filename to open.
public static string SelectFileName()
{
    var openFileDialog = new Microsoft.Win32.OpenFileDialog

    return openFileDialog.ShowDialog() == true
        ? openFileDialog.FileName
        : "ERROR LOADING FILE - There was an error trying to load:\n\n" + openFileDialog.FileName;
}
  
// Choose a filename to open from a specific directory.
public static string SelectFileInSpecificDirectory(string initialDirectory)
{
    var openFileDialog = new Microsoft.Win32.OpenFileDialog
    {
        InitialDirectory = initialDirectory
    };
 
    return openFileDialog.ShowDialog() == true
        ? openFileDialog.FileName
        : "ERROR LOADING FILE - There was an error trying to load:\n\n" + openFileDialog.FileName;
}

// Choose a filename to open, but only with a specific file extention - a .csv in this example.
public static string SelectFileWithSpecificExtension()
{
    var openFileDialog = new Microsoft.Win32.OpenFileDialog
    {
        Title            = "Choose .csv file",
        Filter           =  "Excel files (*.csv)|*.csv|All files (*.*)|*.*",
        FilterIndex      = 1
    };
 
    return openFileDialog.ShowDialog() == true
        ? openFileDialog.FileName
        : "ERROR LOADING FILE - There was an error trying to load:\n\n" + openFileDialog.FileName;
    }
}