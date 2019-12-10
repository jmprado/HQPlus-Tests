# HQ Plus Tests

## Task 1 - HTML Data Extraction
It's a console app who reads the HTML file and generate the JSON and show the result in console. It could be easily refactored to save a JSON file to disk.

Also there's a test project for assure the values returned by HTML extraction.

## Task 2a - Excel report generation
There's a console app who reads the JSON and generate the excel file at [runtime folder]./output/report_[hotel id].xlsx


## Task 2b - Architecture Suggestion
### Email is sent at time x attaching the report
#### Option 1 - Hangfire Cron Job
-------------------------------------------------------------------------------------------------------
#### 1. Use Hangfire (https://www.hangfire.io/) as with crontab to verify existence of reports in folder.
There's plenty of nuget packages for send mail, use the one who best fit the HQ Plus team to prepare, attach the report and send mail

Hangfire has some features that could do a great job on this like requeue failed tasks and a control dashboard.

#### Option 2 - Use an Azure Function (if HQ Plus is already using Azure)
-------------------------------------------------------------------------------------------------------
Using the same approach as Option 1

#### Option 3 - Use a queue system like Rabbit MQ (https://www.rabbitmq.com/) or Azure Queues ()
-------------------------------------------------------------------------------------------------------
When generate the excel report file send a message to one of the queue services to trigger a function
or job who will prepare and send the email

## Task 3 - Api Json 
There's a postman collection with the parameters needed to call the filter api in the file [Task3-HQPlusRest.postman_collection.json](./Task3-HQPlusRest.postman_collection.json).

What is missing in the API is an authentication/authorization to secure the access to it.



