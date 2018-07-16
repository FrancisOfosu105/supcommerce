const gulp = require('gulp'),
    watch = require('gulp-watch');

gulp.task("default", ["scripts", "DeleteScriptFiles"], function () {
    /* watch([
         "./build/styles/!**!/!*.scss",
         "./node_modules/bootstrap/scss/!**!/!*.scss"
     ], function () {
 
         gulp.start("styles");
     });*/

    watch("./assets/scripts/**/*.js", function () {
        return gulp.start("scripts");
    })
});

