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

            label4.Text = Convert.ToString(trackBar1.Value + 2);//Показываем текущее значение 
            dataGridView1.RowCount = trackBar1.Value + 2;//Меняем параметры таблицы
            dataGridView1.ColumnCount = trackBar1.Value + 2;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {//Подписываем хэдеры
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i + 1);
            }
            dataGridView1.AutoResizeColumns();
        }

        //Меняем размеры таблицы смежности и, соответственно, количество вершин графа
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(trackBar1.Value + 2);//Показываем текущее значение 
            dataGridView1.RowCount = trackBar1.Value + 2;//Меняем параметры таблицы
            dataGridView1.ColumnCount = trackBar1.Value + 2;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {//Подписываем хэдеры
                dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(i + 1);
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i + 1);
            }
            dataGridView1.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Нормальные методы очистки не завезли, делаем напрямую через циклы
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
                saveFileDialog1.Title = "Сохранить данные в файл";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {//Выбран файл

                    bool[,] temp = new bool[dataGridView1.ColumnCount, dataGridView1.RowCount];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                            if (Convert.ToString(dataGridView1[i, j].Value) != "")//Если в ячейке не пусто, то есть связь
                            {
                                dataGridView1[i, j].Value = "1";//На всякий случай, перезапишем туда 1
                                temp[i, j] = true;
                            }
                            else { temp[i, j] = false; }
                    }

                    //Сериализуем в строку
                    string json = JsonConvert.SerializeObject(temp, Formatting.Indented);
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);//Сохраняем в виде текстового документа
                    sw.WriteLine(json);//Сохраним
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
            openFileDialog1.Title = "Открыть файл";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                button1_Click(null, null);//Очистим рабочее поле          
                StreamReader sr = new StreamReader(openFileDialog1.FileName);//Прочитаем файл
                string temp = sr.ReadLine();//Строка для десериализации. Ожидаем одну строку
                sr.Close();

                bool[,] testtest = JsonConvert.DeserializeObject<bool[,]>(temp);//Получаем матрицу из строки
                trackBar1.Value = testtest.GetLength(0) - 2;//Устанавливаем ползунки в соответствии с тем, что загрузили
                trackBar1_Scroll(null, null);//Эта функция подгонит габартиы таблицы под то, что загрузили
                for (int i = 0; i < testtest.GetLength(0); i++)
                {
                    for (int j = 0; j < testtest.GetLength(1); j++)
                    {
                        if (testtest[i, j])
                        {
                            dataGridView1[i, j].Value = 1;//заполняем.
                        }
                    }
                }

            }
        }

        //Сделаем более удобный ввод в таблицу
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) //Если это убрать, прога будет вылетать при попытке тыкать по полям таблицы
            {
                DataGridViewCell selected_cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.RowIndex != e.ColumnIndex) //Если строка равна столбцу, то это ребро является петлёй, в цикле его точно не будет, поэтому, запретим его вводить.
                {
                    DataGridViewCell mirror_cell = dataGridView1.Rows[e.ColumnIndex].Cells[e.RowIndex]; // Так как граф у нас не ориентированный, если есть путь из A в B, то должен быть и из B в A
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
                else //На всякий случай, очистим ячейку, лежащую на главной диагонали. А то, мало ли, что у нас может быть в сохранённом файле...
                {
                    selected_cell.Value = null;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            GraphModel field = new GraphModel(trackBar1.Value + 2); //Число вершин задаётся в интерфейсе.
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

            for (int i = 0; i < populationCount; i++)//Генерируем начальную популяцию.
            {
                population.Add(new CreatureModel(field));
                System.Threading.Thread.Sleep(1); //Из-за говнокода, постоянно создаются одинаковые экземпляры класса random и, как следствие, одинаковые особи, которые ничего не могут породить нормального. Надо делать задержку или использовать глобальный рандом
            }
            for (int i = 0; i < gens; i++)
            {
                population.Sort((a, b) => a.GetFitness().CompareTo(b.GetFitness()));//Сортируем список по возрастанию приспособленности.

                textBox1.AppendText("Поколение " + (i + 1).ToString() + ": " + Environment.NewLine
                                    + "Всего особей: " + population.Count.ToString() + Environment.NewLine
                                    + "Лучшее приближение: " + population[0].GetFitness().ToString() + ": " + population[0].GeneticCode + Environment.NewLine
                                    + "Худшее приближение: " + population[populationCount / 2 - 1].GetFitness().ToString() + ": " + population[populationCount / 2 - 1].GeneticCode + Environment.NewLine + Environment.NewLine);

                population.RemoveRange(populationCount / 2, populationCount / 2);//Обрезаем худшую половину текущей популяции. Почти как Танос, только умнее

                for (int j = 0; j < populationCount / 2; j++) //Проводим кроссовер и мутации
                {
                    int partnernumber = j; //Выбираем каждой особи партнёра, отличного от самой особи
                    while (partnernumber == j)
                    {
                        partnernumber = rand.Next(populationCount / 2);
                    }
                    CreatureModel nextchild = population[j].Crossover(population[partnernumber]);
                    if (rand.Next(100) < chance) //Проводим мутацию, если надо
                    {
                        nextchild.MutateMe();
                    }
                    population.Add(nextchild);//Закидываем его в популяцию
                }
                if (population[0].GetFitness() == 0)
                {
                    textBox1.AppendText("Достигнут необходимый результат: " + population[0].GetFitness().ToString() + Environment.NewLine
                        + population[0].DecodeGenome() + Environment.NewLine
                        + "Рёбра не отсортированы. Но они образуют гамильтонов путь, если их отсотрировать.");
                    break;
                }
            }
        }
    }
}