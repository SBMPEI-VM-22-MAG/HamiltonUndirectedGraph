using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HamiltonUndirectedGraph.Models;

//В качестве особи будем рассматривать какой-нибудь маршрут в графе
public class CreatureModel
{
    private GraphModel _liveArea; //Граф, для которого построен маршрут
    private int _fitness; //Её будем стараться минимизировать. Но при этом, это должно быть неотрицательное значение.

    private Random _rand = new Random();

    //Для каждого ребра в графе будем ставить 0, если он не включён в маршрут и 1, если он в него включен.
    public string GeneticCode { get; private set; }

    public CreatureModel(GraphModel lifeArea)
    {
        _liveArea = lifeArea;
        GeneticCode = "";

        StringBuilder genCode = new StringBuilder();

        //Генерируем случайную последовательность 0 и 1, заданной длины
        for(int i = 0; i < _liveArea.Edges.Count; i++)
        {
            if (_rand.Next(2) == 0) genCode.Append('0');
            else genCode.Append('1');

            GeneticCode = genCode.ToString();
            _fitness = -1;
        }
    }

    //Функция приспособленности
    public int GetFitness()
    {
        //В гамильтоновом цикле (именно цикле) столько рёбер, сколько вершин в исходном графе

        //Если ранее не считали приспособленность, считаем её
        if (_fitness == -1) return this.CalcFitness();

        return _fitness;
    }

    private int CalcFitness()
    {
        _fitness = 0;

        //Добавим сюда только те рёбра, что есть в выбранном пути
        List<int[]> usedEdges = new List<int[]>();

        for (int i = 0; i < _liveArea.Edges.Count; i++)
        {
            if (GeneticCode[i] == '1')
            {
                int[] temp = new int[2];
                _liveArea.Edges[i].CopyTo(temp, 0);
                usedEdges.Add(temp);
            }
        }

        //Если сгенерировалась пустая последовательность, всё ломается.
        //Поэтому рассмотрим этот случай отдельно и дадим ему сразу большой штраф
        if (usedEdges.Count == 0) 
        {
            _fitness = 9999;
            return _fitness;
        }

        //В гамильтоновом пути не должно быть вершин, имеющих степень больше 2.
        //Найдём такие вершины, если они есть.
        int overload = 0;
        for (int i = 0; i < _liveArea.VertexCount; i++)
        {
            int counter = 0;
            foreach (int[] tempEdge in usedEdges)
            {
                if (tempEdge[0] == i || tempEdge[1] == i) counter++;
            }

            //Чем выше степень у вершины, тем хуже.
            //В идеале, степени всех вершин либо равны 2,
            //либо среди них есть 2 вершины со степенями 1 (начало и конец пути)
            if (counter > 2) overload += counter - 2;
        }

        //Узнаем, через все ли вершины проходит наш путь.
        //Для этого, будем "сжигать" все вершины, до которых можно по нему добраться
        
        List<int> burnedVertex = new List<int>(); //Те вершины, что уже сгорели
        
        List<int> burningVertex = new List<int>(); //Те вершины, что горят сейчас

        //Берём первое ребро в пути и запихиваем его вершины в список горящих вершин
        burningVertex.Add(usedEdges[0][0]);
        burningVertex.Add(usedEdges[0][1]);

        //Само ребро сразу выпиливаем, ибо оно сгорело.
        usedEdges.RemoveAt(0);

        //Заодно посчитаем длину пути
        int pathLength = 1;
        while (burningVertex.Count > 0)
        {
            //Это будут вершины, которые мы подожжём на текущей итерации
            List<int> newBurningVertex = new List<int>();

            //В каждом оставшемся ребре ищем "горящие" вершины...
            foreach (int[] tempEdge in usedEdges)
            {
                //Сравниваем каждую горящую вершину с каждой вершиной рассматриваемого ребра
                foreach (int tempVertex in burningVertex)
                {
                    if (tempVertex == tempEdge[0])
                    {
                        //Поджигаем противоположную вершину ребра
                        newBurningVertex.Add(tempEdge[1]);

                        //Сжигаем ребро
                        tempEdge[0] = -1;

                        //Т.к. во время прохода по списку, нельзя удалять его элементы,
                        //будем их просто менять, чтобы они больше не мешали
                        tempEdge[1] = -1;

                        pathLength++;
                        break; //И больше его не рассматриваем
                    }

                    //То же самое для противоположного ребра, если оно не сгорело
                    if (tempVertex == tempEdge[1])
                    {
                        //Поджигаем противоположную вершину ребра
                        newBurningVertex.Add(tempEdge[0]);

                        //Сжигаем ребро
                        tempEdge[0] = -1;

                        //Т.к. во время прохода по списку, нельзя удалять его элементы,
                        //будем их просто менять, чтобы они больше не мешали
                        tempEdge[1] = -1;
                        pathLength++;
                        break;//И больше его не рассматриваем
                    }
                }
            }

            //То, что горело на этой итерации, считаем сгоревшим.
            burnedVertex.AddRange(burningVertex);
            burningVertex.Clear();

            //Добавляем то, что подожгли...
            burningVertex.AddRange(newBurningVertex);
        }

        //Штрафуем особь на разницу между количеством вершин в графе и количеством сожжённых вершин...
        _fitness += Math.Abs(burnedVertex.Count - _liveArea.VertexCount);

        //Гамильтонов путь (не являющийся циклом) имеет длину, равную количеству вершин графа минус 1.
        //Если это цикл, то просто количеству вершин графа.
        //В принципе, если убрать из следующей строки это "-1",
        //то оно будет искать гамильтонов цикл, а не путь.
        _fitness += Math.Abs(_liveArea.VertexCount - 1 - pathLength);
                                                                      
        _fitness += overload; //Добавим штрафы за слишком большие степени вершин, если таковые есть

        return _fitness;
    }

    //Расшифровываем геном особи и выводим его в удобоваримом виде
    public string DecodeGenome()
    {
        string res = "";
        for (int i = 0; i < GeneticCode.Length; i++)
        {
            //Добавляем единички, т.к. в таблице нумерация идёт не с нуля
            if (GeneticCode[i] == '1') res += (_liveArea.Edges[i][0] + 1).ToString() + " - " + (_liveArea.Edges[i][1] + 1).ToString() + "; ";
        }
        return res;
    }


    //Первая важная фишка генетических алгоритмов. Тут существа должны плодиться и размножаться
    public CreatureModel Crossover(CreatureModel partner)
    {
        CreatureModel child0 = new CreatureModel(_liveArea);
        CreatureModel child1 = new CreatureModel(_liveArea);

        int slice = _rand.Next(_liveArea.Edges.Count);

        //Выбираем точку разреза и комбинируем гены предков
        child0.GeneticCode = GeneticCode.Substring(0, slice) + partner.GeneticCode.Substring(slice);

        //Данный кроссовер допускает 2 варианта комбинации генов... Будем выбирать лучший из них
        child1.GeneticCode = partner.GeneticCode.Substring(0, slice) + GeneticCode.Substring(slice);

        //Отдаём наиболее удачную особь
        if (child0.GetFitness() < child1.GetFitness()) return child0;
        else return child1;
    }

    //Вторая фишка генетических алгоритмов - случайные мутации.
    //Бывают разными. Здесь ограничимся только инверсией
    public void MutateMe()
    {
        //Так как генокод меняется, нужно обновить приспособленность
        _fitness = -1;

        //Просто инвертируем случайный бит в генокоде
        int point = _rand.Next(_liveArea.Edges.Count);

        if (GeneticCode[point] == '1') GeneticCode = GeneticCode.Remove(point, 1).Insert(point, "0");
        else GeneticCode = GeneticCode.Remove(point, 1).Insert(point, "1");
    }
}
