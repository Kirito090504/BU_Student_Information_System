-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Generation Time: Oct 02, 2024 at 03:11 PM
-- Server version: 9.0.1
-- PHP Version: 8.2.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bu_student_information_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `academic_history`
--

CREATE TABLE `academic_history` (
  `id` varchar(10) NOT NULL,
  `last_school_attended` text COMMENT 'The last school the student attended to.',
  `last_school_attended_year` year DEFAULT NULL COMMENT 'The year the student last attended their previous school.',
  `secondary_school` text COMMENT 'The name of the students secondary school.',
  `secondary_school_year` year DEFAULT NULL COMMENT 'The year the student last attended their secondary school.',
  `awards_received` text COMMENT 'JSON list containing honors/awards received by the student.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Information about the students academic history.';

-- --------------------------------------------------------

--
-- Table structure for table `cities`
--

CREATE TABLE `cities` (
  `id` int NOT NULL,
  `description` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A list of valid cities.';

-- --------------------------------------------------------

--
-- Table structure for table `cities_in_provinces`
--

CREATE TABLE `cities_in_provinces` (
  `city` int NOT NULL COMMENT 'This city is in...',
  `province` int NOT NULL COMMENT '...this province.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains information about which cities are in which provinces.';

-- --------------------------------------------------------

--
-- Table structure for table `contact_information`
--

CREATE TABLE `contact_information` (
  `id` varchar(10) NOT NULL,
  `contact_number` varchar(16) DEFAULT NULL COMMENT 'The students contact number with country code.',
  `email_address` text COMMENT 'The students email address.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Students contact information';

-- --------------------------------------------------------

--
-- Table structure for table `genders`
--

CREATE TABLE `genders` (
  `id` int NOT NULL,
  `description` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `genders`
--

INSERT INTO `genders` (`id`, `description`) VALUES
(2, 'Female'),
(1, 'Male');

-- --------------------------------------------------------

--
-- Table structure for table `nationalities`
--

CREATE TABLE `nationalities` (
  `id` int NOT NULL,
  `description` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A table containing valid values for the students nationality.';

-- --------------------------------------------------------

--
-- Table structure for table `permanent_addresses`
--

CREATE TABLE `permanent_addresses` (
  `id` varchar(10) NOT NULL,
  `line1` text COMMENT 'No./Street/Barangay',
  `city` int NOT NULL COMMENT 'The city of the students permanent address.',
  `province` int NOT NULL COMMENT 'The province of the students permanent address.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='The permanent addresses of the students.';

-- --------------------------------------------------------

--
-- Table structure for table `personalities`
--

CREATE TABLE `personalities` (
  `id` varchar(10) NOT NULL,
  `hobbies` text COMMENT 'JSON list containing the students hobbies.',
  `skills` text COMMENT 'JSON list containing students talents/skills.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A table containing the students personalities.';

-- --------------------------------------------------------

--
-- Table structure for table `present_addresses`
--

CREATE TABLE `present_addresses` (
  `id` varchar(10) NOT NULL,
  `line1` text COMMENT 'No./Street/Barangay',
  `city` int NOT NULL COMMENT 'The city of the students present address.',
  `province` int NOT NULL COMMENT 'The province of the students present address.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='The present addresses of the students.';

-- --------------------------------------------------------

--
-- Table structure for table `provinces`
--

CREATE TABLE `provinces` (
  `id` int NOT NULL,
  `description` varchar(32) NOT NULL,
  `zip_code` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A list of valid provinces.';

-- --------------------------------------------------------

--
-- Table structure for table `religions`
--

CREATE TABLE `religions` (
  `id` int NOT NULL,
  `description` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A table containing a list of religions.';

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `student_number` varchar(10) NOT NULL COMMENT 'The student number of the student in the form of XXX-XXXX.',
  `name_first` text NOT NULL COMMENT 'The first name of the student.',
  `name_middle` text COMMENT 'The middle name of the user.',
  `name_last` text NOT NULL COMMENT 'The last name of the user.',
  `photo` blob COMMENT 'The image data of the students photo.',
  `gender` int NOT NULL COMMENT 'The gender of the student.',
  `birth_date` date NOT NULL COMMENT 'The birth date of the student.',
  `birth_address` text COMMENT 'The address where the student was born.',
  `nationality` int NOT NULL COMMENT 'The students nationality.',
  `citizenship` int NOT NULL COMMENT 'The legal citizenship of the student.',
  `religion` int DEFAULT NULL COMMENT 'The religion of the student.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='The table containing students personal information.';

-- --------------------------------------------------------

--
-- Table structure for table `student_family`
--

CREATE TABLE `student_family` (
  `id` varchar(10) NOT NULL,
  `mother_name` varchar(128) DEFAULT NULL COMMENT 'The mothers full name.',
  `mother_occupation` text COMMENT 'The mothers occupation.',
  `mother_contact_number` varchar(16) DEFAULT NULL COMMENT 'The mothers contact number with country code.',
  `mother_address` text COMMENT 'The mothers address.',
  `father_name` varchar(128) DEFAULT NULL COMMENT 'The fathers full name.',
  `father_occupation` text COMMENT 'The fathers occupation.',
  `father_contact_number` varchar(16) DEFAULT NULL COMMENT 'The fathers contact number with country code.',
  `father_address` text COMMENT 'The fathers address.',
  `guardian_name` varchar(128) DEFAULT NULL COMMENT 'The guardians full name.',
  `guardian_occupation` text COMMENT 'The guardians occupation.',
  `guardian_contact_number` varchar(16) DEFAULT NULL COMMENT 'The guardians contact number with country code.',
  `guardian_address` text COMMENT 'The guardians address.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A table containing the students mother, father, and guardian.';

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int NOT NULL,
  `username` varchar(32) NOT NULL COMMENT 'The username of the user.',
  `userpass` varchar(256) NOT NULL COMMENT 'SHA-256 hashed user password.',
  `privilege` int NOT NULL DEFAULT '1' COMMENT 'The privilege level of the user.',
  `full_name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci COMMENT 'The full name of the user.',
  `photo` blob COMMENT 'The image of the user.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A table containing records of authorized users of the system.';

--
-- Indexes for dumped tables
--

--
-- Indexes for table `academic_history`
--
ALTER TABLE `academic_history`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `cities`
--
ALTER TABLE `cities`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `cities_in_provinces`
--
ALTER TABLE `cities_in_provinces`
  ADD PRIMARY KEY (`city`),
  ADD KEY `cities_in_provinces_province_provinces_id` (`province`);

--
-- Indexes for table `contact_information`
--
ALTER TABLE `contact_information`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `genders`
--
ALTER TABLE `genders`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `description` (`description`);

--
-- Indexes for table `nationalities`
--
ALTER TABLE `nationalities`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `description` (`description`);

--
-- Indexes for table `permanent_addresses`
--
ALTER TABLE `permanent_addresses`
  ADD PRIMARY KEY (`id`),
  ADD KEY `permanent_addresses_city_cities_id` (`city`),
  ADD KEY `permanent_addresses_province_provinces_id` (`province`);

--
-- Indexes for table `personalities`
--
ALTER TABLE `personalities`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `present_addresses`
--
ALTER TABLE `present_addresses`
  ADD PRIMARY KEY (`id`,`city`,`province`),
  ADD KEY `present_addresses_city_cities_id` (`city`),
  ADD KEY `present_addresses_province_provinces_id` (`province`);

--
-- Indexes for table `provinces`
--
ALTER TABLE `provinces`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `description` (`description`),
  ADD UNIQUE KEY `zip_code` (`zip_code`);

--
-- Indexes for table `religions`
--
ALTER TABLE `religions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `description` (`description`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`student_number`),
  ADD KEY `students_gender_genders_id` (`gender`),
  ADD KEY `students_nationality_nationalities_id` (`nationality`),
  ADD KEY `students_citizenship_nationalities_id` (`citizenship`),
  ADD KEY `students_religion_religions_id` (`religion`);

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
-- AUTO_INCREMENT for table `genders`
--
ALTER TABLE `genders`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `nationalities`
--
ALTER TABLE `nationalities`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `religions`
--
ALTER TABLE `religions`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `academic_history`
--
ALTER TABLE `academic_history`
  ADD CONSTRAINT `academic_history_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `cities_in_provinces`
--
ALTER TABLE `cities_in_provinces`
  ADD CONSTRAINT `cities_in_provinces_city_cities_id` FOREIGN KEY (`city`) REFERENCES `cities` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `cities_in_provinces_province_provinces_id` FOREIGN KEY (`province`) REFERENCES `provinces` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `contact_information`
--
ALTER TABLE `contact_information`
  ADD CONSTRAINT `contact_information_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `permanent_addresses`
--
ALTER TABLE `permanent_addresses`
  ADD CONSTRAINT `permanent_addresses_city_cities_id` FOREIGN KEY (`city`) REFERENCES `cities` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `permanent_addresses_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `permanent_addresses_province_provinces_id` FOREIGN KEY (`province`) REFERENCES `provinces` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Constraints for table `personalities`
--
ALTER TABLE `personalities`
  ADD CONSTRAINT `personalities_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `present_addresses`
--
ALTER TABLE `present_addresses`
  ADD CONSTRAINT `present_addresses_city_cities_id` FOREIGN KEY (`city`) REFERENCES `cities` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `present_addresses_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `present_addresses_province_provinces_id` FOREIGN KEY (`province`) REFERENCES `provinces` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `students_citizenship_nationalities_id` FOREIGN KEY (`citizenship`) REFERENCES `nationalities` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `students_gender_genders_id` FOREIGN KEY (`gender`) REFERENCES `genders` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `students_nationality_nationalities_id` FOREIGN KEY (`nationality`) REFERENCES `nationalities` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `students_religion_religions_id` FOREIGN KEY (`religion`) REFERENCES `religions` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Constraints for table `student_family`
--
ALTER TABLE `student_family`
  ADD CONSTRAINT `student_family_id_students_student_number` FOREIGN KEY (`id`) REFERENCES `students` (`student_number`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
