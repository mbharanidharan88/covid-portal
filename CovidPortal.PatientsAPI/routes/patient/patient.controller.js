require('rootpath')();
var express = require('express');
var router = express.Router();
var patientService = require('routes/patient/patient.service.ts');
var authorize = require('helpers/authorize.ts');
var logger = function (req, res, next) {
    console.log("Patient Controller");
    console.log(req.body);
    next();
};
router.use(logger);
router.use(authorize);
router.post('/create', create);
router.get('/list', list);
//router.post('/getPatientById', getPatientById);
module.exports = router;
function create(req, res, next) {
    patientService.createPatient(req.body)
        .then(function (result) {
        var statusCode = 200; //default to ok
        if (result && result.hasData && result.data != null) {
            result.okMessage = "Patient Created";
        }
        else {
            statusCode = 400;
        }
        result = result.toObject();
        delete result.exception;
        res.status(statusCode).json(result);
    })
        .catch(function (err) { return next(err); });
}
function list(req, res, next) {
    patientService.listPatients()
        .then(function (result) {
        res.status(200).json(result);
    })
        .catch(function (err) { return next(err); });
}
//function getRoleByName(req, res, next) {
//    patientService.getRoleByName(req.body)
//        .then(result => {
//            res.status(200).json(result)
//        })
//        .catch(err => next(err))
//}
//# sourceMappingURL=patient.controller.js.map