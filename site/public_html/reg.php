<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Энгельский авиа-ремонтный завод</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css">
</head>
<body>
    <div class="container mt-5">
        <form action="crud/register.php" method="post">
            <h1 class="auth-title">Создание учетной записи</h1><br /><br/>
                <div class="form-group row">
                    <label for="name" class="col-sm-2 col-form-label">ФИО:</label>
                    <div class="col-sm-5">
                    <input name="name" type="text" class="form-control" placeholder="Иванов Иван Иваныч">
                    </div>
                </div><br />
                <div class="form-group row">
                    <label for="phone" class="col-sm-2 col-form-label">Телефон:</label>
                    <div class="col-sm-5">
                    <input name="phone" type="text" class="form-control" placeholder="+7xxx-xxx-xxx">
                    </div>
                </div><br />
                <div class="form-group row">
                    <label for="numpassport" class="col-sm-2 col-form-label">Серия/номер паспорта:</label>
                    <div class="col-sm-5">
                    <input name="numpassport" type="text" class="form-control" placeholder="63225552345">
                    </div>
                </div><br />
                <div class="form-group row">
                    <label for="getpassport" class="col-sm-2 col-form-label">Кем выдан:</label>
                    <div class="col-sm-5">
                    <input name="getpassport" type="text" class="form-control" placeholder="ГУ МВД РОССИИ ПО N-ОБЛАСТИ">
                    </div>
                </div><br />
                <div class="form-group row">
                    <label for="password" class="col-sm-2 col-form-label">Пароль:</label>
                    <div class="col-sm-5">
                    <input name="password" type="password" class="form-control" placeholder="qwerty123">
                    </div>
                </div><br />
                <button type="submit" class="btn btn-primary col-sm-7 mt-4">Зарегистрироваться</button>
                <a href="/auth.php" class="btn btn-light col-sm-7 mt-4">У меня есть учетная запись</a>
        </form>
    </div>
</body>
</html>