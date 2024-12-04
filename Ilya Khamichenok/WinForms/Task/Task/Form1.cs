using System.Globalization;
using System.Text.Json;

namespace Task
{
    public partial class Form1 : Form
    {
        private int year, month;

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
            var json = File.ReadAllText("events.json");
            if (File.Exists("events.json"))
            {
                List<DayEventData> eventList = JsonSerializer.Deserialize<List<DayEventData>>(json);

                flowLayoutPanel1.Controls.Clear();
                this.month = month;
                this.year = year;

                var monthName = new DateTimeFormatInfo().GetMonthName(month);
                lbMonth.Text = monthName.ToString().ToUpper() + " " + year;
                var startedTheMonth = new DateTime(year, month, 1);
                var day = DateTime.DaysInMonth(year, month);
                var week = Convert.ToInt32(startedTheMonth.DayOfWeek.ToString("d"));

                if (week == 0)
                {
                    week = 6;
                }
                else
                {
                    week -= 1;
                }

                for (int i = 0; i < week; i++)
                {
                    var uc = new ucDays("");
                    flowLayoutPanel1.Controls.Add(uc);
                }

                for (int i = 1; i <= day; i++)
                {
                    var dateTime = new DateTime(year, month, i);
                    if (eventList.Count > 0 && eventList.Where(e => e.DateTime == dateTime).FirstOrDefault() != null)
                    {
                        var even = eventList.Where(e => e.DateTime == dateTime).FirstOrDefault();
                        flowLayoutPanel1.Controls.Add(new ucDays(dateTime, even.Text, even.Category));
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(new ucDays(dateTime));
                    }
                }
            }
        }

        private void AddEvent()
        {
            var uc = new ucEvent();
            flowLayoutPanel2.Controls.Add(uc);
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
            month -= 1;
            if (month < 1)
            {
                month = 12;
                year -= 1;
            }

            ShowDays(month, year);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
            month += 1;
            if (month > 12)
            {
                month = 1;
                year += 1;
            }

            ShowDays(month, year);
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
            List<DayEventData> dayEvents = new List<DayEventData>();

            if (File.Exists("events.json"))
            {
                string json = File.ReadAllText("events.json");
                dayEvents = JsonSerializer.Deserialize<List<DayEventData>>(json);
            }
            else
            {
                dayEvents = new List<DayEventData>();
            }

            dayEvents.RemoveAll(e => e.DateTime.Month == month && e.DateTime.Year == year);

            foreach (var ucDay in flowLayoutPanel1.Controls.OfType<ucDays>())
            {
                if (!string.IsNullOrWhiteSpace(ucDay.EventText))
                {
                    dayEvents.Add(new DayEventData
                    {
                        DateTime = ucDay.Date,
                        Text = ucDay.EventText,
                        Category = ucDay.CheckedElement
                    });
                }
            }

            var jsonSave = JsonSerializer.Serialize(dayEvents, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("events.json", jsonSave);
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
            if (e.Data.GetDataPresent(typeof(ucDays)))
            {
                var eventControl = (ucDays)e.Data.GetData(typeof(ucDays));

                var ucEvent = new ucEvent();
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
