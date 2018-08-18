const gulp = require('gulp'),
    sass = require('gulp-sass'),
    autoprefixer = require('gulp-autoprefixer');

gulp.task("styles", ['fa','fonts'], function () {
   return gulp.src([
       "./node_modules/bootstrap/scss/bootstrap.scss",
            "./build/styles/**/*.scss"
        ]).pipe(sass().on("error", sass.logError))
        .pipe(autoprefixer())
        .pipe(gulp.dest("./wwwroot/styles"));
});

gulp.task("fa", function () {
  return gulp.src("./node_modules/@fortawesome/fontawesome-free/css/all.css")
      .pipe(gulp.dest("./wwwroot/styles")); 
});

gulp.task("fonts", function () {
    return gulp.src("./node_modules/@fortawesome/fontawesome-free/webfonts/**")
        .pipe(gulp.dest("./wwwroot/fonts"));
});