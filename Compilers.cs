using System.Collections;

// public static class Compilers
// {
//     public static void PrimeCompile(string s)
//     {
//         var length = s.Length;
//         bool IsExpression(string result, int i)
//         {
//             if (length >= result.Length + i)
//             {
//                 return Substring 
//             }
//         }
//         for (int i = 0; i < length - 5; i++)
//         {
            
//         }
//     }
//     // public static BitArray Bitcode(BitArray bitArray, string s)
//     // {
//     //     var cursor = 0;
//     //     var end = false;
//     //     void Read(char c)
//     //     {
//     //         switch (c)
//     //         {
//     //             case '>':
//     //             if (cursor != bitArray.Length - 1)
//     //             {
//     //                 cursor++;
//     //                 break;
//     //             }
//     //             end = true;
//     //             return;
//     //             case '<':
//     //             if (cursor != 0)
//     //             {
//     //                 cursor--;
//     //                 break;
//     //             }
//     //             end = true;
//     //             return;
//     //         }
// }


// public class ThueInstruction
// {
//     internal ThueInstruction(SymbolTree tree, string input)
//     {
//         Tree = tree;
//         Input = input;
//     }
//     internal SymbolTree? Search()
//     {
//         var symbolTrees = Tree.Trees;
//         if (symbolTrees == null)
//         {
//             return null;
//         }
//         for (int i = 0; i < Input.Length - 1; i++)
//         {
//             symbolTrees.RemoveAll((SymbolTree tree) => { return tree[Input[i]] != null; });
//         }
//         return symbolTrees[0];
//     }
//     internal SymbolTree Tree { get; }
//     public string Input { get; }
// }