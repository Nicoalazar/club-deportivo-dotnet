-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: grupo20_club
-- Source Schemata: grupo20
-- Created: Thu Oct  9 21:11:34 2025
-- Workbench Version: 8.0.42
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema grupo20_club
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `grupo20_club` ;
CREATE SCHEMA IF NOT EXISTS `grupo20_club` ;

-- ----------------------------------------------------------------------------
-- Table grupo20_club.personas
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_club`.`personas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NOT NULL,
  `apellido` VARCHAR(100) NOT NULL,
  `sexo` ENUM('Masculino', 'Femenino', 'Otros') NOT NULL,
  `tipo` ENUM('DNI', 'Pasaporte', 'Extranjero') NOT NULL,
  `documento` VARCHAR(30) NOT NULL,
  `creado_en` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `socio` TINYINT NULL DEFAULT '0',
  `telefono` VARCHAR(20) NULL DEFAULT NULL,
  `email` VARCHAR(50) NULL DEFAULT NULL,
  `aptoFisico` TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uk_postulante_tipo_doc` (`tipo` ASC, `documento` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 29
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_club.roles
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_club`.`roles` (
  `RolUsu` INT NOT NULL,
  `NomRol` VARCHAR(30) NULL DEFAULT NULL,
  PRIMARY KEY (`RolUsu`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_club.usuario
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_club`.`usuario` (
  `CodUsu` INT NOT NULL AUTO_INCREMENT,
  `NombreUsu` VARCHAR(20) NULL DEFAULT NULL,
  `PassUsu` VARCHAR(15) NULL DEFAULT NULL,
  `RolUsu` INT NULL DEFAULT NULL,
  `Activo` TINYINT(1) NULL DEFAULT '1',
  PRIMARY KEY (`CodUsu`),
  INDEX `fk_usuario` (`RolUsu` ASC) VISIBLE,
  CONSTRAINT `fk_usuario`
    FOREIGN KEY (`RolUsu`)
    REFERENCES `grupo20_club`.`roles` (`RolUsu`))
ENGINE = InnoDB
AUTO_INCREMENT = 30
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Routine grupo20_club.IngresoLogin
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_club`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `IngresoLogin`(in Usu varchar(20),in Pass varchar(15))
BEGIN
select NomRol
	from usuario u inner join roles r on u.RolUsu = r.RolUsu
		where NombreUsu = Usu and PassUsu = Pass /* se compara con los parametros */
			and Activo = 1; /* el usuario debe estar activo */
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_club.sp_persona_insert
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_club`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_persona_insert`(
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
BEGIN
INSERT INTO personas (nombre, apellido, sexo, tipo, documento, email, telefono, socio, aptoFisico)
VALUES (p_nombre, p_apellido, p_sexo, p_tipo, p_documento, p_email, p_telefono, p_socio, p_aptoFisico)
ON DUPLICATE KEY UPDATE id = id;
END$$

DELIMITER ;
SET FOREIGN_KEY_CHECKS = 1;
