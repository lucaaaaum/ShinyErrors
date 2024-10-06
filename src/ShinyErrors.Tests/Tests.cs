using ShinyErrors.Extensions;

namespace ShinyErrors.Tests;

public class Tests
{
    [Test]
    public void TryDividingTwoWholeNumbers()
    {
        var number1 = 10;
        var number2 = 5;
        var result = Division(number1, number2);
        Assert.That(result.HasError(), Is.False);
        Assert.That(result.Expected, Is.EqualTo(2));
        Assert.That(result.Error, Is.Null);
    }

    [Test]
    public void TryDividingByZero()
    {
        var number1 = 10;
        var number2 = 0;
        var result = Division(number1, number2);
        Assert.That(result.HasError(), Is.True);
        Assert.That(result.Expected, Is.EqualTo(0));
        Assert.That(result.Error, Is.Not.Null);
        Assert.That(result.Error!.Description, Is.EqualTo("Attempted to divide by zero."));
    }

    [Test]
    public void GetEntityWithSucess()
    {
        var database = new MockDatabase();
        var result = database.GetEntityWithSuccess();
        Assert.That(result.HasError, Is.False);
        Assert.That(result.Expected, Is.Not.Null);
        Assert.That(result.Expected!.Id, Is.EqualTo("69"));
        Assert.That(result.Expected!.AnotherCoolField, Is.EqualTo(420));
        Assert.That(result.Error, Is.Null);
    }

    [Test]
    public void GetEntityWithFailure()
    {
        var database = new MockDatabase();
        var result = database.GetEntityWithFailure();
        Assert.That(result.HasError, Is.True);
        Assert.That(result.Expected, Is.Null);
        Assert.That(result.Error, Is.Not.Null);
        Assert.That(result.Error!.Description, Is.EqualTo("something went terribly wrong."));
    }

    public Result<int> Division(int x, int y)
    {
        int result;

        try
        {
            result = (x / y);
            return result.AsSuccessfulResult();
        }
        catch (Exception e)
        {
            return e.Message.AsFaultyResult<int>();
        }
    }

    public class MockDatabase
    {
        public Result<MockEntity> GetEntityWithSuccess() => new MockEntity
        {
            Id = "69",
            AnotherCoolField = 420
        }.AsSuccessfulResult();

        public Result<MockEntity> GetEntityWithFailure() => "something went terribly wrong.".AsFaultyResult<MockEntity>();
    }

    public class MockEntity
    {
        public string Id { get; set; }
        public int AnotherCoolField { get; set; }
    }
}
