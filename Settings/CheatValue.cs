namespace BannerlordCheats.Settings
{
    public static partial class SettingsManager
    {
        public struct CheatValue<T>
        {
            public CheatValue(bool isChanged, T value)
            {
                this.IsChanged = isChanged;
                this.Value = value;
            }

            public bool IsChanged { get; }

            public T Value { get; }
        }
    }
}
