<?php
    $PDO = new PDO ("mysql:host=localhost;dbname=Polybius","root", "");

	//Preparar uma nova pontuação
	$query = $PDO->prepare("INSERT INTO jogadores (  name,  time , final ) 
								VALUES ( :name, :time, :final )");
	$query->execute([
	":name" => $_POST['name'],
	":time"  => $_POST['time'],
	":final"  => $_POST['final']
	]);

    echo "Ok";
?>