// #pragma warning disable
// class Curier  
// {
//     public Curier()
//     {
//         CurierPublicator = new CurierPublicator(this);
//     }
//     private object Info { get; set; }
//     public DHSender Sender { get; private set; }
//     private IClaimer Target { get; }
//     public bool TrySetInfo(DHSender sender, Order order)
//     {
//         var equals = Sender == sender;
//         if (equals)
//         {
//             Info = sender[order];
//         }
//         return equals;
//     }
//     public object? TryGetInfo(DHSender sender, Order order)
//     {
//         var equals = Sender == sender;
//         if (equals)
//         {
//             Info = sender[order];
//         }
//         return equals;
        
//     }
//     public void Add()
//     {
//     } 
//     private CurierPublicator CurierPublicator { get; }
//     public Order Order { get; private set; }
// }
// class CurierPublicator : IEquatable<CurierPublicator>
// {
//     public IClaimer Publicate { get; private set; }
//     public Curier Curier { get; }

//     public bool CompareClients(IClaimer claimer)
//     {
//         return Publicate == claimer;
//     }

//     public bool Equals(CurierPublicator? other)
//     {
//         return !(this is null && other is { }) &&
//             !(this is { } && other is null) &&
//             (this is { } && other is { }) ||
//             (this is null && other is null) &&
//             other.Curier == Curier &&
//             other.Publicate == Publicate;
//     }

//     public CurierPublicator(Curier curier, IClaimer publicate = null)
//     {
//         Curier = curier;
//         Publicate = publicate;
//     }
// }
