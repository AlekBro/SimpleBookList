
## SimpleBookList Web App with using Angular 4.0.0 (from Angular CLI 1.0)

https://angular.io/docs/ts/latest/cli-quickstart.html

-----------------------------------------------------------------------------------

https://github.com/angular/angular-cli


Updating Angular CLI: 
To update Angular CLI to a new version, you must update both the global package and your project's local package.

Global package:
```bash
npm uninstall -g @angular/cli
npm cache clean
npm install -g @angular/cli@latest
```

Local project package:
```bash
rm -rf node_modules dist # use rmdir /S/Q node_modules dist in Windows Command Prompt; use rm -r -fo node_modules,dist in Windows PowerShell
npm install --save-dev @angular/cli@latest
npm install
```

-----------------------------------------------------------------------------------

Angular CLI version:
```bash
ng -v
```

@angular/cli: 1.0.0
node: 6.9.5
os: win32 x64
@angular/common: 4.0.0
@angular/compiler: 4.0.0
@angular/core: 4.0.0
@angular/forms: 4.0.0
@angular/http: 4.0.0
@angular/platform-browser: 4.0.0
@angular/platform-browser-dynamic: 4.0.0
@angular/router: 4.0.0
@angular/cli: 1.0.0
@angular/compiler-cli: 4.0.0



Generate a new project and skeleton application by running the following commands:
```bash
 ng new WebAngFromCLI2
```
(25.03.17)


Go to the project directory and launch the server:
```bash
cd WebAngFromCLI2
ng serve
```
The ng serve command launches the server, watches our files, 
and rebuilds the app as you make changes to the files.


-----------------------------------------------------------------------------------

http://stackoverflow.com/questions/37409912/how-to-install-jquery-using-typings
https://www.npmjs.com/package/@types/jquery

You can install jquery with the command:

```bash
npm install --save @types/jquery
```




https://www.npmjs.com/package/@types/datatables.net
```bash
npm install --save @types/datatables.net
```

This package contains type definitions for JQuery DataTables (http://www.datatables.net).


https://basarat.gitbooks.io/typescript/docs/types/@types.html

After installation, no special configuration is required really. You just use it like a module e.g.:
```ts
import * as $ from "jquery";
```
#### Not work!

--------------------------------------

#### WORK FOR ME:
```ts
declare var $: any;
```
```html
  <!--jQuery Core 3.1.1 -->
  <script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
```
--------------------------------------

-----------------------------------------------------------------------------------


-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------

https://github.com/swimlane/ngx-datatable

```bash
npm i @swimlane/ngx-datatable --save
```




