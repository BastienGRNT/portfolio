import TechnologieAdmin from "../../components/admin/adminTechnologie/TechnologieAdmin";
import ExperienceAdmin from "../../components/admin/adminExperiencePro/ExperienceProAdmin";
import CompetenceAdmin from "../../components/admin/adminCompetence/CompetenceAdmin";
import HardSkillAdmin from "../../components/admin/adminHardSkill/HardSkillAdmin";
import EtudeAdmin from "../../components/admin/adminEtude/EtudeAdmin";
import FormationAdmin from "../../components/admin/adminFormation/FormationAdmin";
import DiversAdmin from "../../components/admin/adminDivers/DiversAdmin";
import CentreInteretAdmin from "../../components/admin/adminCentreInteret/CentreInteretAdmin";

export default function DebugAdmin() {
    return (
        <>
            <CentreInteretAdmin/>
            <DiversAdmin/>
            <FormationAdmin/>
            <EtudeAdmin/>
            <HardSkillAdmin/>
            <CompetenceAdmin/>
            <TechnologieAdmin/>
            <ExperienceAdmin/>
        </>
    )
}