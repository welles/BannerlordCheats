using TaleWorlds.Core;

namespace BannerlordCheats.Extensions
{
    public static class CharacterExtensions
    {
        public static bool IsPlayer(this BasicCharacterObject characterObject)
        {
            return characterObject?.IsPlayerCharacter ?? false;
        }
    }
}
