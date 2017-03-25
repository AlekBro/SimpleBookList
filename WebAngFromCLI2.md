
# SimpleBookList Web App with using Angular 4.0.0 (from Angular CLI 1.0)

https://angular.io/docs/ts/latest/cli-quickstart.html

-----------------------------------------------------------------------------------

https://github.com/angular/angular-cli


Updating Angular CLI: 
To update Angular CLI to a new version, you must update both the global package and your project's local package.

Global package:

> npm uninstall -g @angular/cli
> npm cache clean
> npm install -g @angular/cli@latest

Local project package:

> rm -rf node_modules dist # use rmdir /S/Q node_modules dist in Windows Command Prompt; use rm -r -fo node_modules,dist in Windows PowerShell
> npm install --save-dev @angular/cli@latest
> npm install

-----------------------------------------------------------------------------------

Angular CLI version:
> ng -v
@angular/cli: 1.0.0
node: 6.9.5
os: win32 x64
@angular/common: 2.4.7
@angular/compiler: 2.4.7
@angular/core: 2.4.7
@angular/forms: 2.4.7
@angular/http: 2.4.7
@angular/platform-browser: 2.4.7
@angular/platform-browser-dynamic: 2.4.7
@angular/router: 3.4.7
@angular/cli: 1.0.0
@angular/compiler-cli: 2.4.7



Generate a new project and skeleton application by running the following commands:
> ng new WebAngFromCLI2
(25.03.17)


Go to the project directory and launch the server:
> cd WebAngFromCLI2
> ng serve
The ng serve command launches the server, watches our files, 
and rebuilds the app as you make changes to the files.