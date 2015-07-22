using System;

namespace Sharper.C.Control
{
    public delegate AppValue<A, Unit, W> Writer<W, A>(
        Unit _,
        Unit __,
        Func<W, W, W> op,
        W id);

    public static class Writer
    {
        public static App<R, W, S, Unit> Tell<R, W, S>(W w)
            => (_, s, __, ___) => AppValue.Mk(default(Unit), s, w);
    }
}