-- Generated by Oracle SQL Developer Data Modeler 20.2.0.167.1538
--   at:        2020-08-24 20:06:15 COT
--   site:      SQL Server 2012
--   type:      SQL Server 2012



CREATE TABLE ATTACHMENT 
    (
     AttachmentID INTEGER NOT NULL IDENTITY , 
     FileName VARCHAR (max) NOT NULL , 
     FilePath VARCHAR (max) NOT NULL , 
     RelatedTableID INTEGER NOT NULL , 
     RelatedID INTEGER NOT NULL , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedBy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE ATTACHMENT ADD CONSTRAINT PK_ATTACHMENT PRIMARY KEY CLUSTERED (AttachmentID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE BUG 
    (
     BugID INTEGER NOT NULL IDENTITY , 
     TaskID INTEGER NOT NULL , 
     Description VARCHAR (max) , 
     StatusID INTEGER NOT NULL , 
     IdentifiedDate DATETIME NOT NULL , 
     ReportedBy INTEGER NOT NULL , 
     Responsible INTEGER , 
     Priority INTEGER NOT NULL , 
     Status INTEGER NOT NULL , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedBy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE BUG ADD CONSTRAINT PK_BUG PRIMARY KEY CLUSTERED (BugID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE BUGLOG 
    (
     BugLogID INTEGER NOT NULL IDENTITY , 
     BugID INTEGER NOT NULL , 
     ColumnName VARCHAR (50) NOT NULL , 
     PreviousValue VARCHAR (max) NOT NULL , 
     NewValue VARCHAR (max) NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE BUGLOG ADD CONSTRAINT PK_BUGLOG PRIMARY KEY CLUSTERED (BugLogID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE COMMENT 
    (
     CommentID INTEGER NOT NULL IDENTITY , 
     CommentText VARCHAR (max) NOT NULL , 
     Author INTEGER NOT NULL , 
     RelatedTableID INTEGER NOT NULL , 
     RelatedID INTEGER NOT NULL , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedBy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE COMMENT ADD CONSTRAINT PK_COMMENT PRIMARY KEY CLUSTERED (CommentID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE ELEMENT 
    (
     ElementID INTEGER NOT NULL IDENTITY , 
     Name VARCHAR (50) NOT NULL 
    )
GO

ALTER TABLE ELEMENT ADD CONSTRAINT PK_ELEMENT PRIMARY KEY CLUSTERED (ElementID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE LOOKUP 
    (
     LookUpID INTEGER NOT NULL , 
     LookUpTypeID INTEGER NOT NULL , 
     Description VARCHAR (100) NOT NULL 
    )
GO

ALTER TABLE LOOKUP ADD CONSTRAINT PK_LOOKUP PRIMARY KEY CLUSTERED (LookUpID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE LOOKUPTYPE 
    (
     LookUpTypeID INTEGER NOT NULL , 
     Description VARCHAR (100) NOT NULL 
    )
GO

ALTER TABLE LOOKUPTYPE ADD CONSTRAINT LOOKUPTYPE_PK PRIMARY KEY CLUSTERED (LookUpTypeID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE PERMISSION 
    (
     PermissionID INTEGER NOT NULL IDENTITY , 
     RoleID INTEGER NOT NULL , 
     ElementID INTEGER NOT NULL , 
     "Create" BIT NOT NULL , 
     "Read" BIT NOT NULL , 
     "Update" BIT NOT NULL , 
     "Delete" BIT NOT NULL , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedBy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE PERMISSION ADD CONSTRAINT PK_PERMISSION PRIMARY KEY CLUSTERED (PermissionID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE PROJECT 
    (
     ProjectID INTEGER NOT NULL IDENTITY , 
     Name VARCHAR (50) NOT NULL , 
     Description VARCHAR (max) , 
     StatusID INTEGER NOT NULL , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedBy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE PROJECT ADD CONSTRAINT PK_PROJECT PRIMARY KEY CLUSTERED (ProjectID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE ROLE 
    (
     RoleID INTEGER NOT NULL IDENTITY , 
     Name VARCHAR (50) NOT NULL , 
     Description VARCHAR (max) , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreateDby INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE ROLE ADD CONSTRAINT PK_ROLE PRIMARY KEY CLUSTERED (RoleID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE STATUS 
    (
     StatusID INTEGER NOT NULL , 
     Description VARCHAR (100) NOT NULL , 
     RelatedTableID INTEGER NOT NULL 
    )
GO

ALTER TABLE STATUS ADD CONSTRAINT STATUS_PK PRIMARY KEY CLUSTERED (StatusID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE "TABLE" 
    (
     TableID INTEGER NOT NULL , 
     Name VARCHAR (50) NOT NULL 
    )
GO

ALTER TABLE "TABLE" ADD CONSTRAINT TABLE_PK PRIMARY KEY CLUSTERED (TableID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE TASK 
    (
     TaskID INTEGER NOT NULL IDENTITY , 
     ProjectID INTEGER NOT NULL , 
     Name VARCHAR (50) NOT NULL , 
     Description VARCHAR (max) , 
     StatusID INTEGER NOT NULL , 
     Responsible INTEGER , 
     Estimation INTEGER , 
     Status INTEGER NOT NULL , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedBy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE TASK ADD CONSTRAINT PK_TASK PRIMARY KEY CLUSTERED (TaskID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE TASKLOG 
    (
     TaskLogID INTEGER NOT NULL IDENTITY , 
     TaskRecordID INTEGER NOT NULL , 
     ColumnName VARCHAR (50) NOT NULL , 
     PreviousValue VARCHAR (max) NOT NULL , 
     NewValue VARCHAR (max) NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE TASKLOG ADD CONSTRAINT PK_TASKLOG PRIMARY KEY CLUSTERED (TaskLogID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE "USER" 
    (
     UserID INTEGER NOT NULL IDENTITY , 
     FirstName VARCHAR (50) NOT NULL , 
     LastName VARCHAR (50) NOT NULL , 
     UserName VARCHAR (50) NOT NULL , 
     Email VARCHAR (100) NOT NULL , 
     Password VARCHAR (255) NOT NULL , 
     StatusID INTEGER NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedBy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE "USER" ADD CONSTRAINT PK_USER PRIMARY KEY CLUSTERED (UserID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE USERPROJECT 
    (
     ProjectID INTEGER NOT NULL , 
     UserID INTEGER NOT NULL , 
     Active BIT NOT NULL , 
     CreateDate DATETIME NOT NULL , 
     CreatedDy INTEGER NOT NULL , 
     EditDate DATETIME NOT NULL , 
     EditedBy INTEGER NOT NULL 
    )
GO

ALTER TABLE USERPROJECT ADD CONSTRAINT PK_USERPROJECT PRIMARY KEY CLUSTERED (ProjectID, UserID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE USERROLE 
    (
     UserID INTEGER NOT NULL , 
     RoleID INTEGER NOT NULL , 
     CreateDate DATETIME , 
     CreatedBy INTEGER , 
     EditDate DATETIME , 
     EditedBy INTEGER 
    )
GO

ALTER TABLE USERROLE ADD CONSTRAINT USERROLE_PK PRIMARY KEY CLUSTERED (UserID, RoleID)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

ALTER TABLE ATTACHMENT 
    ADD CONSTRAINT FK_ATTACHMENT_TABLE FOREIGN KEY 
    ( 
     RelatedTableID
    ) 
    REFERENCES "TABLE" 
    ( 
     TableID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE BUG 
    ADD CONSTRAINT FK_BUG_STATUS FOREIGN KEY 
    ( 
     StatusID
    ) 
    REFERENCES STATUS 
    ( 
     StatusID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE BUG 
    ADD CONSTRAINT FK_BUG_TASK FOREIGN KEY 
    ( 
     TaskID
    ) 
    REFERENCES TASK 
    ( 
     TaskID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE COMMENT 
    ADD CONSTRAINT FK_COMMENT_TABLE FOREIGN KEY 
    ( 
     RelatedTableID
    ) 
    REFERENCES "TABLE" 
    ( 
     TableID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE LOOKUP 
    ADD CONSTRAINT FK_LOOKUP_LOOKUPTYPE FOREIGN KEY 
    ( 
     LookUpTypeID
    ) 
    REFERENCES LOOKUPTYPE 
    ( 
     LookUpTypeID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE PERMISSION 
    ADD CONSTRAINT FK_PERMISSION_ELEMENT FOREIGN KEY 
    ( 
     ElementID
    ) 
    REFERENCES ELEMENT 
    ( 
     ElementID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE PERMISSION 
    ADD CONSTRAINT FK_PERMISSION_ROLE FOREIGN KEY 
    ( 
     RoleID
    ) 
    REFERENCES ROLE 
    ( 
     RoleID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE PROJECT 
    ADD CONSTRAINT FK_PROJECT_STATUS FOREIGN KEY 
    ( 
     StatusID
    ) 
    REFERENCES STATUS 
    ( 
     StatusID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE STATUS 
    ADD CONSTRAINT FK_STATUS_TABLE FOREIGN KEY 
    ( 
     RelatedTableID
    ) 
    REFERENCES "TABLE" 
    ( 
     TableID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE TASK 
    ADD CONSTRAINT FK_TASK_PROJECT FOREIGN KEY 
    ( 
     ProjectID
    ) 
    REFERENCES PROJECT 
    ( 
     ProjectID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE TASK 
    ADD CONSTRAINT FK_TASK_STATUS FOREIGN KEY 
    ( 
     StatusID
    ) 
    REFERENCES STATUS 
    ( 
     StatusID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE "USER" 
    ADD CONSTRAINT FK_USER_STATUS FOREIGN KEY 
    ( 
     StatusID
    ) 
    REFERENCES STATUS 
    ( 
     StatusID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO


ALTER TABLE USERPROJECT 
    ADD CONSTRAINT FK_USERPROJECT_PROJECT FOREIGN KEY 
    ( 
     ProjectID
    ) 
    REFERENCES PROJECT 
    ( 
     ProjectID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE USERPROJECT 
    ADD CONSTRAINT FK_USERPROJECT_USER FOREIGN KEY 
    ( 
     UserID
    ) 
    REFERENCES "USER" 
    ( 
     UserID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE USERROLE 
    ADD CONSTRAINT FK_USERROLE_ROLE FOREIGN KEY 
    ( 
     RoleID
    ) 
    REFERENCES ROLE 
    ( 
     RoleID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE USERROLE 
    ADD CONSTRAINT FK_USERROLE_USER FOREIGN KEY 
    ( 
     UserID
    ) 
    REFERENCES "USER" 
    ( 
     UserID 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO



-- Oracle SQL Developer Data Modeler Summary Report: 
-- 
-- CREATE TABLE                            17
-- CREATE INDEX                             0
-- ALTER TABLE                             33
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
