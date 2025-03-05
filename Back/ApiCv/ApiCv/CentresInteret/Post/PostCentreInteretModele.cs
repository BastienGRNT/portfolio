using System.ComponentModel.DataAnnotations;

namespace ApiCv.CentreInteret.Post;

public class PostCentreInteretModele
{
    [Required]
    public string Nom { get; set; }
}