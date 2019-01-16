--Checklist_Template_User migrations
CREATE SCHEMA IF NOT EXISTS ChecklistDojo;
CREATE TABLE IF NOT EXISTS ChecklistDojo.ChecklistTemplateUser(
  ID SERIAL NOT NULL PRIMARY KEY ,
  UserID SERIAL NOT NULL,
  Name VARCHAR(72) NOT NULL,
  Json JSON NOT NULL
);
--Example Records
INSERT INTO ChecklistDojo.Checklist_Template_User (UserID, Name, Json)
VALUES (01,'ExampleTable', '{ "Title": "ExampleTable","Description": "Doing a thing","Items": {"Text": "thing"}}');