using Verse;

namespace LingGame
{
    public class Hediff_FuckYouMeal : HediffWithComps
    {
        public override void Tick()
        {
            base.Tick();
            if (pawn.RaceProps.Humanlike)
            {
                pawn.mindState.mentalStateHandler.TryStartMentalState(
                    DefDatabase<MentalStateDef>.GetNamed("InsultingSpree"), null, true);
            }

            pawn.health.RemoveHediff(this);
        }
    }
}