CREATE SCHEMA poker;
USE poker;
CREATE TABLE winnerlog(
	id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(45),
    value INT NOT NULL,
    card1number INT NOT NULL,
	card1suit CHAR(1) NOT NULL,
    card2number INT NOT NULL,
    card2suit CHAR(1) NOT NULL,
    card3number INT NOT NULL,
    card3suit CHAR(1) NOT NULL,
    card4number INT NOT NULL,
    card4suit CHAR(1) NOT NULL,
    card5number INT NOT NULL,
    card5suit CHAR(1) NOT NULL
);
CREATE TABLE messagelog(
	id INT PRIMARY KEY AUTO_INCREMENT,
    message VARCHAR(100) NOT NULL,
    time DATETIME NOT NULL
);
CREATE TABLE roundspool(
	id INT PRIMARY KEY AUTO_INCREMENT,
    pool INT NOT NULL,
    winnername VARCHAR(45)
);