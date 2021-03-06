﻿/// <binding Clean='clean' />
"use strict";

//var gulp = require("gulp"),
//    rimraf = require("rimraf"),
//    concat = require("gulp-concat"),
//    cssmin = require("gulp-cssmin"),
//    uglify = require("gulp-uglify");

//var webroot = "./wwwroot/";

//var paths = {
//    js: webroot + "app/**/*.js", //Need to update all Paths
//    minJs: webroot + "app/**/*.min.js",
//    css: webroot + "styles/**/*.css",
//    minCss: webroot + "styles/**/*.min.css",
//    concatJsDest: webroot + "scripts/site.min.js",
//    concatCssDest: webroot + "styles/site.min.css"
//};

//gulp.task("clean:js", function (cb) {
//    rimraf(paths.concatJsDest, cb);
//});

//gulp.task("clean:css", function (cb) {
//    rimraf(paths.concatCssDest, cb);
//});

//gulp.task("clean", ["clean:js", "clean:css"]);

//gulp.task("min:js", function () {
//    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
//        .pipe(concat(paths.concatJsDest))
//        .pipe(uglify())
//        .pipe(gulp.dest("."));
//});

//gulp.task("min:css", function () {
//    return gulp.src([paths.css, "!" + paths.minCss])
//        .pipe(concat(paths.concatCssDest))
//        .pipe(cssmin())
//        .pipe(gulp.dest("."));
//});

//gulp.task("min", ["min:js", "min:css"]);

var gulp = require('gulp');
gulp.task("default", function () { });

gulp.task("copyfiles", function () {
    //js Files
    gulp.src("./node_modules/angular/angular.js").pipe(gulp.dest("./wwwroot/libs/js"));
    gulp.src("./node_modules/angular-ui-router/release/angular-ui-router.js").pipe(gulp.dest("./wwwroot/libs/js"));
    gulp.src("./node_modules/angular/angular.js").pipe(gulp.dest("./wwwroot/libs/js"));
    gulp.src("./node_modules/bootstrap/dist/js/bootstrap.js").pipe(gulp.dest("./wwwroot/libs/js"));

    //CSS
    gulp.src("./node_modules/bootstrap/dist/css/bootstrap.css").pipe(gulp.dest("./wwwroot/libs/css"));

    //Fonts
    gulp.src("./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.eot").pipe(gulp.dest("./wwwroot/libs/fonts"));
    gulp.src("./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.ttf").pipe(gulp.dest("./wwwroot/libs/fonts"));
    gulp.src("./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.woff").pipe(gulp.dest("./wwwroot/libs/fonts"));
    gulp.src("./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.woff2").pipe(gulp.dest("./wwwroot/libs/fonts"));
});
