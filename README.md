# mdpost  
simple static markdown renderer for general purposes

# Docker support

`docker pull the1mason/mdpost:latest`

Added and enabled docker support. For now, mdpost requires editing files in the container manually.  
You can also create a volume for the container with path `/app/wwwroot/posts` to store your .md files separately.

# About
This is a very simple ASP.NET core app for posting static markdown files.  
There are a lot of hardcoded variables including templates, menu items, titles, and other things. If you want to use it, you can rebuild it for yourself.  
# Requirements
- .NET Core 6 SDK - to build and run the project  
- ASP.NET Core runtime - to run the project  
## How to run?
- Check out [wiki page](https://github.com/the1mason/mdpost/wiki) for installation instructions.
  
# To do  

  - [x] Add a dark theme
  - [x] Add syntax highlight 
  - [ ] Add CSS for each markup element (tables, checkboxes, etc.)
  - [x] Docker support
  - [ ] Move configs to appsettings.json file
  - [ ] ~~Request caching~~ Caching can be done using reverse proxy. You don't want to put this app directly to the internet anyway.
  - [ ] ~~Static HTML generation instead of dynamic rendering every time~~ Feature is useless for now
  - [ ] ~~Multiple DB support using Dapper with automatic migrations (MySQL, PostgreSQL, SQLi)~~ Too complicated for this app. We're trying to keep it simple
  - [ ] ~~RESTFul API~~ Probably later. You can just use FTP.
