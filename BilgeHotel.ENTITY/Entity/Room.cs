using BilgeHotel.ENTITY.Base;
using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Room : BaseEntity
    {
        public Room()
        {
            RoomAndReservations = new List<RoomAndReservation>();
            RoomAndBeds = new List<RoomAndBed>();
            RoomType = RoomType.StandartSuit;
            RoomStatus = RoomStatus.Available;         
        }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public byte Capacity { get; set; }
        public decimal PricePerNight { get; set; }

        public RoomType RoomType { get; set; }
        public RoomStatus RoomStatus { get; set; }

        public int RoomFeatureID { get; set; }

        //Relational Properties

        public RoomFeature RoomFeature { get; set; }
        public virtual List<RoomAndReservation> RoomAndReservations { get; set; }
        public virtual List<RoomAndBed> RoomAndBeds { get; set; }
        public virtual List<RoomAndImage> RoomImage { get; set; }

    }

}
