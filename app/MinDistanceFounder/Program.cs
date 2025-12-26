// Начало разработки

string fileName = " ";
Console.WriteLine("Введите название файла");
fileName = Console.ReadLine();

double fuelConsumption;
Console.WriteLine("Введите расход топлива в литрах на 100км пути");
fuelConsumption =  double.Parse( Console.ReadLine() );

double[] vertexes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
double[] lines = { 0.94, 0.66, 1.04, 0.77, 1.92, 1.7, 1.52, 0.86, 1.54, 0.53, 1.2, 1.88};

double[,] mapGraph = {

    {0,      0.94,   10000,     10000,     10000,     10000,     1.88,   10000,     10000,     10000},
    {0.94,   0,      0.66,   10000,     10000,     10000,     1.2,    10000,     10000,     10000},
    {10000,     0.66,   0,      1.04,   10000,     1.7,    10000,     10000,     10000,     10000},
    {10000,     10000,     1.04,   0,       10000,    0.77,   10000,     10000,    10000,      10000},
    {10000,     10000,     10000,     10000,       0,    1.92,   10000,     10000,     10000,     10000},
    {10000,     10000,     1.7,    0.77,    1.92,  0,      10000,     10000,     10000,     1.52},
    {1.88,   1.2,    10000,     10000,       10000, 10000,      0,      0.53,   10000,     10000},
    {10000,     10000,     10000,     10000,       10000,   10000,      0.53,  0,       1.54,  10000},
    {10000,     10000,     10000,     10000,       10000,   10000,      10000,    1.54,       0,  0.86},
    {10000,     10000,     10000,     10000,       10000,   1.52,      10000,  10000,       0.86,  0}
};

int n = 10;

while (true)
{
    string input;
    bool isValild = false;
    int firstPoint;
    int secondPoint;

    double[,] shortWays = Floyd(mapGraph);


    Console.WriteLine("Введите первую точку");

    do
    {
        input = Console.ReadLine();
        if (input == "#")
        {
            return 0;
        }
        isValild = int.TryParse(input, out firstPoint);
        if (!isValild)
            Console.WriteLine("Неверный ввод. Повторите попытку");
    }
    while (!isValild);
    isValild = false;


    Console.WriteLine("Введите первую точку");

    do
    {
        input = Console.ReadLine();
        if (input == "#")
        {
            return 0;
        }
        isValild = int.TryParse(input, out secondPoint);
        if (!isValild)
            Console.WriteLine("Неверный ввод. Повторите попытку");
    }
    while (!isValild);
    isValild = false;


    double result = shortWays[firstPoint - 1, secondPoint - 1];
    Console.WriteLine("Кратчайший путь между точками: " + result);
    Console.WriteLine("Расход топлива: " + result * (fuelConsumption / 100) + " литров");
}


//Функция для нахождения кратчайших путей
double[,] Floyd(double[,] a)
{
    double[,] d = new double[n, n];
    d = (double[,])a.Clone();
    for (int i = 1; i <= n; i++)
        for (int j = 0; j <= n - 1; j++)
            for (int k = 0; k <= n - 1; k++)
                if (d[j, k] > d[j, i - 1] + d[i - 1, k])
                    d[j, k] = d[j, i - 1] + d[i - 1, k];
    return d;
}