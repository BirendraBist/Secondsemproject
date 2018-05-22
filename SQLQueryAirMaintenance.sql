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
--DROP TABLE Stations;

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
--DROP TABLE MonitorTasks;


				  --Users
INSERT Users VALUES (01,'Birendra','birendra@system.dk','system','Technician');
INSERT Users VALUES (02,'Anina','anina@system.dk','system','Technician');
INSERT Users VALUES (03,'Mohammad','mohammad@system.dk','system','Researcher');
INSERT Users VALUES (04,'Jamshid','jamshid@system.dk','system','Researcher');

                  --Tasks
INSERT Tasks VALUES (1,'Change the filters on API monitors',           'Every Week',      'Check','Done',01);
INSERT Tasks VALUES (2,'Check TEOM',                                   'Every Week',      'Check','Done',02);
INSERT Tasks VALUES (3,'Change filter HVS',                            'Every Week',      'Check','Not Done',01);
INSERT Tasks VALUES (4,'SMPS check impactor flow(between 0.95-1.o5)',  'Every 3 months',  'Register','Not Done',01);
INSERT Tasks VALUES (5,'SMPS check butanol',                           'Every Week',      'Check','Done',01);
INSERT Tasks VALUES (6,'SMPS graph/curve-bell shaped',                 'Every Week',      'Check','Not Done',02);
INSERT Tasks VALUES (7,'Change BTX passive sampler',                   'Every week',      'Check','Done',02);
INSERT Tasks VALUES (8,'FPO filter change',                            'Every Week',      'Check','Not Done',02);
INSERT Tasks VALUES (9,'Change filter EC/OC',                          'Every 2 Weeks',   'Check','Done',01);
INSERT Tasks VALUES (10,'Change filter LVS',                           'Every 2 Weeks',   'Check','Not Done',01);
INSERT Tasks VALUES (11,'Change impactor, clean nozzles PM heads',     'Every 2 Weeks',   'Check','Not Done',02);
INSERT Tasks VALUES (12,'Denuder tubes change',                        'Every 2 Weeks',   'Check','Done',02);
INSERT Tasks VALUES (13,'VOC tube change',                             'Every 3 Weeks',   'Check','Not Done',01);
INSERT Tasks VALUES (14,'SMPS front impactor clean',                   'Every month ',    'Check','Done',02);
INSERT Tasks VALUES (15,'Clean HVS head',                              'Every 2 month',   'Check','Done',01);
INSERT Tasks VALUES (16,'Change API Tube',                             'Every 3 months',  'Check','Done',02);
INSERT Tasks VALUES (17,'LVS Control',                                 'Every 3 Months',  'Register','Not Done',01);
INSERT Tasks VALUES (18,'03 calibration',                              'Every 3 Months',  'Register','Not Done',02);
INSERT Tasks VALUES (19,'TEOM Flow Measurements',                      'Every 3 months ', 'Register','Not Done',01);
INSERT Tasks VALUES (20,'FPO control/ calibration',                    'Every 3 month',   'Register','Done',01);
INSERT Tasks VALUES (21,'CO Calibration(change CO gas)',               'Every 3 months',  'Register','Done',02);
INSERT Tasks VALUES (22,'NOx colabration,',                            'Every 3 months',  'Register','Not Done',01);
INSERT Tasks VALUES (23,'Change filter HVS (change NO gas)',           'Every 3 months',  'Register','Done',02);
INSERT Tasks VALUES (24,'SMPS PM head change',                          'Every 6 months', 'Check','Not Done',01);
INSERT Tasks VALUES (25,'SMPS PM1 cyclone clean/change',               'Every 6 months',  'Check','Not Done',02);
INSERT Tasks VALUES (26,'Change LVS EC/OC+ION PM-2.5 head',            'Every 6 Months',  'Check','Done',02);
INSERT Tasks VALUES (27,'Change TEOM heads',                           'Every 6 Months',  'Check','Done',01);
INSERT Tasks VALUES (28,'LVS cool lamella and main filter changes',    'Once a year',     'Register','Done',01);
INSERT Tasks VALUES (29,'LVS calibration',                             'Once a year',     'Register','Done',02);
INSERT Tasks VALUES (30,'Check cool in 0-air cartridge',               'Every 3 Months',  'Check','Not Done',02);
INSERT Tasks VALUES (31,'Check pura fill in 0-air cartridge',          'Every 2  year',   'Check','Done',01);

              --Station
INSERT Stations VALUES (1103, 'HCAB');
INSERT Stations VALUES (2090, 'RISØ/DMU');
INSERT Stations VALUES (1257, 'Jagtvej');
INSERT Stations VALUES (1259, 'HCØ');
INSERT Stations VALUES (2091, 'RISØ ENVS');
INSERT Stations VALUES (2650, 'Hvidovre');
INSERT Stations VALUES (7060, 'Ulborg');
INSERT Stations VALUES (9054, 'Føllesbjerg' );
INSERT Stations VALUES (9159, 'Odense tag' );
INSERT Stations VALUES (9156, 'Odense gade');
INSERT Stations VALUES (6160, 'Aarhus' );
INSERT Stations VALUES (6003, 'TANGE FPO' );
INSERT Stations VALUES (6001, 'anholt');

                 --Monitors
INSERT Monitors VALUES (111,'NOx','Gas-Monitor',6001);
INSERT Monitors VALUES (112,'CO','Gas-Monitor',1259);
INSERT Monitors VALUES (113,'O3','Gas-Monitor',2650);
INSERT Monitors VALUES (114,'SO2','Gas-Monitor',9054);
INSERT Monitors VALUES (115,'TEOM PM-10','Particle-Monitor',9159);
INSERT Monitors VALUES (116,'SMPS','Particle-Monitor',6003);
INSERT Monitors VALUES (117,'LVS PM 2.5','Particle-Monitor',6160);
INSERT Monitors VALUES (118,'LVS EC-OC','Particle-Monitor',2090);
INSERT Monitors VALUES (119,'LVS PM 2.5 ION','Particle-Monitor',1257);
INSERT Monitors VALUES (120,'FPO','Particle-Monitor',2650);
INSERT Monitors VALUES (121,'Denuder ap.','Particle-Monitor',2090);
INSERT Monitors VALUES (122,'LVS PM-10 HM','Particle-Monitor',9054);
 

                     --MonitorTasks
INSERT MonitorTasks VALUES (1001,111,1);
INSERT MonitorTasks VALUES (1002,112,2);
INSERT MonitorTasks VALUES (1003,113,1);
INSERT MonitorTasks VALUES (1004,114,4);
INSERT MonitorTasks VALUES (1005,111,8);
INSERT MonitorTasks VALUES (1006,112,9);
INSERT MonitorTasks VALUES (1007,114,20);
INSERT MonitorTasks VALUES (1008,116,22);
INSERT MonitorTasks VALUES (1009,118,23);
INSERT MonitorTasks VALUES (1010,119,24);









