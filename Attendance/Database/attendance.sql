-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 30, 2022 lúc 07:24 PM
-- Phiên bản máy phục vụ: 10.4.25-MariaDB
-- Phiên bản PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `attendance`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `absent`
--

CREATE TABLE `absent` (
  `id` varchar(50) NOT NULL,
  `subject` varchar(50) NOT NULL,
  `shift` varchar(50) NOT NULL,
  `dayTime` date NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `account`
--

CREATE TABLE `account` (
  `idAccount` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `account`
--

INSERT INTO `account` (`idAccount`, `password`, `name`, `phone`, `email`) VALUES
('50000', '123456', 'Le Kim Tan Loc', '0962972784', '50000@tdtu.edu.vn'),
('50001', '123456', 'Tran Quoc Huy', '091231212', '50001@tdtu.edu.vn'),
('admin', '123456', '=))', '', '');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `calender`
--

CREATE TABLE `calender` (
  `idCalender` varchar(50) NOT NULL,
  `subject` varchar(50) NOT NULL,
  `shift` varchar(50) NOT NULL,
  `dayTime` date NOT NULL,
  `idAccount` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `calender`
--

INSERT INTO `calender` (`idCalender`, `subject`, `shift`, `dayTime`, `idAccount`) VALUES
('10000', 'Cong Nghe Phan Mem', 'Ca3', '2022-11-30', '50000');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `compensate`
--

CREATE TABLE `compensate` (
  `id` varchar(50) NOT NULL,
  `subject` varchar(50) NOT NULL,
  `shift` varchar(50) NOT NULL,
  `dayTime` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`idAccount`);

--
-- Chỉ mục cho bảng `calender`
--
ALTER TABLE `calender`
  ADD KEY `idAccount` (`idAccount`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `calender`
--
ALTER TABLE `calender`
  ADD CONSTRAINT `calender_ibfk_1` FOREIGN KEY (`idAccount`) REFERENCES `account` (`idAccount`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
