DELETE FROM [TABLE]
INSERT INTO [TABLE] (NAME) VALUES
('ATTACHMENT'),
('BUG'),
('BUGLOG'),
('COMMENT'),
('ELEMENT'),
('ERRORLOG'),
('LOOKUP'),
('LOOKUPTYPE'),
('PASSWORDREQUEST'),
('PERMISSION'),
('PROJECT'),
('ROLE'),
('STATUS'),
('TABLE'),
('TASK'),
('TASKLOG'),
('USER'),
('USERPROJECT'),
('USERROLE');

INSERT INTO [STATUS] (Description, RelatedTableID) VALUES
('Active', 17),
('Pending', 17),
('Inactive', 17);
