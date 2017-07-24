using Terraria.ModLoader;
using Terraria;

namespace tgmod.Commands
{
    class NewName : ModCommand
    {
        public override string Command
        {
            get
            {
                return "newname";
            }
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.Chat;
            }
        }

        public override string Usage
        {
            get
            {
                return "/newname [name]";
            }
        }

        public override string Description
        {
            get
            {
                return "Change your name.";
            }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            string newName = input.Substring("/newname ".Length);
            Main.NewText(caller.Player.name + " has changed their name to " + newName);
            caller.Player.name = newName;
        }
    }
}
