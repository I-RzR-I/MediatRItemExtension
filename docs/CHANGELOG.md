### **v3.5.0.0**
-> [DEV] - Add the possibilitiy to create `Stream` operation;<br />
-> [DEV] - Add the possibilitiy to select the operation bp: `Class` or `Record`;<br />
-> [DEV] - Add validation for physical item existence (it may be excluded from the solution);<br />
-> [DEV] - Add the possibilitiy to see the changelog info;<br />

### **v3.4.0.0**
-> [FIX] - Fix possible cases when the cancellation token is not added;<br />
-> [DEV] - Add default value for cancellation token on async action;<br />

### **v3.3.0.0**
-> [DEV] - Add validation for maximum allowed path length;<br />

### **v3.2.0.0**
-> [FIX] - Fix how the selected path is shown and add at the end of the path '/';<br />
-> [DEV] - Add validation to allow selecting only a project or a project item, except for solution;<br />

### **v3.1.0.0**
-> [FIX] - Adjust/fix the solution selected item when the user selects a different project for the next x time after the first selection;<br />
-> [DEV] - Add method to get selected project item path;<br />
-> [DEV] - Add folder name check method;<br />
-> [DEV] - Adjust message for ℹ symbol;<br />

### **v3.0.0.0**
-> [DEV] - Window small cosmetic adjustments;<br />
-> [DEV] - Add link between create operation/handler and operation/handler inheritance;<br />
-> [DEV] - Add bottom info bar;<br />
-> [DEV] - Add `SolutionSettingsStoreService` solution settings store;<br />
-> [DEV] - Add version check helper. Add JSON deserialization using `System.Text.Json`;<br />
-> [DEV] - Adjust location for `ResourceMessage`;<br />
-> [DEV] - Change visibility for `ReqInfoCodeType` enum;<br />
-> [DEV] - Adjust logger file location and add new method in the file logger;<br />
-> [DEV] - Add `MoreInfo` node on get manifes info;<br />
-> [DEV] - Add solution key store and build keys in unique format;<br />

### **v2.1.0.0**
-> [DEV] - Add optional input field: `Handler Inheritance`;<br />

### **v2.0.0.0**
-> [FIX] - Fix injection IStringLocalizer ctor parameter in validator ctor on option 'All operation in one file';<br />
-> [DEV] - Add tooltip information on textboxes and some checkboxes to clarify what inputs are for and what the result will be;<br />
-> [DEV] - Add file logger messages and adjust logger to use also file logger and current package data;<br />
-> [DEV] - Adjust and add new param check in extension methods;<br />
-> [DEV] - Cleanup code and small refactor;<br />
-> [DEV] - Add a helper for 'extension.vsixmanifest' to retrieve info from the file;<br />

### **v1.1.0.0**
-> [DEV] - Adjust message store and add more logs; <br />
-> [DEV] - Add/implement current Visual Studio theme in main window; <br />
-> [DEV] - Add more fields and options on create user defined operation; <br />
-> [DEV] - Improved some code execution.
