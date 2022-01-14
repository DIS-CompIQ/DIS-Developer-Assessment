# Background

This is a test 

This is a technical assessment meant to provide an opportunity for you
to demonstrate your skills as it relates to the varied tasks here at
CompIQ. You should spend no more than 2 hours on the assessment. If you
cannot complete a requirement due to time, please provide a short
response indicating how you would address the requirement.

# Summary

You are a developer at CompIQ and are tasked with implementing a Fugazi
File importer.

Fugazi files are flat-files, meaning that each row of a Fugazi file
represents a record, and their file ending is `.fgz`. The data within
that record is contained in the row and is separated by spaces.

Fugazi File Specification:

  | Name          | Nice Name      | Start   | Length   | Data Type   | Notes
  | ------------- | -------------- | ------- | -------- | ----------- | -------------------------------------------
  | patientName   | Patient Name   | 0       | 25       | string      
  | address       | Address        | 25      | 50       | string      
  | phoneNumber   | Phone Number   | 75      | 10       | int         | No dashes
  | injury        | Injury         | 85      | 30       | string      | Description of injury
  | treatment     | Treatment      | 115     | 30       | string      | Description of treatment
  | amount        | Amount         | 145     | 15       | decimal     | Cost of the claim in USD
  | status        | Status         | 160     | 10       | string      | Whether the claim was approved or denied.

An example record could look like this:

`John Cena                123 Internet Street                               5555555555Torn Bicep                    Surgery                       100           Denied`

Which represented as JSON using the above mapping, this record would
look like this:

``` javascript
{
    "patientName":"John Cena",
    "address":"123 Internet Street",
    "phoneNumber":5555555555,
    "injury":"Torn Bicep",
    "treatment":"Surgery",
    "amount":100,
    "status":"Denied"
}
```

The importer you\'ll design will need to import these Fugazi files via
an API to the `FugaziImport` table of an sqLite database with the
following schema:

``` sql
CREATE TABLE "FugaziImport" (
    "Id"    INTEGER NOT NULL,
    "PatientName"   TEXT NOT NULL,
    "Address"   TEXT,
    "PhoneNumber"   INTEGER,
    "Injury"    TEXT,
    "Treatment" INTEGER,
    "Amount"    NUMERIC,
    "Status"    TEXT,
    PRIMARY KEY("Id" AUTOINCREMENT)
);
```

Additionally, your api will need to return information about the Fugazi
files.

# Requirements

This assessment can be completed with any language or framework you so
choose. A dotnet starter project is included in the repository if you
are so inclined in the `/dotnet6` directory. Sample `.fgz` files can be
found in the `/sample` directory and the sqLite db is in the `/db`
directory. Feel free to create whatever additional tables in the db you
may need, but you must maintain the structure of the FugaziImport table.

## API Endpoints

-   [ ] POST `/upload` Imports a Fugazi file received through a
    multipart form upload
-   [ ] GET `/fugazi` Returns a JSON formatted list of all imported
    Fugazi records in the database
-   [ ] GET `/fugazi/{id}` Returns a specific imported Fugazi record in
    JSON format with the id of `{id}`. E.g. `/fugazi/1` should return
    the Fugazi record with an id of 1.

## Documentation

-   [ ] Running Locally Complete the section `Running Locally` below
    describing how another developer would run your code
-   [ ] Deploying to Production Complete the section
    `Deploying to Production` below describing how to deploy your code
    to production

# Bonus Points

These are not at all required for submission, but are nice to see. If
you run out time or have ideas, please describe them.

-   [ ] UI of some sort
-   [ ] API can generate Fugazi files from a selection of records
-   [ ] Large file handling

# Submission Guidelines

Fork this repo and create as many commits as needed to satisfy the
requirements. Upon completion, create a pull request to this repository
and send a link to the PR to the hiring manager you are working with in
an email.

# Running Locally

# Deploying to Production
