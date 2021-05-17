require('rootpath')()
require('https').globalAgent.options.ca = require('ssl-root-cas').create();
require('https').globalAgent.options.rejectUnauthorized = false
const express = require('express')
const cors = require('cors')
const app = express()
const bodyParser = require('body-parser')

app.use(cors())
app.use(bodyParser.json({ limit: '50mb' }))

const errorHandler = require('helpers/error-handler.ts')
const db = require('helpers/db.ts')
const port = process.env.PORT || 8080

const patientController = require('routes/patient/patient.controller.ts')


app.listen(port, () => {
    console.log("App Started Listening on " + port)
})



app.get('', (req, res) => {
    res.send("Patients API Version v1")
})

app.use('/patient', patientController)
app.use(errorHandler)