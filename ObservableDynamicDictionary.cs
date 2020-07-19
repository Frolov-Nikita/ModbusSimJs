using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSimJs
{
    public class ObservableDynamicDictionary<T> : DynamicObject, IDictionary<string, T> , INotifyCollectionChanged, INotifyPropertyChanged
    {
        private readonly Dictionary<string, T> dictionary = new Dictionary<string, T>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void CollectionChangedInvoke(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
            PropertyChangedInvoke(nameof(Count));
            PropertyChangedInvoke(nameof(Keys));
            PropertyChangedInvoke(nameof(Values));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void PropertyChangedInvoke([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public T this[string key] { get => dictionary[key]; set { dictionary[key] = value; }  }

        public ICollection<string> Keys => dictionary.Keys;

        public ICollection<T> Values => dictionary.Values;

        public int Count => dictionary.Count;

        public bool IsReadOnly => false;

        public void Add(string key, T value) => Add(new KeyValuePair<string, T>(key, value));

        public void Add(KeyValuePair<string, T> item){
            dictionary.Add(item.Key, item.Value);

            var args = new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add,
                item);
            CollectionChangedInvoke(args);
        }

        public void Clear() {
            dictionary.Clear();
            
            var args = new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Reset);

            CollectionChangedInvoke(args);
        }

        public bool Contains(KeyValuePair<string, T> item) => dictionary.Contains(item);

        public bool ContainsKey(string key) => dictionary.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex) => dictionary.ToList().CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => dictionary.GetEnumerator();

        public bool Remove(string key) => 
            Remove(new KeyValuePair<string, T>(key, dictionary[key]));

        public bool Remove(KeyValuePair<string, T> item)
        {
            if (dictionary.Remove(item.Key))
            {
                var args = new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Remove,
                    null,
                    item);

                CollectionChangedInvoke(args);
                return true;
            } else
                return false;

        }

        public bool TryGetValue(string key, out T value) => dictionary.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => dictionary.GetEnumerator();

        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.

            var success = dictionary.TryGetValue(name, out T res);
            result = res;
            return success;
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[binder.Name.ToLower()] = (T)value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames() => dictionary.Keys;
    }
}
