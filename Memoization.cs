using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Youtube
{
    public static class utils
    {
        public static Func<Arg, Ret> Momoize<Arg,Ret>( this Func <Arg,Ret> functor)
        {
            var memo_table = new ConcurrentDictionary<Arg, Ret>();

            return (arg0) =>
                {
                Ret func_return_val;
                if (!memo_table.TryGetValue(arg0, out func_return_val))
                {
                    func_return_val = functor(arg0);
                    memo_table.TryAdd(arg0, func_return_val);
                }
                return func_return_val;
                };
        }

    }
}
