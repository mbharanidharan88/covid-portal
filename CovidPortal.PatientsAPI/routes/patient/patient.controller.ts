require('rootpath')()
const express = require('express')
const router = express.Router()
const patientService = require('routes/patient/patient.service.ts')
const authorize = require('helpers/authorize.ts')
var logger = function (req, res, next) {
    console.log("Patient Controller");
    console.log(req.body);
    next();
}

router.use(logger);
router.use(authorize);
router.post('/create', create);
router.get('/list', list);
//router.post('/getPatientById', getPatientById);

module.exports = router;


function create(req, res, next) {
    patientService.createPatient(req.body)
        .then(result => {
            var statusCode = 200; //default to ok

            if (result && result.hasData && result.data != null) {
                result.okMessage = "Patient Created";
            }
            else {
                statusCode = 400;
            }

            result = result.toObject();
            delete result.exception

            res.status(statusCode).json(result)
        })
        .catch(err => next(err))
}


function list(req, res, next) {
    patientService.listPatients()
        .then(result => {

            res.status(200).json(result)

        })
        .catch(err => next(err))
}

//function getRoleByName(req, res, next) {

//    patientService.getRoleByName(req.body)
//        .then(result => {

//            res.status(200).json(result)

//        })
//        .catch(err => next(err))
//}