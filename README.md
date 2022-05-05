# mdpost  
simple static markdown renderer for blogs and simple websites
# About
This is a very simple asp.net core app for posting static markdown files.  
There are a lot of hardcoded variables including templates, menu items, titles, and other things. If you want to use it, you can rebuild it for yourself.  
# Requirements
- .NET Core 6 SDK - to build and run the project  
- ASP.NET Core runtime - to run the project  
## How to run?
- Download the source code, and modify it if you want. Run using dotnet run --project <path>.  
- If you want to run a compiled project using the DLL file, use 
- the "dotnet publish" command.  
- Creating the first post  
- Create a folder called "posts" inside the wwwroot folder  
- Create index.md file  
Done!  
To create a new post just create another file. You can reach it using its name as a route (for contacts.md route will be website.com/contacts)
BUT you can't use nested folders for your posts (at least for now), so every post should be located in the posts folder.  
