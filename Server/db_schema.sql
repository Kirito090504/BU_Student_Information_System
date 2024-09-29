DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS students;
DROP TABLE IF EXISTS genders;
DROP TABLE IF EXISTS nationalities;
DROP TABLE IF EXISTS religions;
DROP TABLE IF EXISTS cities;
DROP TABLE IF EXISTS provinces;
DROP TABLE IF EXISTS cities_in_provinces;
DROP TABLE IF EXISTS contact_information;
DROP TABLE IF EXISTS present_addresses;
DROP TABLE IF EXISTS permanent_addresses;
DROP TABLE IF EXISTS student_family;
DROP TABLE IF EXISTS academic_history;
DROP TABLE IF EXISTS personalities;
CREATE TABLE users (
    user_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    username VARCHAR(32) NOT NULL UNIQUE COMMENT 'The username of the user.',
    userpass VARCHAR(256) NOT NULL COMMENT 'SHA-256 hashed user password.',
    name_first TEXT NOT NULL COMMENT 'The first name of the user.',
    name_middle TEXT COMMENT 'The middle name of the user.',
    name_last TEXT NOT NULL COMMENT 'The last name of the user.'
) COMMENT = 'A table containing records of authorized users of the system.';
CREATE TABLE students (
    student_number VARCHAR(10) PRIMARY KEY NOT NULL COMMENT 'The student number of the student in the form of XXX-XXXX.',
    name_first TEXT NOT NULL COMMENT 'The first name of the student.',
    name_middle TEXT COMMENT 'The middle name of the user.',
    name_last TEXT NOT NULL COMMENT 'The last name of the user.',
    photo BLOB COMMENT "The image data of the student's photo.",
    gender INT NOT NULL COMMENT 'The gender of the student.',
    birth_date DATE NOT NULL COMMENT 'The birth date of the student.',
    birth_address TEXT COMMENT 'The address where the student was born.',
    nationality INT NOT NULL COMMENT "The student's nationality.",
    citizenship INT NOT NULL COMMENT 'The legal citizenship of the student.',
    religion INT COMMENT 'The religion of the student.'
) COMMENT = "The table containing students' personal information.";
CREATE TABLE genders (
    id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    description TEXT NOT NULL UNIQUE
);
CREATE TABLE nationalities (
    id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    description VARCHAR(32) NOT NULL UNIQUE
) COMMENT = "A table containing valid values for the students' nationality.";
CREATE TABLE religions (
    id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    description VARCHAR(64) NOT NULL UNIQUE
) COMMENT = 'A table containing a list of religions.';
CREATE TABLE cities (
    id INT PRIMARY KEY NOT NULL,
    description VARCHAR(32) NOT NULL
) COMMENT = 'A list of valid cities.';
CREATE TABLE provinces (
    id INT PRIMARY KEY NOT NULL,
    description VARCHAR(32) NOT NULL UNIQUE,
    zip_code INT NOT NULL UNIQUE
) COMMENT = 'A list of valid provinces.';
CREATE TABLE cities_in_provinces (
    city INT PRIMARY KEY NOT NULL COMMENT 'This city is in...',
    province INT NOT NULL COMMENT '...this province.'
) COMMENT = 'Contains information about which cities are in which provinces.';
CREATE TABLE contact_information (
    id VARCHAR(10) PRIMARY KEY NOT NULL,
    contact_number VARCHAR(16) COMMENT "The student's contact number with country code.",
    email_address TEXT COMMENT "The student's email address."
) COMMENT = "Students' contact information";
CREATE TABLE present_addresses (
    id VARCHAR(10) NOT NULL,
    line1 TEXT COMMENT 'No./Street/Barangay',
    city INT NOT NULL COMMENT "The city of the student's present address.",
    province INT NOT NULL COMMENT "The province of the student's present address.",
    PRIMARY KEY (id, city, province)
) COMMENT = 'The present addresses of the students.';
CREATE TABLE permanent_addresses (
    id VARCHAR(10) PRIMARY KEY NOT NULL,
    line1 TEXT COMMENT 'No./Street/Barangay',
    city INT NOT NULL COMMENT "The city of the student's permanent address.",
    province INT NOT NULL COMMENT "The province of the student's permanent address."
) COMMENT = 'The permanent addresses of the students.';
CREATE TABLE student_family (
    id VARCHAR(10) PRIMARY KEY NOT NULL,
    mother_name VARCHAR(128) COMMENT "The mother's full name.",
    mother_occupation TEXT COMMENT "The mother's occupation.",
    mother_contact_number VARCHAR(16) COMMENT "The mother's contact number with country code.",
    mother_address TEXT COMMENT "The mother's address.",
    father_name VARCHAR(128) COMMENT "The father's full name.",
    father_occupation TEXT COMMENT "The father's occupation.",
    father_contact_number VARCHAR(16) COMMENT "The father's contact number with country code.",
    father_address TEXT COMMENT "The father's address.",
    guardian_name VARCHAR(128) COMMENT "The guardian's full name.",
    guardian_occupation TEXT COMMENT "The guardian's occupation.",
    guardian_contact_number VARCHAR(16) COMMENT "The guardian's contact number with country code.",
    guardian_address TEXT COMMENT "The guardian's address."
) COMMENT = "A table containing the students' mother, father, and guardian.";
CREATE TABLE academic_history (
    id VARCHAR(10) PRIMARY KEY NOT NULL,
    last_school_attended TEXT COMMENT 'The last school the student attended to.',
    last_school_attended_year YEAR COMMENT 'The year the student last attended their previous school.',
    secondary_school TEXT COMMENT "The name of the student's secondary school.",
    secondary_school_year YEAR COMMENT 'The year the student last attended their secondary school.',
    awards_received TEXT COMMENT 'JSON list containing honors/awards received by the student.'
) COMMENT = "Information about the students' academic history.";
CREATE TABLE personalities (
    id VARCHAR(10) PRIMARY KEY NOT NULL,
    hobbies TEXT COMMENT "JSON list containing the students' hobbies.",
    skills TEXT COMMENT "JSON list containing students' talents/skills."
) COMMENT = "A table containing the students' personalities.";
ALTER TABLE students
ADD CONSTRAINT students_gender_genders_id FOREIGN KEY (gender) REFERENCES genders(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE students
ADD CONSTRAINT students_nationality_nationalities_id FOREIGN KEY (nationality) REFERENCES nationalities(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE students
ADD CONSTRAINT students_citizenship_nationalities_id FOREIGN KEY (citizenship) REFERENCES nationalities(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE students
ADD CONSTRAINT students_religion_religions_id FOREIGN KEY (religion) REFERENCES religions(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE cities_in_provinces
ADD CONSTRAINT cities_in_provinces_city_cities_id FOREIGN KEY (city) REFERENCES cities(id) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE cities_in_provinces
ADD CONSTRAINT cities_in_provinces_province_provinces_id FOREIGN KEY (province) REFERENCES provinces(id) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE contact_information
ADD CONSTRAINT contact_information_id_students_student_number FOREIGN KEY (id) REFERENCES students(student_number) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE present_addresses
ADD CONSTRAINT present_addresses_id_students_student_number FOREIGN KEY (id) REFERENCES students(student_number) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE present_addresses
ADD CONSTRAINT present_addresses_city_cities_id FOREIGN KEY (city) REFERENCES cities(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE present_addresses
ADD CONSTRAINT present_addresses_province_provinces_id FOREIGN KEY (province) REFERENCES provinces(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE permanent_addresses
ADD CONSTRAINT permanent_addresses_id_students_student_number FOREIGN KEY (id) REFERENCES students(student_number) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE permanent_addresses
ADD CONSTRAINT permanent_addresses_city_cities_id FOREIGN KEY (city) REFERENCES cities(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE permanent_addresses
ADD CONSTRAINT permanent_addresses_province_provinces_id FOREIGN KEY (province) REFERENCES provinces(id) ON DELETE RESTRICT ON UPDATE CASCADE;
ALTER TABLE student_family
ADD CONSTRAINT student_family_id_students_student_number FOREIGN KEY (id) REFERENCES students(student_number) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE academic_history
ADD CONSTRAINT academic_history_id_students_student_number FOREIGN KEY (id) REFERENCES students(student_number) ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE personalities
ADD CONSTRAINT personalities_id_students_student_number FOREIGN KEY (id) REFERENCES students(student_number) ON DELETE CASCADE ON UPDATE CASCADE;