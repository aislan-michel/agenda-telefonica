using AgendaTelefonica.Console.Extensions;

namespace AgendaTelefonica.Console.Entities;

public class Agenda
{
    public Agenda()
    {
        Popular();
    }
    
    private static string CsvPath => @"../../../Data/agenda.csv";

    private IList<Contato> _contatos = new List<Contato>();
    public IEnumerable<Contato> Contatos => _contatos;

    private void Popular()
    {
        if (!File.Exists(CsvPath))
        {
            File.Create(CsvPath);
            
            return;
        }
        
        var registros = File.ReadLines(CsvPath);

        _contatos = registros.Select(linha => (Contato)linha).ToList();
    }

    public void AdicionarContato(Contato contato)
    {
        _contatos.Add(contato);
        
        var lines = File.ReadLines(CsvPath).ToList();

        if (!lines.Any())
        {
            File.AppendAllText(CsvPath, (string) contato);
            return;
        }
        
        File.AppendAllText(CsvPath, "\n" + (string) contato);
    }

    public Contato? ObterContato(string termo)
    {
        if (string.IsNullOrWhiteSpace(termo))
        {
            return null;
        }
    
        if (termo.IsValidEmail())
        {
            return _contatos.FirstOrDefault(x => x.Email == termo);
        }
    
        if (termo.IsDigitsOnly())
        {
            return _contatos.FirstOrDefault(x => x.Telefone == termo);
        }
    
        return _contatos.FirstOrDefault(x => x.Nome == termo);
    }

    public void DeletarContato(Contato contato)
    {
        _contatos.Remove(contato);

        var lines = File.ReadLines(CsvPath).ToList();

        var line = lines.FirstOrDefault(x => x == (string) contato);

        if (!string.IsNullOrWhiteSpace(line))
        {
            lines.Remove(line);
        }
                    
        File.WriteAllText(CsvPath, string.Join("\n", lines));
    }

    public void LimparContatos()
    {
        File.Delete(CsvPath);

        File.Create(CsvPath);

        _contatos.Clear();
    }
}