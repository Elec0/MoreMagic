using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace MoreMagic.Spells
{
    public abstract class MoreSpell : Magic.Spells.Spell
    {
        public MoreSpell(string school, string id) : base(school, id)
        {
        }

        public override string getTranslatedName()
        {
            return ModEntry.instance.Helper.Translation.Get("spell." + FullId + ".name");
        }
        public override string getTranslatedDescription()
        {
            return ModEntry.instance.Helper.Translation.Get("spell." + FullId + ".desc");
        }

        public override void loadIcon()
        {
            try
            {
                Icons = new Texture2D[getMaxCastingLevel()];
                for (int i = 1; i <= getMaxCastingLevel(); ++i)
                {
                    Icons[i - 1] = Content.loadTexture("magic/" + ParentSchool.Id + "/" + Id + "/" + i + ".png");
                }
            }
            catch (ContentLoadException e)
            {
                Log.warn("Failed to load icon for spell " + FullId + ": " + e);
            }
        }
    }
}
