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
            foreach (var tag in Tags.Values)
            {
                var lvi = new ListViewItem(tag.Name);

                lvi.ToolTipText = tag.Description;

                lvi.SubItems.Add(tag.ValueType.ToString());
                lvi.SubItems.Add(tag.Region.ToString());

                var labelValue = new ListViewItem.ListViewSubItem { Text = tag.Value.ToString() };
                lvi.SubItems.Add(labelValue);

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

    }
}
