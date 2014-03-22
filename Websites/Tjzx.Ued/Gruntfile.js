module.exports = function (grunt) {
    // 配置
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        //合并css/js文件
//        concat: {
//            options: {
//                separator: '\n'
//            },
//            basic: {
//                files: {
//                    'build/seed.js': ['src/seed/src/singer.js', 'src/seed/src/*.js']
//                }
//            }
//        },
        //js压缩
        uglify: {
            options: {
                banner: '/*! <%= pkg.name %> version:<%= pkg.version %> <%= grunt.template.today("yyyy-mm-dd HH:MM:ss") %> */\n'
            },
//            seed: {
//                src: ['src/seed/src/singer.js', 'src/seed/src/*.js'],
//                dest: 'build/seed.min.js'
//            },
            list: {
                files: [
                    {
                        expand: true,
                        cwd: 'source/js',
                        src: '*.js',
                        dest: 'js',
                        ext: '.min.js'
                    }
                ]
            }
        },
        //css压缩
        cssmin: {
            options: {
                banner: '/*! <%= pkg.name %> <%= grunt.template.today("yyyy-mm-dd HH:MM:ss") %> */'
            },
            combine: {
                files: [
                    {
                        expand: true,
                        cwd: 'source/css',
                        src: '*.css',
                        dest: 'css',
                        ext: '.min.css'
                    }
                ]
            }
        },
        //文件监视 执行命令 grunt watch
        watch: {
            js: {
                files: ['source/js/*.js'],
                tasks: ['uglify']
            },
            css: {
                files: ['source/css/*.css'],
                tasks: ['cssmin']
            }
        }
    });
    // 载入concat和uglify插件，分别对于合并和压缩
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-watch');
    // 注册任务
    grunt.registerTask('default', ['uglify', 'cssmin']);
}; 