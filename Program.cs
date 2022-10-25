// /////////////////////////////////////
// ///////////////////////////////////////
char[,] field = new char[4, 4] {                                             //// Массив сделал 4 на 4 чтобы использовать строки и столбцы 1-3
        { ' ', ' ', ' ' , ' ' },
        { ' ', ' ', ' ' , ' ' },
        { ' ', ' ', ' ' , ' ' },
        { ' ', ' ', ' ' , ' ' },
    };

void ShowField()                                                             //// Поле для крестиков и ноликов использовал string format чтобы нагляднее показывал  как будет выглядеть строка
{
    Console.WriteLine();
    Console.WriteLine(string.Format("  {0} | {1} | {2}", field[1, 1], field[1, 2], field[1, 3]));
    Console.WriteLine(" ---+---+---");
    Console.WriteLine(string.Format("  {0} | {1} | {2}", field[2, 1], field[2, 2], field[2, 3]));
    Console.WriteLine(" ---+---+---");
    Console.WriteLine(string.Format("  {0} | {1} | {2}", field[3, 1], field[3, 2], field[3, 3]));
    Console.WriteLine();
}

void KeyPressed(ConsoleKeyInfo key, char[,] cage, ref int str, ref int column)
{
    switch (key.Key)
    {
        case ConsoleKey.D1:
            if (cage[3, 1] == ' ') str = 3; column = 1;
            break;
        case ConsoleKey.D2:
            if (cage[3, 2] == ' ') str = 3; column = 2;
            break;
        case ConsoleKey.D3:
            if (cage[3, 3] == ' ') str = 3; column = 3;
            break;
        case ConsoleKey.D4:
            if (cage[2, 1] == ' ') str = 2; column = 1;
            break;
        case ConsoleKey.D5:
            if (cage[2, 2] == ' ') str = 2; column = 2;
            break;
        case ConsoleKey.D6:
            if (cage[2, 3] == ' ') str = 2; column = 3;
            break;
        case ConsoleKey.D7:
            if (cage[1, 1] == ' ') str = 1; column = 1;
            break;
        case ConsoleKey.D8:
            if (cage[1, 2] == ' ') str = 1; column = 2;
            break;
        case ConsoleKey.D9:
            if (cage[1, 3] == ' ') str = 1; column = 3;
            break;
    }
}
// void Coordinate(ref int x, ref int y)                                        //// координаты которые будем присуждать крестикам и ноликам
// {
//     string? coordinat = Console.ReadLine();
//     string[] splitString2 = coordinat.Split(' ');
//     x = Convert.ToInt32(splitString2[0]);
//     y = Convert.ToInt32(splitString2[1]);
// }

int schet = 1;
int str = 0;
int column = 0;
char krestik = 'x';
char nolik = 'o';
bool win = false;

for (int i = 1; i < 6; i++)                                                 //// Главное тело игры
{   Console.Clear();
    Console.WriteLine("Введите крестик по расположению на numpade");
    ShowField();
    proverka(field);
    field[str, column] = krestik;
    Console.Clear();
    pobeda(field, ref schet);
    if (schet == 10)
    {
        Console.WriteLine("конец игры");
        ShowField();
        return;
    }
    Console.WriteLine("Введите нолик по расположению на numpade");
    ShowField();
    proverka(field);
    field[str, column] = nolik;
    Console.Clear();
    pobeda(field, ref schet);
    x(ref schet, ref field);
    if (schet == 10)
    {
        Console.WriteLine("конец игры");
        ShowField();
        return;
    }
}

void pobeda(char[,] field, ref int schet)                                   //// Проверка на победу или ничью
{

    schet++;
    win = (field[1, 1] != ' ' && field[1, 1] == field[1, 2] && field[1, 2] == field[1, 3] ||
                field[2, 1] != ' ' && field[2, 1] == field[2, 2] && field[2, 2] == field[2, 3] ||
                field[3, 1] != ' ' && field[3, 1] == field[3, 2] && field[3, 2] == field[3, 3] ||
                field[1, 1] != ' ' && field[1, 1] == field[2, 1] && field[2, 1] == field[3, 1] ||
                field[1, 2] != ' ' && field[1, 2] == field[2, 2] && field[2, 2] == field[3, 2] ||
                field[1, 3] != ' ' && field[1, 3] == field[2, 3] && field[2, 3] == field[3, 3] ||
                field[1, 1] != ' ' && field[1, 1] == field[2, 2] && field[2, 2] == field[3, 3] ||
                field[1, 3] != ' ' && field[1, 3] == field[2, 2] && field[2, 2] == field[3, 1]);

    if (win == true)
    {
        Console.WriteLine(field[str, column] == 'x' ? "Победили крестики" : "Победили Нолики");
        schet = 10;
        return;
    }
    else if (schet == 10)
    {
        Console.WriteLine("Ничья");
        return;

    }
}
void x(ref int schet, ref char[,] field)
{
    if (schet == 9)
    {

        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (field[i, j] == ' ')
                {
                    field[i, j] = 'x';
                }
            }

        }
        win = (field[1, 1] != ' ' && field[1, 1] == field[1, 2] && field[1, 2] == field[1, 3] ||
                   field[2, 1] != ' ' && field[2, 1] == field[2, 2] && field[2, 2] == field[2, 3] ||
                   field[3, 1] != ' ' && field[3, 1] == field[3, 2] && field[3, 2] == field[3, 3] ||
                   field[1, 1] != ' ' && field[1, 1] == field[2, 1] && field[2, 1] == field[3, 1] ||
                   field[1, 2] != ' ' && field[1, 2] == field[2, 2] && field[2, 2] == field[3, 2] ||
                   field[1, 3] != ' ' && field[1, 3] == field[2, 3] && field[2, 3] == field[3, 3] ||
                   field[1, 1] != ' ' && field[1, 1] == field[2, 2] && field[2, 2] == field[3, 3] ||
                   field[1, 3] != ' ' && field[1, 3] == field[2, 2] && field[2, 2] == field[3, 1]);
        if (win == true)
        {
            Console.WriteLine("Победили крестики");
            schet = 10;
            return;
        }
        else
        {
            Console.WriteLine("Ничья");
            schet = 10;
            return;
        }
    }
}

void proverka(char[,] field)                                                //// Проверка на координаты и пустая клеточка или занята
{
    KeyPressed(Console.ReadKey(), field, ref str, ref column);
    char whi = 'n';
    while (whi == 'n')
    {
        if (field[str, column] == ' ')
        {
            whi = 'y';
        }
        else
        {
            KeyPressed(Console.ReadKey(), field, ref str, ref column);
        }
    }

}
/////////////////////////////////////////////

// int InputInt(string value)
// {
//     int number = 0;
//     while (!int.TryParse(value, out number))
//     {
//         Console.Write("Не подходит к требованиЮ введите число: ");
//         value = Console.ReadLine();
//     }
//     return number;
// }
// void Palindrom(int first, int dlinaNum, int num)
// {
//     int i = 1;
//     while (dlinaNum > i)
//     {
//         first = (int)((num / Math.Pow(10, (dlinaNum - i))) % 10);
//         int last = num % 10;
//         Console.Write($"{first}");
//         Console.WriteLine($"{last}");
//         dlinaNum = dlinaNum - 1;
//         i++;
//         num = num / 10;
//         if (first != last)
//         {
//             Console.WriteLine("не палиндром");
//             return; 
//         }
//     }
//     Console.WriteLine("Палиндром");
// }

// Console.Write("Введите число: ");
// int num = InputInt(Console.ReadLine());
// int first = 0;
// string x = Convert.ToString(num);
// int dlinaNum = x.Length;
// int i = 1;
// if (num > 9)
// {
//     Palindrom(first, dlinaNum, num);
// }
// else Console.WriteLine($"не подходит по требованиям");