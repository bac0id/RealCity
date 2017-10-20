﻿using System;
using System.Reflection;
using ColossalFramework;
using ColossalFramework.Math;
using UnityEngine;

namespace RealCity
{
    public class pc_IndustrialBuildingAI : PrivateBuildingAI
    {
        private TransferManager.TransferReason GetIncomingTransferReason(ushort buildingID)
        {
            switch (this.m_info.m_class.m_subService)
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
                        Array16<Building> buildings = Singleton<BuildingManager>.instance.m_buildings;
                        int num1 = ((int)buildings.m_buffer[buildingID].m_customBuffer2 + (int)buildings.m_buffer[buildingID].m_customBuffer1) >> 1;
                        Randomizer randomizer = new Randomizer(num1);
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

        private int GetConsumptionDivider()
        {
            switch (this.m_info.m_class.m_subService)
            {
                case ItemClass.SubService.IndustrialForestry:
                    return 1;
                case ItemClass.SubService.IndustrialFarming:
                    return 1;
                case ItemClass.SubService.IndustrialOil:
                    return 1;
                case ItemClass.SubService.IndustrialOre:
                    return 1;
                default:
                    return 4;
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

        public override void ModifyMaterialBuffer(ushort buildingID, ref Building data, TransferManager.TransferReason material, ref int amountDelta)
        {
            if (material == this.GetIncomingTransferReason(buildingID))
            {
                int width = data.Width;
                int length = data.Length;
                int num = 4000;
                int num2 = this.CalculateProductionCapacity(new Randomizer((int)buildingID), width, length);
                int consumptionDivider = this.GetConsumptionDivider();
                int num3 = Mathf.Max(num2 * 500 / consumptionDivider, num * 4);
                int customBuffer = (int)data.m_customBuffer1;
                amountDelta = Mathf.Clamp(amountDelta, 0, num3 - customBuffer);
                data.m_customBuffer1 = (ushort)(customBuffer + amountDelta);
            }
            else if (material == this.GetOutgoingTransferReason())
            {
                int customBuffer2 = (int)data.m_customBuffer2;
                amountDelta = Mathf.Clamp(amountDelta, -customBuffer2, 0);
                caculate_trade_income(buildingID, ref data, material, ref amountDelta);
                data.m_customBuffer2 = (ushort)(customBuffer2 + amountDelta);
            }
            else
            {
                base.ModifyMaterialBuffer(buildingID, ref data, material, ref amountDelta);
            }
        }

        public void caculate_trade_income(ushort buildingID, ref Building data, TransferManager.TransferReason material, ref int amountDelta)
        {
            float production_value;
            switch (data.Info.m_class.m_level)
            {
                case ItemClass.Level.Level1:
                    production_value = 1f; break;
                case ItemClass.Level.Level2:
                    production_value = 1.2f; break;
                case ItemClass.Level.Level3:
                    production_value = 1.5f; break;
                default:
                    production_value = 0f; break;
            }

            switch (data.Info.m_class.m_subService)
            {
                case ItemClass.SubService.IndustrialOil:
                    production_value = 0.5f; break;
                case ItemClass.SubService.IndustrialOre:
                    production_value = 0.5f; break;
                case ItemClass.SubService.IndustrialForestry:
                    production_value = 0.4f; break;
                case ItemClass.SubService.IndustrialFarming:
                    production_value = 0.4f; break;
                default:
                    break;
            }
            switch (material)
            {
                case TransferManager.TransferReason.Lumber:
                    float trade_tax = 0;
                    float trade_income = amountDelta * pc_PrivateBuildingAI.lumber_profit * production_value;
                    if (comm_data.building_money[buildingID] > 0)
                    {
                        trade_tax = -trade_income * 0.04f;
                        Singleton<EconomyManager>.instance.AddPrivateIncome((int)trade_tax, ItemClass.Service.Industrial, data.Info.m_class.m_subService, data.Info.m_class.m_level, 111);
                    }
                    comm_data.building_money[buildingID] = comm_data.building_money[buildingID] - (int)(trade_income + trade_tax);
                    break;
                case TransferManager.TransferReason.Food:
                    trade_tax = 0;
                    trade_income = amountDelta * pc_PrivateBuildingAI.food_profit * production_value;
                    if (comm_data.building_money[buildingID] > 0)
                    {
                        trade_tax = -trade_income * 0.04f;
                        Singleton<EconomyManager>.instance.AddPrivateIncome((int)trade_tax, ItemClass.Service.Industrial, data.Info.m_class.m_subService, data.Info.m_class.m_level, 111);
                    }
                    comm_data.building_money[buildingID] = comm_data.building_money[buildingID] - (int)(trade_income + trade_tax);
                    break;
                case TransferManager.TransferReason.Petrol:
                    trade_tax = 0;
                    trade_income = amountDelta * pc_PrivateBuildingAI.petrol_profit * production_value;
                    if (comm_data.building_money[buildingID] > 0)
                    {
                        trade_tax = -trade_income * 0.1f;
                        Singleton<EconomyManager>.instance.AddPrivateIncome((int)trade_tax, ItemClass.Service.Industrial, data.Info.m_class.m_subService, data.Info.m_class.m_level, 111);
                    }
                    comm_data.building_money[buildingID] = comm_data.building_money[buildingID] - (int)(trade_income + trade_tax);
                    break;
                case TransferManager.TransferReason.Coal:
                    trade_tax = 0;
                    trade_income = amountDelta * pc_PrivateBuildingAI.coal_profit * production_value;
                    if (comm_data.building_money[buildingID] > 0)
                    {
                        trade_tax = -trade_income * 1f;
                        Singleton<EconomyManager>.instance.AddPrivateIncome((int)trade_tax, ItemClass.Service.Industrial, data.Info.m_class.m_subService, data.Info.m_class.m_level, 111);
                    }
                    comm_data.building_money[buildingID] = comm_data.building_money[buildingID] - (int)(trade_income + trade_tax);
                    break;
                case TransferManager.TransferReason.Goods:
                    trade_tax = 0;
                    trade_income = amountDelta * pc_PrivateBuildingAI.indu_profit * production_value;
                    if (comm_data.building_money[buildingID] > 0)
                    {
                        trade_tax = -trade_income * 1f;
                        Singleton<EconomyManager>.instance.AddPrivateIncome((int)trade_tax, ItemClass.Service.Industrial, data.Info.m_class.m_subService, data.Info.m_class.m_level, 111);
                    }
                    comm_data.building_money[buildingID] = comm_data.building_money[buildingID] - (int)(trade_income + trade_tax);
                    break;
            }
        }
    }
}
