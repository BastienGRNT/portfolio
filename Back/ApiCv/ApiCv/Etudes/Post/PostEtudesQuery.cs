﻿namespace ApiCv.Etude.Post;

public class PostEtudesQuery
{
    public static string QueryPostEtudes = "INSERT INTO etudes (Description, Titre, DateDebut, DateFin, Lieu) VALUES (@description, @titre, @datedebut, @datefin, @lieu);";
}