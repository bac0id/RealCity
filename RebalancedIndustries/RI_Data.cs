﻿namespace RealCity.RebalancedIndustries
{
    public class RI_Data
    { 
        public static decimal GetFactorCargo(TransferManager.TransferReason material)
        {
            switch (material)
            {
                case TransferManager.TransferReason.Oil:
                case TransferManager.TransferReason.Ore:
                case TransferManager.TransferReason.Coal:
                case TransferManager.TransferReason.Petrol:
                case TransferManager.TransferReason.Food:
                case TransferManager.TransferReason.Grain:
                case TransferManager.TransferReason.Lumber:
                case TransferManager.TransferReason.Logs:
                case TransferManager.TransferReason.Goods:
                case TransferManager.TransferReason.LuxuryProducts:
                case TransferManager.TransferReason.AnimalProducts:
                case TransferManager.TransferReason.Flours:
                case TransferManager.TransferReason.Petroleum:
                case TransferManager.TransferReason.Plastics:
                case TransferManager.TransferReason.Metals:
                case TransferManager.TransferReason.Glass:
                case TransferManager.TransferReason.PlanedTimber:
                case TransferManager.TransferReason.Shopping:
                case TransferManager.TransferReason.ShoppingB:
                case TransferManager.TransferReason.ShoppingC:
                case TransferManager.TransferReason.ShoppingD:
                case TransferManager.TransferReason.ShoppingE:
                case TransferManager.TransferReason.ShoppingH:
                    if (RealCity.reduceVehicle)
                    {
                        return 2m;
                    }
                    else
                    {
                        return 1m;
                    }
            }
            return 1m;
        }
    }
}
