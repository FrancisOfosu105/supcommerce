const path = require("path");
const webpack = require('webpack');
const config = {
    entry: {
        app: './assets/scripts/admin/app.js'
    },
    mode: "development",
    stats: {
        colors: true,
        reasons: true
    },
    output: {
        path: path.resolve(__dirname, "./wwwroot/scripts/admin"),
        filename: "[name].bundle.js",
        publicPath: "/scripts/admin/"
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
    optimization: {
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /[\\/]node_modules[\\/]/,
                    name: "vendor",
                    chunks: "initial",
                },
            },
        },
        runtimeChunk: {
            name: "manifest",
        },

    },
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery"
        })
    ]
};
module.exports = config;
