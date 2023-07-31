﻿using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.IntRep
{
    public interface IGuestRepository
    {
        List<Guest> GetGuestsForReservations(List<int> guestIDs);
    }
}
