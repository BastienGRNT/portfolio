namespace ApiCv.HardSkill.Delete;

public class DeleteHardSkillsQuery
{
    public static string DeleteHardSkills = "DELETE FROM hardskills WHERE hardskillid = @hardskillid;";
}