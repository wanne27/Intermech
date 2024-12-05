namespace Task
{
    public partial class ucEvent : UserControl
    {
        private string[] events = { "Учеба", "Работа", "Спорт" };

        /// <summary>
        /// Текст заметки
        /// </summary>
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

        /// <summary>
        /// Выбранный элемент категории заметки
        /// </summary>
        public string CheckedElement
        {
            get
            {
                if (checkedListBoxEvent.CheckedItems.Count > 0)
                {
                    return checkedListBoxEvent.CheckedItems[0].ToString();
                }

                return String.Empty;
            }
            set
            {
                checkedListBoxEvent.SetSelected(0, true);
            }
        }

        /// <summary>
        /// Кастомный control события/заметки
        /// </summary>
        /// <param name="checkedElement">Категория заметки</param>
        public ucEvent(string checkedElement)
        {
            InitializeComponent();
            checkedListBoxEvent.Items.AddRange(this.events);
            var index = Array.FindIndex(this.events, row => row.Contains(checkedElement));
            checkedListBoxEvent.SetItemChecked(index, true);
        }
        /// <summary>
        /// Кастомный control события/заметки
        /// </summary>
        public ucEvent()
        {
            InitializeComponent();
            checkedListBoxEvent.Items.AddRange(this.events);
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
                panel1.BackColor = ColorHelper.GetColorByCategory(checkedListBoxEvent.CheckedItems[0].ToString());
            }
        }
    }
}
