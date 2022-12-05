-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 05, 2022 lúc 02:01 PM
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
-- Cấu trúc bảng cho bảng `account`
--

CREATE TABLE `account` (
  `idAccount` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `phone` varchar(15) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `account`
--

INSERT INTO `account` (`idAccount`, `password`, `name`, `phone`, `email`) VALUES
('52000', '123456', 'Tran Quoc Huy', '09199999', '[52000@student.tdtu.edu.vn'),
('52001', '123456', 'Le Kim Tan Loc', '09199989', '[52001@student.tdtu.edu.vn'),
('admin', '123456', 'boss', '9999999', 'admin@.tdtu.edu.vn');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `calender`
--

CREATE TABLE `calender` (
  `idCalender` int(11) NOT NULL,
  `subject` varchar(100) NOT NULL,
  `shift` varchar(10) NOT NULL,
  `dayTime` datetime DEFAULT NULL,
  `idAccount` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `calender`
--

INSERT INTO `calender` (`idCalender`, `subject`, `shift`, `dayTime`, `idAccount`) VALUES
(13, 'Cong nghe phan mem', 'Ca2', '2022-12-05 00:00:00', '52000'),
(14, 'Cong nghe Java', 'Ca1', '2022-12-05 00:00:00', '52001'),
(16, 'TH Cong nghe Java', 'Ca1', '2022-12-07 00:00:00', '52001'),
(17, 'TH Cong nghe Java', 'Ca2', '2022-12-07 00:00:00', '52001'),
(20, 'Cong nghe phan mem 3', 'Ca4', '2022-12-05 00:00:00', '52000'),
(22, '[value-2]', '[value-3]', '2022-12-12 00:00:00', '52000'),
(23, '[valuasfe-2]', '[value-3]', '2022-12-12 00:00:00', '52000'),
(24, '[valfsfasue-2]', '[value-3]', '2022-12-12 00:00:00', '52000'),
(25, '[valfsassfaue-2]', '[value-3]', '2022-12-12 00:00:00', '52000');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `history`
--

CREATE TABLE `history` (
  `idCalender` int(11) NOT NULL,
  `subject` varchar(100) NOT NULL,
  `absentShift` varchar(10) NOT NULL,
  `absentDay` varchar(50) NOT NULL,
  `compensateShift` varchar(10) NOT NULL,
  `compensateDay` varchar(50) NOT NULL,
  `idAccount` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `history`
--

INSERT INTO `history` (`idCalender`, `subject`, `absentShift`, `absentDay`, `compensateShift`, `compensateDay`, `idAccount`) VALUES
(13, 'Cong nghe phan mem', 'Ca2', '2022-12-5', 'Ca 1', '2022-12-13', '52000'),
(15, 'TH Cong nghe phan mem', 'Ca3', '2022-12-5', '', '2022-12-16', '52000'),
(19, 'Cong nghe phan mem 2', 'Ca3', '2022-12-5', 'None', 'None', '52000'),
(20, 'Cong nghe phan mem 3', 'Ca4', '2022-12-5', 'Ca 1', '2022-12-10', '52000'),
(21, '[value-2]', '[value-3]', '2022-12-12', 'None', 'None', '52000');

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
  ADD PRIMARY KEY (`idCalender`),
  ADD KEY `idAccount` (`idAccount`);

--
-- Chỉ mục cho bảng `history`
--
ALTER TABLE `history`
  ADD PRIMARY KEY (`idCalender`),
  ADD KEY `idAccount` (`idAccount`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `calender`
--
ALTER TABLE `calender`
  MODIFY `idCalender` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `calender`
--
ALTER TABLE `calender`
  ADD CONSTRAINT `calender_ibfk_1` FOREIGN KEY (`idAccount`) REFERENCES `account` (`idAccount`);

--
-- Các ràng buộc cho bảng `history`
--
ALTER TABLE `history`
  ADD CONSTRAINT `history_ibfk_1` FOREIGN KEY (`idAccount`) REFERENCES `account` (`idAccount`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
