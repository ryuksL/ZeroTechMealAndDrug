using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace LingGame
{
    public class NoWaterPawn : ThingWithComps
    {
        public Pawn NoWaterMan;

        public override string GetInspectString()
        {
            var text = base.GetInspectString();
            if (NoWaterMan != null)
            {
                text = NoWaterMan.Name != null
                    ? text + "NoWaterPawninner".Translate() + NoWaterMan.Name.ToStringFull
                    : text + "NoWaterPawninner".Translate() + NoWaterMan.def.LabelCap;
            }

            return text;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Deep.Look(ref NoWaterMan, "NoWaterMan");
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (var gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }

            yield return new Command_Action
            {
                defaultLabel = "NoWaterPawnUnzip".Translate(),
                defaultDesc = "NoWaterPawnUnzipD".Translate(),
                icon = ContentFinder<Texture2D>.Get("UI/Commands/NoWaterPawnUnzip"),
                action = delegate
                {
                    var map = Map;
                    var position = Position;
                    if (HitPoints < MaxHitPoints)
                    {
                        for (var i = HitPoints; i < MaxHitPoints; i++)
                        {
                            NoWaterMan.TakeDamage(new DamageInfo(DamageDefOf.Bite, 1f, 2f));
                        }
                    }

                    GenSpawn.Spawn(NoWaterMan, position, map);
                    NoWaterMan = null;
                    Destroy();
                }
            };
        }
    }
}