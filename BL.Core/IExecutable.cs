namespace BL.Core;

public interface IExecutable
{
    void Send(Command cmd);
    string Do(Command cmd);

}

