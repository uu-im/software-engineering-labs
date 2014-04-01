var gulp = require('gulp'),
    jade = require('gulp-jade');


gulp.task('default', function(){
  gulp.watch('src/**/*.jade', function(e){
    gulp.src(e.path)
      .pipe(jade())
      .pipe(gulp.dest('./dist'));
  });
});