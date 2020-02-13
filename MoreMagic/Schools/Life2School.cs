using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic;
using Magic.Spells;
using StardewModdingAPI.Utilities;

namespace MoreMagic.Schools
{
    class Life2School : Magic.Schools.School
    {
        public Life2School() : base(SchoolId.Life2)
        {
        }

        public override Spell[] GetSpellsTier1()
        {
            return new Spell[] { SpellBook.get("life2:meditate") };
        }
        
        /*public override Spell[] GetSpellsTier2()
        {
            return new Spell[] { SpellBook.get("life:heal"), SpellBook.get("life:haste") };
        }

        public override Spell[] GetSpellsTier3()
        {
            return new Spell[] { SpellBook.get("life:buff") };
        }*/
    }
}
