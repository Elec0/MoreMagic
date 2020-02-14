using Magic;
using Magic.Spells;
using StardewModdingAPI.Events;
using StardewValley;

namespace MoreMagic.Spells
{
    public class MeditateSpell : MoreSpell
    {
        private int level;
        // An hour in game is 42 seconds realtime, buffs are in game-minutes
        private float gameTime = 60f / 42f; // game minutes / real seconds = about 1.4

        // Make regen 30% of max + 10% / level over whole duration
        private float baseRate = 0.3f;
        private float levelRate = 0.1f;

        public MeditateSpell() : base(Schools.SchoolId.Life2, "meditate")
        {
        }

        public override int getManaCost(Farmer player, int level)
        {
            return 0;
        }

        public override int getMaxCastingLevel()
        {
            return 3;
        }

        public override IActiveEffect onCast(Farmer player, int level, int targetX, int targetY)
        {
            if (player != Game1.player)
                return null;

            foreach (var buff in Game1.buffsDisplay.otherBuffs)
            {
                if (buff.source == "spell:life2:meditate")
                    return null;
            }

            this.level = level;
            int speed = -100; // To stop the player moving as much as possible
            Game1.buffsDisplay.addOtherBuff(new Buff(0, 0, 0, 0, 0, 0, 0, 0, 0, speed, 0, 0, Duration(level), "spell:life2:meditate", "Meditation (spell)"));

            ModEntry.instance.Helper.Events.GameLoop.UpdateTicked += this.UpdateTicked;
            ModEntry.instance.Helper.Events.GameLoop.OneSecondUpdateTicked += this.SecondTicked;
            return null;
        }

        private int Duration(int level)
        {
            // Duration decreases by x seconds each level
            int d = (int)(ConvertToGameTime(30) - (ConvertToGameTime(5) * (level + 1)));
            return d;
        }
        private float ConvertToGameTime(int seconds)
        {
            return seconds * gameTime;
        }

        private void UpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            // Check to see if the buff is still on the player
            foreach (var buff in Game1.buffsDisplay.otherBuffs)
            {
                if (buff.source == "spell:life2:meditate")
                    return;
            }
            // Remove the hook
            ModEntry.instance.Helper.Events.GameLoop.UpdateTicked -= this.UpdateTicked;
            ModEntry.instance.Helper.Events.GameLoop.OneSecondUpdateTicked -= this.SecondTicked;
        } 

        // Do the actual mana regen, since there's no real way to change the mana regen variable like there should be
        private void SecondTicked(object sender, OneSecondUpdateTickedEventArgs e)
        {
            // This runs even if the game is paused, but we don't want to add mana in that case
            if (!Game1.shouldTimePass())
                return;

            // Check to see if the buff is still on the player
            foreach (var buff in Game1.buffsDisplay.otherBuffs)
            {
                if (buff.source == "spell:life2:meditate")
                {
                    int manaRegen = (int)((Game1.player.getMaxMana() * (baseRate + levelRate * (level + 1))) / Duration(level));
                    Game1.player.addMana(manaRegen);
                    return;
                }
            }
        }
    }
}
