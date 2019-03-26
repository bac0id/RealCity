﻿using RealCity.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealCity.CustomAI
{
    public class RealCityVehicleAI
    {
        public static void VehicleAIReleaseVehiclePostFix(ushort vehicleID, ref Vehicle data)
        {
            MainDataStore.vehicleTransferTime[vehicleID] = 0;
            MainDataStore.isVehicleCharged[vehicleID] = false;
        }
    }
}