using _00_ConsoleApp.Services;

MainMenu menu = new MainMenu();
FileService service = new FileService();
service.ReadList();

while (true)
{
    Console.Clear();
    menu.MenuOptions();
}