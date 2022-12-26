
namespace LeftRectangleMethod;

public class LeftRectangleMethod
{
    private readonly double _n;
    private readonly double _a;
    private readonly double _b;
    private readonly double _eps;
    private readonly double _hMin;
    private int _ier=0;
    private double _resultIntegral;
    private double _resultError;
    private double _resultH;
    public LeftRectangleMethod(double n,double a,double b,double eps,double hMin)
    {
        this._n = n;
        this._a = a;
        this._b = b;
        this._eps = eps;
        this._hMin = hMin;
        StartTask();
    }
    /// <summary>
    /// Integrated Function
    /// </summary>
    private double Func(double x)
    {
        return Math.Pow(x,2);
    }
    private double CalcH(double n)
    {
        return (_b - _a) / n;
    }
    /// <summary>
    /// Calc Integral
    /// </summary>
    private double CalcIntegral(double n)
    {
        double sum=0;
        var h = (_b - _a) / n;
        for (int i = 0; i <n; i++)
        {
            var x = _a + i * h;
            var fx = Func(x);
            sum += fx;
        }
        return sum * h;
    } 
    /// <summary>
    /// Calc Integral And Error
    /// </summary>
    private void Solve()
{
    double newN = _n;
    double s1=CalcIntegral(_n);
    double s2=0;
    var newEps = CalcInaccuracy(s1, s2);
    
         while (CalcInaccuracy(s2,s1)>_eps)
         {
             var bufH = CalcH(newN);
             if (bufH < _hMin)
             {
                 _ier = 2;
                 _resultH = bufH;
                 break;
             }
             var oldEps = newEps;
             newN *= 2;
             s2 = s1;
             s1 = CalcIntegral(newN);
             newEps = CalcInaccuracy(s2, s1);
             if (oldEps<=newEps)
             {
                 _ier = 1;
                 break;
             }
         }
         if (_ier != 0) return;
         _resultIntegral = s2;
         _ier = 0;
         _resultH = CalcH(newN / 2);
         _resultError = CalcInaccuracy(s1, s2);

}
/// <summary>
/// Calc error on Runge rule
/// </summary>
private double CalcInaccuracy(double firstIntegral,double secondIntegral)
{
    return Math.Abs((firstIntegral - secondIntegral) / (0.5));
}

/// <summary>
/// Start Solving
/// </summary>
private void StartTask()
{
    Solve();
    switch (this._ier)
    {
        case 1:
            Console.WriteLine($"IER={_ier}");
            break;
        case 0:
            Console.WriteLine($"Integral:{_resultIntegral}");
            Console.WriteLine($"Eps:{_resultError}");
            Console.WriteLine($"H:{_resultH}");
            break;
        case 2:
            Console.WriteLine($"IER:{_ier}");
            Console.WriteLine($"H:{_resultH}");
            break;
    }
}
}