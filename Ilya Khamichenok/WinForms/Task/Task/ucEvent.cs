namespace Task
{
    public partial class ucEvent : UserControl
    {
        public string EventText
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        public string CheckedElement
        {
            get
            {
                if (checkedListBoxEvent.CheckedItems.Count > 0)
                {
                    return checkedListBoxEvent.CheckedItems[0].ToString();
                }
                else
                {
                    return " ";
                }
            }
            set
            {
                checkedListBoxEvent.SetSelected(0, true);
            }
        }

        public ucEvent()
        {
            InitializeComponent();

            string[] events = { "Учеба", "Работа", "Спорт" };
            checkedListBoxEvent.Items.AddRange(events);
        }

        private void checkedListBoxEvent_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBoxEvent.Items.Count; ++i)
            {
                if (i != e.Index)
                {
                    checkedListBoxEvent.SetItemChecked(i, false);
                }
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private void checkedListBoxEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxEvent.CheckedItems.Count > 0)
            {
                switch (checkedListBoxEvent.CheckedItems[0].ToString())
                {
                    case "Учеба":
                        panel1.BackColor = Color.Red;
                        break;
                    case "Работа":
                        panel1.BackColor = Color.Blue;
                        break;
                    case "Спорт":
                        panel1.BackColor = Color.Orange;
                        break;
                }
            }
        }
    }
}
