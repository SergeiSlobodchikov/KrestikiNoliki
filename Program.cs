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
    if (schet == 9)
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
void x(ref int schet,ref char[,] field)
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
