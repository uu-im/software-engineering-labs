var gulp    = require('gulp'),
    jade    = require('gulp-jade'),
    connect = require('gulp-connect'),
    fs      = require('fs'),
    path    = require('path');


gulp.task('default', ['development', 'watch', 'server']);

gulp.task('d', ['development']);
gulp.task('development', function(){
  Tasks.build('tmp-www/software-engineering-labs');
});

gulp.task('watch', function(){
  Tasks.build('tmp-www/software-engineering-labs');
  gulp.watch(['src/**/*', 'code/**/*'], function(e){
    console.log('Changed: ' + e.path);
    Tasks.build('tmp-www/software-engineering-labs');
  });
  Tasks.server();
});

gulp.task('p', ['production']);
gulp.task('production', function(){
  Tasks.build('.');
});

gulp.task('s', ['server']);
gulp.task('server', function(){
  Tasks.server();
});


function getFolders(dir) {
  return fs.readdirSync(dir)
    .filter(function(file) {
      return fs.statSync(path.join(dir, file)).isDirectory();
    });
}




var Tasks = {
  server: function(){
    connect.server({
      root: './tmp-www/',
      livereload: true
    })
  },

  build: function(root){
    /*
      about the directory mapping:
      https://github.com/gulpjs/gulp/blob/master/docs/recipes/running-task-steps-per-folder.md
      http://stackoverflow.com/questions/21905875/gulp-run-is-deprecated-how-do-i-compose-tasks
    */

    var folders = getFolders('src/');
    var tasks = folders.map(function(year) {
      var basedir = path.join('src', year);
      var outdir  = path.join(root, year);

      gulp.src(basedir + '/pages/**/*.jade')
        .pipe(jade().on('error', function(error){
          console.log('Jade error: ', error);
        }))
        .pipe(gulp.dest(outdir));

      gulp.src(basedir + '/assets/**/*')
        .pipe(gulp.dest(outdir + '/assets'));

      gulp.src(basedir + '/code/**/*')
        .pipe(gulp.dest(outdir + '/code'));
    });

    if(root!='./' && root!='.' && root!='' && root!=''){
      gulp.src('./index.html')
        .pipe(gulp.dest(root));
    }
  }
}
