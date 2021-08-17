var gulp = require("gulp");
var del = require("del");
var paths = {
    scripts: ["scripts/**/*.js", "scripts/**/*.ts", "scripts/**/*.map"],
};
gulp.task("clean", function () {
    return del(["wwwroot/js/**/*"]);
});
gulp.task("copy", function (done) {
    gulp.src(paths.scripts[0]).pipe(gulp.dest("wwwroot/js"));
    done();
});
gulp.task("default", gulp.series("clean", "copy"));
gulp.task("watch", function () {
    gulp.watch(paths.scripts, gulp.task("default"));
});
