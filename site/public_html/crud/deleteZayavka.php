<?php
        $id = $_GET['id'];
        
        require_once 'config.php';

        $connect = new Mysqli(SERVERNAME, DBLOGIN, PASSWORD, DBNAME);
        $sql = "DELETE FROM `zayavki` WHERE `id` = '$id'";
        $connect->query($sql);
        $connect->close();

        header('location: ../admin.php');
?>