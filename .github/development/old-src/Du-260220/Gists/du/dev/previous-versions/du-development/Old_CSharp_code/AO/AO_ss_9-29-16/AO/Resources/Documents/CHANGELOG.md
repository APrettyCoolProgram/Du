# AO Changelog


##### 00.52.160928 - SEPTEMBER 28, 2016
* For use with AVATOOL HELPDESK
* Changed "AOControl.ChangeState" to include 3 overload methods that:
  * Changes a state for a type of control on a form, with possible exclusions
  * Changes a state for a type of control in another control, with possible exclusions
  * Changes a state for a list of controls in in a form
* Created a list of controls whose states can be changed (allowAllChanges):
  * Button
  * Label
  * CheckBox
  * ComboBox
  * TabControl
* Removed the following methods, since they are just too simplistic to be part of a framework:
  * AOArray.AsFile
  * AOArray.AsList
  * AOArray.Resize
  * AODictionary.AsFile
  * AODictionary.Extract (copy of ListOfKeysOrValues)
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
* Modified the following methods, to simplify them a bit:
  * AOArray.Count
* Renamed the following methods for clarity:
  * AOArray.Count -> AOArray.CountCharacters
* Code and comment cleanup


##### 00.51.160926 - SEPTEMBER 26, 2016
* For use with Parcel
* Added "AOEmail.cs", which handles email messaging
  * Added ".BuildPackage", which builds everything for an email message EXCEPT the list of emails to send to, and the
    attachments that will be sent
  * Added ".SendEmail", which sends an email
* Added "AOTimer", which will handle timer functionality (currently not used)
* Added "AOWindowsUI", which will handle Windows UI functionality (currently not used)
* Code and comment cleanup


##### 00.50.160923 - SEPTEMBER 23, 2016
* Initial release
* For use with Glint



[Added] for new features.
[Changed] for changes in existing functionality.
[Deprecated] for once-stable features removed in upcoming releases.
[Removed] for deprecated features removed in this release.
[Fixed] for any bug fixes.
[Security] to invite users to upgrade in case of vulnerabilities.