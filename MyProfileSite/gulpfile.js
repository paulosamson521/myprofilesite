/// <binding ProjectOpened='default' />
var gulp = require('gulp');
var sass = require('gulp-sass');
var concat = require('gulp-concat');
var cleanCss = require('gulp-clean-css');


gulp.task('default', ['css', 'watch'])

gulp.task('watch', watch);
gulp.task('css', css);

function css(){
    gulp.src('src/sass/components.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('styles.css'))
        .pipe(cleanCss())
        .pipe(gulp.dest('dist/css'));
}

function js() {
}

function watch() {
    gulp.watch('src/sass/*.scss', ['css']);
}

