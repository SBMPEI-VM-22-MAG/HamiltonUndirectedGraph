namespace HamiltonUndirectedGraph
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            splitContainerCtrls = new SplitContainer();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            groupBox3 = new GroupBox();
            groupBox5 = new GroupBox();
            button2 = new Button();
            MutateChance = new NumericUpDown();
            label6 = new Label();
            GenerationsCount = new NumericUpDown();
            label5 = new Label();
            PopulationSize = new NumericUpDown();
            label3 = new Label();
            groupBox4 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerCtrls).BeginInit();
            splitContainerCtrls.Panel1.SuspendLayout();
            splitContainerCtrls.Panel2.SuspendLayout();
            splitContainerCtrls.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MutateChance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GenerationsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PopulationSize).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Panel2.Controls.Add(splitContainerCtrls);
            splitContainer1.Size = new Size(1230, 706);
            splitContainer1.SplitterDistance = 763;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.AntiqueWhite;
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(763, 706);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Матрица смежности неориентированного графа:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(757, 677);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // splitContainerCtrls
            // 
            splitContainerCtrls.Dock = DockStyle.Fill;
            splitContainerCtrls.Location = new Point(0, 0);
            splitContainerCtrls.Name = "splitContainerCtrls";
            splitContainerCtrls.Orientation = Orientation.Horizontal;
            // 
            // splitContainerCtrls.Panel1
            // 
            splitContainerCtrls.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainerCtrls.Panel2
            // 
            splitContainerCtrls.Panel2.Controls.Add(groupBox3);
            splitContainerCtrls.Size = new Size(463, 706);
            splitContainerCtrls.SplitterDistance = 338;
            splitContainerCtrls.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(463, 338);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Вывод";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DimGray;
            textBox1.Dock = DockStyle.Fill;
            textBox1.ForeColor = Color.Snow;
            textBox1.Location = new Point(3, 26);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Some";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(457, 309);
            textBox1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(463, 364);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Управление";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button2);
            groupBox5.Controls.Add(MutateChance);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(GenerationsCount);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(PopulationSize);
            groupBox5.Controls.Add(label3);
            groupBox5.Dock = DockStyle.Bottom;
            groupBox5.Location = new Point(3, 180);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(457, 181);
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            groupBox5.Text = "Настройки";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkSeaGreen;
            button2.Location = new Point(324, 29);
            button2.Name = "button2";
            button2.Size = new Size(123, 29);
            button2.TabIndex = 6;
            button2.Text = "START";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // MutateChance
            // 
            MutateChance.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            MutateChance.Location = new Point(197, 122);
            MutateChance.Name = "MutateChance";
            MutateChance.Size = new Size(104, 27);
            MutateChance.TabIndex = 5;
            MutateChance.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 126);
            label6.Name = "label6";
            label6.Size = new Size(189, 20);
            label6.TabIndex = 4;
            label6.Text = "Вероятность мутации (%):";
            // 
            // GenerationsCount
            // 
            GenerationsCount.Location = new Point(197, 79);
            GenerationsCount.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            GenerationsCount.Name = "GenerationsCount";
            GenerationsCount.Size = new Size(104, 27);
            GenerationsCount.TabIndex = 3;
            GenerationsCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 83);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 2;
            label5.Text = "Поколений:";
            // 
            // PopulationSize
            // 
            PopulationSize.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            PopulationSize.Location = new Point(197, 31);
            PopulationSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            PopulationSize.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            PopulationSize.Name = "PopulationSize";
            PopulationSize.Size = new Size(104, 27);
            PopulationSize.TabIndex = 1;
            PopulationSize.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 35);
            label3.Name = "label3";
            label3.Size = new Size(158, 20);
            label3.TabIndex = 0;
            label3.Text = "Особей в поколении:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(button3);
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(trackBar1);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 23);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(457, 338);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Вершины";
            // 
            // button4
            // 
            button4.Location = new Point(353, 88);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 7;
            button4.Text = "Открыть";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(253, 88);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 6;
            button3.Text = "Сохранить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(10, 88);
            button1.Name = "button1";
            button1.Size = new Size(143, 29);
            button1.TabIndex = 5;
            button1.Text = "Быстрая очистка";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(223, 59);
            label4.Name = "label4";
            label4.Size = new Size(17, 20);
            label4.TabIndex = 4;
            label4.Text = "2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(415, 30);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 2;
            label2.Text = "24";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 31);
            label1.Name = "label1";
            label1.Size = new Size(17, 20);
            label1.TabIndex = 1;
            label1.Text = "2";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(30, 26);
            trackBar1.Maximum = 22;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(388, 56);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 706);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Нахождение  гамильтонова  обхода  в  неориентированном   графе";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainerCtrls.Panel1.ResumeLayout(false);
            splitContainerCtrls.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerCtrls).EndInit();
            splitContainerCtrls.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MutateChance).EndInit();
            ((System.ComponentModel.ISupportInitialize)GenerationsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)PopulationSize).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private SplitContainer splitContainerCtrls;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label4;
        private Label label2;
        private Label label1;
        private TrackBar trackBar1;
        private GroupBox groupBox5;
        private NumericUpDown PopulationSize;
        private Label label3;
        private Button button4;
        private Button button3;
        private Button button1;
        private NumericUpDown MutateChance;
        private Label label6;
        private NumericUpDown GenerationsCount;
        private Label label5;
        private Button button2;
    }
}