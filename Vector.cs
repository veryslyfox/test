// #pragma warning disable
// [Flags()]
// enum MyFlags
// {
//     A = 1,
//     B = 2,
//     C = 4,
//     D = 8,
// }
// class Vector
// {
//     public Vector(int[] values)
//     {
//         Values = values;
//     }
//     public int[] Values { get; }
//     public static int operator *(Vector vector1, Vector vector2)
//     {
//         if (vector1.Length != vector2.Length)
//         {
//             throw new VectorMultiplyException("", vector1, vector2);
//         }
//         var accumulator = 0;
//         for (int i = 0; i < vector1.Length; i++)
//         {
//             accumulator += vector1[i] * vector2[i];
//         }
//         return accumulator;
//     }
//     public IEnumerator<int> GetEnumerator()
//     {
//         return (IEnumerator<int>)Values.GetEnumerator();
//     }
//     public int this[int index]
//     {
//         get => Values[index];
//     }
//     public int Length
//     {
//         get => Values.Length;
//     }
// }