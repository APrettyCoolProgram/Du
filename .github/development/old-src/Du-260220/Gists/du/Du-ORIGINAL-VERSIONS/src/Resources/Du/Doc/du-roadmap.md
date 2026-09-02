# DuButton.cs
## DuButton.Template()
### Cannot pass `HorizontalContentAlignment` or `VerticalContentAlignment` as parameters
* Passing `HorizontalContentAlignment` or `VerticalContentAlignment` as parameters results in a "The type or namespace name 'type/namespace' could not be found (are you missing a using directive or an assembly reference?" error.
* Fix: Refactor so `HorizontalContentAlignment btnhorizontalContentAlignment` can be passed, or potentially just have everything done by a generic "DuControl.Template()" method.