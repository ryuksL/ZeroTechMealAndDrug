using RimWorld;
using Verse;

namespace LingGame;

public class IngestionOutcomeDoer_LoseWeightMeal : IngestionOutcomeDoer
{
    protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
    {
        if (!pawn.RaceProps.Humanlike)
        {
            return;
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Male)
        {
            pawn.story.bodyType = BodyTypeDefOf.Thin;
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Female)
        {
            pawn.story.bodyType = BodyTypeDefOf.Thin;
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Hulk)
        {
            switch (pawn.gender)
            {
                case Gender.Female:
                    pawn.story.bodyType = BodyTypeDefOf.Female;
                    break;
                case Gender.Male:
                    pawn.story.bodyType = BodyTypeDefOf.Male;
                    break;
            }
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Fat)
        {
            pawn.story.bodyType = BodyTypeDefOf.Hulk;
        }

        pawn.Drawer.renderer.graphics.ResolveAllGraphics();
    }
}