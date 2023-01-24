using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonUndirectedGraph.Services;

public interface IMessageService
{
    void ShowMessage(string message);
    void ShowError(string message);
    void ShowSuccess(string message);
    void ShowWarning(string message);
}

public class MessageService : IMessageService
{
    public void ShowMessage(string message)
    {
        MessageBox.Show(message);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowSuccess(string message)
    {
        MessageBox.Show(message, "Success!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void ShowWarning(string message)
    {
        MessageBox.Show(message, "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
