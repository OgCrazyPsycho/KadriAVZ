<?php
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $name = trim(filter_var($_POST['name']));
        $phone = trim(filter_var($_POST['phone']));
        $numpasport = trim(filter_var($_POST['numpassport']));
        $getpasport = trim(filter_var($_POST['getpassport']));
        $pass = trim(filter_var($_POST['password']));

        require_once 'config.php';

        $connect = new Mysqli(SERVERNAME, DBLOGIN, PASSWORD, DBNAME);

        $sql = "INSERT INTO `users`(name, phone, numpasport, getpasport, password, status) VALUES('$name', '$phone', '$numpasport', '$getpasport', '$pass', 'user')";
        $connect->query($sql);
        $connect->close();

        header('location: ../auth.php');

    }
?>