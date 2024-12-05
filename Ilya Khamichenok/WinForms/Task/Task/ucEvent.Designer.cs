namespace Task
{
    partial class ucEvent
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            checkedListBoxEvent = new CheckedListBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Verdana", 12F);
            textBox1.Location = new Point(3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(117, 94);
            textBox1.TabIndex = 0;
            textBox1.MouseDown += textBox1_MouseDown;
            // 
            // checkedListBoxEvent
            // 
            checkedListBoxEvent.Font = new Font("Verdana", 12F);
            checkedListBoxEvent.FormattingEnabled = true;
            checkedListBoxEvent.Location = new Point(135, 4);
            checkedListBoxEvent.Name = "checkedListBoxEvent";
            checkedListBoxEvent.Size = new Size(81, 92);
            checkedListBoxEvent.TabIndex = 1;
            checkedListBoxEvent.ItemCheck += checkedListBoxEvent_ItemCheck;
            checkedListBoxEvent.SelectedIndexChanged += checkedListBoxEvent_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(checkedListBoxEvent);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 98);
            panel1.TabIndex = 2;
            // 
            // ucEvent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "ucEvent";
            Padding = new Padding(1);
            Size = new Size(226, 100);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private CheckedListBox checkedListBoxEvent;
        private Panel panel1;
    }
}
