using OrderPaymentsConsoleApp;

/*
 * Materiał do nauki testów jednostkowych:
 * 1. BankAccount: wynik metody, zmiana stanu, granice i wyjątki.
 * 2. OrderPaymentService: zależność przekazana przez konstruktor.
 * 3. Mok IAccount: ustawianie wyniku, sprawdzanie argumentów,
 *    liczby wywołań i braku wywołania zależności.
 *
 * Każdy test dzielimy na trzy sekcje:
 * - Arrange (przygotowanie): obiekt, dane i ewentualnie mok zależności.
 * - Act (wykonanie): jedna badana operacja.
 * - Assert (sprawdzenie): wynik, stan, wyjątek lub wywołania zależności.
 * Scenariusze znajdują się nad metodami w plikach klas.
 *
 * Poniżej jest tylko przykład użycia prawdziwych obiektów.
 * Nie jest to zestaw testów jednostkowych.
 */

BankAccount account = new BankAccount(100m);
OrderPaymentService payments = new OrderPaymentService(account);

bool paid = payments.Pay(100m, 30m);
Console.WriteLine($"Płatność za zamówienie: {paid}, saldo: {account.Balance} zł");

bool secondPayment = payments.Pay(50m, 0m);
Console.WriteLine($"Kolejna płatność: {secondPayment}, saldo: {account.Balance} zł");

bool coveredByVoucher = payments.Pay(100m, 100m);
Console.WriteLine($"Płatność pokryta bonem: {coveredByVoucher}, saldo: {account.Balance} zł");

payments.Refund(20m);
Console.WriteLine($"Saldo po zwrocie: {account.Balance} zł");
