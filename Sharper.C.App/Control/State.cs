using System;

namespace Sharper.C.Control
{
    public delegate AppValue<A, S, Unit> State<S, A>(
        Unit _,
        S s,
        Func<Unit, Unit, Unit> __ = null,
        Unit ___ = default(Unit));

    public static class State
    {
        public static App<R, W, S, S> Get<R, W, S>()
            => (_, s, __, id) => AppValue.Mk(s, s, id);

        public static App<R, W, S, A> Gets<R, W, S, A>(Func<S, A> f)
            => (_, s, __, id) => AppValue.Mk(f(s), s, id);

        public static App<R, W, S, Unit> Put<R, W, S>(S s)
            => (_, __, ___, id) => AppValue.Mk(default(Unit), s, id);

        public static App<R, W, S, Unit> Modify<R, W, S>(Func<S, S> f)
            => (_, s, __, id) => AppValue.Mk(default(Unit), f(s), id);
    }
}