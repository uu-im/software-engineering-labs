var gulp = require('gulp'),
    jade = require('gulp-jade');


gulp.task('default', function(){
  gulp.watch('src/*.jade', function(e){
    console.log("Running jade on:  " + e.path);
    gulp.src(e.path)
      .pipe(jade().on('error', function(error){
        console.log('Jade error: ', error);
      }))
      .pipe(gulp.dest('./dist'));
  });
});