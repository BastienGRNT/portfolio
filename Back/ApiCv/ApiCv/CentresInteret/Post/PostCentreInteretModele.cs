using System.ComponentModel.DataAnnotations;

namespace ApiCv.CentresInteret.Post;

public class PostCentreInteretModele
{
    [Required]
    public string Nom { get; set; }
}