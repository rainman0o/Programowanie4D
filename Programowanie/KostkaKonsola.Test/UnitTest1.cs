using Kosc;

namespace KostkaKonsola.Test
{
    public class KostkaUnitTests
    {
        [Fact]
        public void ThrowDice_DrawingNumbers_IsInRange()
        { 
           Kostka kostka = new Kostka();

           kostka.ThrowDice();

           Assert.InRange(kostka.throwResult, 1, 6);
        }

        [Fact]
        public void ThrowDice_SkipResoultIfNotAvalible()
        {
            Kostka kostka = new Kostka();
            kostka.throwResult = 1;
            kostka.isDiceAvalible = false;

            kostka.ThrowDice();

            Assert.Equal(1, kostka.throwResult);
        }
    }
}
