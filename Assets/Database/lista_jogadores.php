<?php
    $PDO = new PDO ("mysql:host=localhost;dbname=Polybius","root", "");

    //Consultar no BD
    $queryConsulta = $PDO->prepare("SELECT * FROM jogadores order by time DESC");

	$queryConsulta->execute();

    $resultado = $queryConsulta->fetchAll(PDO::FETCH_ASSOC);

	$json = json_encode(array("objetos" => $resultado));

    print_r($json);
?>