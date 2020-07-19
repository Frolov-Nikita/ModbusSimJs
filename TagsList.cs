using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSimJs
{
    public class TagsList : ObservableDynamicDictionary<Tag>
    {
        public void Add(Tag tag)
        {
            if (ContainsKey(tag.Name))
                throw new Exception($"Tag '{tag.Name}' is not unique.");
         
            Add(tag.Name, tag);
        }

        public object get(string tagName)
        {
            if (!ContainsKey(tagName))
                throw new Exception($"Tag '{tagName}' doesn't exist.");
            
            return this[tagName].Value;
        }

        public void set(string tagName, object value)
        {
            if (!ContainsKey(tagName))
                throw new Exception($"Tag '{tagName}' doesn't exist.");

            this[tagName].Value = value;
        }
    }
}
