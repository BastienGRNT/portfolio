import TechnologiesAdmin from "../components/admin/Technologies/TechnologiesAdmin";
import ExperienceAdmin from "../components/admin/Experiences/ExperiencesAdmin";
import CompetencesExperiencesAdmin from "../components/admin/CompetencesExperiences/CompetencesExperiencesAdmin";

export default function DebugAdmin() {
    return (
        <>
            <CompetencesExperiencesAdmin/>
            <TechnologiesAdmin/>
            <ExperienceAdmin/>
        </>
    )
}