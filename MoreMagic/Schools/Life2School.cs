using Magic;
using Magic.Spells;

namespace MoreMagic.Schools
{
    public class Life2School : Magic.Schools.School
    {
        public Life2School() : base(SchoolId.Life2)
        {
        }

        public override Spell[] GetSpellsTier1()
        {
            return new Spell[] { SpellBook.get("life2:meditate") };
        }
        
        public override Spell[] GetSpellsTier2()
        {
            return new Spell[] { SpellBook.get("life2:meditate"), SpellBook.get("life2:meditate") };
        }

        public override Spell[] GetSpellsTier3()
        {
            return new Spell[] { SpellBook.get("life2:meditate") };
        }
    }
}
