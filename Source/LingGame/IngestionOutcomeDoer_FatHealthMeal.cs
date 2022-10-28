using RimWorld;
using Verse;

namespace LingGame;

public class IngestionOutcomeDoer_FatHealthMeal : IngestionOutcomeDoer
{
    protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
    {
        if (!pawn.RaceProps.Humanlike)
        {
            return;
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Hulk)
        {
            pawn.story.bodyType = BodyTypeDefOf.Fat;
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Male)
        {
            pawn.story.bodyType = BodyTypeDefOf.Hulk;
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Female)
        {
            pawn.story.bodyType = BodyTypeDefOf.Hulk;
        }

        if (pawn.story.bodyType == BodyTypeDefOf.Thin)
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

        pawn.Drawer.renderer.graphics.ResolveAllGraphics();
    }
}