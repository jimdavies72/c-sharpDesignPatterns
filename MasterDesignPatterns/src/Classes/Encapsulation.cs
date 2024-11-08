//Encapsulation

namespace MasterDesignPatterns.src.Classes
{
  public class BadBankAccount
  {
    public decimal balance;
  }

  public class BankAccount
  {
    private decimal balance;

    public BankAccount(decimal initialBalance)
    {
      Deposit(initialBalance);
    }

    public decimal GetBalance()
    {
      return balance;
    }

    public void Deposit(decimal amount)
    {
      if (amount <= 0)
      {
        throw new System.ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
      }

      balance += amount;
    }

    public void Withdraw(decimal amount)
    {
      if (amount <= 0)
      {
        throw new System.ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
      }

      if (amount > balance)
      {
        throw new System.ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount cannot exceed account balance");
      }

      balance -= amount;
    }
  }
}