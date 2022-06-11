namespace AgendaTelefonica.Console.Data;

public abstract class Repository
{
    protected Repository(string path)
    {
        Path = path;
    }

    protected string Path { get; set; }
    
    public abstract void Write(string text);
    public abstract string Read();

    public abstract void Clear();

}