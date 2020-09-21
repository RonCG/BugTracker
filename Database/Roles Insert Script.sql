DELETE FROM [ROLE]
INSERT INTO [ROLE] (NAME, DESCRIPTION, ACTIVE, CREATEDATE, CREATEDBY, EDITDATE, EDITEDBY) VALUES
('ADMIN', 'System Administrator', 1, getDate(), 1, getDate(), 1),
('PROJECT LEAD', 'Project Lead', 1, getDate(), 1, getDate(), 1),
('DEVELOPER', 'Developer', 1, getDate(), 1, getDate(), 1),
('QA', 'Quality Analyst', 1, getDate(), 1, getDate(), 1);
