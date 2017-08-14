SRSP Facebook prize giveaway
Introduction
This project is about Facebook prize giveaway. The purpose of it is having an ability to give prizes to users who correctly answered the quiz questions, posted from time to time to our facebook page. This process should be automated.

Requirements
REQ-FBP-1.0-1 Facebook app

Attribute
Description
Description
Register a new FB app, add authentication token, app secret, webhooks to allow automation of quiz.
Fit criterion
Customer should be able to start automation of quiz with ability to post new messages and reply to existing ones on his facebook page. 
Customer should be able to retrieve FB messages popping up on his page in real time.

OPS: Create facebook app
Create facebook page. Investigate, create and setup facebook app. 
Bind FB app to created customer’s page. 
Generate FB app secret, app token, setup webhooks (only initial, without validation).

OPS: Create GIT repo and solution
Setup solution, GIT repository, CI, slack.
REQ-FBP-1.0-2 FB Webhook handling

Attribute
Description
Description
Create ability to retrieve and properly handle messages popping up on FB page through Web API real time updates (RTU)
Fit criterion
Messages should be handled without delay and be immediately processed. If message is a comment from user, and the original post is quiz post, message should be saved as an answer to the quiz. 
Participant information (like comment id and fullname) should be saved for further processing).
BK: Create facebook post thread model in db.
Our db model should look like next one:
Post
Id
Text
ExternalId
AuthorId
CreatedDateTime
Comment
Id
Text
ExternalId
AuthorId
PostId
CreatedDateTime
Author
Id
FullName
ExternalId

BK: Create web api project with initial FB webhook debugging.
Create solution with Web Api project.
Create GatewayController with 
POST RecieveNotifications endpoint
GET Validate endpoint
Ensure through ngrok.io that FB can reach and succeed in posting to your Web Api
BK: Setup IOC (Autofac)
Provide base implementation for dependency injection
BK: Create EF context and bind it to DB through fluent API
Using model above create EF context
Setup basic fluent API in code first manner
Allow db migrations
OPS: Deploy Web api project to local IIS
Investigate and deploy newly created web api project to your local IIS instance and ensure it is up and running

BK: Create service to parse incoming JSON from FB
Create service to parse JSON from FB into DB model and save it in db.
Validate for duplicates in posts, comments, authors.
REQ-FBP-1.0-3 Giveaway console app

Attribute
Description
Description
Create ability to start new quiz, and giveaway prizes to authors with winning answers.
Fit criterion
Customer should be able to start a new quiz through any some kind of UI. 
New answers should be analyzed for win condition. In case of win condition, quiz should be ended, winning comment should be replied with prize description.

BK: Create quiz model in db.
We should add new tables to our db:
Prize
Id
Description
WinMessage
Quiz
Id
Question
Answer
PrizeId
PostId
WinnerId



BK: Create console app for quiz
Create console app for quiz and setup IOC, push it to GIT.

BK: Create PrizeService
Create service to create prizes.
Bind it to console IO from user (readline/printline).
Only one prize is accepted.

BK: Create PublishService
Create FB publish service that will be able to post a message to page that will be a quiz thread start.

BK: Create QuizService
Create quiz service, that will be listening every 5 seconds for any newly appeared messages, related to our quiz in db.
Analyze incoming messages and if winning message found, reply to winner with congratulation and close quiz.
Present to customer quiz result and read new quiz input.
