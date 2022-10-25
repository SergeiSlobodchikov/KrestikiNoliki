
// Задача 19

// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.

// 14212 -> нет

// 12821 -> да

// 23432 -> да

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
// Console.Write("Введите пятизначное число: ");
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

/////////////////////////////////////
///////////////////////////////////////
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

void Coordinate(ref int x, ref int y)                                        //// координаты которые будем присуждать крестикам и ноликам
{
    string? coordinat = Console.ReadLine();
    string[] splitString2 = coordinat.Split(' ');
    x = Convert.ToInt32(splitString2[0]);
    y = Convert.ToInt32(splitString2[1]);
}

int schet = 1;
int str = 0;
int column = 0;
char krestik = 'x';
char nolik = 'o';
bool win = false;

for (int i = 1; i < 6; i++)                                                 //// Главное тело игры
{
    Console.WriteLine("Введите координаты крестика строка через пробел столбец");
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
    Console.WriteLine("Введите координаты нолика строка через пробел столбец");
    ShowField();
    proverka(field);
    field[str, column] = nolik;
    Console.Clear();
    pobeda(field, ref schet);
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
    if (schet == 9)
    {

        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (field[i, j] == ' ')
                {
                    field[i, j] = 'x';
                    schet = 10;
                }
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
        if (schet == 10)
        {
            Console.WriteLine("Победили крестики");
            return;
        }
        else
        {
            Console.WriteLine(field[str, column] == 'x' ? "Победили крестики" : "Победили Нолики");
            return;
        }
    }
    else if (schet == 10)
    {
        Console.WriteLine("Ничья");
        return;

    }
}

void proverka(char[,] field)                                                //// Проверка на координаты и пустая клеточка или занята
{
    char whi = 'n';
    Coordinate(ref str, ref column);
    if (str > 3 || str < 1)
    {
        Console.WriteLine("Введите координаты (1-3) строка через пробел столбец");
        Coordinate(ref str, ref column);
    }
    if (column > 3 || column < 1)
    {
        Console.WriteLine("Введите координаты (1-3) строка через пробел столбец");
        Coordinate(ref str, ref column);
    }
    while (whi == 'n')
    {
        if (field[str, column] == ' ')
        {
            whi = 'y';
        }
        else
        {
            Coordinate(ref str, ref column);
        }
    }

}
/////////////////////////////////////////////
// В консоль вводятся два числа. В обоих числах есть одна общая цифра. 
// Выведите в консоль цифру, которая есть в обоих числах через пробел столько раз, сколько раз она встречается в первом числе.

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
// Console.Write("Введите число");
// int oneNum = InputInt(Console.ReadLine());
// Console.Write("Введите число");
// int twoNum = InputInt(Console.ReadLine());
// string oneNumStr = Convert.ToString(oneNum);
// string twoNumStr = Convert.ToString(twoNum);
// int oneNumLength = oneNumStr.Length;
// int twoNumLength = oneNumStr.Length;
// for (int i = 0; i < oneNumLength; i++)
// {
//     for (int j = 0; j < twoNumLength; j++)
//     {
//         if(oneNumStr[i] == twoNumStr[j])
//         {
//             Console.Write($"{oneNumStr[i]} ");
//             twoNumStr = twoNumStr.Remove(j, 1);
//             twoNumLength= twoNumLength-1;
//         }

//     }
// }


// int count = 0;
// while (number>1)
// {
//     if (number % 2 == 0)
//     {
//         number = number/2;
//     }
//     else
//     {
//         number = number*3 + 1;
//     }
//     count++;
// }
// Console.WriteLine($"Количество необходимых действий над числом - {count}");
