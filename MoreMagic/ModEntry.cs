using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
//using Magic;
using SpaceCore;
using SpaceShared.APIs;
using System.IO;

namespace MoreMagic
{
    public class ModEntry : StardewModdingAPI.Mod
    {
        public static ModEntry instance;


        public override void Entry(IModHelper helper)
        {
            instance = this;
            Log.Monitor = Monitor;

            //Config = Helper.ReadConfig<Configuration>();

            helper.Events.GameLoop.GameLaunched += onGameLaunched;
            helper.Events.GameLoop.SaveLoaded += onSaveLoaded;
            helper.Events.GameLoop.Saved += onSaved;

            MoreMagic.init(helper.Events, helper.Input, helper.Multiplayer.GetNewID);
        }

        /// <summary>Raised after the game is launched, right before the first update tick. This happens once per game session (unrelated to loading saves). All mods are loaded and initialised at this point, so this is a good time to set up mod integrations.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void onGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            //var capi = Helper.ModRegistry.GetApi<SpaceShared.APIs.GenericModConfigMenuAPI>("spacechase0.GenericModConfigMenu");
            //if (capi != null)
            {

            }
        }

        /// <summary>Raised after the player loads a save slot.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void onSaveLoaded(object sender, SaveLoadedEventArgs e)
        {

        }

        /// <summary>Raised after the game finishes writing data to the save file (except the initial save creation).</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void onSaved(object sender, SavedEventArgs e)
        {
            if (!Game1.IsMultiplayer || Game1.IsMasterGame)
            {
                //Log.info($"Saving save data (\"{MultiplayerSaveData.FilePath}\")...");
                //File.WriteAllText(MultiplayerSaveData.FilePath, JsonConvert.SerializeObject(Data));
            }
        }
    }
}
