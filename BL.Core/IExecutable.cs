namespace BL.Core;

public interface IExecutable
{
    void Send(string cmd);
    string Do(string cmd);
}

