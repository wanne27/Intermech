using System.Globalization;
using System.Text.Json;

namespace Task
{
    public partial class Form1 : Form
    {
        private int year;
        private int month;
        private readonly string fileName = "events.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDays(DateTime.Now.Month, DateTime.Now.Year);
        }

        private void ShowDays(int month, int year)
        {
            var eventList = GetEventList();

            flowLayoutPanel1.Controls.Clear();
            this.month = month;
            this.year = year;

            var monthName = new DateTimeFormatInfo().GetMonthName(month);
            lbMonth.Text = monthName.ToString().ToUpper() + " " + year;
            var startedTheMonth = new DateTime(year, month, 1);
            var day = DateTime.DaysInMonth(year, month);
            var week = Convert.ToInt32(startedTheMonth.DayOfWeek.ToString("d"));

            week = week == 0 ? 6 : week -= 1;

            for (int i = 0; i < week; i++) 
            {
                flowLayoutPanel1.Controls.Add(new ucDays());
            }

            for (int i = 1; i <= day; i++)
            {
                var dateTime = new DateTime(year, month, i);
                var even = eventList.Where(e => e.DateTime == dateTime).FirstOrDefault();

                if (eventList.Count > 0 && even != null)
                {                   
                    flowLayoutPanel1.Controls.Add(new ucDays(dateTime, even.Text, even.Category));
                }
                else
                {
                    flowLayoutPanel1.Controls.Add(new ucDays(dateTime));
                }
            }
        }

        private List<DayEventData> GetEventList()
        {     
            if (File.Exists(this.fileName))
            {
                var json = File.ReadAllText(this.fileName);
                return JsonSerializer.Deserialize<List<DayEventData>>(json);
            }

            return new List<DayEventData>();            
        }

        private void AddEvent()
        {
            flowLayoutPanel2.Controls.Add(new ucEvent());
        }

        private void RemoveEvent()
        {
            var uc = flowLayoutPanel2.Controls.OfType<ucEvent>().FirstOrDefault();
            if (uc != null)
            {
                flowLayoutPanel2.Controls.Remove(uc);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            this.month -= 1;
            if (this.month < 1)
            {
                this.month = 12;
                this.year -= 1;
            }

            ShowDays(this.month, this.year);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
            this.month += 1;
            if (this.month > 12)
            {
                this.month = 1;
                this.year += 1;
            }

            ShowDays(this.month, this.year);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveEvent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var eventList = GetEventList();

            eventList.RemoveAll(e => e.DateTime.Month == month && e.DateTime.Year == year);

            foreach (var ucDay in flowLayoutPanel1.Controls.OfType<ucDays>())
            {
                if (!string.IsNullOrWhiteSpace(ucDay.EventText))
                {
                    eventList.Add(new DayEventData
                    {
                        DateTime = ucDay.Date,
                        Text = ucDay.EventText,
                        Category = ucDay.CheckedElement
                    });
                }
            }

            var jsonSave = JsonSerializer.Serialize(eventList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(this.fileName, jsonSave);
        }

        private void flowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ucDays)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void flowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
        {
            var eventControl = (ucDays)e.Data.GetData(typeof(ucDays));

            if (eventControl != null)
            {
                var ucEvent = new ucEvent(eventControl.CheckedElement);

                ucEvent.EventText = eventControl.EventText;
                ucEvent.CheckedElement = eventControl.CheckedElement;
                flowLayoutPanel2.Controls.Add(ucEvent);

                var index = flowLayoutPanel1.Controls.GetChildIndex(eventControl);             
                var emptyDayControl = new ucDays(eventControl.Date);
                
                flowLayoutPanel1.Controls.Remove(eventControl);
                flowLayoutPanel1.Controls.Add(emptyDayControl);
                flowLayoutPanel1.Controls.SetChildIndex(emptyDayControl, index);
            }
        }        
    }
}
