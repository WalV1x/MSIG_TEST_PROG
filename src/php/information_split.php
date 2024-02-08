
    <!--
    Auteur      : Liandro Gameiro
    Date        : 08.02.2024
    Description : Permet de réutiliser ce code afin d'avoir les informations provenant de la base de données
    -->

<?php
global $conn, $result;

$converter = @$_GET["Converter"];
include "db.php";
?>

<link href="../css/style_tableau.css" rel="stylesheet">

<h1>Liste des jobs</h1>

<table>
    <tr>
        <th>ID</th>
        <th>Company Name</th>
        <th>Job Title</th>
        <th>Location</th>
        <th>CHF</th>
        <th>image</th>
    </tr>

    <?php
    while ($row = $result->fetch_assoc()) {
        echo "<tr>";
        echo "<td>" . $row["idJob"] . "</td>";
        echo "<td>" . $row["jobCompanyName"] . "</td>";
        echo "<td>" . $row["jobJobTitle"] . "</td>";
        echo "<td>" . $row["jobLocation"] . "</td>";
        echo "<td>" . $row["jobCHF"]. " CHF" . " " . "(" . $row["jobSalary"] . ")" . "</td>";
        echo "<td><img src='/99. TEST/src/img/{$row["jobImage"]}' alt='image inconnue'></td>";
        echo "</tr>";
    }

    $conn->close();
    ?>