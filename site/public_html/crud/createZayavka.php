<?php
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        session_start();
        $id = $_SESSION['user_id'];
        $education = trim(filter_var($_POST['education']));
        $occupation = trim(filter_var($_POST['occupation']));
        $description = trim(filter_var($_POST['description']));

        require_once('config.php');

        $connect = new Mysqli(SERVERNAME,DBLOGIN,PASSWORD,DBNAME);
        $sql = "INSERT INTO `zayavki`(userId, education, occupation, description) VALUES('$id', '$education', '$occupation', '$description')";
        $connect->query($sql);
        $connect->close();

        header('location: ../index.php');
    }
?>