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
        <form method="post" action="crud/authorize.php">
            <h1 class="auth-title">Вход в систему</h1><br /><br/>
                <div class="form-group row">
                    <label for="phone" class="col-sm-2 col-form-label">Телефон:</label>
                    <div class="col-sm-5">
                    <input name="phone" type="text" class="form-control" placeholder="+7xxx-xxx-xxx">
                    </div>
                </div><br />
                <div class="form-group row">
                    <label for="password" class="col-sm-2 col-form-label">Пароль:</label>
                    <div class="col-sm-5">
                    <input name="password" type="password" class="form-control" placeholder="password">
                    </div>
                </div><br />
                <button type="submit" class="btn btn-primary col-sm-7 mt-4">Войти</button>
                <a href="/reg.php" class="btn btn-light col-sm-7 mt-4">У меня нет учетной записи</a>
        </form>
    </div>
</body>
</html>