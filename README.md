# HQ Plus Tests

## Task 2 Optional - Architecture Suggestion

#### Email is sent at time x attaching the report

### Option 1 - Hangfire Cron Job
-------------------------------------------------------------------------------------------------------
Step 1 - Use Hangfire (https://www.hangfire.io/) as with crontab to verify existence of reports in folder.
Step 2 - There's plenty of nuget packages for send mail, use the one who best fit the HQ Plus team to prepare, attach the report and send mail.

Hangfire has some features that could do a great job on this like requeue failed tasks and a control dashboard.

### Option 2 - Use an Azure Function (if HQ Plus is already using Azure)
-------------------------------------------------------------------------------------------------------
Using the same approach as Option 1

### Option 3 - Use a queue system like Rabbit MQ (https://www.rabbitmq.com/) or Azure Queues
-------------------------------------------------------------------------------------------------------
When generate the excel report file send a message to one of the queue services to trigger a function
or job who will prepare and send the email.

## Task 3 - Api Json 
There's a postman collection with the parameters needed to call the filter api in the file "Task3-HQPlusRest.postman_collection.json".

What is missing in the API is an authentication/authorization to secure the access to it.



