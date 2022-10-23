
// Задача 19

// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.

// 14212 -> нет

// 12821 -> да

// 23432 -> да

int InputInt(string value)
{
    int number = 0;
    while (!int.TryParse(value, out number))
    {
        Console.Write("Не подходит к требованиЮ введите число: ");
        value = Console.ReadLine();
    }
    return number;
}
void Palindrom(int first, int dlinaNum, int num)
{
    int i = 1;
    while (dlinaNum > i)
    {
        first = (int)((num / Math.Pow(10, (dlinaNum - i))) % 10);
        int last = num % 10;
        Console.Write($"{first}");
        Console.WriteLine($"{last}");
        dlinaNum = dlinaNum - 1;
        i++;
        num = num / 10;
        if (first != last)
        {
            Console.WriteLine("не палиндром");
            return; 
        }
    }
    Console.WriteLine("Палиндром");
}
Console.Write("Введите пятизначное число: ");
int num = InputInt(Console.ReadLine());
int first = 0;
string x = Convert.ToString(num);
int dlinaNum = x.Length;
int i = 1;
if (num > 9)
{
    Palindrom(first, dlinaNum, num);
}
else Console.WriteLine($"не подходит по требованиям");

