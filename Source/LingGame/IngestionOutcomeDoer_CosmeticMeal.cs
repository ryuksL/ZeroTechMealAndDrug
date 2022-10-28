using RimWorld;
using Verse;

namespace LingGame;

public class IngestionOutcomeDoer_CosmeticMeal : IngestionOutcomeDoer
{
    protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
    {
        if (!pawn.RaceProps.Humanlike)
        {
            return;
        }

        if (pawn.story.traits.HasTrait(TraitDefOf.Beauty))
        {
            var trait = pawn.story.traits.GetTrait(TraitDefOf.Beauty);
            pawn.story.traits.allTraits.Remove(trait);
        }

        var degree = new[] { -2, -1, 1, 2 }.RandomElement();
        var trait2 = new Trait(TraitDefOf.Beauty, degree);
        pawn.story.traits.GainTrait(trait2);
    }
}