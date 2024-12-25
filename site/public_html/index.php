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
            <form action="crud/createZayavka.php" class="offer-form" method="post">
            <h1 class="offer-title">Заявка на вакансию</h1><br /><br/>
            <div class="form-group row">
                <label for="education" class="col-sm-2 col-form-label">Образование:</label>
                <div class="col-sm-7">
                <input name="education" type="text" class="form-control" placeholder="Название учреждения">
                </div>
            </div><br />
            <div class="form-group row">
                <label for="occupation" class="col-sm-2 col-form-label">Специальность:</label>
                <div class="col-sm-7">
                <select name="occupation" class="form-control">
                    <option>Электрик</option>
                    <option>Токарь</option>
                    <option>Фрезеровщик</option>
                    <option>Газовик</option>
                </select>
                </div>
            </div><br />
            <div class="form-group row">
                <label for="description" class="col-sm-2 col-form-label">Сопроводительное письмо:</label>
                <div class="col-sm-7">
                <textarea style="resize: none;" placeholder="Опишите себя" name="description" id="" class="form-control"></textarea>
                </div>
            </div><br /><br /><br />
            <button type="submit" class="btn btn-primary col-sm-9 mt-4">Отправить оффер</button>
            </form>
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