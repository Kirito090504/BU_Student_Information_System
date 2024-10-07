-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Generation Time: Oct 07, 2024 at 02:16 PM
-- Server version: 9.0.1
-- PHP Version: 8.2.24
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */
;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */
;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */
;
/*!40101 SET NAMES utf8mb4 */
;
--
-- Database: `bu_student_information_system`
--

-- --------------------------------------------------------
--
-- Table structure for table `academic_history`
--

CREATE TABLE `academic_history` (
  `id` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `last_school_attended` text COLLATE utf8mb4_general_ci COMMENT 'The last school the student attended to.',
  `last_school_attended_year` year DEFAULT NULL COMMENT 'The year the student last attended their previous school.',
  `secondary_school` text COLLATE utf8mb4_general_ci COMMENT 'The name of the students secondary school.',
  `secondary_school_year` year DEFAULT NULL COMMENT 'The year the student last attended their secondary school.',
  `awards_received` text COLLATE utf8mb4_general_ci COMMENT 'JSON list containing honors/awards received by the student.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'Information about the students academic history.';
-- --------------------------------------------------------
--
-- Table structure for table `contact_information`
--

CREATE TABLE `contact_information` (
  `id` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `contact_number` varchar(16) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'The students contact number with country code.',
  `email_address` text COLLATE utf8mb4_general_ci COMMENT 'The students email address.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'Students contact information';
-- --------------------------------------------------------
--
-- Table structure for table `permanent_addresses`
--

CREATE TABLE `permanent_addresses` (
  `id` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `line1` text COLLATE utf8mb4_general_ci COMMENT 'No./Street/Barangay',
  `city` int NOT NULL COMMENT 'The city of the students permanent address.',
  `province` int NOT NULL COMMENT 'The province of the students permanent address.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'The permanent addresses of the students.';
-- --------------------------------------------------------
--
-- Table structure for table `personalities`
--

CREATE TABLE `personalities` (
  `id` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `hobbies` text COLLATE utf8mb4_general_ci COMMENT 'JSON list containing the students hobbies.',
  `skills` text COLLATE utf8mb4_general_ci COMMENT 'JSON list containing students talents/skills.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'A table containing the students personalities.';
-- --------------------------------------------------------
--
-- Table structure for table `present_addresses`
--

CREATE TABLE `present_addresses` (
  `id` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `line1` text COLLATE utf8mb4_general_ci COMMENT 'No./Street/Barangay',
  `city` int NOT NULL COMMENT 'The city of the students present address.',
  `province` int NOT NULL COMMENT 'The province of the students present address.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'The present addresses of the students.';
-- --------------------------------------------------------
--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `student_number` varchar(10) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'The student number of the student in the form of XXX-XXXX.',
  `name_first` text COLLATE utf8mb4_general_ci NOT NULL COMMENT 'The first name of the student.',
  `name_middle` text COLLATE utf8mb4_general_ci COMMENT 'The middle name of the user.',
  `name_last` text COLLATE utf8mb4_general_ci NOT NULL COMMENT 'The last name of the user.',
  `photo` mediumblob COMMENT 'The image data of the students photo.',
  `gender` int NOT NULL COMMENT 'The gender of the student.',
  `birth_date` date NOT NULL COMMENT 'The birth date of the student.',
  `birth_address` text COLLATE utf8mb4_general_ci COMMENT 'The address where the student was born.',
  `nationality` int NOT NULL COMMENT 'The students nationality.',
  `citizenship` int NOT NULL COMMENT 'The legal citizenship of the student.',
  `religion` int DEFAULT NULL COMMENT 'The religion of the student.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'The table containing students personal information.';
-- --------------------------------------------------------
--
-- Table structure for table `student_family`
--

CREATE TABLE `student_family` (
  `id` varchar(10) COLLATE utf8mb4_general_ci NOT NULL,
  `mother_name` varchar(128) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'The mothers full name.',
  `mother_occupation` text COLLATE utf8mb4_general_ci COMMENT 'The mothers occupation.',
  `mother_contact_number` varchar(16) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'The mothers contact number with country code.',
  `mother_address` text COLLATE utf8mb4_general_ci COMMENT 'The mothers address.',
  `father_name` varchar(128) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'The fathers full name.',
  `father_occupation` text COLLATE utf8mb4_general_ci COMMENT 'The fathers occupation.',
  `father_contact_number` varchar(16) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'The fathers contact number with country code.',
  `father_address` text COLLATE utf8mb4_general_ci COMMENT 'The fathers address.',
  `guardian_name` varchar(128) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'The guardians full name.',
  `guardian_occupation` text COLLATE utf8mb4_general_ci COMMENT 'The guardians occupation.',
  `guardian_contact_number` varchar(16) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'The guardians contact number with country code.',
  `guardian_address` text COLLATE utf8mb4_general_ci COMMENT 'The guardians address.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'A table containing the students mother, father, and guardian.';
-- --------------------------------------------------------
--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int NOT NULL,
  `username` varchar(32) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'The username of the user.',
  `userpass` varchar(256) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'SHA-256 hashed user password.',
  `privilege` int NOT NULL DEFAULT '1' COMMENT 'The privilege level of the user.',
  `full_name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci COMMENT 'The full name of the user.'
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = 'A table containing records of authorized users of the system.';
--
-- Dumping data for table `users`
--

INSERT INTO `users` (
    `user_id`,
    `username`,
    `userpass`,
    `privilege`,
    `full_name`
  )
VALUES (
    1,
    'bu_admin',
    'd24560aa8c38adb31c57edeaa556c1fc82550b3c158968b2c4299a4e31302ef2',
    2,
    NULL
  );
--
-- Indexes for dumped tables
--

--
-- Indexes for table `academic_history`
--
ALTER TABLE `academic_history`
ADD PRIMARY KEY (`id`);
--
-- Indexes for table `contact_information`
--
ALTER TABLE `contact_information`
ADD PRIMARY KEY (`id`);
--
-- Indexes for table `permanent_addresses`
--
ALTER TABLE `permanent_addresses`
ADD PRIMARY KEY (`id`);
--
-- Indexes for table `personalities`
--
ALTER TABLE `personalities`
ADD PRIMARY KEY (`id`);
--
-- Indexes for table `present_addresses`
--
ALTER TABLE `present_addresses`
ADD PRIMARY KEY (`id`) USING BTREE;
--
-- Indexes for table `students`
--
ALTER TABLE `students`
ADD PRIMARY KEY (`student_number`);
--
-- Indexes for table `student_family`
--
ALTER TABLE `student_family`
ADD PRIMARY KEY (`id`);
--
-- Indexes for table `users`
--
ALTER TABLE `users`
ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);
--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
MODIFY `user_id` int NOT NULL AUTO_INCREMENT,
  AUTO_INCREMENT = 2;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `academic_history`
--
ALTER TABLE `academic_history`
ADD CONSTRAINT `academic_history_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;
--
-- Constraints for table `contact_information`
--
ALTER TABLE `contact_information`
ADD CONSTRAINT `contact_information_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;
--
-- Constraints for table `permanent_addresses`
--
ALTER TABLE `permanent_addresses`
ADD CONSTRAINT `permanent_addresses_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;
--
-- Constraints for table `personalities`
--
ALTER TABLE `personalities`
ADD CONSTRAINT `personalities_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;
--
-- Constraints for table `present_addresses`
--
ALTER TABLE `present_addresses`
ADD CONSTRAINT `present_addresses_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;
--
-- Constraints for table `student_family`
--
ALTER TABLE `student_family`
ADD CONSTRAINT `student_family_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */
;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */
;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */
;