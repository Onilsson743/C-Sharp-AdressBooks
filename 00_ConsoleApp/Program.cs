using _00_ConsoleApp.Models;
using _00_ConsoleApp.Services;

//Sets title of the console
Console.Title = "Adress Book";

//Sets the color of the text
Console.ForegroundColor = ConsoleColor.Black;

//Sets the color of the background
Console.BackgroundColor = ConsoleColor.White;


MainMenu menu = new MainMenu();
FileService service = new FileService();
service.ReadList();


while (true)
{
    Console.Clear();
    menu.MenuOptions();
}