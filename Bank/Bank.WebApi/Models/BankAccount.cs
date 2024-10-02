namespace Bank.WebApi.Models
{
    public class BankAccount
    {
        private readonly string _customerName;
        private double _balance;

        public BankAccount(string customerName, double balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        public string CustomerName => _customerName;
        public double Balance => _balance;

        public void Debit(double amount)
        {
            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Debit amount exceeds balance");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Debit amount is less than zero");
            }

            _balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Credit amount is less than zero");
            }

            _balance += amount;
        }
    }
}
