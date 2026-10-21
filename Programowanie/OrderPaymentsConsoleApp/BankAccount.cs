namespace OrderPaymentsConsoleApp;

// Konto nie wykonuje operacji na konsoli ani nie korzysta z bazy danych.
// Kwoty są wyrażone w złotych i mają typ decimal.
public class BankAccount : IAccount
{
    // Scenariusze do testów:
    // 1. Po utworzeniu konta z saldem 100m właściwość Balance zwraca 100m.
    // 2. Po wpłacie lub udanej wypłacie Balance zwraca nowe saldo.
    // 3. Po odrzuconej operacji Balance nadal zwraca wcześniejsze saldo.
    public decimal Balance { get; private set; }

    /*
     * Scenariusze do testów konstruktora:
     * 1. Przygotowanie: saldo początkowe 100m.
     *    Wykonanie: utwórz konto. Sprawdzenie: Balance wynosi 100m.
     * 2. Przygotowanie: saldo początkowe 0m.
     *    Wykonanie: utwórz konto. Sprawdzenie: Balance wynosi 0m.
     * 3. Przygotowanie: saldo początkowe -1m.
     *    Wykonanie: spróbuj utworzyć konto i przechwyć wyjątek.
     *    Sprawdzenie: ArgumentOutOfRangeException, ParamName = "initialBalance".
     */
    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialBalance),
                "Saldo początkowe nie może być ujemne.");
        }

        Balance = initialBalance;
    }

    /*
     * Scenariusze do testów Deposit (każdy w osobnym teście):
     * 1. Przygotowanie: konto z saldem 100m.
     *    Wykonanie: Deposit(50m). Sprawdzenie: saldo wynosi 150m.
     * 2. Przygotowanie: konto z saldem 0m.
     *    Wykonanie: Deposit(0.50m). Sprawdzenie: saldo wynosi 0.50m.
     * 3. Przygotowanie: konto z saldem 100m i kwota 0m lub -10m.
     *    Wykonanie: wywołaj Deposit i przechwyć wyjątek.
     *    Sprawdzenie: ArgumentOutOfRangeException, ParamName = "amount",
     *    saldo nadal wynosi 100m. Sprawdź osobno zero i liczbę ujemną.
     */
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Kwota wpłaty musi być dodatnia.");
        }

        Balance += amount;
    }

    /*
     * Scenariusze do testów TryWithdraw:
     * 1. Przygotowanie: konto z saldem 100m.
     *    Wykonanie: zapisz wynik TryWithdraw(40m).
     *    Sprawdzenie: wynik true, saldo 60m.
     * 2. Przygotowanie: konto z saldem 100m.
     *    Wykonanie: zapisz wynik TryWithdraw(100m).
     *    Sprawdzenie: wynik true, saldo 0m (przypadek graniczny).
     * 3. Przygotowanie: konto z saldem 100m.
     *    Wykonanie: zapisz wynik TryWithdraw(120m).
     *    Sprawdzenie: wynik false, saldo nadal 100m.
     * 4. Przygotowanie: konto z saldem 0m.
     *    Wykonanie: zapisz wynik TryWithdraw(1m).
     *    Sprawdzenie: wynik false, saldo nadal 0m.
     * 5. Przygotowanie: konto z saldem 100m i kwota 0m lub -10m.
     *    Wykonanie: wywołaj TryWithdraw i przechwyć wyjątek.
     *    Sprawdzenie: ArgumentOutOfRangeException, ParamName = "amount",
     *    saldo nadal 100m. Sprawdź osobno zero i liczbę ujemną.
     */
    public bool TryWithdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Kwota wypłaty musi być dodatnia.");
        }

        if (amount > Balance)
        {
            return false;
        }

        Balance -= amount;
        return true;
    }
}
