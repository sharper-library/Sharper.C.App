using System;
using System.Runtime.CompilerServices;

namespace Sharper.C.Control
{
    public delegate AppValue<A, S, W> App<R, W, S, A>(
        R r,
        S s,
        Func<W, W, W> op,
        W id);

    public static class App
    {
        public static App<R, W, S, B> Map<R, W, S, A, B>(
            this App<R, W, S, A> app,
            Func<A, B> f)
            => (r, s, o, id) => app(r, s, o, id).Map(f);

        public static App<R, W, S, B> FlatMap<R, W, S, A, B>(
            this App<R, W, S, A> app,
            Func<A, App<R, W, S, B>> f)
            => (r, s, o, id) =>
            {
                var x = app(r, s, o, id);
                var y = f(x.Value)(r, x.State, o, id);
                return AppValue.Mk(y.Value, y.State, o(x.Accum, y.Accum));
            };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static App<R, W, S, B> Select<R, W, S, A, B>(
            this App<R, W, S, A> app,
            Func<A, B> f)
            => Map(app, f);

        public static App<R, W, S, C> SelectMany<R, W, S, A, B, C>(
            this App<R, W, S, A> app,
            Func<A, App<R, W, S, B>> f,
            Func<A, B, C> g)
            => FlatMap(app, a => f(a).Map(b => g(a, b)));
    }
}