using System;
using System.Linq;

class Compare : IComparable<Compare>
{
    public int X { get; set; }
    public int Y { get; set; }
    public int A { get; set; }
    public int B { get; set; }

    public int CompareTo(Compare other)
    {
        return A.CompareTo(other.A);
    }
}

class Program
{
    static int[] dest = new int[205];

    static int Find(int x)
    {
        if (dest[x] == x)
            return x;
        return dest[x] = Find(dest[x]);
    }

    static void Main(string[] args)
    {
        int n, m, A, B;
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        n = input[0];
        m = input[1];
        input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        A = input[0];
        B = input[1];

        Compare[] a = new Compare[50000];
        Compare[] q = new Compare[2000];

        for (int i = 1; i <= m; i++)
        {
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            a[i] = new Compare { X = input[0], Y = input[1], A = input[2], B = input[3] };
        }

        Array.Sort(a, 1, (int)m);

        int ans = int.MaxValue;
        for (int i = 1, t = 0, s; i <= m; i++)
        {
            q[++t] = a[i];
            s = 0;

            for (int j = t - 1; j > 0 && q[j + 1].B < q[j].B; j--)
            {
                var temp = q[j];
                q[j] = q[j + 1];
                q[j + 1] = temp;
            }

            for (int j = 1; j <= n; j++)
                dest[j] = j;

            for (int j = 1, x, y; s < n - 1 && j <= t; j++)
            {
                if ((x = Find(q[j].X)) != (y = Find(q[j].Y)))
                {
                    dest[x] = y;
                    q[++s] = q[j];
                }
            }

            if (s == n - 1)
                ans = Math.Min(ans, A * a[i].A + B * q[s].B);

            t = s;
        }

        if (ans < int.MaxValue)
        {
            Console.WriteLine(ans);
        }
        else
        {
            Console.WriteLine(-1);
        }

        Console.ReadLine();
    }
}