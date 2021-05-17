const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const resultSchema = new Schema({
    data: {},
    total: Number,
    hasData: Boolean,
    okMessage: String,
    failMessage: String,
    exception: {}
});

resultSchema.set("toJSON", { virtuals: true });

module.exports = mongoose.model('Result', resultSchema)