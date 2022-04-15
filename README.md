# mdpost
simple static markdown renderer for blogs and simple websites

## About  
This is very simple asp.net core app for posting static markdown files.  
There's a lot of hardcoded variables including templates, menu items, titles and other things.
If you ACTUALLY want to use it, you can rebuild it for yourself.  

## Requirements

.NET Core 6 SDK - to build and run project
ASP.NET Core runtime - to run project

## How to run?
Download source code, modify it if you want.
Run using `dotnet run --project <path>`.  
If you want to compile it, use `dotnet publish` command.

## Creating first post  
- Create folder called "posts" in the same place where binaries located (/bin/posts)
- Create `index.md` file
- Done!
- To create new post just create another file. You can reach it using it's name as route (for `contacts.md` route will be `website.com/contacts`)  

BUT you can't use nested folders for your posts (at least for now), so every post should be located in the `posts` folder.

## Roadmap

I am still working on this project, so that's not final version.  
In the future I will add some features:

- Commandline args for configs (customizable urls, ports and other)
- Nested folders
- Simple API for posting
- View counter
- Maybe comments (MAYBE)
