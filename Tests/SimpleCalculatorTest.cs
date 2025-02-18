using Calculator;

namespace Tests;

public class SimpleCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
        var n = -1;
        
        //Act, Assert
        Assert.Throws<ArgumentException>( () => calc.Factorial(n));
    }

    [Test]
    public void FactorialPositiveArgument()
    {
        //Arrange
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
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
        var calc = new SimpleCalculator();
        var a = 8;
        
        //Act
        var result = calc.IsPrime(a);
        
        //Assert
        Assert.That(result, Is.False);
    }
}