<?php
    session_start();
    if (!isset($_SESSION['user_id'])) {
        header('location: /auth.php');
    }
    else if ($_SESSION['status'] == 'user') {
        header('location: /index.php');
    }
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Энгельский авиа-ремонтный завод</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css">
</head>
<body>
    <header class="header">
        <div class="back-header">
            <img class="header-img" src="assets/images/header.png">
        </div>
        <div class="nav-header">
            <div class="container">
                <nav class="nav">
                    <a href="/index.php" class="header-link">Главная</a>
                    <a href="/profile.php" class="header-link">Личный кабинет</a>
                    <a href="/crud/exit.php" class="header-link">Выйти</a>
                </nav>
            </div>
        </div>
    </header>
    <main class="main">
        <div class="container">
           <?php
                require_once('crud/config.php');

                 $connect = new Mysqli(SERVERNAME,DBLOGIN,PASSWORD,DBNAME);
                 $sql = "SELECT * FROM `zayavki`";
                 $result = $connect->query($sql);
                 
                 echo "<h3 class='tableTitle'>Таблица офферов</h3>
                     <br><table class='table'>
                     <thead>
                         <tr>
                             <th>Id</th>
                             <th>UserId</th>
                             <th>Образование</th>
                             <th>Должность</th>
                             <th>Описание</th>
                         </tr>
                     </thead>
                     <tbody>";
                 while($row=$result->fetch_assoc()) {
                 echo "
                             <tr>
                                 <td>$row[id]</td>
                                 <td>$row[userId]</td>
                                 <td>$row[education]</td>
                                 <td>$row[occupation]</td>
                                 <td>$row[description]</td>
                                 <td>
                                        <a class='btn btn-success btn-sm text-light' href='crud/deleteZayavka.php?id=$row[id]'>Принять</a>
                                        <a class='btn btn-danger btn-sm text-light' href='crud/deleteZayavka.php?id=$row[id]'>Отклонить</a>
                                </td>
                             </tr>";
                 }
                 echo "</tbody>
                 </table>";

                 $connect = new Mysqli(SERVERNAME,DBLOGIN,PASSWORD,DBNAME);
                 $sql = "SELECT * FROM `users`";
                 $result = $connect->query($sql);
                 echo "<h3 class='tableTitle'>Таблица пользователей</h3>
                     <br><table class='table'>
                     <thead>
                         <tr>
                            <th>Id</th>
                            <th>ФИО</th>
                            <th>Паспорт</th>
                            <th>Кем выдан</th>
                            <th>Статус</th>
                         </tr>
                     </thead>
                     <tbody>";
                 while($row=$result->fetch_assoc()) {
                 echo "
                             <tr>
                                 <td>$row[id]</td>
                                 <td>$row[name]</td>
                                 <td>$row[numpasport]</td>
                                 <td>$row[getpasport]</td>
                                 <td>$row[status]</td>
                             </tr>";
                 }
                 echo "</tbody>
                 </table>";

                 $connect->close();
           ?>
        </div>
    </main>