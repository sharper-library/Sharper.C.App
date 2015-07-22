using System;

namespace Sharper.C.Control
{
    public sealed class AppValue<A, S, W>
    {
        internal AppValue(A a, S s, W w)
        {
            Value = a;
            State = s;
            Accum = w;
        }

        public A Value { get; }

        public S State { get; }

        public W Accum { get; }

        public AppValue<B, S, W> Map<B>(Func<A, B> f)
            => new AppValue<B, S, W>(f(Value), State, Accum);
    }

    public static class AppValue
    {
        public static AppValue<A, S, W> Mk<A, S, W>(A a, S s, W w)
            => new AppValue<A, S, W>(a, s, w);
    }
}
