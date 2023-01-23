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
            vertexCount = vertexCount;
            Edges = new List<int[]>();
        }
    }
}
