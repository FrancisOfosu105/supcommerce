const gulp = require('gulp'),
    watch = require('gulp-watch');

gulp.task("default", ["scripts","styles"], function () {
     watch([
         "./assets/styles/**/*.scss",
     ], function () {
         gulp.start("styles");
     });

    watch("./assets/scripts/**/*.js", function () {
        return gulp.start("scripts");
    })
});

