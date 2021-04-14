using System;
using System.Collections.Generic;
using System.Reflection;

namespace BannerlordCheats.Extensions
{
    public interface IPropertyAccessor<in TObject, TValue>
    {
        PropertyInfo PropertyInfo { get; }

        string Name { get; }

        TValue GetValue(TObject source);

        void SetValue(TObject source, TValue value);
    }

    public static class PropertyInfoHelper<TObject, TValue>
    {
        private static readonly Dictionary<PropertyInfo, IPropertyAccessor<TObject, TValue>> Cache = new Dictionary<PropertyInfo, IPropertyAccessor<TObject, TValue>>();

        public static IPropertyAccessor<TObject, TValue> GetFastAccessor(PropertyInfo propertyInfo)
        {
            IPropertyAccessor<TObject, TValue> result;

            lock (PropertyInfoHelper<TObject, TValue>.Cache)
            {
                if (!PropertyInfoHelper<TObject, TValue>.Cache.TryGetValue(propertyInfo, out result))
                {
                    result = PropertyInfoHelper<TObject, TValue>.CreateAccessor(propertyInfo);

                    PropertyInfoHelper<TObject, TValue>.Cache.Add(propertyInfo, result);
                }
            }

            return result;
        }

        private static IPropertyAccessor<TObject, TValue> CreateAccessor(PropertyInfo propertyInfo)
        {
            var instance = new PropertyWrapper<TObject, TValue>(propertyInfo);

            return instance;
        }
    }

    public class PropertyWrapper<TObject, TValue> : IPropertyAccessor<TObject, TValue>
    {
        private readonly Func<TObject, TValue> _getMethod;

        private readonly Action<TObject, TValue> _setMethod;

        public PropertyWrapper(PropertyInfo propertyInfo)
        {
            this.PropertyInfo = propertyInfo;

            var mGet = propertyInfo.GetGetMethod(true);
            var mSet = propertyInfo.GetSetMethod(true);

            this._getMethod = (Func<TObject, TValue>)Delegate.CreateDelegate(typeof(Func<TObject, TValue>), mGet);
            this._setMethod = (Action<TObject, TValue>)Delegate.CreateDelegate(typeof(Action<TObject, TValue>), mSet);
        }

        TValue IPropertyAccessor<TObject, TValue>.GetValue(TObject source)
        {
            return this._getMethod(source);
        }

        void IPropertyAccessor<TObject, TValue>.SetValue(TObject source, TValue value)
        {
            this._setMethod(source, value);
        }

        public string Name => this.PropertyInfo.Name;

        public PropertyInfo PropertyInfo { get; }
    }
}
