### **v3.2.0.0**
-> [FIX] - Fix how the selected path is shown and add at the end of the path '/';<br />
-> [DEV] - Add validation to allow selecting only a project or a project item, except for solution;<br />

### **v3.1.0.0**
-> [FIX] - Adjust/fix the solution selected item when the user selects a different project for the next x time after the first selection;<br />
-> [DEV] - Add method to get selected project item path;<br />
-> [DEV] - Add folder name check method;<br />
-> [DEV] - Adjust message for ℹ symbol;<br />

### **v3.0.0.0**
-> Window small cosmetic adjustments;<br />
-> Add link between create operation/handler and operation/handler inheritance;<br />
-> Add bottom info bar;<br />
-> Add `SolutionSettingsStoreService` solution settings store;<br />
-> Add version check helper. Add JSON deserialization using `System.Text.Json`;<br />
-> Adjust location for `ResourceMessage`;<br />
-> Change visibility for `ReqInfoCodeType` enum;<br />
-> Adjust logger file location and add new method in the file logger;<br />
-> Add `MoreInfo` node on get manifes info;<br />
-> Add solution key store and build keys in unique format;<br />

### **v2.1.0.0**
-> Add optional input field: `Handler Inheritance`;<br />

### **v2.0.0.0**
-> Fix injection IStringLocalizer ctor parameter in validator ctor on option 'All operation in one file';<br />
-> Add tooltip information on textboxes and some checkboxes to clarify what inputs are for and what the result will be;<br />
-> Add file logger messages and adjust logger to use also file logger and current package data;<br />
-> Adjust and add new param check in extension methods;<br />
-> Cleanup code and small refactor;<br />
-> Add a helper for 'extension.vsixmanifest' to retrieve info from the file;<br />

### **v1.1.0.0**
-> Adjust message store and add more logs; <br />
-> Add/implement current Visual Studio theme in main window; <br />
-> Add more fields and options on create user defined operation; <br />
-> Improved some code execution.
