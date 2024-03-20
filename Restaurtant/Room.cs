namespace Restaurtant
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<int> RemainingSpace { get; set; }
        public string Description { get; set; }
    
        public virtual Booking Booking { get; set; }
        public virtual User User { get; set; }
    }
}
