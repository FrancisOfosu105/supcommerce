const gulp = require('gulp'),
    webpack = require('webpack'),
    del = require('del');

gulp.task("scripts", function (callback) {
    webpack(require('../../webpack.config'), function (err, stats) {
        if (err)
            console.error(err.toString());

        console.info(stats.toString());
        
        callback();
        
    });

});


gulp.task('DeleteScriptFiles', function () {
    return del('./wwwroot/scripts/*');
});