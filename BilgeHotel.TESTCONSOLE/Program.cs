using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.COMMON.Tools;
using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BilgeHotel.TESTCONSOLE
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReservationRepository resRep = new ReservationRepository();
            RoomAndReservationRepository rrRep = new RoomAndReservationRepository();
            RoomRepository roomRep = new RoomRepository();
            //Console.WriteLine(EmailCreator.CreateEmail("İerhan", "zörlü"));
            //Console.ReadLine();


            //ExtraShiftRepository rep = new ExtraShiftRepository();

            //ExtraShift yeni = new ExtraShift
            //{
            //    ID = 2,
            //    ExtraShiftDate = DateTime.Now.Date,
            //    HowManyHours = 3,
            //    ShiftWagePerHour = 50,
            //    TotalWage = 150

            //};


            //ExtraShift eski = rep.Find(yeni.ID);


            //Console.WriteLine("ESKİ");
            //Console.WriteLine(eski.ShiftWagePerHour);
            //Console.WriteLine(eski.HowManyHours);
            //Console.WriteLine(eski.TotalWage);


            //rep.Update(yeni);

            //Console.WriteLine("--------------------------------");

            //Console.WriteLine("YENİ DEĞERLER");
            //Console.WriteLine(eski.ShiftWagePerHour);
            //Console.WriteLine(eski.HowManyHours);
            //Console.WriteLine(eski.TotalWage);

            //TimeSpan span1 = new TimeSpan(5, 25, 0);
            //TimeSpan span2 = new TimeSpan(1, 10, 0);
            //TimeSpan span3 = TimeSpan.FromDays(1);


            //Console.WriteLine("TimeSpan1 = " + span1);
            //Console.WriteLine("TimeSpan2 = " + span2);
            //Console.WriteLine("TimeSpan3 = " + span3);

            //Timer timer = new Timer(2000); // 2 saniye aralığında tekrarlanacak timer oluşturuldu
            //timer.Elapsed += Timer_Elapsed; // Timer.Elapsed olayına bir olay işleyici ekleniyor
            //timer.Start(); // Timer başlatılıyor

            //Console.WriteLine("Timer başladı. Çıkmak için bir tuşa basın.");
            //Console.ReadKey();


            //void Timer_Elapsed(object sender, ElapsedEventArgs e)
            //{
            //    Console.WriteLine("Timer tetiklendi: " + DateTime.Now);
            //}


            //Console.WriteLine("Başladım");

            //Timer timer = new Timer(5000);
            //timer.Start();

            //Console.WriteLine("Beş saniye geçti");
            //timer.Stop();

            //Console.ReadLine();


            //Timer timer1 = new Timer
            //{
            //    Interval = 2000
            //};
            //timer1.Enabled = true;

            //var password = PasswordCryptographer.Crypt("bebekuş");
            //Console.WriteLine(password);
            //Console.ReadKey();


            //var liste = resRep.GetOnlineReservations(DateTime.Today.AddMonths(1).AddHours(14), DateTime.Today.AddMonths(1).AddDays(1).AddHours(10));
            ////var liste = resRep.GetOnlineReservations(DateTime.Today, DateTime.Today.AddDays(1));


            //var idler = resRep.GetReservationIDs(liste);

            //var odaIdler = rrRep.FindReservedRoomIDs(idler);

            //List<Room> rezervasyonaUygunOdalar = roomRep.GetRoomsForReservation(odaIdler, 1);

            ////var odaIdleri = rrRep.FindReservedRoomIDs(idler);
            //int sayac = 0;
            //foreach (var item in rezervasyonaUygunOdalar)
            //{
            //    sayac++;
            //    Console.WriteLine(item.ID + "------------"+ item.FloorNumber + "-------------" +item.Capacity);
            //    Console.WriteLine("***************************");
            //}

            //Console.WriteLine(sayac);

            //Console.ReadLine();

            //foreach (var item in idler)
            //{
            //    Console.WriteLine(item);
            //}


            


            //DateTime checkIn = DateTime.Now;
            //DateTime checkOut = DateTime.Now;
            ////deneme.AddHours(4);

            //SetTimes(checkIn, checkOut);

            //Console.WriteLine(checkIn);
            //Console.WriteLine(checkOut);
            //Console.ReadLine();



        }

        static void SetTimes(DateTime checkIn, DateTime checkOut)
        {
            checkIn = checkIn.AddHours(1);
            checkOut = checkOut.AddHours(2);
        }
    }
}
