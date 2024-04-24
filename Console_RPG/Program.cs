using System.Security.Cryptography.X509Certificates;

namespace Console_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player();
            Inventory inventory = new Inventory();
            Store store = new Store();

            Console.Write("플레이어의 이름을 입력해주세요 : ");
            string name = Console.ReadLine();
            player.name = name;

            Stage stage = new Stage(player, inventory, store);
            stage.Intro();
        }
    }
}
