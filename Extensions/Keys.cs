using System.Collections.Generic;
using System.Linq;
using TaleWorlds.InputSystem;

namespace BannerlordCheats.Extensions
{
    public static class Keys
    {
        private static readonly List<InputKey> PressedKeys = new List<InputKey>();

        public static bool IsKeyPressed(params InputKey[] keys)
        {
            if (keys.All(key => key.IsDown()))
            {
                if (keys.All(key => PressedKeys.Contains(key)))
                {
                    // Key press already handled in a previous tick
                    return false;
                }

                foreach (var key in keys)
                {
                    if (!PressedKeys.Contains(key))
                    {
                        PressedKeys.Add(key);
                    }
                }
            }
            else if (keys.Any(key => key.IsDown()))
            {
                foreach (var key in keys)
                {
                    if (!key.IsDown() && PressedKeys.Contains(key))
                    {
                        PressedKeys.Remove(key);
                    }
                }
            }
            else
            {
                foreach (var key in keys)
                {
                    if (PressedKeys.Contains(key))
                    {
                        PressedKeys.Remove(key);
                    }
                }
            }

            return keys.All(key => PressedKeys.Contains(key));
        }
    }
}
