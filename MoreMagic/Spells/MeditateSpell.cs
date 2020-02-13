using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic;
using Magic.Spells;
using StardewValley;

namespace MoreMagic.Spells
{
    public class MeditateSpell : MoreSpell
    {
        public MeditateSpell() : base(Schools.SchoolId.Life2, "meditate")
        {
        }

        public override int getManaCost(Farmer player, int level)
        {
            return 0;
        }

        public override int getMaxCastingLevel()
        {
            return 1;
        }

        public override IActiveEffect onCast(Farmer player, int level, int targetX, int targetY)
        {
            if (player != Game1.player)
                return null;

            foreach (var buff in Game1.buffsDisplay.otherBuffs)
            {
                if (buff.source == "spell:life:haste")
                    return null;
            }

            Game1.buffsDisplay.addOtherBuff(new Buff(0, 0, 0, 0, 0, 0, 0, 0, 0, level + 1, 0, 0, 60 + level * 120, "spell:life:haste", "Haste (spell)"));
            //player.AddCustomSkillExperience(Magic.Skill, 5);
            return null;
        }
    }
}
