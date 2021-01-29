CREATE TABLE IF NOT EXISTS `chacras` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `consulenteID` int NOT NULL,
  `atendenteID` int NOT NULL,
  `data_atendimento` date NOT NULL,
  `basico` int NOT NULL,
  `coronario` int NOT NULL,
  `cardiaco` int NOT NULL,
  `laringeo` int NOT NULL,
  `umbilical` int NOT NULL,
  `frontal` int NOT NULL,
  `plexosolar` int NOT NULL,
  `tipo_medicao` varchar(2) NOT NULL,
  PRIMARY KEY (`id`)
);