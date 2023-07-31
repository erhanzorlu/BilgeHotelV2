using BilgeHotel.COMMON.Tools;
using BilgeHotel.DAL.Context;
using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Data;
using System.Security.Cryptography;


namespace BilgeHotel.DAL.Init
{
    public class MyInit : CreateDatabaseIfNotExists<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            base.Seed(context);

            #region HotelInfo
            HotelInfo hi = new HotelInfo()
            {
                Name = "Bilge Hotel",
                Description = "Bilge Hotel, 44 kişilik uzman çalışan kadrosu ve 77 adet odasıyla 7/24 hizmet veren 5 yıldızlı bir oteldir.",
                Address = "Kemer/Antalya."

            };
            context.HotelInfos.Add(hi);
            context.SaveChanges();
            #endregion

            #region Campaigns

            Campaign c1 = new Campaign()
            {
                DiscountPercentage = 0.18M,
            };

            Campaign c2 = new Campaign()
            {
                DiscountPercentage = 0.16M
            };

            Campaign c3 = new Campaign()
            {
                DiscountPercentage = 0.23M
            };
            context.Campaigns.Add(c1);
            context.Campaigns.Add(c2);
            context.Campaigns.Add(c3);
            context.SaveChanges();
            //gecelik*kaçgün*(1-discount);
            #endregion

            #region Shifts

            Shift s1 = new Shift()
            {
                ShiftInterval = "08:00 - 16:00",
                DailyWorkingHour = 8
            };
           
            
            Shift s2 = new Shift()
            {
                ShiftInterval = "16:00 - 00:00",
                DailyWorkingHour = 8
            };
            Shift s3 = new Shift()
            {
                ShiftInterval = "00:00 - 08:00",
                DailyWorkingHour = 8

            };
            Shift s4 = new Shift()
            {
                ShiftInterval = "08:00 - 18:00",
                DailyWorkingHour = 10
            };
            context.Shifts.Add(s1);
            context.Shifts.Add(s2);
            context.Shifts.Add(s3);
            context.Shifts.Add(s4);
            context.SaveChanges();
            #endregion

            #region Jobs
            Job job = new Job()
            {
                Name = "Otel Sahibi"
            };

            Job job2 = new Job()
            {
                Name = "İnsan Kaynakları Müdürü"
            };

            Job job3 = new Job()
            {
                Name = "Satış Müdürü"
            };

            Job job4 = new Job()
            {
                Name = "Resepsiyon Şefi"
            };

            Job job6 = new Job()
            {
                Name = "Resepsiyonist"
            };

            Job job7 = new Job()
            {
                Name = "Muhasebeci"
            };
            Job job8 = new Job()
            {
                Name = "Temizlikçi"
            };
            Job job9 = new Job()
            {
                Name = "Aşçı"
            };
            Job job10 = new Job()
            {
                Name = "Garson"
            };
            Job job11 = new Job()
            {
                Name = "Elektrikçi"
            };
            Job job12 = new Job()
            {
                Name = "IT Sorumlusu"
            };

            context.Jobs.Add(job);
            context.Jobs.Add(job2);
            context.Jobs.Add(job3);
            context.Jobs.Add(job4);
           
            context.Jobs.Add(job6);
            context.Jobs.Add(job7);
            context.Jobs.Add(job8);
            context.Jobs.Add(job9);
            context.Jobs.Add(job10);
            context.Jobs.Add(job11);
            context.Jobs.Add(job12);
            context.SaveChanges();
            #endregion

            #region Employees

            Employee owner = new Employee();
            owner.FirstName = "Sakıp";
            owner.LastName = "Bilge";
            owner.Password = PasswordCryptographer.Crypt("123456");
            owner.JobID = 1;
            owner.Email = EmailCreator.CreateEmail(owner.FirstName, owner.LastName);
            owner.Salary = 14000;

            context.Employees.Add(owner);

            Employee hr = new Employee();

            hr.FirstName = "Selahattin";
            hr.LastName = "Alkomut";
            hr.Password = PasswordCryptographer.Crypt("567894");
            hr.JobID = 2;
            hr.Email = EmailCreator.CreateEmail(hr.FirstName, hr.LastName);
            hr.Salary = 10000;

            context.Employees.Add(hr);

            Employee sales = new Employee();

            sales.FirstName = "Levent";
            sales.LastName = "Sişarpsoy";
            sales.Password = PasswordCryptographer.Crypt("3691215");
            sales.JobID = 3;
            sales.Email = EmailCreator.CreateEmail(sales.FirstName, sales.LastName);
            sales.Salary = 8000;

            context.Employees.Add(sales);

            Employee receptionChief = new Employee();

            receptionChief.FirstName = "Gülay";
            receptionChief.LastName = "Aydınlık";
            receptionChief.Password = PasswordCryptographer.Crypt("756842");
            receptionChief.JobID = 4;
            receptionChief.Email = EmailCreator.CreateEmail(receptionChief.FirstName, receptionChief.LastName);
            receptionChief.Salary = 8500;

            context.Employees.Add(receptionChief);

            Employee it = new Employee();

            it.FirstName = "Selahattin";
            it.LastName = "Karadibag";
            it.Password = PasswordCryptographer.Crypt("8974256");
            it.JobID = 11;
            it.Email = EmailCreator.CreateEmail(it.FirstName, it.LastName);
            it.Salary = 11000;

            context.Employees.Add(it);
            context.SaveChanges();

            //Resepsiyonistler

            Employee receps1 = new Employee();
            receps1.FirstName = "Deneme";
            receps1.LastName = "Denemeoğlu";
            receps1.Address = "Rize Çayeli";
            receps1.PhoneNumber = "05355506897";
            receps1.WagePerHour = 16;
            receps1.JobID = 5;
            receps1.OffDay = ENTITY.Enum.WeekDays.Çarşamba;
            receps1.Password = PasswordCryptographer.Crypt("123456");
            receps1.Email = EmailCreator.CreateEmail(receps1.FirstName, receps1.LastName);

            context.Employees.Add(receps1);
            context.SaveChanges();

            Employee receps2 = new Employee();
            receps2.FirstName = "Denemeiki";
            receps2.LastName = "Denemeiki";
            receps2.Address = "Gebze Kocaeli";
            receps2.PhoneNumber = "05424869552";
            receps2.WagePerHour = 10;
            receps2.JobID = 5;
            receps2.Password = PasswordCryptographer.Crypt("123456");
            receps2.Email = EmailCreator.CreateEmail(receps2.FirstName, receps2.LastName);

            context.Employees.Add(receps2);
            context.SaveChanges();

            Employee receps3 = new Employee();
            receps3.FirstName = "Denemeüç";
            receps3.LastName = "Denemeüç";
            receps3.Address = "İzmir";
            receps3.PhoneNumber = "05535535154";
            receps3.WagePerHour = 13;
            receps3.JobID = 5;
            receps3.Password = PasswordCryptographer.Crypt("123456");
            receps3.Email = EmailCreator.CreateEmail(receps3.FirstName, receps3.LastName);

            context.Employees.Add(receps3);
            context.SaveChanges();
            #endregion

            #region RoomFeatures

            //Tek kişilik

            RoomFeature rf = new RoomFeature()
            {
                Description = "Klima, televizyon, saç kurutma makinesi, kablosuz internet."
            };

            //Tek Kişilik Olmayan
            RoomFeature rf2 = new RoomFeature()
            {
                Description = "Minibar, klima, televizyon, saç kurutma makinesi, kablosuz internet."
            };

            //Tek kişilik Olmayan ve 3v4.Katlarda bulunan
            RoomFeature rf3 = new RoomFeature()
            {
                Description = "Balkon, minibar, klima, televizyon, saç kurutma makinesi, kablosuz internet."
            };
            context.RoomFeatures.Add(rf);
            context.RoomFeatures.Add(rf2);
            context.RoomFeatures.Add(rf3);
            context.SaveChanges();
            #endregion

            #region Beds
            Bed b1 = new Bed()
            {
                BedType = "Tek Kişilik Yatak"
            };

            context.Beds.Add(b1);

            Bed b2 = new Bed()
            {
                BedType = "Çift Kişilik Yatak"
            };

            context.Beds.Add(b2);
            context.SaveChanges();
            #endregion

            #region Rooms

            //1.KAT
            for (int i = 1; i <= 10; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 1,
                    RoomNumber = i,
                    Capacity = 1,
                    PricePerNight = 1250,
                    RoomFeatureID = 1

                };

                context.Rooms.Add(r1);
            }


            for (int i = 11; i <= 20; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 1,
                    RoomNumber = i,
                    Capacity = 3,
                    PricePerNight = 3400,
                    RoomFeatureID = 2

                };
                context.Rooms.Add(r1);
            }

            //2.KAT
            for (int i = 21; i <= 30; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 2,
                    RoomNumber = i,
                    Capacity = 1,
                    PricePerNight = 1250,
                    RoomFeatureID = 1

                };

                context.Rooms.Add(r1);
            }

            for (int i = 31; i <= 40; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 2,
                    RoomNumber = i,
                    Capacity = 2,
                    PricePerNight = 2500,
                    RoomFeatureID = 2

                };

                context.Rooms.Add(r1);
            }

            //3.KAT

            for (int i = 41; i <= 50; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 3,
                    RoomNumber = i,
                    Capacity = 2,
                    PricePerNight = 2500,
                    RoomFeatureID = 3

                };

                context.Rooms.Add(r1);
            }


            for (int i = 51; i <= 60; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 3,
                    RoomNumber = i,
                    Capacity = 3,
                    PricePerNight = 3500,
                    RoomFeatureID = 3

                };

                context.Rooms.Add(r1);
            }

            //4.KAT
            for (int i = 61; i <= 70; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 4,
                    RoomNumber = i,
                    Capacity = 2,
                    PricePerNight = 2500,
                    RoomFeatureID = 3

                };

                context.Rooms.Add(r1);
            }

            for (int i = 71; i <= 76; i++)
            {
                Room r1 = new Room()
                {
                    FloorNumber = 4,
                    RoomNumber = i,
                    Capacity = 4,
                    PricePerNight = 4500,
                    RoomFeatureID = 3

                };

                context.Rooms.Add(r1);
            }

            Room king = new Room()
            {
                FloorNumber = 4,
                RoomNumber = 77,
                Capacity = 2,
                PricePerNight = 6000,
                RoomType = ENTITY.Enum.RoomType.KingSuit,
                RoomFeatureID = 3

            };

            context.Rooms.Add(king);
            context.SaveChanges();
            #endregion

            #region Images

            //Hotel Fotileri
            Image i1 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/12789/1278975/1278975595/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            Image i2 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/12789/1278975/1278975664/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            Image i3 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/7124/712480/712480096/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            Image i4 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/8211/821121/821121950/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };
            Image i5 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/11628/1162840/1162840491/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };
            Image i6 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/12789/1278975/1278975772/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };
            Image i7 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/11596/1159656/1159656753/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            Image i8 = new Image()
            {
                ImagePath = "https://img.directbooking.ro/getimage.ashx?w=880&h=660&file=c892d359-e4b2-472c-bea9-2c0a52a684a4.jpg"
            };
            Image i9 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/12789/1278975/1278975631/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            //Tek Kişilik Oda Fotoğrafları ID(10, 11)
            Image i10 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457//7124/712481/712481338.JPEG"
            };
            Image i11 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/4611/461129/461129982/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            //İki Kişilik Oda (ID 12)
            Image i12 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/4610/461014/461014380/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            //3 kişik oda (ID 13)
            Image i13 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/4610/461014/461014287/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            //4 kişilik oda (ID 14)
            Image i14 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/8211/821119/821119538/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            //Kral dairesi (ID 15 16)

            Image i15 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/12789/1278975/1278975316/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };
            Image i16 = new Image()
            {
                ImagePath = "https://a-for-art-hotel-thasos-island.bookeder.com/data/Photos/r1366x457/12789/1278975/1278975811/A-For-Art-Hotel-Limenas-Exterior.JPEG"
            };

            context.Images.Add(i1);
            context.Images.Add(i2);
            context.Images.Add(i3);
            context.Images.Add(i4);
            context.Images.Add(i5);
            context.Images.Add(i6);
            context.Images.Add(i7);
            context.Images.Add(i8);
            context.Images.Add(i9);
            context.Images.Add(i10);
            context.Images.Add(i11);
            context.Images.Add(i12);
            context.Images.Add(i13);
            context.Images.Add(i14);
            context.Images.Add(i15);
            context.Images.Add(i16);
            context.SaveChanges();

            #endregion

            #region RoomAndBeds

            //1.KAT
            for (int i = 1; i <= 10; i++)
            {
                RoomAndBed roomAndBed = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 1,
                    Count = 1

                };
                context.RoomAndBeds.Add(roomAndBed);

            }

            for (int i = 11; i <= 20; i++)
            {
                RoomAndBed roomAndBed = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 1,
                    Count = 3,
                };
                context.RoomAndBeds.Add(roomAndBed);

            }
            //2.KAT
            for (int i = 21; i <= 30; i++)
            {
                RoomAndBed roomAndBed = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 1,
                    Count = 1,

                };
                context.RoomAndBeds.Add(roomAndBed);
            }

            for (int i = 31; i <= 40; i++)
            {
                RoomAndBed roomAndBed = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 1,
                    Count = 2,

                };
                context.RoomAndBeds.Add(roomAndBed);
            }

            //3.KAT
            for (int i = 41; i <= 50; i++)
            {
                RoomAndBed roomAndBed = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 2,
                    Count = 1,
                };
                context.RoomAndBeds.Add(roomAndBed);
            }

            for (int i = 51; i <= 60; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    RoomAndBed roomAndBed = new RoomAndBed()
                    {
                        RoomID = i,
                        BedID = j,
                        Count = 1,
                    };
                    context.RoomAndBeds.Add(roomAndBed);
                }

            }

            //4.KAT
            for (int i = 61; i <= 70; i++)
            {
                RoomAndBed roomAndBed = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 2,
                    Count = 1,
                };
                context.RoomAndBeds.Add(roomAndBed);
            }

            for (int i = 71; i <= 76; i++)
            {
                RoomAndBed roomAndBedX = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 1,
                    Count = 2,
                };
                context.RoomAndBeds.Add(roomAndBedX);

                RoomAndBed roomAndBed = new RoomAndBed()
                {
                    RoomID = i,
                    BedID = 2,
                    Count = 1,
                };
                context.RoomAndBeds.Add(roomAndBed);

            }

            RoomAndBed roomAndBedKing = new RoomAndBed()
            {
                RoomID = 77,
                BedID = 2,
                Count = 1,
            };
            context.RoomAndBeds.Add(roomAndBedKing);

            #endregion

            #region HotelInfoAndImages

            for (int i = 1; i <= 9; i++)
            {
                HotelInfoAndImage hotelImages = new HotelInfoAndImage()
                {
                    HotelInfoID = 1,
                    ImageID = i
                };
                context.HotelInfoAndImages.Add(hotelImages);
            }
            
            #endregion

            #region RoomAndImages

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 10; j <= 11; j++)
                {
                    RoomAndImage roomImage = new RoomAndImage()
                    {
                        RoomID = i,
                        ImageID = j,
                    };

                    context.RoomAndImages.Add(roomImage);
                }

            }

            for (int i = 11; i <= 20; i++)
            {
                RoomAndImage roomImage = new RoomAndImage()
                {
                    RoomID = i,
                    ImageID = 12
                };
                context.RoomAndImages.Add(roomImage);
            }

            for (int i = 21; i <= 30; i++)
            {
                for (int j = 10; j <= 11; j++)
                {
                    RoomAndImage roomImage = new RoomAndImage()
                    {
                        RoomID = i,
                        ImageID = j
                    };
                    context.RoomAndImages.Add(roomImage);
                }
            }

            for (int i = 31; i <= 40; i++)
            {
                RoomAndImage roomImage = new RoomAndImage()
                {
                    RoomID = i,
                    ImageID = 12
                };
                context.RoomAndImages.Add(roomImage);
            }

            for (int i = 41; i <= 50; i++)
            {
                RoomAndImage roomImage = new RoomAndImage()
                {
                    RoomID = i,
                    ImageID = 12
                };
                context.RoomAndImages.Add(roomImage);
            }

            for (int i = 51; i <= 60; i++)
            {
                RoomAndImage roomImage = new RoomAndImage()
                {
                    RoomID = i,
                    ImageID = 13
                };
                context.RoomAndImages.Add(roomImage);
            }

            for (int i = 61; i <= 70; i++)
            {
                RoomAndImage roomImage = new RoomAndImage()
                {
                    RoomID = i,
                    ImageID = 12
                };
                context.RoomAndImages.Add(roomImage);
            }
            for (int i = 71; i <= 76; i++)
            {
                RoomAndImage roomImage = new RoomAndImage()
                {
                    RoomID = i,
                    ImageID = 14
                };
                context.RoomAndImages.Add(roomImage);
            }

            RoomAndImage kingImage1 = new RoomAndImage()
            {
                RoomID = 77,
                ImageID = 15
            };
            context.RoomAndImages.Add(kingImage1);

            RoomAndImage kingImage2 = new RoomAndImage()
            {
                RoomID = 77,
                ImageID = 16
            };
            context.RoomAndImages.Add(kingImage2);

            context.SaveChanges();
            #endregion


            #region TEST USER
            AppUser user = new AppUser()
            {
                FirstName = "Erva",
                LastName = "Kio",
                IdentificationNumber = "666666666660"
            };

            context.AppUsers.Add(user);
            context.SaveChanges();

            UserProfile profile = new UserProfile()
            {
                ID= user.ID,
                Email = "ervvkucukislamoglu@gmail.com",
                Password = PasswordCryptographer.Crypt("123456"),
                UserName = "kekocu53",
                ActivationCode = new Guid(),
                Role = ENTITY.Enum.UserRole.Member
            };

            context.UserProfiles.Add(profile);
            context.SaveChanges();
            #endregion

            #region Reservation
            //Reservation r1 = new Reservation()
            //{
            //    AppUserID = 1,
            //    AdultCount = 2,
            //    ChildrenCount = 1,
            //    CheckInDate = DateTime.Today,
            //    CheckOutDate = DateTime.Today,
            //    Package = ENTITY.Enum.ReservationPackage.AllInOne,
            //    Type = ENTITY.Enum.ReservationType.Online,
            //};

            //Reservation r2 = new Reservation()
            //{
            //    AppUserID = 1,
            //    AdultCount = 4,
            //    ChildrenCount = 0,
            //    CheckInDate = DateTime.Today,
            //    CheckOutDate = DateTime.Today,
            //    Package = ENTITY.Enum.ReservationPackage.FullPension,
            //    Type = ENTITY.Enum.ReservationType.Online,
            //};

            //context.Reservation.Add(r1);
            //resRep.Add(r2);
            #endregion

            #region RoomAndReservations

            #endregion

            #region Kaydetme İşlemi
            //context.SaveChanges();
            #endregion


        }




    }
}
