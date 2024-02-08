<?php

/**
 * ETML - MSIG
 * Auteur : Liandro Gameiro
 * Date : 08.02.2024
 * Description : Connexion à la base de donnée
 */

$servername = "db";
$username = "root";
$password = "root";
$dbname = "db_india";
$port = 3306;
$conn = new mysqli($servername, $username, $password, $dbname, $port);
?>