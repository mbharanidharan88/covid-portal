require('rootpath')();
const mongoose = require('mongoose');
const Schema = mongoose.Schema;


const patientSchema = new Schema({
    patientName: { type: String, unique: true, required: true },
    email: String,
    mobile: String,
    covidTestedDate: String,
    healthComplications: String,
    daysInQueue: String,
    applicationUserId: String
});

patientSchema.set("toJSON", { virtuals: true });

module.exports = mongoose.model('Patient', patientSchema)