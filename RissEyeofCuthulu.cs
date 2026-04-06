using System;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace RissEyeofCuthulu
{
    [ApiVersion(2, 1)]
    public class RissEyeofCuthulu : TerrariaPlugin
    {
        public override string Name => "RissEyeofCuthulu";
        public override string Author => "Riss";
        public override string Description => "EoC upgrade";
        public override Version Version => new Version(1, 0);

        Random rand = new Random();

        public RissEyeofCuthulu(Main game) : base(game) { }

        public override void Initialize()
        {
            ServerApi.Hooks.GameUpdate.Register(this, Update);
        }

        private void Update(EventArgs args)
        {
            foreach (var npc in Main.npc)
            {
                if (npc.active && npc.type == 4)
                {
                    if (rand.Next(300) == 0)
                        npc.velocity *= 1.5f;

                    if (rand.Next(200) == 0)
                        NPC.NewNPC(npc.GetSource_FromAI(), (int)npc.Center.X, (int)npc.Center.Y, 5);

                    if (npc.life < npc.lifeMax / 2)
                        npc.velocity *= 1.01f;
                }
            }
        }
    }
}
