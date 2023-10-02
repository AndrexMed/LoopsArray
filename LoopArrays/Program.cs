List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//DoWhile
int i = 0;
do
{
    Console.WriteLine("DoWhile: " + numbers[i]);
    i++;
} while (i < numbers.Count);
//-----------------------------------------------------------------

//While
int j = 0;
while (j < numbers.Count)
{
    Console.WriteLine("While: " + numbers[j]);
    j++;
}
//-----------------------------------------------------------------

//For tradicional
for (int k = 0; k < numbers.Count; k++)
{
    Console.WriteLine("For Tradicional: " + numbers[k]);
}
//-----------------------------------------------------------------

//foreach
foreach (var item in numbers)
{
    Console.WriteLine("foreach: " + item);
}
//-----------------------------------------------------------------

//foreach con posicion y valor
foreach (var item in numbers.Select((num, index) => new { index, num }))
{
    Console.WriteLine("ForEach con Posicion y valor: " + item.index + " " + item.num);
}
//-----------------------------------------------------------------

//Metodo foreach
numbers.ForEach((num) => Console.WriteLine("Foreach one-Line: " + num));
//-----------------------------------------------------------------

//Recursividad
static void Show(List<int> list, int i = 0)
{
    if (i < list.Count)
    {
        Console.WriteLine("Recursividad: " + list[i++]);
        Show(list, i);
    }
    else
    {
        return;
    }
}
Show(numbers);
//-----------------------------------------------------------------

//Goto - no recomendado
int x = 0;
Again:
Console.WriteLine("goto: "+numbers[x]);
x++;
if (x < numbers.Count)
    goto Again;
//-----------------------------------------------------------------

//Paralell.ForEach - Lee en desorden
Parallel.ForEach(numbers, (num) =>
{
    Console.WriteLine("Paralell: "+num);
});
//-----------------------------------------------------------------

//Lambda
int y = 0;
Action fn = null;
fn = () =>
{
    if (y < numbers.Count)
    {
        Console.WriteLine("Lambda: "+numbers[y]);
        y++;
        fn();
    }
};
fn();
//-----------------------------------------------------------------

//Closure
static Action Show2(List<int> list)
{
    int y = 0;
    Action fn = null;
    fn = () =>
    {
        if (y < list.Count)
        {
            Console.WriteLine("Closure: " + list[y]);
            y++;
            fn();
        }
    };
    fn();

    return fn;
}

Action executor = Show2(numbers);
executor();