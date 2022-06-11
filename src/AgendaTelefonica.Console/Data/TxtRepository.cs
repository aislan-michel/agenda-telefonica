namespace AgendaTelefonica.Console.Data;

public class TxtRepository : Repository
{
    public TxtRepository(string path) : base(path)
    {
    }

    public override void Write(string text)
    {
        File.WriteAllText(Path, text);
    }

    public override string Read()
    {
        throw new NotImplementedException();
    }

    public override void Clear()
    {
        File.Delete(Path);

        File.Create(Path);
    }
}