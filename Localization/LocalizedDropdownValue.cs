using System;
using System.Collections.Generic;
using System.Linq;
using MCM.Common;

namespace BannerlordCheats.Localization
{
    public struct LocalizedDropdownValue<T> : IEquatable<LocalizedDropdownValue<T>>
        where T : Enum
    {
        public LocalizedDropdownValue(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public string DisplayName
        {
            get
            {
                var key = $"Enum_{typeof(T).Name}_{Enum.GetName(typeof(T), this.Value)}";

                return L10N.GetText(key);
            }
        }

        public override string ToString() => this.DisplayName;

        public bool Equals(T other)
        {
            return EqualityComparer<T>.Default.Equals(this.Value, other);
        }

        public bool Equals(LocalizedDropdownValue<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LocalizedDropdownValue<T>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(this.Value);
        }

        public static bool operator ==(LocalizedDropdownValue<T> left, T right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LocalizedDropdownValue<T> left, T right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(LocalizedDropdownValue<T> left, LocalizedDropdownValue<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LocalizedDropdownValue<T> left, LocalizedDropdownValue<T> right)
        {
            return !Equals(left, right);
        }

        public static Dropdown<LocalizedDropdownValue<T>> GenerateDropdown(T selected)
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>().Select(value => new LocalizedDropdownValue<T>(value)).ToArray();

            var selectedIndex = Array.IndexOf(values, values.First(x => x.Value.Equals(selected)));

            return new Dropdown<LocalizedDropdownValue<T>>(values, selectedIndex);
        }
    }
}