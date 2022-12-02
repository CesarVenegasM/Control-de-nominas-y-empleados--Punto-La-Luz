-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-12-2022 a las 02:54:26
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `puntolaluz`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `administradores`
--

CREATE TABLE `administradores` (
  `id_admin` varchar(10) NOT NULL,
  `user_admin` varchar(15) NOT NULL,
  `contr_admin` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `administradores`
--

INSERT INTO `administradores` (`id_admin`, `user_admin`, `contr_admin`) VALUES
('AD20012022', 'megaman567', '123');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `colaboradores`
--

CREATE TABLE `colaboradores` (
  `id_colab` varchar(10) NOT NULL,
  `nom_colab` varchar(45) NOT NULL,
  `fecha_ingreso` date NOT NULL,
  `puesto` varchar(45) NOT NULL,
  `salario` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `colaboradores`
--

INSERT INTO `colaboradores` (`id_colab`, `nom_colab`, `fecha_ingreso`, `puesto`, `salario`) VALUES
('15236', 'Axel Josue De La Rosa López', '2022-11-17', 'Cocina', 43.75),
('3271', 'asdas', '2022-11-30', 'Barra', 43.72),
('8151', 'asda', '2022-11-30', 'Barra', 43.85),
('9773', 'Cesar Iván Venegas Mendoza', '2022-02-09', 'Cocina', 43.74);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `entradas_salidas`
--

CREATE TABLE `entradas_salidas` (
  `fecha_es` date NOT NULL,
  `entrada` time NOT NULL,
  `salida` time NOT NULL,
  `colab` int(11) NOT NULL,
  `horasT` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `entradas_salidas`
--

INSERT INTO `entradas_salidas` (`fecha_es`, `entrada`, `salida`, `colab`, `horasT`) VALUES
('2022-11-21', '11:00:00', '19:00:00', 9773, 8),
('2022-11-22', '11:00:00', '19:00:00', 9773, 8),
('2022-11-23', '11:00:00', '19:00:00', 9773, 8),
('2022-11-27', '01:51:41', '01:51:42', 9773, NULL),
('2022-11-28', '11:09:09', '23:09:11', 9773, 12),
('2022-11-30', '11:57:40', '23:57:43', 9773, 12);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE `inventario` (
  `id_inv` int(10) NOT NULL,
  `nom_produc` varchar(45) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `area` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`id_inv`, `nom_produc`, `cantidad`, `area`) VALUES
(1010, 'Papel de baño', 6, 'Baño'),
(1011, 'Bolsa de basura pequeña', 30, 'Baño'),
(1012, 'Jabón de baño', 15, 'Baño'),
(1013, 'asd', 3, 'Baño'),
(1020, 'Jabón trastes', 10, 'Cocina'),
(1021, 'Esponja', 3, 'Cocina'),
(1022, 'Trapos', 3, 'Cocina'),
(1023, 'Vitafim', 3, 'Cocina'),
(1024, 'Guantes de látex ', 3, 'Cocina'),
(1025, 'Bolsa de basura grande', 3, 'Cocina'),
(1026, 'Porta vasos', 3, 'Cocina'),
(1027, 'Popotes', 3, 'Cocina'),
(1028, 'Vaso de 12 oz', 3, 'Cocina'),
(1029, 'Tapa domo 12 oz', 3, 'Cocina'),
(1030, 'Cahorolas', 3, 'Cocina'),
(1031, 'Servilletas', 3, 'Cocina'),
(1032, 'Cucharas', 3, 'Cocina'),
(1033, 'Papel aluminio', 3, 'Cocina'),
(1034, 'Salsa valentina', 3, 'Cocina'),
(1035, 'Limon', 3, 'Cocina'),
(1036, 'Queso monterrey', 3, 'Cocina'),
(1037, 'Queso cotija', 3, 'Cocina'),
(1038, 'Queso mozarella', 3, 'Cocina'),
(1039, 'Elote', 3, 'Cocina'),
(1040, 'Cheetos flamming', 3, 'Cocina'),
(1041, 'Tostitos Flamming ', 3, 'Cocina'),
(1042, 'Chile morita', 3, 'Cocina'),
(1043, 'Sal', 3, 'Cocina'),
(1044, 'Ajinomoto', 3, 'Cocina'),
(1045, 'Laurel', 3, 'Cocina'),
(1070, 'Cafiza', 3, 'Barra'),
(1071, 'Cepillo de grupos', 3, 'Barra'),
(1072, 'Cafe grano', 3, 'Barra'),
(1073, 'Vaso de 12 oz caliente', 3, 'Barra'),
(1074, 'Tapa 12 oz caliente', 3, 'Barra'),
(1075, 'Vaso de 12 oz frio', 3, 'Barra'),
(1076, 'vaso de 16 oz frio', 3, 'Barra'),
(1077, 'Tapa 12 oz frio', 3, 'Barra'),
(1078, 'Tapa 16 oz frio', 3, 'Barra'),
(1079, 'Servilletas', 3, 'Barra'),
(1080, 'Cocacola', 3, 'Barra'),
(1081, 'Sprite', 3, 'Barra'),
(1082, 'Leche deslactosada jersey', 3, 'Barra'),
(1083, 'Leche entera jersey', 3, 'Barra'),
(1084, 'Almendra', 3, 'Barra'),
(1085, 'Coco', 3, 'Barra'),
(1086, 'Soya', 3, 'Barra'),
(1087, 'Jarabe vainilla', 3, 'Barra'),
(1088, 'Jarabe caramelo', 3, 'Barra'),
(1089, 'Carbón activado', 3, 'Barra'),
(1090, 'Garrafón de agua', 3, 'Barra'),
(1091, 'Hielo', 3, 'Barra'),
(1110, 'Detergente para piso', 3, 'Limpieza general'),
(1111, 'Windex', 3, 'Limpieza general'),
(1112, 'Papel de manos', 3, 'Limpieza general'),
(1113, 'Insecticida', 3, 'Limpieza general'),
(1114, 'Aromatizante', 3, 'Limpieza general'),
(1115, 'Desengrasante', 3, 'Limpieza general'),
(1116, 'Swipe', 3, 'Limpieza general'),
(1117, 'Liquido para retrete', 3, 'Limpieza general');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_prod` int(11) NOT NULL,
  `producto` varchar(20) NOT NULL,
  `tipo` varchar(11) NOT NULL,
  `precio` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_prod`, `producto`, `tipo`, `precio`) VALUES
(1, 'extra shot', 'extra', 5),
(2, 'big-c', 'tamaño', 60),
(3, 'shorty', 'tamaño', 55),
(4, 'afogato', 'comida', 5),
(5, 'caliente', 'temperatura', 55),
(6, 'frio', 'temperatura', 60),
(7, 'americano', 'comida', -5),
(8, 'jarabe', 'extra', 5),
(9, 'leche alternativa', 'extra', 10),
(10, 'tradicional', 'comida', 60),
(11, 'flamming', 'comida', 65),
(12, 'Tostielote', 'comida', 90),
(13, 'papalote', 'comida', 95),
(14, 'entero', 'comida', 45),
(15, 'enterrado', 'comida', 50),
(16, 'queso', 'extra', 5),
(17, 'brownies', 'comida', 35),
(18, 'galletas', 'comida', 20),
(19, 'pan', 'comida', 25);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `id_venta` int(10) NOT NULL,
  `fecha` date NOT NULL,
  `producto` varchar(15) NOT NULL,
  `tipo` varchar(15) DEFAULT NULL,
  `extra` varchar(15) DEFAULT NULL,
  `precio` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`id_venta`, `fecha`, `producto`, `tipo`, `extra`, `precio`) VALUES
(1, '2022-11-01', 'nectar negro', 'big-c', 'extra shot', 65),
(12, '2022-11-28', 'Americano', 'Caliente', 'Leche Alternati', 50),
(13, '2022-11-28', 'Latte', 'Frio', '', 60),
(14, '2022-11-28', 'Nectar Negro', 'Big-C', 'Extra Shot', 65),
(15, '2022-11-28', 'Bandido', 'Big-C', '', 60),
(16, '2022-11-28', 'Flamming', '', 'Queso', 70),
(17, '2022-11-29', 'Americano', 'Caliente', 'Jarabe', 55),
(18, '2022-11-29', 'Nectar Negro', 'Shorty', 'Extra Shot', 60),
(19, '2022-11-29', 'Bandido', 'Big-C', '', 60),
(20, '2022-11-29', 'Bandido', 'Big-C', 'Extra Shot', 65),
(21, '2022-11-29', 'Tradicional', '', '', 60),
(22, '2022-11-29', 'Tostielote', '', 'Queso', 95),
(23, '2022-11-29', 'Galletas', '', '', 20),
(24, '2022-11-29', 'Brownies', '', '', 35),
(25, '2022-11-29', 'Brownies', '', '', 35),
(26, '2022-11-29', 'Galletas', '', '', 20),
(27, '2022-11-29', 'Brownies', '', '', 35),
(28, '2022-11-29', 'Brownies', '', '', 35),
(29, '2022-12-01', 'Americano', 'Caliente', '', 50),
(30, '2022-12-01', 'Americano', 'Caliente', 'Leche Alternati', 60);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `administradores`
--
ALTER TABLE `administradores`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indices de la tabla `colaboradores`
--
ALTER TABLE `colaboradores`
  ADD PRIMARY KEY (`id_colab`);

--
-- Indices de la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD PRIMARY KEY (`id_inv`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_prod`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`id_venta`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `ventas`
--
ALTER TABLE `ventas`
  MODIFY `id_venta` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
