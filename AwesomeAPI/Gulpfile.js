var gulp = require('gulp'),
    shell = require('gulp-shell');

gulp.task('default', function(cb) {
	return gulp.start('watch');
});

gulp.task('watch', shell.task(['dnx-watch --dnx-args web --project project.json']));
