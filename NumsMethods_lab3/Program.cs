int n = 8;
double[] a = new double[9] { 0, 4, 0, 6, 0, 7, 0, 8,9 }; // Строка верхних элементов
double[] b = new double[8] { 2, 0, 0, 0, 0, 0, 0, 0 }; // Диагональные элементы
double[] c = new double[7] { 1, 0, 0, 0, 0, 0, 0 }; // Столбцовые элементы
double[] d = new double[8]; // Вспомогательная переменная для хранения значений уравнений
double[] x = new double[8]; // Решение матричного уравнения 

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        
    }
}
for (int i = 1; i <= n; ++i)
    d[i] = 1 / b[i];

for (int k = 1; k < n; ++k)
{
    if (a[k + 1] != 0)
        d[k] *= (b[k] - a[k + 1] * d[k + 1]);
    else
        d[k] = 1 / b[k];

    if (c[k] != 0)
        d[n] -= c[k] * d[k];
}

for (int j = n - 1; j >= 0; --j)
{
    x[j] = d[j] * (d[n] - c[j] * x[j + 1]);
}
