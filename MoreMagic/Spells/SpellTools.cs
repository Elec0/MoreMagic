using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreMagic.Spells
{
    class SpellTools
    {

        public void Populate()
        {
            Magic.SpellBook.register(new MeditateSpell());
        }
    }
}
