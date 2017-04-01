# Software Engineering Labs

The labs are made available to the students using [GitHub Pages](https://pages.github.com/).

- Latest year: http://uu-im.github.io/software-engineering-labs
- Specific year: http://uu-im.github.io/software-engineering-labs/vt[YY]



## Getting started

1. Ensure you have all the dependencies.
2. Install Node
3. Install npm
4. Run `npm install`
5. Run `./build.sh` to compile source into `./tmp-www` and start dev server preview (at `http://localhost:8080`)
6. Run `./publish.sh` **with a clean working directory** to publish to GitHub Pages.
7. Note: Production builds are stored in `./` (sorry about that but it was to make GitHub Pages publishing easier).
8. The build scripts only works in bash-like environment. Sorry Windows.



### Writing new labs

The simplest way to create a set of new labs for a new year is probably to duplicate a folder of a previous year (i.e. `./src/[llyy]`). Note that the build script needs to be updated when you add a new year (see `./build.sh`). You'll trivially figure it out :)

- `./`
  - `assets/`
  - `code/`
  - `pages/`

All `.pug` files are compiled into `html` while all other formats are blindly passed through to the build folder.



## Credits

Labs up to and including 2017 created by [chrokh](https://github.com/chrokh).
