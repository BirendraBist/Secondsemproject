CREATE DATABASE AirMaintenanceSystem;

CREATE TABLE Users(
User_ID INT NOT NULL PRIMARY KEY ,
User_Name NVARCHAR (100) NOT NULL ,
User_Email NVARCHAR (100) NOT NULL,
User_Password VARCHAR(100) NOT NULL,
User_Type VARCHAR (100) NOT NULL
);

CREATE TABLE Tasks(
Task_ID INT NOT NULL PRIMARY KEY ,
Task_Description NVARCHAR(500) NOT NULL,
Task_Schedule NVARCHAR(500) NOT NULL,
Task_Type VARCHAR (500) NOT NULL,
Task_Status VARCHAR (500) NOT NULL,
User_ID INT NOT NULL,
FOREIGN KEY (User_ID) REFERENCES Users(User_ID)
);


CREATE TABLE Stations(
Station_ID INT NOT NULL PRIMARY KEY ,
Station_Name VARCHAR(200) NOT NULL ,
);
--DROP TABLE Statons;

CREATE TABLE Monitors(
Monitor_ID INT NOT NULL PRIMARY KEY ,
Monitor_Name VARCHAR (200) NOT NULL ,
Monitor_Type VARCHAR (200) NOT NULL ,
Station_ID INT NOT NULL,
FOREIGN KEY (Station_ID) REFERENCES Stations(Station_ID)
);
--DROP TABLE Monitors;

CREATE TABLE MonitorTasks(
MonitorTask_ID INT NOT NULL PRIMARY KEY,
Monitor_ID INT NOT NULL ,
Task_ID INT NOT NULL ,
FOREIGN KEY (Monitor_ID) REFERENCES Monitors(Monitor_ID),
FOREIGN KEY (Task_ID) REFERENCES Tasks(Task_ID)
);
--DROP TABLE MonitorsTasks;

				  --Users
INSERT Users VALUES (01,'Birendra','birendra@system.dk','system','Technician');
INSERT Users VALUES (02,'Anina','anina@system.dk','system','Technician');
INSERT Users VALUES (05,'Vitus','vitus@system.dk','system','Technician');
INSERT Users VALUES (06,'Monique','monique@system.dk','system','Technician');
INSERT Users VALUES (07,'Megija','megija@system.dk','system','Technician');
INSERT Users VALUES (03,'Mohammed','mohammed@system.dk','system','Technician');
INSERT Users VALUES (04,'Jamshid','jamshid@system.dk','system','Technician');
--INSERT Users VALUES (08,'Mohammed','mohammed@system.dk','system','Researcher');
--INSERT Users VALUES (09,'Jamshid','jamshid@system.dk','system','Researcher');


                                     --Tasks
INSERT Tasks VALUES (1,'Change the filters on API monitors',           'Every Week',      'Check','Done',01);
INSERT Tasks VALUES (2,'Check TEOM',                                   'Every Week',      'Check','Done',02);
INSERT Tasks VALUES (3,'Change filter HVS',                            'Every Week',      'Check','Not Done',05);
INSERT Tasks VALUES (4,'SMPS check impactor flow(between 0.95-1.o5)',  'Every 3 months',  'Register','Not Done',06);
INSERT Tasks VALUES (5,'SMPS check butanol',                           'Every Week',      'Check','Done',07);
INSERT Tasks VALUES (6,'SMPS graph/curve-bell shaped',                 'Every Week',      'Check','Not Done',01);
INSERT Tasks VALUES (7,'Change BTX passive sampler',                   'Every week',      'Check','Done',02);
INSERT Tasks VALUES (8,'FPO filter change',                            'Every Week',      'Check','Not Done',05);
INSERT Tasks VALUES (9,'Change filter EC/OC',                          'Every 2 Weeks',   'Check','Done',06);
INSERT Tasks VALUES (10,'Change filter LVS',                           'Every 2 Weeks',   'Check','Not Done',07);
INSERT Tasks VALUES (11,'Change impactor, clean nozzles PM heads',     'Every 2 Weeks',   'Check','Not Done',01);
INSERT Tasks VALUES (12,'Denuder tubes change',                        'Every 2 Weeks',   'Check','Done',02);
INSERT Tasks VALUES (13,'VOC tube change',                             'Every 3 Weeks',   'Check','Not Done',05);
INSERT Tasks VALUES (14,'SMPS front impactor clean',                   'Every month ',    'Check','Done',06);
INSERT Tasks VALUES (15,'Clean HVS head',                              'Every 2 month',   'Check','Done',01);
INSERT Tasks VALUES (16,'Change API Tube',                             'Every 3 months',  'Check','Done',07);
INSERT Tasks VALUES (17,'LVS Control',                                 'Every 3 Months',  'Register','Not Done',06);
INSERT Tasks VALUES (18,'03 calibration',                              'Every 3 Months',  'Register','Not Done',05);
INSERT Tasks VALUES (19,'TEOM Flow Measurements',                      'Every 3 months ', 'Register','Not Done',01);
INSERT Tasks VALUES (20,'FPO control/ calibration',                    'Every 3 month',   'Register','Done',01);
INSERT Tasks VALUES (21,'CO Calibration(change CO gas)',               'Every 3 months',  'Register','Done',02);
INSERT Tasks VALUES (22,'NOx colabration,',                            'Every 3 months',  'Register','Not Done',02);
INSERT Tasks VALUES (23,'Change filter HVS (change NO gas)',           'Every 3 months',  'Register','Done',05);
INSERT Tasks VALUES (24,'SMPS PM head change',                          'Every 6 months', 'Check','Not Done',06);
INSERT Tasks VALUES (25,'SMPS PM1 cyclone clean/change',               'Every 6 months',  'Check','Not Done',07);
INSERT Tasks VALUES (26,'Change LVS EC/OC+ION PM-2.5 head',            'Every 6 Months',  'Check','Done',07);
INSERT Tasks VALUES (27,'Change TEOM heads',                           'Every 6 Months',  'Check','Done',06);
INSERT Tasks VALUES (28,'LVS cool lamella and main filter changes',    'Once a year',     'Register','Done',05);
INSERT Tasks VALUES (29,'LVS calibration',                             'Once a year',     'Register','Done',07);
INSERT Tasks VALUES (30,'Check cool in 0-air cartridge',               'Every 3 Months',  'Check','Not Done',02);
INSERT Tasks VALUES (31,'Check pura fill in 0-air cartridge',          'Every 2  year',   'Check','Done',01);

              --Stations
INSERT Stations VALUES (1103, 'HCAB');
INSERT Stations VALUES (2090, 'RISØ/DMU');
INSERT Stations VALUES (1257, 'Jagtvej');
INSERT Stations VALUES (1259, 'HCØ');
INSERT Stations VALUES (2091, 'RISØ ENVS');
INSERT Stations VALUES (2650, 'Hvidovre');
INSERT Stations VALUES (7060, 'Ulborg');
INSERT Stations VALUES (9054, 'Føllesbjerg' );
INSERT Stations VALUES (9159, 'Odense tag' );
INSERT Stations VALUES (9156, 'Odense gade' );
INSERT Stations VALUES (6160, 'Aarhus' );
INSERT Stations VALUES (6003, 'TANGE FPO');
INSERT Stations VALUES (6001, 'anholt');
                                 
							--Monitors
INSERT Monitors VALUES (111,'NOx','Gas-Monitor',1103);
INSERT Monitors VALUES (112,'CO','Gas-Monitor',2090);
INSERT Monitors VALUES (113,'O3','Gas-Monitor',1257);
INSERT Monitors VALUES (114,'SO2','Gas-Monitor',1259);
INSERT Monitors VALUES (115,'TEOM PM-10','Particle-Monitor',2091);
INSERT Monitors VALUES (116,'SMPS','Particle-Monitor',2650);
INSERT Monitors VALUES (117,'LVS PM 2.5','Particle-Monitor',7060);
INSERT Monitors VALUES (118,'LVS EC-OC','Particle-Monitor',9054);
INSERT Monitors VALUES (119,'LVS PM 2.5 ION','Particle-Monitor',9159);
INSERT Monitors VALUES (120,'FPO','Particle-Monitor',9156);
INSERT Monitors VALUES (121,'Denuder ap.','Particle-Monitor',6160);
INSERT Monitors VALUES (122,'LVS PM-10 HM','Particle-Monitor',6003);
INSERT Monitors VALUES (123,'NOx','Gas-Monitor',6001);
INSERT Monitors VALUES (124,'NOx','Gas-Monitor',2090);
INSERT Monitors VALUES (125,'CO','Gas-Monitor',1103);
INSERT Monitors VALUES (126,'O3','Gas-Monitor',1103);
INSERT Monitors VALUES (127,'SO2','Gas-Monitor',1103);
INSERT Monitors VALUES (128,'TEOM PM-10','Particle-Monitor',1103);
INSERT Monitors VALUES (129,'SMPS','Particle-Monitor',1103);
INSERT Monitors VALUES (130,'LVS PM 2.5','Particle-Monitor',2090);
INSERT Monitors VALUES (131,'LVS EC-OC','Particle-Monitor',1103);
INSERT Monitors VALUES (132,'LVS PM 2.5 ION','Particle-Monitor',2090);
INSERT Monitors VALUES (133,'FPO','Particle-Monitor',2090);
INSERT Monitors VALUES (134,'Denuder ap.','Particle-Monitor',2090);
INSERT Monitors VALUES (135,'LVS PM-10 HM','Particle-Monitor',6001);
INSERT Monitors VALUES (136,'NOx','Gas-Monitor',1257);
INSERT Monitors VALUES (137,'CO','Gas-Monitor',1259);
INSERT Monitors VALUES (138,'O3','Gas-Monitor',2091);
INSERT Monitors VALUES (139,'SO2','Gas-Monitor',2650);
INSERT Monitors VALUES (140,'TEOM PM-10','Particle-Monitor',1257);
INSERT Monitors VALUES (141,'SMPS','Particle-Monitor',1259);
INSERT Monitors VALUES (142,'LVS PM 2.5','Particle-Monitor',2091);
INSERT Monitors VALUES (143,'LVS EC-OC','Particle-Monitor',2650);
INSERT Monitors VALUES (144,'LVS PM 2.5 ION','Particle-Monitor',1257);
INSERT Monitors VALUES (145,'FPO','Particle-Monitor',1259);
INSERT Monitors VALUES (146,'Denuder ap.','Particle-Monitor',2091);
INSERT Monitors VALUES (147,'LVS PM-10 HM','Particle-Monitor',2650);
INSERT Monitors VALUES (148,'NOx','Gas-Monitor',1257);
INSERT Monitors VALUES (149,'NOx','Gas-Monitor',7060);
INSERT Monitors VALUES (150,'CO','Gas-Monitor',9054);
INSERT Monitors VALUES (151,'O3','Gas-Monitor',9159);
INSERT Monitors VALUES (152,'SO2','Gas-Monitor',7060);
INSERT Monitors VALUES (153,'TEOM PM-10','Particle-Monitor',9054);
INSERT Monitors VALUES (154,'SMPS','Particle-Monitor',9159);
INSERT Monitors VALUES (155,'LVS PM 2.5','Particle-Monitor',9159);
INSERT Monitors VALUES (156,'LVS EC-OC','Particle-Monitor',7060);
INSERT Monitors VALUES (157,'LVS PM 2.5 ION','Particle-Monitor',9054);
INSERT Monitors VALUES (158,'FPO','Particle-Monitor',9054);
INSERT Monitors VALUES (159,'Denuder ap.','Particle-Monitor',7060);
INSERT Monitors VALUES (160,'LVS PM-10 HM','Particle-Monitor',9159);
INSERT Monitors VALUES (161,'NOx','Gas-Monitor',9054);
INSERT Monitors VALUES (162,'NOx','Gas-Monitor',6001);
INSERT Monitors VALUES (163,'SO2','Gas-Monitor',6003);
INSERT Monitors VALUES (164,'TEOM PM-10','Particle-Monitor',6160);
INSERT Monitors VALUES (165,'SMPS','Particle-Monitor',6160);
INSERT Monitors VALUES (166,'LVS PM 2.5','Particle-Monitor',6003);
INSERT Monitors VALUES (167,'LVS EC-OC','Particle-Monitor',6160);
INSERT Monitors VALUES (168,'LVS PM 2.5 ION','Particle-Monitor',6001);
INSERT Monitors VALUES (169,'FPO','Particle-Monitor',6160);
INSERT Monitors VALUES (170,'Denuder ap.','Particle-Monitor',9054);
INSERT Monitors VALUES (171,'LVS PM-10 HM','Particle-Monitor',6160);
INSERT Monitors VALUES (172,'NOx','Gas-Monitor',6003);
INSERT Monitors VALUES (173,'CO','Gas-Monitor',9156);
INSERT Monitors VALUES (174,'SO2','Gas-Monitor',9156);
INSERT Monitors VALUES (175,'LVS PM 2.5 ION','Particle-Monitor',9156);
INSERT Monitors VALUES (176,'NOx','Gas-Monitor',9156);

                     --MonitorTasks
INSERT MonitorTasks VALUES (1001,111,1);
INSERT MonitorTasks VALUES (1002,112,2);
INSERT MonitorTasks VALUES (1003,113,1);
INSERT MonitorTasks VALUES (1004,114,1);
INSERT MonitorTasks VALUES (1005,111,2);
INSERT MonitorTasks VALUES (1006,112,3);
INSERT MonitorTasks VALUES (1007,114,10);
INSERT MonitorTasks VALUES (1008,116,12);
INSERT MonitorTasks VALUES (1009,118,13);
INSERT MonitorTasks VALUES (1010,119,14);
INSERT MonitorTasks VALUES (1011,112,12);
INSERT MonitorTasks VALUES (1012,111,13);
INSERT MonitorTasks VALUES (1013,112,1);
INSERT MonitorTasks VALUES (1014,123,2);
INSERT MonitorTasks VALUES (1015,124,3);
INSERT MonitorTasks VALUES (1016,125,4);
INSERT MonitorTasks VALUES (1017,126,5);
INSERT MonitorTasks VALUES (1018,127,6);
INSERT MonitorTasks VALUES (1019,128,7);
INSERT MonitorTasks VALUES (1020,129,7);
INSERT MonitorTasks VALUES (1021,111,1);
INSERT MonitorTasks VALUES (1022,121,2);
INSERT MonitorTasks VALUES (1023,116,1);
INSERT MonitorTasks VALUES (1024,117,4);
INSERT MonitorTasks VALUES (1025,118,8);
INSERT MonitorTasks VALUES (1026,119,9);
INSERT MonitorTasks VALUES (1027,120,20);
INSERT MonitorTasks VALUES (1028,120,22);
INSERT MonitorTasks VALUES (1029,121,23);
INSERT MonitorTasks VALUES (1030,114,24);
INSERT MonitorTasks VALUES (1031,120,1);
INSERT MonitorTasks VALUES (1032,121,2);
INSERT MonitorTasks VALUES (1033,122,1);
INSERT MonitorTasks VALUES (1034,123,4);
INSERT MonitorTasks VALUES (1035,124,8);
INSERT MonitorTasks VALUES (1036,125,9);
INSERT MonitorTasks VALUES (1037,126,20);
INSERT MonitorTasks VALUES (1038,127,22);
INSERT MonitorTasks VALUES (1039,128,23);
INSERT MonitorTasks VALUES (1040,129,24);

INSERT MonitorTasks VALUES (1041,112,1);
INSERT MonitorTasks VALUES (1042,111,2);
INSERT MonitorTasks VALUES (1043,112,3);
INSERT MonitorTasks VALUES (1044,113,4);
INSERT MonitorTasks VALUES (1045,114,5);
INSERT MonitorTasks VALUES (1046,111,6);
INSERT MonitorTasks VALUES (1047,113,5);
INSERT MonitorTasks VALUES (1048,114,22);
INSERT MonitorTasks VALUES (1049,122,22);
INSERT MonitorTasks VALUES (1050,122,22);





