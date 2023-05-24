const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  chainWebpack: (config) => {
    config.module
      .rule('typescript')
      .test(/\.tsx?$/)
      .use('ts-loader')
      .loader('ts-loader')
      .options({
        transpileOnly: true,
        appendTsSuffixTo: [/\.vue$/],
      });
  },
})
