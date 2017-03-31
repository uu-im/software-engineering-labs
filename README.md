# Software Engineering Labs

The labs are made available to the students using [GitHub Pages](https://pages.github.com/).

- Latest year: http://uu-im.github.io/software-engineering-labs
- Specific year: http://uu-im.github.io/software-engineering-labs/vt16



## Dependencies

- Node
- NPM
- Gulp.js


## Getting started

1. Ensure you have all the dependencies.
2. Run `npm install`
3. Run `gulp` to start the dev server.
4. Open http://localhost:8080. The page will livereload on source changes.
5. Source files are found in `./src`.
6. Development builds are stored in `./tmp-www`.
7. Production builds are stored in `./` (sorry about that but it was to make GitHub Pages publishing easier).



### Publishing to GitHub Pages

1. Ensure your git working directory is clean (i.e. no uncommited changes).
2. Execute `./publish.sh` if you're running `bash`/`zsh`. If not then just execute the commands outlined in that file. Sorry Windows:ers :)



### Writing new labs

The simplest way to create a set of new labs for a new year is probably to duplicate a folder of a previous year (i.e. `./src/[llyy]`). The gulp scripts assume the following folder structure of lab...

- `./`
  - `assets/`
  - `code/`
  - `pages/`

All `.jade` files are compiled into `html` while all other formats are blindly passed through to the build folder.



## Gulp commands

- `gulp development`
  - Aliases: `gulp d` `gulp`
  - Builds all labs to `./tmp-www`.
- `gulp production`
  - Aliases: `gulp p`
  - Builds all labs to `./`.
- `gulp watch`
  - Watches `./src` folder and runs `gulp d` on changes.
- `gulp server`
  - Aliases: `gulp s`
  - Serves `./tmp-www` at http://localhost:8080.

## Credits

Labs up to and including 2017 created by [chrokh](https://github.com/chrokh).
