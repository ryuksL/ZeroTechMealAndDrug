using RimWorld;
using Verse;

namespace LingGame
{
    public class Thought_BreakFellingPill : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn other, Pawn pawn)
        {
            if (!other.RaceProps.Humanlike || !RelationsUtility.PawnsKnowEachOther(pawn, other))
            {
                return false;
            }

            if (RelationsUtility.IsDisfigured(other))
            {
                return false;
            }

            if (other.health.hediffSet.HasHediff(DefDatabase<HediffDef>.GetNamed("BreakFellingPill")))
            {
                return ThoughtState.ActiveAtStage(0);
            }

            return false;
        }
    }
}