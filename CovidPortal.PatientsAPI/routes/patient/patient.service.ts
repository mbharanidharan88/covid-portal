require('rootpath')()
const db = require('helpers/db.ts')
const Result = db.Result;
const Patient = db.Patient;


module.exports = {
    createPatient,
    listPatients,
    // getPatientById
}

async function createPatient(patientParam) {

    var result = new Result();

    try {
        //create User Object from user param
        var patient = new Patient(patientParam);

        var doc = await patient.save();

        result.hasData = true;
        result.data = doc._id;

    }
    catch (err) {
        result.hasData = false;
        result.exception = err;
        result.failMessage = err.message;
    }

    return result;
}


async function listPatients() {

    var result = new Result();

    try {
        await Patient.find().select("-__v")
            .then(data => {
                result.hasData = true;
                result.data = data;

                return result;
            })
    }
    catch (err) {
        result.hasData = false;
        result.exception = err;
        result.failMessage = err.message;
    }

    return result;

}

//async function getPatientById(roleData) {

//    var result = new Result();

//    try {
//        await Patient.findOne({ roleName: { $regex: roleData.roleName, $options: 'i' } }).select("-__v")
//            .then(data => {

//                result.hasData = data != null;
//                result.data = data;

//                return result;
//            })
//    }
//    catch (err) {
//        result.hasData = false;
//        result.exception = err;
//        result.failMessage = err.message;
//    }

//    return result;

//}