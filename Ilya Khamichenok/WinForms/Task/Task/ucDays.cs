namespace Task
{
    public partial class ucDays : UserControl
    {
        public string CheckedElement { get; set; }
        public string EventText { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Кастомный control, представляет собой день месяца
        /// </summary>
        public ucDays()
        {
            InitializeComponent();
            label1.Text = String.Empty;
        }

        /// <summary>
        /// Кастомный control, представляет собой день месяца
        /// </summary>
        /// <param name="day">DateTim, дата дня</param>
        public ucDays(DateTime day)
        {
            InitializeComponent();
            label1.Text = day.Day.ToString("d");
            Date = day;
        }

        /// <summary>
        /// Кастомный control, представляет собой день месяца
        /// </summary>
        /// <param name="day">DateTim, дата дня</param>
        /// <param name="text">Текст заметки</param>
        /// <param name="category">Категория заметки</param>
        public ucDays(DateTime day, string text, string category)
        {
            InitializeComponent();
            label1.Text = day.Day.ToString();
            textBox1.Text = text;
            labelCategory.Text = category;
            ChangeColor(category);

            CheckedElement = category;
            EventText = text;
            Date = day;
        }

        private void ucDays_Load(object sender, EventArgs e)
        {

        }

        private void ucDays_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ucEvent)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ucDays_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ucEvent)))
            {
                var eventControl = (ucEvent)e.Data.GetData(typeof(ucEvent));

                textBox1.Text = eventControl.EventText;
                labelCategory.Text = eventControl.CheckedElement;

                CheckedElement = eventControl.CheckedElement;
                EventText = eventControl.EventText;

                if (eventControl.Parent is FlowLayoutPanel oldPanel)
                {
                    oldPanel.Controls.Remove(eventControl);
                }

                ChangeColor(eventControl.CheckedElement);
            }
        }

        private void ChangeColor(string category)
        {
            panel1.BackColor = ColorHelper.GetColorByCategory(category);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EventText = textBox1.Text;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(this, DragDropEffects.Move);
            }
        }
    }
}
