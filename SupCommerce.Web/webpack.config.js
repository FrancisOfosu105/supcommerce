const path = require("path");
const webpack = require('webpack');
const config = {
    entry: {
        'admin-category': "./assets/scripts/admin/pages/category.js",
        'admin-product': "./assets/scripts/admin/pages/product.js",
        vender: './assets/scripts/vendor.js'
    },
    mode: "development",
    stats: {
        colors: true,
        reasons: true
    },
    output: {
        path: path.resolve(__dirname, "./wwwroot/scripts"),
        filename: "[name].js",
        publicPath: "/scripts/"
    },

    resolve: {
        extensions: [".ts", ".js"],
        alias: {
            vue: 'vue/dist/vue.js'
        }
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /(node_modules)/,
                loaders: ["babel-loader"]
            }
        ]
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery"
        })
    ]
};
module.exports = config;
