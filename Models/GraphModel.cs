using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonUndirectedGraph.Models;

public class GraphModel
{
    public int VertexCount { get; private set; }
    public List<int[]> Edges { get; private set; }

    public GraphModel(int vertexCount)
    {
        if (vertexCount >= 2)
        {
            VertexCount = vertexCount;
            Edges = new List<int[]>();
        }
    }

    public int AddEdge(int topA, int topB)
    {
        //Вершины в графе нумеруются с 0, номер вершины должен быть меньше количества вершин в графе. Также запретим создавать петли из вершины в саму себя
        bool checkInput = (topA < VertexCount) && (topB < VertexCount) && (topA >= 0) && (topB >= 0) && (topA != topB);
        if (!checkInput) return -1;

        //Пусть в рёбрах, для порядка, вершины идут от меньшей к большей
        if (topA > topB)
        {
            var temp = topA;
            topA = topB;
            topB = temp;
        }

        //Проверим на наличие дубликатов
        var duplicate = false;
        foreach (var edge in Edges)
        {
            //Мы знаем, что у нас вершины в рёбрах упорядочены, так что, просто проверяем их на соответствие
            if (topA == edge[0] && topB == edge[1]) duplicate = true;
        }

        //Если дубликатов нет, то закинем ребро в список. Если есть, то ничего не делаем.
        if (!duplicate)
        {
            Edges.Add(new int[] { topA, topB });
            return 1;
        }

        return 0;
    }
}
