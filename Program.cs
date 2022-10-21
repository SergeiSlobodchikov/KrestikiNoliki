void Write(string message)
{
    Console.Write(message);
}
void WriteL(string message)
{
    Console.WriteLine(message);
}

Write("Вводим число: ");
string? znak = Console.ReadLine();
int x1 = znak.Length;
bool result = (int.TryParse(znak, out int num));
int first = 0;
int last = 0;
int i = 1;
if (result == true && num > 0)         
{

    while (x1 > i)
    {
        first = (int)((num / Math.Pow(10, (x1 - i))) % 10);
        last = num % 10;
        Write($"{first}");
        WriteL($"{last}");
        x1 = x1 - 1;
        i++;
        num = num / 10;
        if(first==last);
        else
        {
            WriteL("не палиндром");
            return;
        }

    }
     WriteL("Палиндром");



}
else WriteL($"не подходит по требованиям");