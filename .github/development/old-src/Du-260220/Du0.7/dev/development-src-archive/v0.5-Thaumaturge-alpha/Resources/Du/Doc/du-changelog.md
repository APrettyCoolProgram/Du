# Du: Changelog

## Version 0.5
> Development version for Thaumaturge-alpha


## Version 0.4
> Development version for Archiwizator v1.0

#### v0.4.21 (2021-02-01)
* `ADDED` DuFont.cs

#### v0.4.21027.1358 (2021-01-27)
* `INFO` Initial v0.4 branch release

## Version 0.3
> Development version for Sobchak-alpha

#### v0.3.21027.1317 (2021-01-27)
* `INFO` Final 0.3.x.x branch release
* `ADDED` DuLabel.cs
* `ADDED` DuLabel.RefreshContent()
* `ADDED` DuTextBlock.cs
* `ADDED` DuTextBlock.RefreshContent()
* `ADDED` DuTextBox.cs
* `ADDED` DuTextBox.RefreshContent()
* `MODIFIED` Code and comment cleanup
* `REMOVED` DuArray.ToString()

#### v0.3.21026.1450 (2021-01-26)
* `INFO` Code and comment cleanup
* `RENAMED` DuSha.cs -> DuSha256.cs

#### v0.3.21025. (2021-01-25)
* `MODIFIED` DuSHA.cs methods
* `ADDED` DuApplication.GetVersionAssembly()
* `ADDED` DuApplication.GetVersionFile()

#### v0.3.21025.1929 (2021-01-25)
* `RENAMED` DuApplication.GetApplicationAssemblyName() -> DuApplication.GetAssemblyName()
* `ADDED` DuApplication.GetVersionAssembly()
* `ADDED` DuApplication.GetVersionFile()
* `ADDED` DuApplication.GetVersionInformational()
* `ADDED` DuApplication.GetVersionProduct()

#### v0.3.21021.1518 (2021-01-20)
* `FIXED` Du.Application.GetApplicationAssemblyName(): This was getting the *executing* assembly name, not the *entry* assembly name, so it was always returning "Du".
* `REMOVED` CONTROL/DuImage.cs

#### v0.3.21020.1540 (2021-01-20)
* `INFO` Comment cleanup
* `ADDED` CONTROL/DuImage.cs
* `ADDED` UTILITIES/DuSobchak.cs

#### v0.3.21020.1433 (2021-01-20)
* `INFO` Mostly comment and framework cleanup
* `ADDED` CONTROL/
* `RENAMED` DUTILITIES/ -> UTILITIES/

#### v0.3.21020.1433 (2021-01-20)
* `ADDED` CONTROL/
* `MOVED` WPF.DuTextBox.cs -> CONTROL.DuTextBox.cs 
* `MODIFIED` Added a note to Du.WPF.DuMsgBox becuase this is being back-burnered for now, but I don't want to remove the functionality in the event that it's useful at some point in the future.
* `REMOVED` License header information for .md and .xml files
* `REMOVED` WPF.DuWindow.cs, since it's not being used for anything and is just creating clutter.

## Version 0.2
> Development version for Archiwizator v0.905b

## Version 0.1
> Development version for Archiwizator-alpha

## Version 0.0
> Development version for Kompressor