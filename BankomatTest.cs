using banko;
using Xunit;

public class BankomatTest
{
  [Fact]
  public void TestInsertCard()
  {
    // Arrange - variables, classes, mocks
    Bankomat bankomat = new();
    Account account = new();
    Card card = new(account);

    // Act
    bool result = bankomat.insertCard(card);

    // Assert
    Assert.True(result);
  }

  [Fact]
  public void TestEnterPin()
  {
    // Arrange - variables, classes, mocks
    Bankomat bankomat = new();
    Account account = new();
    Card card = new(account);
    bankomat.insertCard(card);

    // Act correct pin
    bool result = bankomat.enterPin("0123");
    // Assert
    Assert.True(result);

    // Act incorrect pin
    result = bankomat.enterPin("1234");
    // Assert
    Assert.False(result);

  }

  [Fact]
  public void TestMachineBalance()
  {
    // Arrange - variables, classes, mocks
    Bankomat bankomat = new();

    // Act
    int balance = bankomat.GetMachineBalance();

    // Assert
    Assert.Equal(11000, balance);
  }

  [Theory]
  [InlineData(15000, 5000, 20000)]
  [InlineData(20000, 1000, 21000)]
  [InlineData(20000, 0, 20000)]
  [InlineData(20000, -1000, 19000)]
  public void TheoryTestMachineBalance(int initialBalance, int amount, int expectedBalance)
  {
    // Arrange - variables, classes, mocks
    Bankomat bankomat = new();

    // Act
    bankomat.AddToMachineBalance(amount);
    int actualBalance = bankomat.GetMachineBalance();

    // Assert
    Assert.Equal(expectedBalance, actualBalance);
  }


}