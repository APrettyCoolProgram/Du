# Du: Changelog

## v0.10
> Development version for Thaumaturge
#### v0.10.21126.1409 (2021-06-23)
* * `MODIFIED` DuApplication.cs: Simplified everything into a single method.

## v0.9
> Development version for Thaumaturge

#### v0.9.21116.1845 (2021-04-26)
* `ADDED` DuFont.Load()

## v0.8
> Development version for APrettyCoolDigitalAssetManager-beta

## v0.7
> Development version for APrettyCoolDigitalAssetManager-alpha

#### v0.7.21090.1314 (2021-03-31)
* `INFO` Code and comment cleanup.
* `MODIFIED` Renamed  DuApplication.GetAssemblyName() => DuApplication.GetEntryAssemblyName()
* `MODIFIED` Renamed  DuApplication.GetAssemblyVersion() => DuApplication.GetEntryAssemblyVersion()
* `MODIFIED` Renamed  DuApplication.GetEntryVersionFile() => DuApplication.GetEntryAssemblyFileVersion()
* `MODIFIED` Renamed  DuApplication.GetVersionInformational() => DuApplication.GetEntryAssemblyInformationalVersion()
* `MODIFIED` Renamed  DuApplication.GetVersionProduct() => DuApplication.GetEntryAssemblyProductVersio()

#### v0.7.21089.1354 (2021-03-30)
* `INFO` License header update

#### v0.7.21087.2349 (2021-03-28)
* `INFO` Code and comment cleanup.
* `FIXED` DuJson.SerializeFile() and DuJson.SerializeString() were actually the Deserialize methods. Doh!
* `MODIFIED` Renamed  DuJson.SerializeFile() => DuJson.DeserializeFile()
* `MODIFIED` Renamed  DuJson.SerializeString() => DuJson.DeserializeString()
* `ADDED` DuJson.SerializeToFormattedString()
* `ADDED` DuJson.SerializeToMinifiedString()
* `ADDED` DuJson.WriteFormattedJsonToFile()
* `ADDED` DuJson.WriteMinifiedJsonToFile()

#### v0.7.21085.xxxx (2021-03-26)
* `INFO` Code and comment cleanup.
* `MODIFIED` du.licenseheader

#### v0.7.21085.1320 (2021-03-26)
* `INFO` Code and comment cleanup.
* `MODIFIED` du.licenseheader
* `MODIFIED` DuJson.cs

#### v0.7.21082.1358 (2021-03-23)
* `INFO` Code and comment cleanup.
* `ADDED` /Resources/Doc/du-roadmap.md

#### v0.7.21081.2130 (2021-03-22)
* `INFO` Code and comment cleanup.
* `ADDED` DuButton.cs
* `ADDED` DuButton.Template()
* `ADDED` DuButton.BuildArray()

## v0.6
> Development version for MagicArenaDeckEditorAdvancedSearchSyntaxGenerator-alpha

## v0.5
> Development version for Thaumaturge-alpha

## v0.4
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

## v0.2
> Development version for Archiwizator v0.905b

## v0.1
> Development version for Archiwizator-alpha

## v0.0
> Development version for Kompressor