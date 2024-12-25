<?php
    session_start();
    if (!isset($_SESSION['user_id'])) {
        header('location: /auth.php');
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
        <div class="container main-container">
           <div class="profile">
            <div class="avatar">
                <img src="assets/images/worker.png" alt="" class="avatar-image">
            </div>
            <?php
                session_start();
                require_once('crud/config.php');

                $id = $_SESSION['user_id'];

                $connect = new Mysqli(SERVERNAME,DBLOGIN,PASSWORD,DBNAME);
                $sql = "SELECT * FROM `users` WHERE id = '$id'";
                $result = $connect->query($sql);
                $result = $result->fetch_assoc();

                echo "<div class='info'>
                <h4 class='worker-info'>ФИО: $result[name]</h4>
                <h4 class='worker-info'>Паспорт: $result[numpasport]</h4>
                <h4 class='worker-info'>Кем выдан: $result[getpasport]</h4>
                <h4 class='worker-info'>Номер телефона: $result[phone]</h4>
                <h4 class='worker-info'>Пароль: $result[password]</h4>
                </div>  ";
            ?>
            </div>
            <aside class="aside">
                <div class="news">
                    <div class="card">
                        <h5 class="card-title">Title</h5>
                        <p class="card-desc">
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Eum, voluptatem, tenetur similique odit dicta doloremque repudiandae debitis dignissimos sit cupiditate voluptatibus est obcaecati, nam ab quia nemo eius ea beatae?
                            Asperiores error ipsam, vero, consequuntur repudiandae eius saepe placeat cupiditate, ab impedit voluptatem. Veritatis, vitae suscipit nam eveniet quas, perferendis, quasi eum veniam praesentium hic cupiditate. Placeat eum sit tempora.
                        </p>
                    </div>
                    <div class="card mt-5">
                        <h5 class="card-title">Title</h5>
                        <p class="card-desc">
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Eum, voluptatem, tenetur similique odit dicta doloremque repudiandae debitis dignissimos sit cupiditate voluptatibus est obcaecati, nam ab quia nemo eius ea beatae?
                        </p>
                    </div>
                </div>
            </aside>
        </div>
    </main>
    <footer class="footer">
        <a href="" class="footer-contact">+7(800)555-35-35</a>
        <a href="" class="footer-contact">engels.zavod.ru</a>
        <a href="https://vk.com/id566359088" class="footer-contact">vk.com/id566359088</a>
    </footer>
</body>
</html>