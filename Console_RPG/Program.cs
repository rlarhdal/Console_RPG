using System.Security.Cryptography.X509Certificates;

namespace Console_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("플레이어의 이름을 입력해주세요 : ");
            string name = Console.ReadLine();

            Player player = new Player(name);
            Inventory inventory = new Inventory();
            Store store = new Store();

            Stage stage = new Stage(player, inventory, store);
            stage.Intro();
        }
    }
}
