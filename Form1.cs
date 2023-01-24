using HamiltonUndirectedGraph.Models;
using HamiltonUndirectedGraph.Services;
using Newtonsoft.Json;
using System.Text.Json;

namespace HamiltonUndirectedGraph
{
    public partial class Form1 : Form
    {
        private IMessageService _srvMsg;

        public Form1(IMessageService srvMsg)
        {
            _srvMsg = srvMsg;
            InitializeComponent();

            label4.Text = Convert.ToString(trackBar1.Value + 2);//���������� ������� �������� 
            dataGridView1.RowCount = trackBar1.Value + 2;//������ ��������� �������
            dataGridView1.ColumnCount = trackBar1.Value + 2;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {//����������� ������
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i + 1);
            }
            dataGridView1.AutoResizeColumns();
        }

        //������ ������� ������� ��������� �, ��������������, ���������� ������ �����
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(trackBar1.Value + 2);//���������� ������� �������� 
            dataGridView1.RowCount = trackBar1.Value + 2;//������ ��������� �������
            dataGridView1.ColumnCount = trackBar1.Value + 2;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {//����������� ������
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i + 1);
            }
            dataGridView1.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //���������� ������ ������� �� �������, ������ �������� ����� �����
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1[i, j].Value = null;
                }
            }
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "��������� ������ � ����";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {//������ ����

                    bool[,] temp = new bool[dataGridView1.ColumnCount, dataGridView1.RowCount];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                            if (Convert.ToString(dataGridView1[i, j].Value) != "")//���� � ������ �� �����, �� ���� �����
                            {
                                dataGridView1[i, j].Value = "1";//�� ������ ������, ����������� ���� 1
                                temp[i, j] = true;
                            }
                            else { temp[i, j] = false; }
                    }

                    //����������� � ������
                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);//��������� � ���� ���������� ���������
                    sw.WriteLine(json);//��������
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                _srvMsg.ShowError(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "������� ����";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                button1_Click(null, null);//������� ������� ����          
                StreamReader sr = new StreamReader(openFileDialog1.FileName);//��������� ����
                string temp = sr.ReadLine();//������ ��� ��������������. ������� ���� ������
                sr.Close();

                bool[,] testtest = JsonConvert.DeserializeObject<bool[,]>(temp);//�������� ������� �� ������
                trackBar1.Value = testtest.GetLength(0) - 2;//������������� �������� � ������������ � ���, ��� ���������
                trackBar1_Scroll(null, null);//��� ������� �������� �������� ������� ��� ��, ��� ���������
                for (int i = 0; i < testtest.GetLength(0); i++)
                {
                    for (int j = 0; j < testtest.GetLength(1); j++)
                    {
                        if (testtest[i, j])
                        {
                            dataGridView1[i, j].Value = 1;//���������.
                        }
                    }
                }

            }
        }

        //������� ����� ������� ���� � �������
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) //���� ��� ������, ����� ����� �������� ��� ������� ������ �� ����� �������
            {
                DataGridViewCell selected_cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.RowIndex != e.ColumnIndex) //���� ������ ����� �������, �� ��� ����� �������� �����, � ����� ��� ����� �� �����, �������, �������� ��� �������.
                {
                    DataGridViewCell mirror_cell = dataGridView1.Rows[e.ColumnIndex].Cells[e.RowIndex]; // ��� ��� ���� � ��� �� ���������������, ���� ���� ���� �� A � B, �� ������ ���� � �� B � A
                    if (selected_cell.Value == null)
                    {
                        selected_cell.Value = "1";
                        mirror_cell.Value = "1";
                    }
                    else
                    {
                        selected_cell.Value = null;
                        mirror_cell.Value = null;
                    }

                }
                else //�� ������ ������, ������� ������, ������� �� ������� ���������. � ��, ���� ��, ��� � ��� ����� ���� � ���������� �����...
                {
                    selected_cell.Value = null;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            GraphModel field = new GraphModel(trackBar1.Value + 2); //����� ������ ������� � ����������.
            for (int i = 0; i < field.VertexCount; i++)
            {
                for (int j = i; j < field.VertexCount; j++)
                {
                    if (dataGridView1[i, j].Value != null)
                    {
                        field.AddEdge(i, j);
                    }
                }
            }
            List<CreatureModel> population = new List<CreatureModel>();
            int populationCount = Convert.ToInt32(PopulationSize.Value);
            int gens = Convert.ToInt32(GenerationsCount.Value);
            int chance = Convert.ToInt32(MutateChance.Value);
            Random rand = new Random();

            for (int i = 0; i < populationCount; i++)//���������� ��������� ���������.
            {
                population.Add(new CreatureModel(field));
                System.Threading.Thread.Sleep(1); //��-�� ���������, ��������� ��������� ���������� ���������� ������ random �, ��� ���������, ���������� �����, ������� ������ �� ����� �������� �����������. ���� ������ �������� ��� ������������ ���������� ������
            }
            for (int i = 0; i < gens; i++)
            {
                population.Sort((a, b) => a.GetFitness().CompareTo(b.GetFitness()));//��������� ������ �� ����������� �����������������.

                textBox1.AppendText("��������� " + (i + 1).ToString() + ": " + Environment.NewLine
                                    + "����� ������: " + population.Count.ToString() + Environment.NewLine
                                    + "������ �����������: " + population[0].GetFitness().ToString() + ": " + population[0].GeneticCode + Environment.NewLine
                                    + "������ �����������: " + population[populationCount / 2 - 1].GetFitness().ToString() + ": " + population[populationCount / 2 - 1].GeneticCode + Environment.NewLine + Environment.NewLine);

                population.RemoveRange(populationCount / 2, populationCount / 2);//�������� ������ �������� ������� ���������. ����� ��� �����, ������ �����

                for (int j = 0; j < populationCount / 2; j++) //�������� ��������� � �������
                {
                    int partnernumber = j; //�������� ������ ����� �������, ��������� �� ����� �����
                    while (partnernumber == j)
                    {
                        partnernumber = rand.Next(populationCount / 2);
                    }
                    CreatureModel nextchild = population[j].Crossover(population[partnernumber]);
                    if (rand.Next(100) < chance) //�������� �������, ���� ����
                    {
                        nextchild.MutateMe();
                    }
                    population.Add(nextchild);//���������� ��� � ���������
                }
                if (population[0].GetFitness() == 0)
                {
                    textBox1.AppendText("��������� ����������� ���������: " + population[0].GetFitness().ToString() + Environment.NewLine
                        + population[0].DecodeGenome() + Environment.NewLine
                        + "и��� �� �������������. �� ��� �������� ����������� ����, ���� �� �������������.");
                    break;
                }
            }
        }
    }
}