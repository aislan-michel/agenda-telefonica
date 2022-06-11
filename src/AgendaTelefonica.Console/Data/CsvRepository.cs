namespace AgendaTelefonica.Console.Data;

public class CsvRepository : Repository
{
    public CsvRepository(string path) : base(path)
    {
    }

    public override void Write(string text)
    {
        throw new NotImplementedException();
    }

    public override string Read()
    {
        throw new NotImplementedException();
    }

    public override void Clear()
    {
        throw new NotImplementedException();
    }
}