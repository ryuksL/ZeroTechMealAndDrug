using RimWorld;
using Verse;

namespace LingGame
{
    public class IngestionOutcomeDoer_CleanBody : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            pawn.health.RestorePart(GetTorso(pawn));
        }

        private BodyPartRecord GetTorso(Pawn pawn)
        {
            foreach (var notMissingPart in pawn.health.hediffSet.GetNotMissingParts())
            {
                if (notMissingPart.def.defName.Contains("Torso"))
                {
                    return notMissingPart;
                }
            }

            return null;
        }
    }
}