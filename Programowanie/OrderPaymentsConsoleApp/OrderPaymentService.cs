namespace OrderPaymentsConsoleApp;

// W testach tej klasy zastępujemy konto mokiem interfejsu IAccount.
// Nie sprawdzamy salda prawdziwego konta: sprawdzamy wynik serwisu
// oraz to, czy i z jakimi argumentami korzysta ze swojej zależności.
public class OrderPaymentService
{
    private readonly IAccount account;

    /*
     * Scenariusze do testów konstruktora:
     * 1. Przygotowanie: mok IAccount.
     *    Wykonanie: utwórz serwis z mokiem.
     *    Sprawdzenie: serwis powstał i nie wywołał żadnej metody konta.
     * 2. Przygotowanie: zależność o wartości null.
     *    Wykonanie: spróbuj utworzyć serwis i przechwyć wyjątek.
     *    Sprawdzenie: ArgumentNullException, ParamName = "account".
     */
    public OrderPaymentService(IAccount account)
    {
        if (account is null)
        {
            throw new ArgumentNullException(nameof(account));
        }

        this.account = account;
    }

    /*
     * Zamówienie musi mieć dodatnią wartość. Bon może pokryć część
     * lub całość zamówienia, ale nie może być ujemny ani większy
     * od wartości zamówienia. Nie ma częściowej płatności z konta.
     *
     * Scenariusze do testów Pay:
     * 1. Przygotowanie: mok zwraca true dla TryWithdraw(70m);
     *    utwórz serwis z mokiem.
     *    Wykonanie: zapisz wynik Pay(100m, 30m).
     *    Sprawdzenie: true; TryWithdraw(70m) wywołano dokładnie raz.
     * 2. Przygotowanie: mok zwraca false dla TryWithdraw(100m);
     *    utwórz serwis z mokiem.
     *    Wykonanie: zapisz wynik Pay(100m, 0m).
     *    Sprawdzenie: false; TryWithdraw(100m) wywołano dokładnie raz.
     * 3. Przygotowanie: mok zwraca true dla TryWithdraw(100m);
     *    utwórz serwis z mokiem.
     *    Wykonanie: zapisz wynik Pay(100m, 0m).
     *    Sprawdzenie: true; TryWithdraw(100m) wywołano dokładnie raz.
     * 4. Przygotowanie: mok konta i serwis.
     *    Wykonanie: zapisz wynik Pay(100m, 100m).
     *    Sprawdzenie: true; nie wywołano żadnej metody konta.
     * 5. Przygotowanie: mok konta i serwis; orderAmount = 0m lub -1m,
     *    voucherAmount = 0m. Sprawdź osobno obie wartości zamówienia.
     *    Wykonanie: wywołaj Pay i przechwyć wyjątek.
     *    Sprawdzenie: ArgumentOutOfRangeException,
     *    ParamName = "orderAmount"; brak wywołań metod konta.
     * 6. Przygotowanie: mok konta i serwis; orderAmount = 100m,
     *    voucherAmount = -1m lub 120m. Sprawdź osobno obie wartości bonu.
     *    Wykonanie: wywołaj Pay i przechwyć wyjątek.
     *    Sprawdzenie: ArgumentOutOfRangeException,
     *    ParamName = "voucherAmount"; brak wywołań metod konta.
     *
     * We wszystkich scenariuszach Pay metoda Deposit nie jest wywoływana.
     */
    public bool Pay(decimal orderAmount, decimal voucherAmount)
    {
        if (orderAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(orderAmount),
                "Wartość zamówienia musi być dodatnia.");
        }

        if (voucherAmount < 0 || voucherAmount > orderAmount)
        {
            throw new ArgumentOutOfRangeException(nameof(voucherAmount),
                "Wartość bonu musi mieścić się od zera do wartości zamówienia.");
        }

        decimal amountToPay = orderAmount - voucherAmount;

        if (amountToPay == 0)
        {
            return true;
        }

        return account.TryWithdraw(amountToPay);
    }

    /*
     * Scenariusze do testów Refund:
     * 1. Przygotowanie: mok konta i serwis.
     *    Wykonanie: Refund(40m).
     *    Sprawdzenie: Deposit(40m) wywołano dokładnie raz,
     *    nie wywołano TryWithdraw.
     * 2. Przygotowanie: mok konta i serwis; kwota 0m lub -10m.
     *    Wykonanie: wywołaj Refund i przechwyć wyjątek.
     *    Sprawdzenie: ArgumentOutOfRangeException, ParamName = "amount";
     *    brak wywołań metod konta. Sprawdź osobno zero i liczbę ujemną.
     */
    public void Refund(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Kwota zwrotu musi być dodatnia.");
        }

        account.Deposit(amount);
    }
}
