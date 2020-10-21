USE harbinger666;
-- CREATE TABLE contractors
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   address VARCHAR(255) NOT NULL,
--   contactPhone INTEGER (10) NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );

 /* INSERT INTO contractors (name, address, contactPhone) VALUES ("The Dude","123 W. Bowling Ln.","2081232546");
 INSERT INTO contractors (name, address, contactPhone) VALUES ("Walter Sobchak","1 E. Main St.","2081232478");
 INSERT INTO contractors (name, address, contactPhone) VALUES ("Theodore Donald Kerabatsos ","13 S. Easy St.","2081232546");
 INSERT INTO contractors (name, address, contactPhone) VALUES ("Maude Lebowski","4550 E. Peppercorn Dr.","2081234346");  */

 /* SELECT * FROM contractors */

-- DROP TABLE contractors
-- DROP TABLE contractors
-- DROP TABLE reviews
-- DROP TABLE bids

-- CREATE TABLE jobs
-- (
--   id INT NOT NULl AUTO_INCREMENT,
--   location VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   contactPhone INTEGER(10) NOT NULL,
--   startDate VARCHAR(255) NOT NULL,
--   timeEst VARCHAR(255) NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id) 
-- )

/* INSERT INTO jobs (location, description, contactPhone, startDate, timeEst) VALUES ("234 E. Second Ave.","Build a Bowling Ally.", "2081234567","12/1/2020", "10 Days" );
INSERT INTO jobs (location, description, contactPhone, startDate, timeEst) VALUES ("123 E. First Ave.","Build a Bowling Ally.", "2081234567","12/10/2020", "10 Days" ); */

/* SELECT * FROM jobs */

-- CREATE TABLE reviews
-- (
--   id INT AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   body VARCHAR(255) NOT NULL,
--   rating INT,
--   dateStamp VARCHAR(255),
--   contractorId INT,
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),

--   INDEX (contractorId),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (contractorId)
--     REFERENCES contractors (id)
--     ON DELETE CASCADE 
  
-- );

-- CREATE TABLE bids
-- (
--   id INT AUTO_INCREMENT,
--   jobId INT,
--   contractorId INT,
--   bidPrice DECIMAL(9,2),
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (contractorId)
--     REFERENCES contractors (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (jobId)
--     REFERENCES jobs (id)
--     ON DELETE CASCADE
-- );

