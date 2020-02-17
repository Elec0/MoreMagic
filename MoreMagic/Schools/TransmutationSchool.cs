using Magic;
using Magic.Spells;

namespace MoreMagic.Schools
{
    class TransmutationSchool : Magic.Schools.School
    {
        public TransmutationSchool() : base(Schools.SchoolId.Transmutation)
        {
        }

        public override Spell[] GetSpellsTier1()
        {
            return new Spell[] { SpellBook.get("transmutation:transmuteore") };
        }

        public override Spell[] GetSpellsTier2()
        {
            return new Spell[] { SpellBook.get("transmutation:transmutebar") };
        }

        public override Spell[] GetSpellsTier3()
        {
            return new Spell[] { SpellBook.get("transmutation:transmutebar") };
        }
    }
}
