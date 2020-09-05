readme for OkumaProject

(Jake, 8/26/20)
I initially did the project in Visual Basic, but the necessary build configurations aren't available in visual studio for the Visual Basic language, and it auto compiles into an x86 architecture, which is breaking the program, so I think we'll need a C# program to make this happen (Yay for the language!) but the lack of documentation for C# specifically will be a challenge. I'm going to create a second project in C# that we can try to get working.

Target device specifications:
API VERSION: 1.19
.NET FRAMEWORK VERSION: 2.0
TARGET WINDOWS ARCHITECTURE: x32 bit

Austin told me that the machines themselves have a startup program that monitors and makes sure the required programs are active, otherwise it'll initiate a restart/shutdown. Our program will be on there, so making sure this program initiates on startup shouldn't be an issue.

Current problems needing solving:
--Making the console minimize when the variable hasn't changed
--Making the console maximize when the variable has changed, and having the user input to make it minimize again.

The OkumaOpenAPI folder also has a help folder with the necessary documentation in .chm files. MC or Machine Center's are mills. It's just what people in the industry call mills, and I'm pretty sure we'll be testing on a mill, so using the MC documentation is probably best.

(Jake, 9/5/20)
To get the git submodule (Okuma API), use the commands
git submodule init (initializes their respective git repos)
git submodule update (pulls from repos and updates necessary files)