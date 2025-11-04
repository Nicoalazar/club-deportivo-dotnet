CREATE DATABASE `appdb`;

-- appdb.roles definition

CREATE TABLE `roles` (
  `RolUsu` int NOT NULL,
  `NomRol` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`RolUsu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- appdb.usuario definition

CREATE TABLE `usuario` (
  `CodUsu` int NOT NULL AUTO_INCREMENT,
  `NombreUsu` varchar(20) DEFAULT NULL,
  `PassUsu` varchar(15) DEFAULT NULL,
  `RolUsu` int DEFAULT NULL,
  `Activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`CodUsu`),
  KEY `fk_usuario` (`RolUsu`),
  CONSTRAINT `fk_usuario` FOREIGN KEY (`RolUsu`) REFERENCES `roles` (`RolUsu`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- appdb.personas definition

CREATE TABLE `personas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `sexo` enum('Masculino','Femenino','Otros') NOT NULL,
  `tipo` enum('DNI','Pasaporte','Extranjero') NOT NULL,
  `documento` varchar(30) NOT NULL,
  `creado_en` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `socio` tinyint DEFAULT '0',
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `aptoFisico` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uk_postulante_tipo_doc` (`tipo`,`documento`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE DEFINER=`appuser`@`%` PROCEDURE `appdb`.`IngresoLogin`(in Usu varchar(20),in Pass varchar(15))
begin
  /* proyecto en la consulta el rol que tiene el usuario que ingresa */
  
  select NomRol
	from usuario u inner join roles r on u.RolUsu = r.RolUsu
		where NombreUsu = Usu and PassUsu = Pass /* se compara con los parametros */
			and Activo = 1; /* el usuario debe estar activo */


end;

CREATE DEFINER=`appuser`@`%` PROCEDURE `appdb`.`sp_persona_insert`(
  IN p_nombre     VARCHAR(100),
  IN p_apellido   VARCHAR(100),
  IN p_sexo		VARCHAR(10),
  IN p_tipo       VARCHAR(20), 
  IN p_documento  VARCHAR(30),
  IN p_email      VARCHAR(50),
  IN p_telefono   VARCHAR(20),
  IN p_socio      TINYINT,
  IN p_aptoFisico BINARY
  )
INSERT INTO personas (nombre, apellido, sexo, tipo, documento, email, telefono, socio, aptoFisico)
VALUES (p_nombre, p_apellido, p_sexo, p_tipo, p_documento, p_email, p_telefono, p_socio, p_aptoFisico)
ON DUPLICATE KEY UPDATE id = id;