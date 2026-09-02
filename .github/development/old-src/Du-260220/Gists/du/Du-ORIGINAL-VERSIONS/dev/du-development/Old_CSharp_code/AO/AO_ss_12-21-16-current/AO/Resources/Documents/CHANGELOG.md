# AO Changelog

##### 00.53.04.161220- December 20, 2016
* Code and comment cleanup for the following methods:
  * AOFile
  * AOForm
  * AOFormMessage
  * AOFormSettings
  * AOGlobal
  * AOJSON

##### 00.53.03.161219- December 19, 2016
* Code and comment cleanup for the following methods:
    * AODictionary
    * AODirectory
    * AOEmail

##### 00.53.02.161218- December 18, 2016
* Code and comment cleanup for the following methods:
  * AOArray
  * AOControl
  * AOControl.Btn
  * AOControl.Cbx
  * AOControl.Flp
  * AOControl.Lbl
  * AOControl.Pnl
  * AOControl.Tbx
* Renamed:
  * AOArray.CountCharacters -> AOArray.CountChars
  * AOArray.To2DArrays-> AOArray.ToMultiArray
  * AOArray.Remove -> AOArray.RemoveItem
* Added:
  * AOArray.CountElements (no code yet)

##### 00.53.01.161213- December 13, 2016
* Fixed AOControls.Paint

##### 00.53.00.161114- November 14, 2016
* Broke the control logic in AOControl out to the following classes:
	* AOControl.Btn.cs - Buttons
	* AOControl.Cbx.cs - CheckBoxes
	* AOControl.Flp.cs - FlowLayoutPanels
	* AOControl.Lbl.cs - Labels
	* AOControl.Pnl.cs - Panels
	* AOControl.Tbx.cs - TextBoxes

##### 00.53.00.161028- October 28, 2016
* Signficant re-write of how files are read and cleaned.
* Added the following Methods:
	* AODictionary.BuildCleaningRules, to build cleaning settings for files. There are two overloaded methods
	* AOFile.ReadAsString, to read files in as strings
	* AOString.ToList, for converting strings to lists via a delimiter
* Modified the following methods
	* Renamed AOFile.Read -> AOFile.ReadToList, since there will be seperate methods for different types of reads
	* AOString.ToArray now can convert using any delimiter, not just newlines
* Added the following classes
  * AOWeb.cs, for web stuff
* Modified the following classes
	* Renamed AOMessageBox.cs -> AOMessage.cs, since this will do more than just MessageBoxes
* Added XML comments back in. They are helpful!

##### 00.52.00.161004- October 4, 2016
* Added the following classes
	* AOJSON.cs - serializing/deserializing JSON files (not implemented yet)
* Modified the following classes
	* AOControls.cs - now contains additional control types (CheckBox, ComboBox, TabControl) whose states can be changed
* Removed the following classes
  * None
* Added the following methods
  * AOArray.ToJaggedArray - will create jagged arrays (not implemented yet)
  * AOSystem.GetWindowsVersion - gets the version of Windows
* Modified the following methods
  * AOControl.ChangeState now has three overloads:
	  * Change a state for a type of control on a form, with possible exclusions
	  * Change a state for a type of control in another control, with possible exclusions
	  * Change a state for a list of controls in in a form
  * AOArray.Count now just counts characters
  * AOArray.Count has been renamed AOArray.CountCharacters
  * AODirectory.Create now has an option for the trailing slash
  * Moved AODirectory.GetSpecial to AOSystem.Directory, since it makes more sense there
  * Moved AOFile.EmbeddedAsList and AOFile.ExternalAsList to ToList, since they belong there.
  * Renamed AOSystem.GetSpecialDirectory ->AOSystem.GetSystemDirectory
  * Renamed AOSystem.GetBitLevel -> AOSystem.Is64Bit
  * Rewrote AOSystem.Is64Bit to use Environment.Is64BitOperatingSystem, but retained pervious method
  * Renamed AOList.Remove -> AOList.Clean, because that's what it does
* Removed the following methods for being too simple for this framework
  * AOArray.AsFile
  * AOArray.AsList
  * AOArray.Resize
  * AODictionary.AsFile
  * AODictionary.GetSpecificKeyOrValue
  * AODictionary.ListOfKeysOrValues
  * AOFile.AppendAllText
  * AOFile.Count
  * AOFile.GetExt
  * AOFile.GetName
  * AOFile.RndLine
  * AOList.ToDictionary
  * AOString.AsColor
  * AOString.Count
  * AOString.Replace
  * AOString.ToFile
  * AOSystem.PauseMilliseconds
  * AOSystem.GetProgramFilesLocation
  * AOSystem.GetSystemDirectory now finds all of the special Windows directories
* Removed the following methods for having duplicate functionality
	* AODictionary.Extract - same functionality as AODictionary.ListOfKeysOrValues
	* AODictionary.Remove - same functionality as AODictionary.Clean
	* AOFile.EmbeddedAsList - moved to AOFile.ToList
	* AOFile.ExternalAsList - moved to AOFile.ToList
* Removed XML Intellisense comments, it was just too much! Replaced with standard coding comments
* Beefed up comments across the board

##### 00.51.160926 - SEPTEMBER 26, 2016 - For use with Parcel .90
* Added "AOEmail.cs", which handles email messaging
  * Added ".BuildPackage", which builds everything for an email message EXCEPT the list of emails to send to, and the
	attachments that will be sent
  * Added ".SendEmail", which sends an email
* Added "AOTimer", which will handle timer functionality (not currently implemented)
* Added "AOWindowsUI", which will handle Windows UI functionality (not currently implemented)
* Code and comment cleanup

##### 00.50.160923 - SEPTEMBER 23, 2016 - For use with Glint .90
* Initial release



[Added] for new features.
[Changed] for changes in existing functionality.
[Deprecated] for once-stable features removed in upcoming releases.
[Removed] for deprecated features removed in this release.
[Fixed] for any bug fixes.
[Security] to invite users to upgrade in case of vulnerabilities.