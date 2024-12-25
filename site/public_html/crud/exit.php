<?php
    session_start();

    unset($_SESSION['user_id']);
    unset($_SESSION['phone']);
    unset($_SESSION['status']);

    session_destroy();

    header('Location: ../auth.php');
    exit();
?>