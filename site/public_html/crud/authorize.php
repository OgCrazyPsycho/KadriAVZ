<?php
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    session_start();

    $phone = trim(filter_var($_POST['phone'], FILTER_SANITIZE_STRING));
    $password = trim(filter_var($_POST['password'], FILTER_SANITIZE_STRING));

    require_once 'config.php';

    $connect = new mysqli(SERVERNAME, DBLOGIN, PASSWORD, DBNAME);

    if ($connect->connect_error) {
        die("Ошибка подключения: " . $connect->connect_error);
    }

    $sql = "SELECT * FROM `users` WHERE `phone` = ? AND `password` = ?";
    $stmt = $connect->prepare($sql);
    $stmt->bind_param("ss", $phone, $password);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        $user = $result->fetch_assoc();

        $_SESSION['user_id'] = $user['id'];
        $_SESSION['phone'] = $user['phone'];
        $_SESSION['status'] = $user['status'];

        if($user['status'] === 'admin') {
            header('Location: ../admin.php');
        } else {
            header('Location: ../index.php');
        }
        exit();
    } else {
        echo "Пользователь не найден или неверные данные.";
    }

    $stmt->close();
    $connect->close();
}
?>