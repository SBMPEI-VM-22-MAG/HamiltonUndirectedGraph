using HamiltonUndirectedGraph.Services;
using System.ComponentModel;

namespace HamiltonUndirectedGraph
{
    public partial class Form1 : Form
    {
        private IMessageService _srvMsg;

        public Form1(IMessageService srvMsg)
        {
            _srvMsg = srvMsg;
            InitializeComponent();
        }
    }
}