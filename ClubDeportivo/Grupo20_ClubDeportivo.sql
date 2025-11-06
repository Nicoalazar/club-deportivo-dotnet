-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: grupo20_ClubDeportivo
-- Source Schemata: grupo20
-- Created: Wed Nov  5 21:45:33 2025
-- Workbench Version: 8.0.43
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema grupo20_ClubDeportivo
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `grupo20_ClubDeportivo` ;
CREATE SCHEMA IF NOT EXISTS `grupo20_ClubDeportivo` ;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.configuracion_cuotas
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`configuracion_cuotas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `tipo_cuota` ENUM('Mensual', 'Diaria') NOT NULL DEFAULT 'Diaria',
  `importe_actual` DOUBLE NOT NULL,
  `vigente_desde` DATE NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.cuotas_socios
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`cuotas_socios` (
  `id_pago` INT NOT NULL AUTO_INCREMENT,
  `id_socio` INT NOT NULL,
  `periodo` CHAR(6) NOT NULL,
  `fecha_vencimiento` DATE NOT NULL,
  `fecha_pago` DATE NULL DEFAULT NULL,
  `monto` DOUBLE NOT NULL,
  `medio` ENUM('Efectivo', 'Virtual', 'Debito', 'Credito') NULL DEFAULT NULL,
  `usuario_registro` VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (`id_pago`),
  INDEX `fk_socio` (`id_socio` ASC),
  CONSTRAINT `fk_socio`
    FOREIGN KEY (`id_socio`)
    REFERENCES `grupo20_ClubDeportivo`.`socios` (`id_socio`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 28
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.no_socios
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`no_socios` (
  `id_no_socio` INT NOT NULL AUTO_INCREMENT,
  `id_persona` INT NOT NULL,
  `estado` ENUM('Adherente', 'Baja Administrativa', 'Baja Voluntaria') NULL DEFAULT 'Adherente',
  `apto_fisico_vencimiento` DATE NULL DEFAULT NULL,
  `motivo` VARCHAR(255) NULL DEFAULT NULL,
  `fecha_registro` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fecha_actualizacion` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id_no_socio`),
  INDEX `fk_no_socios_personas` (`id_persona` ASC),
  CONSTRAINT `fk_no_socios_personas`
    FOREIGN KEY (`id_persona`)
    REFERENCES `grupo20_ClubDeportivo`.`personas` (`id_persona`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.pases_diarios
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`pases_diarios` (
  `id_pase` INT NOT NULL AUTO_INCREMENT,
  `id_no_socio` INT NOT NULL,
  `fecha` DATE NOT NULL,
  `monto` DOUBLE NOT NULL,
  `medio` ENUM('Efectivo', 'Virtual', 'Debito', 'Credito') NULL DEFAULT 'Efectivo',
  `usuario_registro` VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (`id_pase`),
  INDEX `fk_no_socio` (`id_no_socio` ASC),
  CONSTRAINT `fk_no_socio`
    FOREIGN KEY (`id_no_socio`)
    REFERENCES `grupo20_ClubDeportivo`.`no_socios` (`id_no_socio`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.personas
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`personas` (
  `id_persona` INT NOT NULL AUTO_INCREMENT,
  `nombres` VARCHAR(80) NOT NULL,
  `apellidos` VARCHAR(100) NOT NULL,
  `sexo` ENUM('Masculino', 'Femenino', 'Otros') NOT NULL,
  `tipo_documento` ENUM('DNI', 'Pasaporte') NOT NULL,
  `nro_documento` VARCHAR(10) NOT NULL,
  `fecha_nacimiento` DATE NULL DEFAULT NULL,
  `email` VARCHAR(120) NULL DEFAULT NULL,
  `telefono` VARCHAR(30) NULL DEFAULT NULL,
  `domicilio` VARCHAR(200) NULL DEFAULT NULL,
  `es_activo` TINYINT NOT NULL DEFAULT '1',
  `fecha_modificacion` DATETIME NULL DEFAULT NULL,
  `fecha_alta` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_persona`))
ENGINE = InnoDB
AUTO_INCREMENT = 56
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.roles
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`roles` (
  `RolUsu` INT NOT NULL,
  `NomRol` VARCHAR(30) NULL DEFAULT NULL,
  PRIMARY KEY (`RolUsu`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.socios
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`socios` (
  `id_socio` INT NOT NULL AUTO_INCREMENT,
  `id_persona` INT UNSIGNED NOT NULL,
  `fecha_alta` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fecha_baja` DATETIME NULL DEFAULT NULL,
  `apto_fisico_vencimiento` DATE NULL DEFAULT NULL,
  `observaciones` VARCHAR(225) NULL DEFAULT NULL,
  PRIMARY KEY (`id_socio`))
ENGINE = InnoDB
AUTO_INCREMENT = 11
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table grupo20_ClubDeportivo.usuario
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `grupo20_ClubDeportivo`.`usuario` (
  `CodUsu` INT NOT NULL AUTO_INCREMENT,
  `NombreUsu` VARCHAR(20) NULL DEFAULT NULL,
  `PassUsu` VARCHAR(15) NULL DEFAULT NULL,
  `RolUsu` INT NULL DEFAULT NULL,
  `Activo` TINYINT(1) NULL DEFAULT '1',
  PRIMARY KEY (`CodUsu`),
  INDEX `fk_usuario` (`RolUsu` ASC),
  CONSTRAINT `fk_usuario`
    FOREIGN KEY (`RolUsu`)
    REFERENCES `grupo20_ClubDeportivo`.`roles` (`RolUsu`))
ENGINE = InnoDB
AUTO_INCREMENT = 36
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- View grupo20_ClubDeportivo.personas_data
-- ----------------------------------------------------------------------------
USE `grupo20_ClubDeportivo`;
CREATE VIEW `grupo20_ClubDeportivo`.`personas_data` AS 
SELECT `s`.`id_socio` AS `Id`,
		'Socio' AS `Categoría`,
        `p`.`nombres` AS `Nombres`,
        `p`.`apellidos` AS `Apellidos`,
        `p`.`sexo` AS `Sexo`,
        `p`.`tipo_documento` AS `Tipo`,
        `p`.`nro_documento` AS `NroDocumento`,
        `p`.`fecha_nacimiento` AS `Nacimiento`,
        `p`.`email` AS `Email`,
        `s`.`apto_fisico_vencimiento` AS `VtoAptoFisico`
        ,'Activo' AS `Estado`,
        `s`.`fecha_alta` AS `FechaAlta` 
FROM (`grupo20_ClubDeportivo`.`personas` `p` 
JOIN `grupo20_ClubDeportivo`.`socios` `s` 
ON ((`p`.`id_persona` = `s`.`id_persona`)))
 WHERE (`s`.`fecha_baja` is null) 
 UNION 
SELECT `n`.`id_no_socio` AS `Id`,
		'No Socio' AS `Categoría`,
        `p1`.`nombres` AS `Nombres`,
        `p1`.`apellidos` AS `Apellidos`,
        `p1`.`sexo` AS `Sexo`,
        `p1`.`tipo_documento` AS `Tipo`,
        `p1`.`nro_documento` AS `NroDocumento`,
        `p1`.`fecha_nacimiento` AS `Nacimiento`,
        `p1`.`email` AS `Email`,
        `n`.`apto_fisico_vencimiento` AS `VtoAptoFisico`,
        `n`.`estado` AS `Estado`,
        `n`.`fecha_registro` AS `FechaAlta` 
FROM (`grupo20_ClubDeportivo`.`personas` `p1` 
JOIN `grupo20_ClubDeportivo`.`no_socios` `n` 
	ON((`p1`.`id_persona` = `n`.`id_persona`)));

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_actividad_search
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actividad_search`(
IN p_id_no_socio VARCHAR(80),
IN p_fecha DATE)
BEGIN
	SELECT count(*) AS Cantidad
    FROM pases_diarios
    WHERE id_no_socio = p_id_no_socio 
    AND fecha = p_fecha;
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_cuotas_pendientes
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cuotas_pendientes`(
    IN p_fecha DATE,
    IN p_incluir_por_vencer BOOLEAN
)
BEGIN
    SELECT 
        p.id,
        p.nombres,
        p.apellidos,
        p.email,
        ps.periodo,
        ps.fecha_vencimiento,
        ps.monto,
        DATEDIFF(p_fecha, ps.fecha_vencimiento) AS dias_vencidos,
        CASE 
            WHEN ps.fecha_vencimiento < p_fecha THEN 'VENCIDO'
            WHEN ps.fecha_vencimiento = p_fecha THEN 'VENCE HOY'
            ELSE 'POR VENCER'
        END AS estado
    FROM personas_data p
    INNER JOIN cuotas_socios ps 
        ON p.id = ps.id_socio AND p.Categoría = 'Socio'
    WHERE ps.fecha_pago IS NULL
      AND (
            p_incluir_por_vencer = TRUE
            OR ps.fecha_vencimiento <= p_fecha
          )
    ORDER BY ps.fecha_vencimiento ASC, p.apellidos, p.nombres;
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_generar_cuotas
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_generar_cuotas`(
    IN p_periodo CHAR(6),           -- Ej: '202411'
    IN p_dia_vencimiento INT,        -- Ej: 10 (día del mes)
    IN p_monto double,
    IN p_usuario VARCHAR(100)
)
BEGIN
    DECLARE v_fecha_vencimiento DATE;
    
    -- Calcular fecha de vencimiento (AAAAMM + día)
    SET v_fecha_vencimiento = STR_TO_DATE(
        CONCAT(p_periodo, LPAD(p_dia_vencimiento, 2, '0')), 
        '%Y%m%d'
    );
    
    -- Insertar cuotas solo para socios que no tienen ese periodo registrado
    INSERT INTO cuotas_socios (
        id_socio, 
        periodo, 
        fecha_vencimiento, 
        fecha_pago,
        monto, 
        usuario_registro
    )
    SELECT 
        s.id_socio,
        p_periodo,
        v_fecha_vencimiento,
        NULL,  -- Sin pagar
        p_monto, 
        p_usuario
    FROM socios s
    WHERE s.fecha_baja is null  -- Solo socios activos
      AND NOT EXISTS (
          SELECT 1 FROM cuotas_socios cs 
          WHERE cs.id_socio = s.id_socio 
            AND cs.periodo = p_periodo
      );
      
    SELECT ROW_COUNT() AS cuotas_generadas;
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_login
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login`(in Usu varchar(20),in Pass varchar(15))
BEGIN
select NomRol, NombreUsu
	from usuario u inner join roles r on u.RolUsu = r.RolUsu
		where NombreUsu = Usu and PassUsu = Pass
			and Activo = 1;
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_no_socio_insert
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_no_socio_insert`(
	IN p_id_persona  INT,
    IN p_estado      ENUM('Adherente','Baja Administrativa','Baja Voluntaria'),
	IN p_apto_vencimiento   DATE,
    IN p_motivo      VARCHAR(255)
)
BEGIN
	INSERT INTO no_socios (
        id_persona,
        estado,
        apto_fisico_vencimiento,
        motivo
    ) VALUES (
        p_id_persona,
        p_estado,
        p_apto_vencimiento,
        p_motivo
    );
    SELECT LAST_INSERT_ID() AS id_no_socio;
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_pago_actividad
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pago_actividad`(
    IN p_id_no_socio INT,
    IN p_fecha DATE,
    IN p_monto DOUBLE,
    IN p_medio ENUM('Efectivo','Virtual','Debito','Credito'),
    IN p_usuario VARCHAR(20)
)
BEGIN
    INSERT INTO pases_diarios (
        id_no_socio,
        fecha,
        monto,
        medio,
        usuario_registro
    ) VALUES (
        p_id_no_socio,
        p_fecha,
        p_monto,
        p_medio,
        p_usuario
    );
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_pago_cuota
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pago_cuota`(
    IN p_id_socio INT,
    IN p_periodo CHAR(6),
    IN p_medio ENUM('Efectivo','Virtual','Debito','Credito'),
    IN p_usuario VARCHAR(20)
)
BEGIN
        UPDATE cuotas_socios SET 
            fecha_pago = current_date,
            medio = p_medio,
            usuario_registro = p_usuario
			WHERE id_socio = p_id_socio 
            AND periodo = p_periodo;

END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_persona_insert
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_persona_insert`(
    IN p_nombres          VARCHAR(80),
    IN p_apellidos        VARCHAR(80),
    IN p_sexo			  VARCHAR(10),
    IN p_tipo_documento   VARCHAR(10),
    IN p_nro_documento    VARCHAR(20),
    IN p_fecha_nacimiento DATE,
    IN p_email            VARCHAR(120),
    IN p_telefono         VARCHAR(30),
    IN p_domicilio        VARCHAR(200)
  )
BEGIN
INSERT INTO personas (
nombres,
apellidos,
sexo,
        tipo_documento,
        nro_documento,
        fecha_nacimiento,
        email,
        telefono,
        domicilio
    ) VALUES (
       p_nombres         ,
   p_apellidos        ,
   p_sexo			 ,
     p_tipo_documento  ,
     p_nro_documento   ,
    p_fecha_nacimiento ,
     p_email           ,
    p_telefono        ,
  p_domicilio
	);
    SELECT LAST_INSERT_ID() AS id_persona;
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_persona_search
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_persona_search`(
IN p_nombres VARCHAR(80),
IN p_apellidos VARCHAR(80),
IN p_nro_documento VARCHAR(20)
)
BEGIN
	IF p_nombres = '' AND p_apellidos = '' AND p_nro_documento = '' THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Debe enviar al menos un valor de búsqueda';
	END IF;

    SELECT *
    FROM personas_data
   WHERE 
(
	-- Si hay documento buscar SOLO por documento exacto
    (p_nro_documento <> '' AND NroDocumento = p_nro_documento)

    OR

    -- Si NO hay documento buscar por nombre + apellido (mínimo 3 letras)
    (
        p_nro_documento = '' 
        AND LENGTH(p_nombres) >= 3
        AND LENGTH(p_apellidos) >= 3
        AND Nombres   LIKE CONCAT('%', p_nombres, '%')
        AND Apellidos LIKE CONCAT('%', p_apellidos, '%')
    )
)
LIMIT 10; -- Para evitar exceso de datos
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- Routine grupo20_ClubDeportivo.sp_socio_insert
-- ----------------------------------------------------------------------------
DELIMITER $$

DELIMITER $$
USE `grupo20_ClubDeportivo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_socio_insert`(
   IN p_id_persona         INT UNSIGNED,
   IN p_apto_vencimiento   DATE
)
BEGIN
    INSERT INTO socios (
        id_persona,
        apto_fisico_vencimiento
    ) VALUES (
        p_id_persona,
        p_apto_vencimiento
 );
    SELECT LAST_INSERT_ID() AS id_socio;
END$$

DELIMITER ;
SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO grupo20_ClubDeportivo.roles VALUES (1,'Administrador'),(2,'Empleado');

INSERT INTO grupo20_ClubDeportivo.usuario (NombreUsu, PassUsu, RolUsu) VALUES ('Admin','admin',1),('nzalazar','1234',2),('profe','1234',2);