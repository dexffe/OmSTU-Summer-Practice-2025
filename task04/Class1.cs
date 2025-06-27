namespace task04;

public interface ISpaceship
{
    void MoveForward();     
    void Rotate(int angle); 
    void Fire();           
    int Speed { get; }      
    int FirePower { get; }   
}

public class Fighter : ISpaceship
{
    public void MoveForward() => Console.WriteLine("Истребитель: Движение впред");

    public void Rotate(int angel) =>Console.WriteLine("Истребитель: Поворот на угол (градусы) " + angel);

    public void Fire() =>Console.WriteLine("Истребитель: Выстрел ракетой (слабый)");

    public int Speed { get;  } = 100;
    public int FirePower { get; } = 1;
}


public class Cruiser : ISpaceship
{
    public void MoveForward() => Console.WriteLine("Крейсер: Движение впред");

    public void Rotate(int angel) =>Console.WriteLine("Крейсер: Поворот на угол (градусы) " + angel);

    public void Fire() =>Console.WriteLine("Крейсер: Выстрел ракетой (сильный)");

    public int Speed { get;  } = 50;
    public int FirePower { get; } = 100;
}
