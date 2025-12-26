using MinDistanceFounder;

string fileName = " ";
Console.WriteLine("Введите название файла");
Console.WriteLine("Файл должен находиться в папке files текущего проекта");

fileName = Console.ReadLine();
int n = 10;

double fuelConsumption;
Console.WriteLine("Введите расход топлива в литрах на 100км пути");
fuelConsumption =  double.Parse( Console.ReadLine() );


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



while (true)
{

    string input;
    bool isValild = false;
    int firstPoint;
    int secondPoint;

    WaysFounder founder = new WaysFounder();
    double[,] shortWays = founder.Floyd(mapGraph);


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


    double result = founder.DistanceFounder(shortWays, firstPoint, secondPoint);
    Console.WriteLine("Кратчайший путь между точками: " + result + "км");
    Console.WriteLine("Расход топлива: " + result * (fuelConsumption / 100) + " литров");
}

