namespace ApiCv.FormationsProfessionnelles.Delete;

public class DeleteFormationQuery
{
    public static string DeleteFormation = "DELETE FROM FormationsProfessionnelles WHERE FormationID = @formationid;";
}