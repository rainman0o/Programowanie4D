namespace OrderPaymentsConsoleApp;

// Serwis płatności zna ten interfejs, a nie konkretną klasę BankAccount.
// Na co dzień otrzymuje prawdziwe konto, a w testach może otrzymać mok.
public interface IAccount
{
    // Kwota musi być dodatnia. Niepoprawna kwota powoduje
    // ArgumentOutOfRangeException.
    void Deposit(decimal amount);

    // Kwota musi być dodatnia. Niepoprawna kwota powoduje
    // ArgumentOutOfRangeException. Brak środków oznacza false.
    bool TryWithdraw(decimal amount);
}
