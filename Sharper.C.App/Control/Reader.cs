using System;

namespace Sharper.C.Control
{
    public delegate AppValue<A, Unit, Unit> Reader<R, A>(
        R r,
        Unit _ = default(Unit),
        Func<Unit, Unit, Unit> __ = null,
        Unit ___ = default(Unit));

    public static class Reader
    {
        public static App<R, W, S, R> Ask<R, W, S>()
            => (r, s, _, id) => AppValue.Mk(r, s, id);

        public static App<R, W, S, A> Asks<R, W, S, A>(Func<R, A> f)
            => (r, s, _, id) => AppValue.Mk(f(r), s, id);
    }
}