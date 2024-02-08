
    <!--
    Auteur      : Liandro Gameiro
    Date        : 08.02.2024
    Description : Résultat de la recherche
    -->

<title>IndiaJobs - Recherche</title>

    <link href="../css/style_index.css" rel="stylesheet">

    <link href="https://cdn.jsdelivr.net/npm/daisyui@4.6.0/dist/full.min.css" rel="stylesheet" type="text/css" />
    <script src="https://cdn.tailwindcss.com"></script>

    <div class="navbar bg-base-100">
        <div class="flex-1">
            <form  action="index.php">
                <button type="submit" class="btn btn-ghost text-xl">IndiaJobs</button>
            </form>
        </div>
    </div>

    <body>
    <form method="get" action="search_user.php">
        <div class="flex-none gap-2">
            <div class="form-control">
                <input type="text" name="search" placeholder="Que cherchez-vous ?" class="input input-bordered w-24 md:w-auto" />
                <input type="hidden" value="">
            </div>
        </div>
    </form>
    </body>
    </html>
    </div>

<?php
global $conn;
include "db.php";

if (isset($_GET['search'])) {
$searchTerm = $_GET['search'];

$query = "
SELECT * FROM t_job
WHERE jobJobTitle LIKE '%$searchTerm%' LIMIT 100";

$result = $conn->query($query);
?>

<title>India - Search</title>

    <?php
    include "information_split.php";
    }
    ?>