var gulp = require('gulp'),
    jade = require('gulp-jade');


gulp.task('default', function(){
  var watchfiles = ['src/**/*.*', 'assets/**/*.*']
  gulp.watch(watchfiles, function(e){
    console.log('Running jade');
    gulp.src('./src/*.jade')
      .pipe(jade().on('error', function(error){
        console.log('Jade error: ', error);
      }))
      .pipe(gulp.dest('./dist'));
  });
});