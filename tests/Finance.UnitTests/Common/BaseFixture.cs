using Bogus;

namespace Finance.UnitTests.Common
{
    public abstract class BaseFixture
    {
        public Faker Faker { get; set; }

        protected BaseFixture()
            => Faker = new Faker("pt_BR");

        public bool GetRandomBoolean()
            => new Random().NextDouble() < 0.5;

        public long GetRandomLong()
            => new Random().NextInt64();
    }
}