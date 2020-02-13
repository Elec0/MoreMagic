using Magic;
using SpaceCore.Events;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreMagic
{
    class MoreMagic
    {
        private static IModEvents events;
        private static IInputHelper inputHelper;

        internal static void init(IModEvents events, IInputHelper inputHelper, Func<long> getNewId)
        {
            MoreMagic.events = events;
            MoreMagic.inputHelper = inputHelper;

            SpaceEvents.ActionActivated += actionTriggered;
        }

        private static void actionTriggered(object sender, EventArgsAction args)
        {
            string[] actionArgs = args.ActionString.Split(' ');
            if (args.Action == "MagicAltar")
            {
                if (Game1.player.eventsSeen.Contains(90001))
                {
                    Game1.player.addMana(Game1.player.getMaxMana());
                }
            }
        }

    }
}
