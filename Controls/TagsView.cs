using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusSimJs.Controls
{
    public partial class TagsView : UserControl
    {
        public TagsList Tags { get; private set; }

        public TagsView()
        {

            InitializeComponent();
        }

        public void Load(TagsList tags)
        {
            Tags = tags;
            FillList();
        }

        void FillList()
        {
            listViewTags.Items.Clear();
            foreach (var tag in Tags.Values)
            {
                var lvi = new ListViewItem(tag.Name);
                lvi.Tag = tag;

                lvi.ToolTipText = tag.Description;

                lvi.SubItems.Add(tag.ValueType.ToString());
                lvi.SubItems.Add(tag.Region.ToString());

                var labelValue = new ListViewItem.ListViewSubItem { Text = tag.Value.ToString() };
                
                lvi.SubItems.Add(labelValue);
                
                lvi.SubItems.Add(tag.Description);

                tag.PropertyChanged += (sender, args) => { labelValue.Text = tag.Value.ToString(); };

                listViewTags.Items.Add(lvi);
            }
        }


        Control GetControlByType(ModbusValueType valueType)
        {
            switch (valueType)
            {
                case ModbusValueType.Bool:
                    return new CheckBox { };
                case ModbusValueType.Float:
                    return new NumericUpDown
                    {
                        Maximum = decimal.MaxValue,
                        Minimum = decimal.MinValue,
                        DecimalPlaces = 6,
                    };
                case ModbusValueType.Int16:
                    return new NumericUpDown { };
                case ModbusValueType.Int32:
                    return new NumericUpDown { };
                default:
                    return new TextBox { };
            }
        }

        private void listViewTags_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listView = (ListView)sender;
            var item = listView.SelectedItems[0];
            var tag = (Tag)item.Tag;
            switch (tag.ValueType)
            {
                case ModbusValueType.Bool:
                    new ModbusSimJs.Forms.TagBoolValueEditor(tag).Show();
                    break;
                case ModbusValueType.Int16:
                    new ModbusSimJs.Forms.TagInt16ValueEditor(tag).Show();
                    break;
                case ModbusValueType.Int32:
                    new ModbusSimJs.Forms.TagInt32ValueEditor(tag).Show();
                    break;
                case ModbusValueType.Float:
                    new ModbusSimJs.Forms.TagFloatValueEditor(tag).Show();
                    break;
                default:
                    break;
            }

        }

    }
}
