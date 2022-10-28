using Verse;

namespace LingGame;

public class Hediff_LingLoseWater : HediffWithComps
{
    public override void Tick()
    {
        base.Tick();
        if (!(Severity >= 1f) || !pawn.Spawned)
        {
            return;
        }

        var map = pawn.Map;
        var position = pawn.Position;
        pawn.DeSpawn(DestroyMode.WillReplace);
        var noWaterPawn = (NoWaterPawn)ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("LingNoWaterPawn"));
        noWaterPawn.NoWaterMan = pawn;
        pawn.health.AddHediff(DefDatabase<HediffDef>.GetNamed("LingHaveWaterPawn"));
        pawn.health.RemoveHediff(this);
        if (noWaterPawn.NoWaterMan.RaceProps.Humanlike)
        {
            noWaterPawn.SetColor(pawn.story.SkinColor);
        }

        GenSpawn.Spawn(noWaterPawn, position, map);
    }
}