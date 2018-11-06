﻿using ColossalFramework;
using ColossalFramework.Math;
using UnityEngine;
using ColossalFramework.Globalization;
using System;

namespace RealCity
{
    public class RealCityIndustrialBuildingAI : PrivateBuildingAI
    {
        public override void CreateBuilding(ushort buildingID, ref Building data)
        {
            base.CreateBuilding(buildingID, ref data);
            int width = data.Width;
            int length = data.Length;
            int num = 4000;
            int num2 = this.CalculateProductionCapacity((ItemClass.Level)data.m_level,new Randomizer((int)buildingID), width, length);
            int consumptionDivider = GetConsumptionDivider(buildingID, data);
            int num3 = Mathf.Max(num2 * 500 / consumptionDivider, num * 4);
            data.m_customBuffer1 = 8000;
            MainDataStore.building_buffer1[buildingID] = 8000;
            //new add start
            MainDataStore.building_money[buildingID] -= 8000 * RealCityPrivateBuildingAI.GetPrice(false, buildingID, data);
            //new add end
            DistrictPolicies.Specialization specialization = this.SpecialPolicyNeeded();
            if (specialization != DistrictPolicies.Specialization.None)
            {
                DistrictManager instance = Singleton<DistrictManager>.instance;
                byte district = instance.GetDistrict(data.m_position);
                District[] expr_9C_cp_0 = instance.m_districts.m_buffer;
                byte expr_9C_cp_1 = district;
                expr_9C_cp_0[(int)expr_9C_cp_1].m_specializationPoliciesEffect = (expr_9C_cp_0[(int)expr_9C_cp_1].m_specializationPoliciesEffect | specialization);
            }
        }

        public override int CalculateProductionCapacity(ItemClass.Level level, Randomizer r, int width, int length)
        {
            ItemClass @class = this.m_info.m_class;
            int num;
            if (@class.m_subService == ItemClass.SubService.IndustrialGeneric)
            {
                if (level == ItemClass.Level.Level1)
                {
                    num = 100;
                }
                else if (level == ItemClass.Level.Level2)
                {
                    num = 140;
                }
                else
                {
                    num = 160;
                }
            }
            else
            {
                num = 100;
            }
            if (num != 0)
            {
                num = Mathf.Max(100, width * length * num + r.Int32(100u)) / 100;
            }
            return num;
        }

        private DistrictPolicies.Specialization SpecialPolicyNeeded()
        {
            switch (this.m_info.m_class.m_subService)
            {
                case ItemClass.SubService.IndustrialForestry:
                    return DistrictPolicies.Specialization.Forest;
                case ItemClass.SubService.IndustrialFarming:
                    return DistrictPolicies.Specialization.Farming;
                case ItemClass.SubService.IndustrialOil:
                    return DistrictPolicies.Specialization.Oil;
                case ItemClass.SubService.IndustrialOre:
                    return DistrictPolicies.Specialization.Ore;
                default:
                    return DistrictPolicies.Specialization.None;
            }
        }


        private int GetConsumptionDivider(ushort buildingID, Building data)
        {
            int ConsumptionDivider;
            switch (this.m_info.m_class.m_subService)
            {
                case ItemClass.SubService.IndustrialForestry:
                    ConsumptionDivider = 1; break;
                case ItemClass.SubService.IndustrialFarming:
                    ConsumptionDivider = 1; break;
                case ItemClass.SubService.IndustrialOil:
                    ConsumptionDivider = 1; break;
                case ItemClass.SubService.IndustrialOre:
                    ConsumptionDivider = 1; break;
                default:
                    ConsumptionDivider = 4; break;
            }
            return ConsumptionDivider;
        }

        public static TransferManager.TransferReason GetIncomingTransferReason(ushort buildingID)
        {
            switch (Singleton<BuildingManager>.instance.m_buildings.m_buffer[buildingID].Info.m_class.m_subService)
            {
                case ItemClass.SubService.IndustrialForestry:
                    return TransferManager.TransferReason.Logs;
                case ItemClass.SubService.IndustrialFarming:
                    return TransferManager.TransferReason.Grain;
                case ItemClass.SubService.IndustrialOil:
                    return TransferManager.TransferReason.Oil;
                case ItemClass.SubService.IndustrialOre:
                    return TransferManager.TransferReason.Ore;
                default:
                    {
                        Randomizer randomizer = new Randomizer((int)buildingID);
                        switch (randomizer.Int32(4u))
                        {
                            case 0:
                                return TransferManager.TransferReason.Lumber;
                            case 1:
                                return TransferManager.TransferReason.Food;
                            case 2:
                                return TransferManager.TransferReason.Petrol;
                            case 3:
                                return TransferManager.TransferReason.Coal;
                            default:
                                return TransferManager.TransferReason.None;
                        }
                    }
            }
        }

        public override void ModifyMaterialBuffer(ushort buildingID, ref Building data, TransferManager.TransferReason material, ref int amountDelta)
        {
            if (material == GetIncomingTransferReason(buildingID) || material == GetSecondaryIncomingTransferReason(buildingID))
            {
                int width = data.Width;
                int length = data.Length;
                int num = 16000;
                int num2 = CalculateProductionCapacity((ItemClass.Level)data.m_level, new Randomizer((int)buildingID), width, length);
                float consumptionDivider = GetConsumptionDivider(buildingID, data);
                int num3 = Mathf.Max((int)(num2 * 500 / consumptionDivider), num * 4);
                num3 = 64000;
                int customBuffer = (int)data.m_customBuffer1;
                amountDelta = Mathf.Clamp(amountDelta, 0, num3 - customBuffer);
                process_incoming(buildingID, ref data, material, ref amountDelta);

                if (material == GetSecondaryIncomingTransferReason(buildingID))
                {
                    if ((customBuffer + amountDelta * MainDataStore.industialPriceAdjust) > 64000)
                    {
                        data.m_customBuffer1 = 64000;
                        MainDataStore.building_buffer1[buildingID] += amountDelta * MainDataStore.industialPriceAdjust;
                    }
                    else
                    {
                        data.m_customBuffer1 = (ushort)(customBuffer + amountDelta);
                        MainDataStore.building_buffer1[buildingID] = data.m_customBuffer1;
                    }
                }
                else
                {
                    if ((customBuffer + amountDelta) > 64000)
                    {
                        data.m_customBuffer1 = 64000;
                        MainDataStore.building_buffer1[buildingID] += amountDelta;
                    }
                    else
                    {
                        data.m_customBuffer1 = (ushort)(customBuffer + amountDelta);
                        MainDataStore.building_buffer1[buildingID] = data.m_customBuffer1;
                    }
                }
            }
            else if (material == GetOutgoingTransferReason())
            {
                int customBuffer2 = (int)data.m_customBuffer2;
                amountDelta = Mathf.Clamp(amountDelta, -customBuffer2, 0);
                if (amountDelta < -8000)
                {
                    amountDelta = -8000;
                }
                caculate_trade_income(buildingID, ref data, material, ref amountDelta);
                data.m_customBuffer2 = (ushort)(customBuffer2 + amountDelta);
                MainDataStore.building_buffer2[buildingID] = data.m_customBuffer2;
            }
            else
            {
                base.ModifyMaterialBuffer(buildingID, ref data, material, ref amountDelta);
            }
        }

        private TransferManager.TransferReason GetOutgoingTransferReason()
        {
            switch (this.m_info.m_class.m_subService)
            {
                case ItemClass.SubService.IndustrialForestry:
                    return TransferManager.TransferReason.Lumber;
                case ItemClass.SubService.IndustrialFarming:
                    return TransferManager.TransferReason.Food;
                case ItemClass.SubService.IndustrialOil:
                    return TransferManager.TransferReason.Petrol;
                case ItemClass.SubService.IndustrialOre:
                    return TransferManager.TransferReason.Coal;
                default:
                    return TransferManager.TransferReason.Goods;
            }
        }


        public static TransferManager.TransferReason GetSecondaryIncomingTransferReason(ushort buildingID)
        {
            if (Singleton<BuildingManager>.instance.m_buildings.m_buffer[buildingID].Info.m_class.m_subService == ItemClass.SubService.IndustrialGeneric)
            {
                Randomizer randomizer = new Randomizer((int)buildingID);
                switch (randomizer.Int32(8u))
                {
                    case 0:
                        return TransferManager.TransferReason.PlanedTimber;
                    case 1:
                        return TransferManager.TransferReason.Paper;
                    case 2:
                        return TransferManager.TransferReason.Flours;
                    case 3:
                        return TransferManager.TransferReason.AnimalProducts;
                    case 4:
                        return TransferManager.TransferReason.Petroleum;
                    case 5:
                        return TransferManager.TransferReason.Plastics;
                    case 6:
                        return TransferManager.TransferReason.Metals;
                    case 7:
                        return TransferManager.TransferReason.Glass;
                }
            }
            return TransferManager.TransferReason.None;
        }

        public void process_incoming(ushort buildingID, ref Building data, TransferManager.TransferReason material, ref int amountDelta)
        {
            float trade_income1 = (float)amountDelta * RealCityIndustryBuildingAI.GetResourcePrice(material);
            MainDataStore.building_money[buildingID] = MainDataStore.building_money[buildingID] - trade_income1;
        }

        public void caculate_trade_income(ushort buildingID, ref Building data, TransferManager.TransferReason material, ref int amountDelta)
        {
            float trade_income1 = (float)amountDelta * RealCityPrivateBuildingAI.GetPrice(true, buildingID, data);
            float trade_tax = 0;
            trade_tax = -trade_income1 * (float)RealCityPrivateBuildingAI.GetTaxRate(data, buildingID) /100f;
            Singleton<EconomyManager>.instance.AddPrivateIncome((int)trade_tax, ItemClass.Service.Industrial, data.Info.m_class.m_subService, data.Info.m_class.m_level, 111);
            MainDataStore.building_money[buildingID] = (MainDataStore.building_money[buildingID] - (trade_income1 + trade_tax));                    
        }
    }
}