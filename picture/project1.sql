-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 01, 2017 at 03:54 PM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project1`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `AuserName` varchar(30) NOT NULL,
  `AcontactNum` varchar(20) NOT NULL,
  `Aid` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`AuserName`, `AcontactNum`, `Aid`) VALUES
('', '', ''),
('amul', '01670165108', '121'),
('anik', '01670165108', '1234'),
('yohan', '012345678', '145'),
('minhaz', '01670165108', '15288161'),
('admin', '01670165108', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `bussitctg`
--

CREATE TABLE `bussitctg` (
  `userName` varchar(50) DEFAULT NULL,
  `contactNo` varchar(50) DEFAULT NULL,
  `sitNum` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bussitctg`
--

INSERT INTO `bussitctg` (`userName`, `contactNo`, `sitNum`) VALUES
(NULL, NULL, 'A1'),
('amul', '0168245312', 'A2'),
(NULL, NULL, 'B1'),
('amul', '0168245312', 'B2'),
('amul', '0168245312', 'C1'),
('amul', '0168245312', 'C2'),
(NULL, NULL, 'D1'),
(NULL, NULL, 'D2'),
(NULL, NULL, 'E1'),
(NULL, NULL, 'E2'),
('amul', '0168245312', 'F1'),
(NULL, NULL, 'F2'),
(NULL, NULL, 'G1'),
(NULL, NULL, 'G2'),
(NULL, NULL, 'H');

-- --------------------------------------------------------

--
-- Table structure for table `bussitdtok`
--

CREATE TABLE `bussitdtok` (
  `userName` varchar(50) DEFAULT NULL,
  `contactNo` varchar(50) DEFAULT NULL,
  `sitNum` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bussitdtok`
--

INSERT INTO `bussitdtok` (`userName`, `contactNo`, `sitNum`) VALUES
('anik1', '01670165108', 'A1'),
(NULL, NULL, 'A2'),
(NULL, NULL, 'B1'),
(NULL, NULL, 'B2'),
(NULL, NULL, 'C1'),
(NULL, NULL, 'C2'),
('amul', '0168245312', 'D1'),
(NULL, NULL, 'D2'),
('Rai', '016701542317', 'E1'),
('Rai', '016701542317', 'E2'),
(NULL, NULL, 'F1'),
(NULL, NULL, 'F2'),
(NULL, NULL, 'G1'),
(NULL, NULL, 'G2'),
(NULL, NULL, 'H');

-- --------------------------------------------------------

--
-- Table structure for table `bus_sit_k_to_d`
--

CREATE TABLE `bus_sit_k_to_d` (
  `userName` varchar(50) DEFAULT NULL,
  `contactNo` varchar(50) DEFAULT NULL,
  `sitNum` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bus_sit_k_to_d`
--

INSERT INTO `bus_sit_k_to_d` (`userName`, `contactNo`, `sitNum`) VALUES
(NULL, NULL, 'A1'),
(NULL, NULL, 'A2'),
(NULL, NULL, 'B1'),
(NULL, NULL, 'B2'),
(NULL, NULL, 'C1'),
(NULL, NULL, 'C2'),
(NULL, NULL, 'D1'),
(NULL, NULL, 'D2'),
(NULL, NULL, 'E1'),
(NULL, NULL, 'E2'),
(NULL, NULL, 'F1'),
(NULL, NULL, 'F2'),
(NULL, NULL, 'G1'),
(NULL, NULL, 'G2'),
(NULL, NULL, 'H');

-- --------------------------------------------------------

--
-- Table structure for table `sit`
--

CREATE TABLE `sit` (
  `userName` varchar(100) DEFAULT NULL,
  `contactNo` varchar(100) DEFAULT NULL,
  `sitNum` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sit`
--

INSERT INTO `sit` (`userName`, `contactNo`, `sitNum`) VALUES
(NULL, NULL, 'A1'),
(NULL, NULL, 'A2'),
(NULL, NULL, 'B1'),
(NULL, NULL, 'B2'),
(NULL, NULL, 'C1'),
(NULL, NULL, 'C2'),
(NULL, NULL, 'D1'),
(NULL, NULL, 'D2'),
(NULL, NULL, 'E1'),
(NULL, NULL, 'E2'),
(NULL, NULL, 'F1'),
(NULL, NULL, 'F2'),
(NULL, NULL, 'G1'),
(NULL, NULL, 'G2'),
(NULL, NULL, 'H');

-- --------------------------------------------------------

--
-- Table structure for table `travle`
--

CREATE TABLE `travle` (
  `travleFrom` varchar(55) NOT NULL,
  `travleTo` varchar(55) NOT NULL,
  `userName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `travle`
--

INSERT INTO `travle` (`travleFrom`, `travleTo`, `userName`) VALUES
('chitagong', 'Dhaka', 'amul'),
('chitagong', 'Dhaka', 'imo'),
('chitagong', 'Dhaka', 'imo'),
('chitagong', 'Dhaka', 'minu'),
('chitagong', 'Dhaka', 'minu'),
('chitagong', 'Dhaka', 'minu'),
('chitagong', 'Dhaka', 'minu'),
('Dhaka', 'Khulna', 'minhaz007'),
('Dhaka', 'Khulna', 'amul'),
('chitagong', 'Dhaka', 'amul'),
('Dhaka', 'Khulna', 'minhaz007'),
('chitagong', 'Dhaka', 'amul'),
('Dhaka', 'chitagong', 'amul'),
('Dhaka', 'chitagong', 'minhaz007'),
('chitagong', 'Dhaka', 'amul'),
('Dhaka', 'chitagong', 'amul'),
('Dhaka', 'Khulna', 'amul'),
('Dhaka', 'Khulna', 'minhaz007'),
('chitagong', 'Dhaka', 'amul'),
('Dhaka', 'chitagong', 'amul'),
('Dhaka', 'Khulna', 'minhaz007'),
('Dhaka', 'Khulna', 'minhaz'),
('Dhaka', 'Khulna', 'amul'),
('Dhaka', 'Khulna', 'anik1'),
('Dhaka', 'Khulna', 'anik1'),
('Dhaka', 'Khulna', 'amul'),
('Dhaka', 'chitagong', 'panda'),
('Dhaka', 'Khulna', 'amul'),
('chitagong', 'Dhaka', 'anik1'),
('Dhaka', 'Khulna', 'amul'),
('chitagong', 'Dhaka', 'amul'),
('Dhaka', 'Khulna', 'amul'),
('Dhaka', 'Khulna', 'Rai'),
('Dhaka', 'chitagong', 'amul'),
('chitagong', 'Dhaka', 'amul'),
('Dhaka', 'chitagong', 'minhaz007'),
('Dhaka', 'chitagong', 'minhaz007'),
('Dhaka', 'chitagong', 'minhaz'),
('Dhaka', 'chitagong', 'minhaz007'),
('Dhaka', 'chitagong', 'minhaz007'),
('Dhaka', 'chitagong', 'amul'),
('Dhaka', 'chitagong', 'minhaz007'),
('Dhaka', 'chitagong', 'amul'),
('Dhaka', 'Khulna', 'afroza'),
('chitagong', 'Dhaka', 'amul'),
('chitagong', 'Dhaka', 'amul'),
('Dhaka', 'Khulna', 'amul');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userName` varchar(55) NOT NULL,
  `firstName` varchar(100) NOT NULL,
  `lastName` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `contactNo` varchar(100) NOT NULL,
  `dateofBirth` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userName`, `firstName`, `lastName`, `password`, `email`, `gender`, `contactNo`, `dateofBirth`) VALUES
('aa', 'aa', 'aa', 'aa', 'aa', 'Male', 'aa', '2010-Jan-1'),
('afroza', 'AFROZA', 'BEGUM', '1234', 'afroja@gmail.com', 'Male', '01654231665', '1991-Aug-6'),
('amul', 'ashfaqur', 'rahman', '121', 'amul@gmail.com', 'Male', '0168245312', '1995-June-7'),
('anik1', 'Anik', 'faisal', '1234', 'anik@gmail.com', 'Male', '01670165108', '2002-July-6'),
('imo', 'imran', 'imo', '121', 'imo@gmail.com', 'Male', '01670164380', '1993-June-7'),
('minhaz', 'MINHAZ', 'UDDIN', '1234', 'uddinminhaz09@gmail.com', 'Male', '01670165108', '1994-Aug-6'),
('minhaz007', 'minhaz', 'uddin', '1234', 'minhaz09@gmail.com', 'Male', '01670165108', '1994-Aug-6'),
('minu', 'minu', 'uddin', '121', 'minu@gmail.com', 'Female', '01625593069', '2009-Feb-2'),
('panda', 'panda', 'panda', '1234', 'panda', 'Male', '01670165107', '2005-May-6'),
('Rai', 'Raisul', 'Islam', '121', 'rai@gmail.com', 'Male', '016701542317', '1994-Apr-6');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`Aid`);

--
-- Indexes for table `bussitctg`
--
ALTER TABLE `bussitctg`
  ADD PRIMARY KEY (`sitNum`);

--
-- Indexes for table `bussitdtok`
--
ALTER TABLE `bussitdtok`
  ADD PRIMARY KEY (`sitNum`);

--
-- Indexes for table `bus_sit_k_to_d`
--
ALTER TABLE `bus_sit_k_to_d`
  ADD PRIMARY KEY (`sitNum`);

--
-- Indexes for table `sit`
--
ALTER TABLE `sit`
  ADD PRIMARY KEY (`sitNum`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userName`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
