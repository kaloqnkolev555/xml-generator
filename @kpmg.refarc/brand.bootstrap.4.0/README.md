## KPMG Branding Bootstrap
A package containing the KPMG Bootstrap Theme with Default KPMG colors, based on Bootstrap v4.0. Includes styling for: Headers, Buttons, Typography, Table grid, Form controls, Pagination, Alerts, Labels, Badges, Progress bars, Wells, Modals, Popovers, Tooltips, Jumbotron and Carousel.

## Table of contents

- [Installation](#installation)
- [What's included](#whats-included)
- [Demo](#demo)
- [Usage with Angular](#usage-angular)
- [KPMG Font](#kpmg-font)
- [Logo](#logo)
- [Versioning](#versioning)

<a name="installation"></a>
## Installation

Install using npm:

``` BASH
npm install "@kpmg.refarc/brand.bootstrap.4.0" --registry https://npm.de.kworld.kpmg.com
```

Don't forget the quotation marks around the package name! They are needed because of the dot in the package scope name.

<a name="whats-included"></a>
## What's included

Within the download you'll find the following directories, providing also both compiled and minified variations. You'll see something like this:

``` BASH
brand.bootstrap.4.0/
├── css/
├── fonts/
├── images/
├── js/
└── scss/
```

We provide compiled CSS and JS (`bootstrap.*`), as well as compiled and minified CSS and JS (`bootstrap.min.*`). CSS [source maps](https://developers.google.com/web/tools/chrome-devtools/debug/readability/source-maps) (`bootstrap.*.map`) are available for use with certain browsers' developer tools.

The `bootstrap.*` files have been modified to match the KPMG Branding. There are also KPMG-specific files such as ``kpmg-logo.css``, ``kpmg-web-light.css`` and ``kpmg-icons.css``.

### CSS files

The CSS files are compiled from the SCSS files. The main Bootstrap file is ``bootstrap.css`` and its minified version ``bootstrap.min.css``. The KPMG font is included in ``kpmg-web-light.css`` (also has minified version). The ``*map`` files are not included in the list below for brevity.

``` BASH
css/
├── bootstrap-grid.css
├── bootstrap-grid.min.css
├── bootstrap-reboot.css
├── bootstrap-reboot.min.css
├── bootstrap.css
├── bootstrap.min.css
├── kpmg-icons.css
├── kpmg-icons.min.css
├── kpmg-logo.css
├── kpmg-logo.min.css
├── kpmg-web-light.css
└── kpmg-web-light.min.css
```

### SASS files

All Bootstrap files are available in the ``scss`` directory. You can import just ``bootstrap.scss``. The names of some nested Bootstrap  ``_*.scss`` files are not included in the list below for brevity. You can check Bootstrap's documentation or repository for them.

``` bash
scss/
├─── mixins/ - files not shown, contains Bootstrap mixins
├─── utilities/ - files not shown, contains Bootstrap utilities
├─── palettes/
│    ├── _other.scss
│    └── _web.scss
├── _alert.scss
├── _badge.scss
├── _breadcrumb.scss
├── _button-group.scss
├── _buttons.scss
├── _card.scss
├── _carousel.scss
├── _close.scss
├── _code.scss
├── _custom-forms.scss
├── _dropdown.scss
├── _font-variables.scss
├── _forms.scss
├── _functions.scss
├── _grid.scss
├── _icon-variables.scss
├── _images.scss
├── _input-group.scss
├── _jumbotron.scss
├── _KPMG_config.scss
├── _KPMG_overrides.scss
├── _list-group.scss
├── _media.scss
├── _mixins.scss
├── _modal.scss
├── _nav.scss
├── _navbar.scss
├── _pagination.scss
├── _popover.scss
├── _print.scss
├── _progress.scss
├── _reboot.scss
├── _root.scss
├── _tables.scss
├── _tooltip.scss
├── _transitions.scss
├── _type.scss
├── _utilities.scss
├── _variables.scss
├── bootstrap.scss
├── bootstrap-grid.scss
├── bootstrap-reboot.scss
├── kpmg-icons.scss
├── kpmg-logo.scss
└── kpmg-web-light.scss
```

### Fonts

The folder contains the KPMG Light and KPMG icons font files. They are being used by ``kpmg-web-light.[scss|css]`` and ``kpmg-icons.[scss|css]``.

``` bash
fonts/
├── kpmg-icons.eot
├── kpmg-icons.svg
├── kpmg-icons.ttf
├── kpmg-icons.woff
├── KPMG-Web-Light.eot
├── KPMG-Web-Light.html
├── KPMG-Web-Light.svg
├── KPMG-Web-Light.ttf
├── KPMG-Web-Light.woff
└── KPMG-Web-Light.woff2
```

### Images

The folder contains the KPMG logo images. The SVG is being used by ``kpmg-logo.[scss|css]``.

``` bash
images/
├── KPMG-logo-blue.png
├── KPMG-logo-blue.svg
├── KPMG-logo-white.png
└── KPMG-logo-white.svg
```

### JS

The folder contains the JavaScript files from Bootstrap. The map files are not shown below for brevity.

``` bash
js/
├───dist/
│   ├── alert.js
│   ├── bootstrap.bundle.js
│   ├── bootstrap.bundle.min.js
│   ├── bootstrap.js
│   ├── bootstrap.min.js
│   ├── button.js
│   ├── carousel.js
│   ├── collapse.js
│   ├── dropdown.js
│   ├── index.js
│   ├── modal.js
│   ├── popover.js
│   ├── scrollspy.js
│   ├── tab.js
│   ├── tooltip.js
│   ├── util.js
│       
└───src/
│   ├── alert.js
│   ├── button.js
│   ├── carousel.js
│   ├── collapse.js
│   ├── dropdown.js
│   ├── index.js
│   ├── modal.js
│   ├── popover.js
│   ├── scrollspy.js
│   ├── tab.js
│   ├── tooltip.js
└── └── util.js
```

<a name="#demo"></a>
## Demo

You can see a demo here -> http://ux.de.kworld.kpmg.com/bootstrap

<a name="usage-angular"></a>
## Usage with Angular

You can use either the CSS or the SASS files depending on your preference.

The files you must include are the main Bootstrap file (either ```bootstrap.css```, ```bootstrap.min.css``` or ```bootstrap.scss```)
and the font file (```kpmg-web-light.css```, SCSS and minified versions also available).

All the examples are intended for Angular 6+ and Angular CLI 6+. However, the package can also be used in earlier versions - just adjust the paths accordingly to be used in ``.angular-cli.json``.

### SASS

To make Angular CLI work with SASS:

**With Angular CLI 1.x**
1. Run ``ng set defaults.styleExt scss``  to tell the Angular CLI to start processing .scss files.
2. Rename ``styles.css`` to ``styles.scss`` both the file and in ``.angular-cli.json``.

**With Angular CLI 6.x+**
1. Run ``ng config schematics.@schematics/angular:component.styleext scss``.
2. Rename ``src/styles.css`` to ``src/styles.scss`` both the file and in ``angular.json``.

**Using the package:**
1. Add in the Angular CLI configuration file (``.angular-cli.json`` for 1.x or ``angular.json`` for 6.0+) after ``styles`` so it can be easily imported:
``` JSON
"stylePreprocessorOptions": {
  "includePaths": [
      // v1.x
      "../node_modules/@kpmg.refarc/brand.bootstrap.4.0/scss"

     // v6+
     "node_modules/@kpmg.refarc/brand.bootstrap.4.0/scss"
   ]},
```
2. Import Bootstrap into ``styles.scss``:
``` css
@import 'bootstrap';
```

and then you can just use Bootstrap classes in your Angular components and they will be KPMG styled.

You can also use Bootstrap mixins in your component styles to reduce repetition when you have many elements with the same classes. Example:

``` css
/* You need these threee imports for the mixins */
@import 'functions';
@import 'variables';
@import 'mixins';

.example-row {
   @include make-row();
}

/* Same result as applying class="col-6 col-lg-8" */
.example-column {
  @include make-col-ready();
  @include make-col(6);
  @include media-breakpoint-up(lg) { @include make-col(8); }
}
```

Don't forget to add the font (see [KPMG Font](#kpmg-font)).

### CSS

Add ``bootstrap.css`` to the ``styles`` array in ``angular.json``.

``` json
"styles": [
  ...
  "node_modules/@kpmg.refarc/brand.bootstrap.4.0/css/bootstrap.css"
  ...
],
```

and then you can just use Bootstrap classes in your Angular components and they will be KPMG styled.

Don't forget to add the font (see [KPMG Font](#kpmg-font)).

### JS

You need jQuery to run the Bootstrap JS files.

1. Install it through npm

``` bash
npm install jquery
```

2. Add it to ``scripts`` in ``angular.json`` before ``bootstrap.js``:

``` json
"scripts": [
  ...
  "node_modules/jquery/dist/jquery.js",
  "node_modules/@kpmg.refarc/brand.bootstrap.4.0/js/dist/bootstrap.js"
  ...
],
```

<a name="#kpmg-font"></a>
## KPMG Font 

You can use either the css or the scss files. Add the font files to the ``styles`` array in ``angular.json``. Example with scss:
```  json
"styles": [
  ...
  "node_modules/@kpmg.refarc/brand.bootstrap.4.0/scss/kpmg-web-light.scss"
  ...
],
```
The font is used for ``<h1>`` elements.

<a name="#logo"></a>
## Logo

You can use either the images directly or use the ``kpmg-logo`` files.

1. Add the logo styles to ``angular.json``:
``` json
"styles": [
  ...
  "node_modules/@kpmg.refarc/brand.bootstrap.4.0/scss/kpmg-logo.scss"
  ...
],
```
2. Use the base class ``.logo-svg`` and a colored version - ``.logo-svg-blue`` or ``.logo-svg-white``. Control the size using ``font-size``.
```html
<span alt="KPMG" class="logo-svg logo-svg-blue" style="font-size: 150px;"></span>
```

<a name="#versioning"></a>
## Versioning
The version number matches the Bootstrap version being used since v4 of the package.

### Current Version

| Version       | Date           | Description                  |
| ------------- |:--------------:|:----------------------------:|
| 4.1.3         | 07-Dec-2018    | upgrade to Bootstrap 4.1.3  |

**Previous Versions**

| Version       | Date           | Description                                 |
| ------------- |:--------------:|:-------------------------------------------:|
| 4.0.0         | 30-Nov-2018    | matches Bootstrap 4.0.0, sync versions      |
| 2.0.0         | 05-Nov-18      | matches Bootstrap 4.0.0                     |
