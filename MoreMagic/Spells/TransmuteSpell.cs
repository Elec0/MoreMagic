using Magic;
using StardewValley;

namespace MoreMagic.Spells
{
    class TransmuteSpell : MoreSpell
    {
        public bool TransmuteOre { get; }
        private string postfix;

        public TransmuteSpell(bool isOre) : base(Schools.SchoolId.Transmutation, "transmute" + (isOre ? "ore" : "bar"))
        {
            TransmuteOre = isOre;
            postfix = TransmuteOre ? "Ore" : "Bar";
        }

        public override int getManaCost(Farmer player, int level)
        {
            return TransmuteOre ? 50 : 200;
        }

        public override int getMaxCastingLevel()
        {
            return 2;
        }

        public override IActiveEffect onCast(Farmer player, int level, int targetX, int targetY)
        {
            if (player != Game1.player)
                return null;

            var obj = Game1.player.ActiveObject;
            // Make sure we have a selected item handled by the spell
            if (obj == null || !(obj.Name.Equals("Copper " + postfix) || obj.Name.Equals("Iron " + postfix) || obj.Name.Equals("Gold " + postfix)))
                return null;

            // Stop if at max level
            if ((obj.Name.Contains("Gold") && level == 0) || (obj.Name.Contains("Iridium") && level == 1))
                return null;

            // Remove + add items
            try
            {
                Game1.player.consumeObject(obj.ParentSheetIndex, 1);
                Game1.player.addItemToInventory((Item)new Object(getStepUp(obj), 1));
            }
            catch(System.IndexOutOfRangeException e)
            {
                // We failed, give the item back
                Game1.player.addItemToInventory(obj.getOne(), 1);
                Log.error(e.Message);
            }

            return null;
        }

        private int getStepUp(Object obj)
        {
            switch(obj.ParentSheetIndex)
            {
                case Object.copper:
                    return Object.iron;

                case Object.copperBar:
                    return Object.ironBar;

                case Object.iron:
                    return Object.gold;

                case Object.ironBar:
                    return Object.goldBar;

                case Object.gold:
                    return Object.iridium;

                case Object.goldBar:
                    return Object.iridiumBar;
            }
            // IndexOutOfRange isn't *really* correct, but whatever
            throw new System.IndexOutOfRangeException("TransmuteSpell: " + obj.Name + " is invalid.");
        }
    }
}
