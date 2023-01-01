using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace Youtube
{
    public static class FastObjectAllocator<T> where T : new ()
    {
        public static Func<T> mObjectCreator = null;
                 
        static FastObjectAllocator ()
        {

            if (mObjectCreator == null)
            {
                Type objectType = typeof(T);
                ConstructorInfo defaultCtor = objectType.GetConstructor(new Type[] { });

                DynamicMethod dynMethod = new DynamicMethod(
                    name: string.Format("_{0:N}", Guid.NewGuid()),
                    returnType: objectType,
                    parameterTypes: null);
                ILGenerator il = dynMethod.GetILGenerator();
                il.Emit(OpCodes.Newobj, defaultCtor);
                il.Emit(OpCodes.Ret);

                mObjectCreator = dynMethod.CreateDelegate(typeof(Func<T>)) as Func<T>;
            }

        }

        public static T New()
        {
            
            return mObjectCreator();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NewInline()
        {

            return mObjectCreator();

        }
    }
}
