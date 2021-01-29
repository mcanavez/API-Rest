CREATE TABLE IF NOT EXISTS `consulente` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `sobrenome` varchar(80) NOT NULL,
  `idade` varchar(6) NOT NULL,
  `endereco` varchar(100) NOT NULL,
  `telefone` varchar(13) NOT NULL,
  `celular` varchar(13) NOT NULL,
  `data_aniversario` date NOT NULL,
  `sexo` varchar(7) NOT NULL,
  `email` varchar(30) NOT NULL,
  `enabled` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

