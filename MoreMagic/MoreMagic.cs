using Magic;
using SpaceCore.Events;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using MoreMagic.Schools;
using MoreMagic.Spells;

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

            // Inject our new schools
            SchoolTools schoolTools = new SchoolTools();
            schoolTools.Populate();

            // Inject our new spells
            SpellTools spellTools = new SpellTools();
            spellTools.Populate();
            
        }

        private static void actionTriggered(object sender, EventArgsAction args)
        {
            string[] actionArgs = args.ActionString.Split(' ');
            if (args.Action == "MagicAltar")
            {
                if (Game1.player.eventsSeen.Contains(90001))
                {
                    // For testing
                    Game1.player.learnSpell("life2:meditate", 0, true);

                    Game1.player.addMana(Game1.player.getMaxMana());
                }
            }
        }

    }
}
