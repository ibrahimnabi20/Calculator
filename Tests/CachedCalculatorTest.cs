using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Substract()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;
        
        //Act
        var result = calc.Subtract(a, b);
        
        //Result
        Assert.That(result, Is.EqualTo(-1));
    }
    
    [Test]
    public void Multiply()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;
        
        //Act
        var result = calc.Multiply(a, b);
        
        //Assert 
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void Divide()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 4;
        var b = 2;
        
        //Act
        var result = calc.Divide(a, b);
        
        //Assert
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void FactorialNegativeArgumentException()
    {
        //Arrange
        var calc = new CachedCalculator();
        var n = -1;
        
        //Act, Assert
        Assert.Throws<ArgumentException>( () => calc.Factorial(n));
    }

    [Test]
    public void FactorialPositiveArgument()
    {
        //Arrange
        var calc = new CachedCalculator();
        var n = 5;
        
        //Act
        var result = calc.Factorial(n);
        
        //Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void FactorialArugmentIsZero()
    {
        //Arrange
        var calc = new CachedCalculator();
        var n = 0;
        
        //Act
        var result = calc.Factorial(n);
        
        //Assert
        Assert.That(result, Is.EqualTo(1));
    }
    
    [Test]
    public void IsPrimeLessThanTwo()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 1;
        
        //Act
        var result = calc.IsPrime(a);
        
        //Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsPrimeTrue()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 7;
        
        //Act
        var result = calc.IsPrime(a);
        
        //Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPrimeFalse()
    {
        //Arrange
        var calc = new CachedCalculator();
        var a = 8;
        
        //Act
        var result = calc.IsPrime(a);
        
        //Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void Add_ShouldUseCache()
    {
        // Arrange
        var calculator = new CachedCalculator();

        // Act
        int saveToCache1st = calculator.Add(2, 3);
        int saveToCache2nd = calculator.Add(2, 3);

        //Assert
        Assert.That(calculator._cache, Has.Count.EqualTo(1));
    }

    [Test]
    public void Substract_ShouldUseCache()
    {
        // Arrange
        var calculator = new CachedCalculator();
        
        // Act
        int saveToCache1st = calculator.Subtract(2, 3);
        int saveToCache2nd = calculator.Subtract(2, 3);
        
        // Assert
        Assert.That(calculator._cache, Has.Count.EqualTo(1));
    }

    [Test]
    public void Multiply_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        
        int saveToCache1st = calculator.Multiply(2, 3);
        int saveToCache2nd = calculator.Multiply(2, 3);
        
        Assert.That(calculator._cache, Has.Count.EqualTo(1));
    }

    [Test]
    public void Divide_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        
        int saveToCache1st = calculator.Divide(2, 3);
        int saveToCache2nd = calculator.Divide(2, 3);
        
        Assert.That(calculator._cache, Has.Count.EqualTo(1));
    }

    [Test]
    public void Factorial_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        
        int saveToCache1st = calculator.Factorial(5);
        int saveToCache2nd = calculator.Factorial(5);
        
        Assert.That(calculator._cache, Has.Count.EqualTo(1));
    }

    [Test]
    public void IsPrime_ShouldUseCache()
    {
        var calculator = new CachedCalculator();
        
        bool saveToCache1st = calculator.IsPrime(5);
        bool saveToCache2nd = calculator.IsPrime(5);
        
        Assert.That(calculator._cache, Has.Count.EqualTo(1));
    }
}