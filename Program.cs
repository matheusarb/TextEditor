internal class Program
{
    private static void Main(string[] args)
    {
      Menu();
    }

    static void Menu(){
      Console.Clear();
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1 - Abrir arquivo de texto");
      Console.WriteLine("2 - Criar novo arquivo");
      Console.WriteLine("0 - Sair");

      short option = short.Parse(Console.ReadLine());
      switch(option){
        case 0: System.Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
      }
    }
    static void Abrir(){
      Console.Clear();
      System.Console.WriteLine("Qual o caminho do arquivo?");
      string path = Console.ReadLine();

      //serve para ler ou salvar um arquivo
      using(var file = new StreamReader(path)){
        string text = file.ReadToEnd();
        System.Console.WriteLine(text);
      }

      System.Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }
    static void Editar() {
      Console.Clear();
      System.Console.WriteLine("Digite o seu texto abaixo (digite ESC para sair)\n------------");
      string text = "";

      do{
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while(Console.ReadKey().Key != ConsoleKey.Escape);

      System.Console.WriteLine(text);
      Salvar(text);
    }

    static void Salvar(string text) {
      Console.Clear();
      System.Console.WriteLine("Onde você deseja salvar seu arquivo?");
      string path = Console.ReadLine();

      using(var file = new StreamWriter(path)){
        file.Write(text);
      }

      System.Console.WriteLine($"Arquivo {path} salvo!");
      Console.ReadKey();
      Menu();
    }
}