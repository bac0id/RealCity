﻿using System;
using ColossalFramework;
using UnityEngine;
using ColossalFramework.Math;
using System.Reflection;
using TrafficManager.Custom.AI;
using TrafficManager.Manager.Impl;
using TrafficManager.Traffic.Data;

namespace RealCity
{
    public class pc_ResidentAI : ResidentAI
    {
        public static uint precitizenid = 0;
        public static int family_count = 0;
        public static uint family_very_profit_money_num = 0;
        public static uint family_profit_money_num = 0;
        public static uint family_loss_money_num = 0;
        public static int citizen_salary_count = 0;
        public static int citizen_outcome_count = 0;
        public static int citizen_salary_tax_total = 0;
        public static float temp_citizen_salary_tax_total = 0f;
        //public static bool citizen_process_done = false;
        //govement salary outconme
        public static int Road = 0;
        public static int Electricity = 0;
        public static int Water = 0;
        public static int Beautification = 0;
        public static int Garbage = 0;
        public static int HealthCare = 0;
        public static int PoliceDepartment = 0;
        public static int Education = 0;
        public static int Monument = 0;
        public static int FireDepartment = 0;
        public static int PublicTransport_bus = 0;
        public static int PublicTransport_tram = 0;
        public static int PublicTransport_ship = 0;
        public static int PublicTransport_plane = 0;
        public static int PublicTransport_metro = 0;
        public static int PublicTransport_train = 0;
        public static int PublicTransport_taxi = 0;
        public static int PublicTransport_cablecar = 0;
        public static int PublicTransport_monorail = 0;
        public static int Disaster = 0;

        public static uint family_weight_stable_high;
        public static uint family_weight_stable_low;

        public static byte[] save_data = new byte[124];
        public static byte[] load_data = new byte[124];

        public static void load()
        {
            int i = 0;
            precitizenid = saveandrestore.load_uint(ref i, load_data);
            family_count = saveandrestore.load_int(ref i, load_data);
            family_very_profit_money_num = saveandrestore.load_uint(ref i, load_data);
            family_profit_money_num = saveandrestore.load_uint(ref i, load_data);
            family_loss_money_num = saveandrestore.load_uint(ref i, load_data);
            citizen_salary_count = saveandrestore.load_int(ref i, load_data);
            citizen_outcome_count = saveandrestore.load_int(ref i, load_data);
            citizen_salary_tax_total = saveandrestore.load_int(ref i, load_data);
            temp_citizen_salary_tax_total = saveandrestore.load_float(ref i, load_data);

            Road = saveandrestore.load_int(ref i, load_data);
            Electricity = saveandrestore.load_int(ref i, load_data);
            Water = saveandrestore.load_int(ref i, load_data);
            Beautification = saveandrestore.load_int(ref i, load_data);
            Garbage = saveandrestore.load_int(ref i, load_data);
            HealthCare = saveandrestore.load_int(ref i, load_data);
            PoliceDepartment = saveandrestore.load_int(ref i, load_data);
            Education = saveandrestore.load_int(ref i, load_data);
            Monument = saveandrestore.load_int(ref i, load_data);
            FireDepartment = saveandrestore.load_int(ref i, load_data);
            PublicTransport_bus = saveandrestore.load_int(ref i, load_data);
            PublicTransport_tram = saveandrestore.load_int(ref i, load_data);
            PublicTransport_ship = saveandrestore.load_int(ref i, load_data);
            PublicTransport_plane = saveandrestore.load_int(ref i, load_data);
            PublicTransport_metro = saveandrestore.load_int(ref i, load_data);
            PublicTransport_train = saveandrestore.load_int(ref i, load_data);
            PublicTransport_taxi = saveandrestore.load_int(ref i, load_data);
            PublicTransport_cablecar = saveandrestore.load_int(ref i, load_data);
            PublicTransport_monorail = saveandrestore.load_int(ref i, load_data);
            Disaster = saveandrestore.load_int(ref i, load_data);

            family_weight_stable_high = saveandrestore.load_uint(ref i, load_data);
            family_weight_stable_low = saveandrestore.load_uint(ref i, load_data);
        }

        public static void save()
        {
            int i = 0;

            //2*4 + 3*4 + 4*4 = 36
            saveandrestore.save_uint(ref i, precitizenid, ref save_data);
            saveandrestore.save_int(ref i, family_count, ref save_data);
            saveandrestore.save_uint(ref i, family_very_profit_money_num, ref save_data);
            saveandrestore.save_uint(ref i, family_profit_money_num, ref save_data);
            saveandrestore.save_uint(ref i, family_loss_money_num, ref save_data);
            saveandrestore.save_int(ref i, citizen_salary_count, ref save_data);
            saveandrestore.save_int(ref i, citizen_outcome_count, ref save_data);
            saveandrestore.save_int(ref i, citizen_salary_tax_total, ref save_data);
            saveandrestore.save_float(ref i, temp_citizen_salary_tax_total, ref save_data);

            //20 * 4 = 80
            saveandrestore.save_int(ref i, Road, ref save_data);
            saveandrestore.save_int(ref i, Electricity, ref save_data);
            saveandrestore.save_int(ref i, Water, ref save_data);
            saveandrestore.save_int(ref i, Beautification, ref save_data);
            saveandrestore.save_int(ref i, Garbage, ref save_data);
            saveandrestore.save_int(ref i, HealthCare, ref save_data);
            saveandrestore.save_int(ref i, PoliceDepartment, ref save_data);
            saveandrestore.save_int(ref i, Education, ref save_data);
            saveandrestore.save_int(ref i, Monument, ref save_data);
            saveandrestore.save_int(ref i, FireDepartment, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_bus, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_tram, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_ship, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_plane, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_metro, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_train, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_taxi, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_cablecar, ref save_data);
            saveandrestore.save_int(ref i, PublicTransport_monorail, ref save_data);
            saveandrestore.save_int(ref i, Disaster, ref save_data);

            //8
            saveandrestore.save_uint(ref i, family_weight_stable_high, ref save_data);
            saveandrestore.save_uint(ref i, family_weight_stable_low, ref save_data);
        }


        public int citizen_salary(uint citizen_id)
        {
            int num = 0;
            System.Random rand = new System.Random();
            //Array16<Building> buildings = Singleton<BuildingManager>.instance.m_buildings;
            if (citizen_id != 0u)
            {
                Citizen.Flags temp_flag = Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_flags;
                if (((temp_flag & Citizen.Flags.Arrested) != Citizen.Flags.None) || ((temp_flag & Citizen.Flags.Student) != Citizen.Flags.None) || ((temp_flag & Citizen.Flags.Sick) != Citizen.Flags.None))
                {
                    return num;
                }
                if (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_workBuilding != 0u)
                {
                    int work_building = Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_workBuilding;
                    switch (Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_subService)
                    {
                        case ItemClass.SubService.CommercialHigh:
                            switch (Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_level)
                            {
                                case ItemClass.Level.Level1:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.comm_high_level1_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.comm_high_level1_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.comm_high_level1_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.comm_high_level1_education3) + rand.Next(4); break;
                                    }
                                    break;
                                case ItemClass.Level.Level2:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.comm_high_level2_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.comm_high_level2_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.comm_high_level2_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.comm_high_level2_education3) + rand.Next(4); break;
                                    }
                                    break;
                                case ItemClass.Level.Level3:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.comm_high_level3_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.comm_high_level3_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.comm_high_level3_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.comm_high_level3_education3) + rand.Next(4); break;
                                    }
                                    break;
                            }
                            break; //
                        case ItemClass.SubService.CommercialLow:
                            switch (Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_level)
                            {
                                case ItemClass.Level.Level1:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.comm_low_level1_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.comm_low_level1_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.comm_low_level1_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.comm_low_level1_education3) + rand.Next(4); break;
                                    }
                                    break;
                                case ItemClass.Level.Level2:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.comm_low_level2_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.comm_low_level2_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.comm_low_level2_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.comm_low_level2_education3) + rand.Next(4); break;
                                    }
                                    break;
                                case ItemClass.Level.Level3:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.comm_low_level3_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.comm_low_level3_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.comm_low_level3_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.comm_low_level3_education3) + rand.Next(4); break;
                                    }
                                    break;
                            }
                            break; //
                        case ItemClass.SubService.IndustrialGeneric:
                            switch (Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_level)
                            {
                                case ItemClass.Level.Level1:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.indus_gen_level1_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.indus_gen_level1_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.indus_gen_level1_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.indus_gen_level1_education3) + rand.Next(4); break;
                                    }
                                    break;
                                case ItemClass.Level.Level2:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.indus_gen_level2_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.indus_gen_level2_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.indus_gen_level2_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.indus_gen_level2_education3) + rand.Next(4); break;
                                    }
                                    break;
                                case ItemClass.Level.Level3:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.indus_gen_level3_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.indus_gen_level3_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.indus_gen_level3_education2) + rand.Next(3); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.indus_gen_level3_education3) + rand.Next(4); break;
                                    }
                                    break;
                            }
                            break; //
                        case ItemClass.SubService.IndustrialFarming:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.indus_far_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.indus_far_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.indus_far_education2) + rand.Next(3); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.indus_far_education3) + rand.Next(4); break;
                            }
                            break; //
                        case ItemClass.SubService.IndustrialForestry:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.indus_for_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.indus_for_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.indus_for_education2) + rand.Next(3); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.indus_for_education3) + rand.Next(4); break;
                            }
                            break; //
                        case ItemClass.SubService.IndustrialOil:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.indus_oil_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.indus_oil_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.indus_oil_education2) + rand.Next(3); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.indus_oil_education3) + rand.Next(4); break;
                            }
                            break; //
                        case ItemClass.SubService.IndustrialOre:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.indus_ore_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.indus_ore_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.indus_ore_education2) + rand.Next(3); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.indus_ore_education3) + rand.Next(4); break;
                            }
                            break; //
                        case ItemClass.SubService.OfficeGeneric:
                            switch (Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_level)
                            {
                                case ItemClass.Level.Level1:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.office_gen_level1_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.office_gen_level1_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.office_gen_level1_education2) + rand.Next(3);
                                            num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.office_gen_level1_education3) + rand.Next(4);
                                            num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                                    }
                                    break;
                                case ItemClass.Level.Level2:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.office_gen_level2_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.office_gen_level2_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.office_gen_level2_education2) + rand.Next(3);
                                            num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.office_gen_level2_education3) + rand.Next(4);
                                            num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                                    }
                                    break;
                                case ItemClass.Level.Level3:
                                    switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                                    {
                                        case Citizen.Education.Uneducated:
                                            num = num + (int)(comm_data.office_gen_level3_education0) + rand.Next(1); break;
                                        case Citizen.Education.OneSchool:
                                            num = num + (int)(comm_data.office_gen_level3_education1) + rand.Next(2); break;
                                        case Citizen.Education.TwoSchools:
                                            num = num + (int)(comm_data.office_gen_level3_education2) + rand.Next(3);
                                            num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                                        case Citizen.Education.ThreeSchools:
                                            num = num + (int)(comm_data.office_gen_level3_education3) + rand.Next(4);
                                            num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                                    }
                                    break;
                            }
                            break; //
                        case ItemClass.SubService.OfficeHightech:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.office_high_tech_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.office_high_tech_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.office_high_tech_education2) + rand.Next(3);
                                    num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.office_high_tech_education3) + rand.Next(4);
                                    num = (int)(num * pc_PrivateBuildingAI.office_gen_salary_index); break;
                            }
                            break; //
                        case ItemClass.SubService.CommercialLeisure:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.comm_lei_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.comm_lei_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.comm_lei_education2) + rand.Next(3); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.comm_lei_education3) + rand.Next(4); break;
                            }
                            break; //
                        case ItemClass.SubService.CommercialTourist:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.comm_tou_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.comm_tou_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.comm_tou_education2) + rand.Next(3); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.comm_tou_education3) + rand.Next(4); break;
                            }
                            break; //
                        case ItemClass.SubService.CommercialEco:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.comm_eco_education0) + rand.Next(1); break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.comm_eco_education1) + rand.Next(2); break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.comm_eco_education2) + rand.Next(3); break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.comm_eco_education3) + rand.Next(4); break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportBus:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_bus_education0) + rand.Next(1); PublicTransport_bus += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_bus_education1) + rand.Next(2); PublicTransport_bus += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_bus_education2) + rand.Next(3); PublicTransport_bus += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_bus_education3) + rand.Next(4); PublicTransport_bus += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportTram:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_tram_education0) + rand.Next(1); PublicTransport_tram += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_tram_education1) + rand.Next(2); PublicTransport_tram += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_tram_education2) + rand.Next(3); PublicTransport_tram += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_tram_education3) + rand.Next(4); PublicTransport_tram += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportTrain:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_train_education0) + rand.Next(1); PublicTransport_train += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_train_education1) + rand.Next(2); PublicTransport_train += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_train_education2) + rand.Next(3); PublicTransport_train += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_train_education3) + rand.Next(4); PublicTransport_train += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportTaxi:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_taxi_education0) + rand.Next(1); PublicTransport_taxi += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_taxi_education1) + rand.Next(2); PublicTransport_taxi += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_taxi_education2) + rand.Next(3); PublicTransport_taxi += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_taxi_education3) + rand.Next(4); PublicTransport_taxi += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportShip:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_ship_education0) + rand.Next(1); PublicTransport_ship += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_ship_education1) + rand.Next(2); PublicTransport_ship += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_ship_education2) + rand.Next(3); PublicTransport_ship += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_ship_education3) + rand.Next(4); PublicTransport_ship += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportMetro:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_metro_education0) + rand.Next(1); PublicTransport_metro += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_metro_education1) + rand.Next(2); PublicTransport_metro += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_metro_education2) + rand.Next(3); PublicTransport_metro += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_metro_education3) + rand.Next(4); PublicTransport_metro += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportPlane:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_plane_education0) + rand.Next(1); PublicTransport_plane += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_plane_education1) + rand.Next(2); PublicTransport_plane += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_plane_education2) + rand.Next(3); PublicTransport_plane += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_plane_education3) + rand.Next(4); PublicTransport_plane += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportCableCar:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_cablecar_education0) + rand.Next(1); PublicTransport_cablecar += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_cablecar_education1) + rand.Next(2); PublicTransport_cablecar += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_cablecar_education2) + rand.Next(3); PublicTransport_cablecar += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_cablecar_education3) + rand.Next(4); PublicTransport_cablecar += num; break;
                            }
                            break; //
                        case ItemClass.SubService.PublicTransportMonorail:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PublicTransport_monorail_education0) + rand.Next(1); PublicTransport_monorail += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PublicTransport_monorail_education1) + rand.Next(2); PublicTransport_monorail += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PublicTransport_monorail_education2) + rand.Next(3); PublicTransport_monorail += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PublicTransport_monorail_education3) + rand.Next(4); PublicTransport_monorail += num; break;
                            }
                            break; //
                        default: break;
                    }
                    switch (Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_service)
                    {
                        case ItemClass.Service.Disaster:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.disaster_education0) + rand.Next(1); Disaster += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.disaster_education1) + rand.Next(2); Disaster += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.disaster_education2) + rand.Next(3); Disaster += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.disaster_education3) + rand.Next(4); Disaster += num; break;
                            }
                            break; //
                        case ItemClass.Service.PoliceDepartment:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.PoliceDepartment_education0) + rand.Next(1); PoliceDepartment += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.PoliceDepartment_education1) + rand.Next(2); PoliceDepartment += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.PoliceDepartment_education2) + rand.Next(3); PoliceDepartment += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.PoliceDepartment_education3) + rand.Next(4); PoliceDepartment += num; break;
                            }
                            break; //
                        case ItemClass.Service.Education:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.Education_education0) + rand.Next(1); Education += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.Education_education1) + rand.Next(2); Education += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.Education_education2) + rand.Next(3); Education += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.Education_education3) + rand.Next(4); Education += num; break;
                            }
                            break; //
                        case ItemClass.Service.Road:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.road_education0) + rand.Next(1); Road += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.road_education1) + rand.Next(2); Road += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.road_education2) + rand.Next(3); Road += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.road_education3) + rand.Next(4); Road += num; break;
                            }
                            break; //
                        case ItemClass.Service.Garbage:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.Garbage_education0) + rand.Next(1); Garbage += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.Garbage_education1) + rand.Next(2); Garbage += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.Garbage_education2) + rand.Next(3); Garbage += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.Garbage_education3) + rand.Next(4); Garbage += num; break;
                            }
                            break; //
                        case ItemClass.Service.HealthCare:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.HealthCare_education0) + rand.Next(1); HealthCare += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.HealthCare_education1) + rand.Next(2); HealthCare += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.HealthCare_education2) + rand.Next(3); HealthCare += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.HealthCare_education3) + rand.Next(4); HealthCare += num; break;
                            }
                            break; //
                        case ItemClass.Service.Beautification:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.Beautification_education0) + rand.Next(1); Beautification += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.Beautification_education1) + rand.Next(2); Beautification += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.Beautification_education2) + rand.Next(3); Beautification += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.Beautification_education3) + rand.Next(4); Beautification += num; break;
                            }
                            break; //
                        case ItemClass.Service.Monument:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.Monument_education0) + rand.Next(1); Monument += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.Monument_education1) + rand.Next(2); Monument += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.Monument_education2) + rand.Next(3); Monument += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.Monument_education3) + rand.Next(4); Monument += num; break;
                            }
                            break;
                        case ItemClass.Service.Water:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.Water_education0) + rand.Next(1); Water += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.Water_education1) + rand.Next(2); Water += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.Water_education2) + rand.Next(3); Water += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.Water_education3) + rand.Next(4); Water += num; break;
                            }
                            break; //
                        case ItemClass.Service.Electricity:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.Electricity_education0) + rand.Next(1); Electricity = +num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.Electricity_education1) + rand.Next(2); Electricity = +num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.Electricity_education2) + rand.Next(3); Electricity = +num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.Electricity_education3) + rand.Next(4); Electricity = +num; break;
                            }
                            break; //
                        case ItemClass.Service.FireDepartment:
                            switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel)
                            {
                                case Citizen.Education.Uneducated:
                                    num = num + (int)(comm_data.FireDepartment_education0) + rand.Next(1); FireDepartment += num; break;
                                case Citizen.Education.OneSchool:
                                    num = num + (int)(comm_data.FireDepartment_education1) + rand.Next(2); FireDepartment += num; break;
                                case Citizen.Education.TwoSchools:
                                    num = num + (int)(comm_data.FireDepartment_education2) + rand.Next(3); FireDepartment += num; break;
                                case Citizen.Education.ThreeSchools:
                                    num = num + (int)(comm_data.FireDepartment_education3) + rand.Next(4); FireDepartment += num; break;
                            }
                            break; //
                        default:
                            break;
                    }
                    if (num == 0)
                    {
                        DebugLog.LogToFileOnly("find unknown citizen workbuilding" + " building servise is" + Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_service + " building subservice is" + Singleton<BuildingManager>.instance.m_buildings.m_buffer[work_building].Info.m_class.m_subService);
                    }
                }//if (citizen_id != 0u)
            }


            if (comm_data.building_money[Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_workBuilding] < 0)
            {
                num = (int)((float)num * comm_data.salary_idex / 2 + 0.5f);
                /*if (Singleton<BuildingManager>.instance.m_buildings.m_buffer[Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_workBuilding].Info.m_class.m_service == ItemClass.Service.Commercial)
                {
                    num = num /2;
                }

                if (Singleton<BuildingManager>.instance.m_buildings.m_buffer[Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_workBuilding].Info.m_class.m_service == ItemClass.Service.Industrial)
                {
                    num = num - rand.Next((int)(Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].EducationLevel + 1));
                }*/
            }
            else
            {
                num = (int)((float)num * comm_data.salary_idex + 0.5f);
            }
            return num;
        }//public

        public byte process_citizen(uint homeID, ref CitizenUnit data)
        {
            //DebugLog.LogToFileOnly("we go in now, pc_ResidentAI");
            if (precitizenid > homeID)
            {
                //citizen_process_done = true;
                comm_data.family_count = family_count;
                comm_data.family_profit_money_num = family_profit_money_num;
                comm_data.family_loss_money_num = family_loss_money_num;
                if (family_count != 0)
                {
                    comm_data.citizen_salary_per_family = (int)((citizen_salary_count / family_count));
                    comm_data.citizen_outcome_per_family = (int)((citizen_outcome_count / family_count));
                }
                comm_data.citizen_outcome = citizen_outcome_count;
                comm_data.citizen_salary_tax_total = citizen_salary_count;
                comm_data.Monument = Monument;
                comm_data.PublicTransport_bus = PublicTransport_bus;
                comm_data.PublicTransport_tram = PublicTransport_tram;
                comm_data.PublicTransport_train = PublicTransport_train;
                comm_data.PublicTransport_taxi = PublicTransport_taxi;
                comm_data.PublicTransport_metro = PublicTransport_metro;
                comm_data.PublicTransport_plane = PublicTransport_plane;
                comm_data.PublicTransport_ship = PublicTransport_ship;
                comm_data.PublicTransport_monorail = PublicTransport_monorail;
                comm_data.PublicTransport_cablecar = PublicTransport_cablecar;
                comm_data.Beautification = Beautification;
                comm_data.Education = Education;
                comm_data.Disaster = Disaster;
                comm_data.PoliceDepartment = PoliceDepartment;
                comm_data.Electricity = Electricity;
                comm_data.Water = Water;
                comm_data.Garbage = Garbage;
                comm_data.HealthCare = HealthCare;
                comm_data.Road = Road;
                comm_data.FireDepartment = FireDepartment;
                comm_data.family_weight_stable_high = family_weight_stable_high;
                comm_data.family_weight_stable_low = family_weight_stable_low;
                family_profit_money_num = 0;
                family_loss_money_num = 0;
                family_count = 0;
                citizen_salary_count = 0;
                citizen_outcome_count = 0;
                citizen_salary_tax_total = 0;
                temp_citizen_salary_tax_total = 0f;
                PublicTransport_bus = 0;
                PublicTransport_tram = 0;
                PublicTransport_train = 0;
                PublicTransport_ship = 0;
                PublicTransport_taxi = 0;
                PublicTransport_metro = 0;
                PublicTransport_plane = 0;
                PublicTransport_monorail = 0;
                PublicTransport_cablecar = 0;
                Road = 0;
                FireDepartment = 0;
                Education = 0;
                Disaster = 0;
                HealthCare = 0;
                PoliceDepartment = 0;
                Electricity = 0;
                Water = 0;
                Beautification = 0;
                Garbage = 0;
                Monument = 0;
                family_weight_stable_high = 0;
                family_weight_stable_low = 0;
            }
            else if (precitizenid < homeID)
            {
                //citizen_process_done = false;
                family_count++;
            }

            if (homeID > 524288)
            {
                DebugLog.LogToFileOnly("Error: citizen ID greater than 524288");
            }

            //here we caculate citizen income
            int temp_num;
            temp_num = citizen_salary(data.m_citizen0);
            temp_num = temp_num + citizen_salary(data.m_citizen1);
            temp_num = temp_num + citizen_salary(data.m_citizen2);
            temp_num = temp_num + citizen_salary(data.m_citizen3);
            temp_num = temp_num + citizen_salary(data.m_citizen4);
            //DebugLog.LogToFileOnly("Citzen " + homeID.ToString() + "salary is " + temp_num.ToString());
            citizen_salary_count = citizen_salary_count + temp_num;
            int citizen_salary_current = temp_num;
            temp_num = 0;

            if (data.m_citizen0 != 0u)
            {
                temp_num++;
            }
            if (data.m_citizen1 != 0u)
            {
                temp_num++;
            }

            if (data.m_citizen2 != 0u)
            {
                temp_num++;
            }

            if (data.m_citizen3 != 0u)
            {
                temp_num++;
            }

            if (data.m_citizen4 != 0u)
            {
                temp_num++;
            }
            //caculate tax
            float salary_per_family_member;
            if (temp_num != 0)
            {
                salary_per_family_member = (float)citizen_salary_current / temp_num;
            }
            else
            {
                salary_per_family_member = 0;
                DebugLog.LogToFileOnly("temp_num == 0 in ResidentAI");
            }
            float tax = 0;
            //0-10 10% 10-20 20% 20-30 30% >30 40%
            if (salary_per_family_member < 10)
            {
                tax = salary_per_family_member * 0.1f;
            }
            else if (salary_per_family_member >= 10 && salary_per_family_member <= 20)
            {
                tax = (salary_per_family_member - 10) * 0.2f + 1f;
            }
            else if (salary_per_family_member > 20 && salary_per_family_member <= 30)
            {
                tax = (salary_per_family_member - 20) * 0.3f + 3f;
            }
            else if (salary_per_family_member > 30)
            {
                tax = (salary_per_family_member - 30) * 0.4f + 6f;
            }
            temp_citizen_salary_tax_total = temp_citizen_salary_tax_total + tax;
            citizen_salary_tax_total = (int)temp_citizen_salary_tax_total;
            process_citizen_income_tax(homeID, tax);
            //here we caculate outcome
            temp_num = 0;
            int outcomerate = 0;
            CitizenManager instance = Singleton<CitizenManager>.instance;
            uint num3 = 0u;
            int num4 = 0;
            if (data.m_citizen4 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen4)].Dead)
            {
                num4++;
                num3 = data.m_citizen4;
                outcomerate = 0;
                temp_num += GetOutcomeRate(data.m_citizen4, out outcomerate);
            }
            if (data.m_citizen3 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen3)].Dead)
            {
                num4++;
                num3 = data.m_citizen3;
                outcomerate = 0;
                temp_num += GetOutcomeRate(data.m_citizen3, out outcomerate);
            }
            if (data.m_citizen2 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen2)].Dead)
            {
                num4++;
                num3 = data.m_citizen2;
                outcomerate = 0;
                temp_num += GetOutcomeRate(data.m_citizen2, out outcomerate);
            }
            if (data.m_citizen1 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen1)].Dead)
            {
                num4++;
                num3 = data.m_citizen1;
                outcomerate = 0;
                temp_num += GetOutcomeRate(data.m_citizen1, out outcomerate);
            }
            if (data.m_citizen0 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen0)].Dead)
            {
                num4++;
                num3 = data.m_citizen0;
                outcomerate = 0;
                temp_num += GetOutcomeRate(data.m_citizen0, out outcomerate);
            }


            //temp = education&sick   outcomerate = house rent(one family)
            process_citizen_house_rent(homeID, outcomerate);
            citizen_outcome_count = citizen_outcome_count + temp_num + outcomerate;

            //income - outcome
            temp_num = citizen_salary_current - (int)(tax + 0.5f) - temp_num;// - comm_data.citizen_average_transport_fee;
            comm_data.citizen_money[homeID] = (short)(comm_data.citizen_money[homeID] + temp_num);
            //set other non-exist citizen status to 0
            uint i;
            if (precitizenid < homeID)
            {
                for (i = (precitizenid + 1); i < homeID; i++)
                {
                    if ((comm_data.citizen_money[i] != 0) || (comm_data.citizen_profit_status[i] != 128))
                    {
                        comm_data.citizen_money[i] = 0;
                        comm_data.citizen_profit_status[i] = 128;
                    }
                }
            }
            precitizenid = homeID;
            //process citizen status
            System.Random rand = new System.Random();
            if (temp_num <= 0)
            {
                temp_num = rand.Next(5);
                family_loss_money_num = (uint)(family_loss_money_num + 1);
                comm_data.citizen_profit_status[homeID]--;
                //try_move_family to do here;
            }
            else if (temp_num > 30)
            {
                temp_num = 20 + rand.Next(10);
                family_very_profit_money_num = (uint)(family_very_profit_money_num + 1);
                comm_data.citizen_profit_status[homeID]++;
            }
            else
            {
                temp_num = (temp_num - rand.Next(5) > 5) ? (temp_num - rand.Next(5)) : 5;
                family_profit_money_num = (uint)(family_profit_money_num + 1);
            }

            if (comm_data.citizen_money[homeID] > 30000)
            {
                comm_data.citizen_money[homeID] = 30000;
            }

            if (comm_data.citizen_profit_status[homeID] > 250)
            {
                comm_data.citizen_profit_status[homeID] = 250;
            }
            if (comm_data.citizen_profit_status[homeID] < 5)
            {
                comm_data.citizen_profit_status[homeID] = 5;
            }

            ItemClass.Level home_level = Singleton<BuildingManager>.instance.m_buildings.m_buffer[Singleton<CitizenManager>.instance.m_units.m_buffer[(int)((UIntPtr)homeID)].m_building].Info.m_class.m_level;
            if ((comm_data.citizen_money[homeID] > 0) && (comm_data.citizen_profit_status[homeID] >= 230))
            {
                family_weight_stable_high = (ushort)(family_weight_stable_high + 1);
                if ((home_level == ItemClass.Level.Level1) || (home_level == ItemClass.Level.Level2) || (home_level == ItemClass.Level.Level3))
                {
                    if (rand.Next(20) < 20)
                    {
                        if (num3 != 0u)
                        {
                            TryMoveFamily_1(homeID, num3, ref instance.m_citizens.m_buffer[(int)((UIntPtr)num3)], num4);
                        }
                    }
                }
                //change wealth to high
                //try move family here (1、2、3 level house to 4-5 level house)
            }
            else if ((comm_data.citizen_money[homeID] <= 0) && (comm_data.citizen_profit_status[homeID] <= 25))
            {
                if ((home_level == ItemClass.Level.Level2) || (home_level == ItemClass.Level.Level3) || (home_level == ItemClass.Level.Level4) || (home_level == ItemClass.Level.Level5))
                {
                    if (rand.Next(20) < 20)
                    {
                        if (num3 != 0u)
                        {
                            TryMoveFamily_1(homeID, num3, ref instance.m_citizens.m_buffer[(int)((UIntPtr)num3)], num4);
                        }
                    }
                }
                //change wealth to low
                //try move family here try move family here (2-5 level house to 1 level house)
            }
            else if (comm_data.citizen_money[homeID] > 0)
            {
                if (home_level == ItemClass.Level.Level1)
                {
                    if (rand.Next(50) < 50)
                    {
                        if (num3 != 0u)
                        {
                            TryMoveFamily_1(homeID, num3, ref instance.m_citizens.m_buffer[(int)((UIntPtr)num3)], num4);
                        }
                    }
                }
                else if ((home_level == ItemClass.Level.Level4) || (home_level == ItemClass.Level.Level5))
                {
                    if (rand.Next(50) < 50)
                    {
                        if (num3 != 0u)
                        {
                            TryMoveFamily_1(homeID, num3, ref instance.m_citizens.m_buffer[(int)((UIntPtr)num3)], num4);
                        }
                    }
                }
                //change wealth to medium if wealth is low
                //change wealth to medium if wealth is high
                //by move family;
            }
            else if (comm_data.citizen_money[homeID] <= 0)
            {

            }
            else
            {
                //just keep;
            }

            if (comm_data.citizen_money[homeID] < 0)
            {
                family_weight_stable_low = (ushort)(family_weight_stable_low + 1);
            }

            comm_data.citizen_money[homeID] = (short)(comm_data.citizen_money[homeID] - temp_num);

            //comm_data.citizen_shopping_idex = (byte)temp_num;
            return (byte)temp_num;
            //return to original game code.
        }

        public void TryMoveFamily_1(uint homeID, uint citizenID, ref Citizen data, int familySize)
        {
            if (data.Dead)
            {
                return;
            }
            if (data.m_homeBuilding == 0)
            {
                return;
            }
            TransferManager.TransferOffer offer = default(TransferManager.TransferOffer);
            offer.Priority = Singleton<SimulationManager>.instance.m_randomizer.Int32(1, 7);
            offer.Citizen = citizenID;
            offer.Position = Singleton<BuildingManager>.instance.m_buildings.m_buffer[(int)data.m_homeBuilding].m_position;
            offer.Amount = 1;
            offer.Active = true;
            if (familySize == 1)
            {
                if (Singleton<SimulationManager>.instance.m_randomizer.Int32(2u) == 0)
                {
                    switch (data.EducationLevel)
                    {
                        case Citizen.Education.Uneducated:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single0, offer);
                            break;
                        case Citizen.Education.OneSchool:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single1, offer);
                            break;
                        case Citizen.Education.TwoSchools:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single2, offer);
                            break;
                        case Citizen.Education.ThreeSchools:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single3, offer);
                            break;
                    }
                }
                else
                {
                    switch (data.EducationLevel)
                    {
                        case Citizen.Education.Uneducated:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single0B, offer);
                            break;
                        case Citizen.Education.OneSchool:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single1B, offer);
                            break;
                        case Citizen.Education.TwoSchools:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single2B, offer);
                            break;
                        case Citizen.Education.ThreeSchools:
                            Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Single3B, offer);
                            break;
                    }
                }
            }
            else
            {
                if (comm_data.citizen_profit_status[homeID] >= 230)
                {
                    Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Family3, offer);
                }
                else if (comm_data.citizen_money[homeID] < 0)
                {
                    Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Family0, offer);
                }
                else if (Singleton<SimulationManager>.instance.m_randomizer.Int32(2u) == 0)
                {
                    Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Family2, offer);
                }
                else
                {
                    Singleton<TransferManager>.instance.AddOutgoingOffer(TransferManager.TransferReason.Family1, offer);
                }
            }
        }

        public void process_citizen_income_tax(uint homeID, float tax)
        {
            CitizenManager instance = Singleton<CitizenManager>.instance;
            ushort building = instance.m_units.m_buffer[(int)((UIntPtr)homeID)].m_building;
            Building buildingdata = Singleton<BuildingManager>.instance.m_buildings.m_buffer[building];
            Singleton<EconomyManager>.instance.AddPrivateIncome((int)(tax + 0.5f), buildingdata.Info.m_class.m_service, buildingdata.Info.m_class.m_subService, buildingdata.Info.m_class.m_level, 112);
        }

        public void process_citizen_house_rent(uint homeID, int outcomerate)
        {
            CitizenManager instance = Singleton<CitizenManager>.instance;
            ushort building = instance.m_units.m_buffer[(int)((UIntPtr)homeID)].m_building;
            Building buildingdata = Singleton<BuildingManager>.instance.m_buildings.m_buffer[building];
            DistrictManager instance2 = Singleton<DistrictManager>.instance;
            byte district = instance2.GetDistrict(buildingdata.m_position);
            DistrictPolicies.Taxation taxationPolicies = instance2.m_districts.m_buffer[(int)district].m_taxationPolicies;
            int num2;
            num2 = Singleton<EconomyManager>.instance.GetTaxRate(this.m_info.m_class, taxationPolicies);
            Singleton<EconomyManager>.instance.AddPrivateIncome(outcomerate, buildingdata.Info.m_class.m_service, buildingdata.Info.m_class.m_subService, buildingdata.Info.m_class.m_level, num2 * 100);
        }


        // ResidentAI
        public void SimulationStep_1(uint homeID, ref CitizenUnit data)
        {
            CitizenManager instance = Singleton<CitizenManager>.instance;
            ushort building = instance.m_units.m_buffer[(int)((UIntPtr)homeID)].m_building;
            if (data.m_citizen0 != 0u && data.m_citizen1 != 0u && (data.m_citizen2 == 0u || data.m_citizen3 == 0u || data.m_citizen4 == 0u))
            {
                bool flag = this.CanMakeBabies(data.m_citizen0, ref instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen0)]);
                bool flag2 = this.CanMakeBabies(data.m_citizen1, ref instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen1)]);
                if (flag && flag2 && Singleton<SimulationManager>.instance.m_randomizer.Int32(12u) == 0)
                {
                    int family = (int)instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen0)].m_family;
                    uint num;
                    if (instance.CreateCitizen(out num, 0, family, ref Singleton<SimulationManager>.instance.m_randomizer))
                    {
                        instance.m_citizens.m_buffer[(int)((UIntPtr)num)].SetHome(num, 0, homeID);
                        Citizen[] expr_126_cp_0 = instance.m_citizens.m_buffer;
                        UIntPtr expr_126_cp_1 = (UIntPtr)num;
                        expr_126_cp_0[(int)expr_126_cp_1].m_flags = (expr_126_cp_0[(int)expr_126_cp_1].m_flags | Citizen.Flags.Original);
                        if (building != 0)
                        {
                            DistrictManager instance2 = Singleton<DistrictManager>.instance;
                            Vector3 position = Singleton<BuildingManager>.instance.m_buildings.m_buffer[(int)building].m_position;
                            byte district = instance2.GetDistrict(position);
                            District[] expr_183_cp_0_cp_0 = instance2.m_districts.m_buffer;
                            byte expr_183_cp_0_cp_1 = district;
                            expr_183_cp_0_cp_0[(int)expr_183_cp_0_cp_1].m_birthData.m_tempCount = expr_183_cp_0_cp_0[(int)expr_183_cp_0_cp_1].m_birthData.m_tempCount + 1u;
                        }
                    }
                }
            }
            if (data.m_citizen0 != 0u && data.m_citizen1 == 0u)
            {
                this.TryFindPartner(data.m_citizen0, ref instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen0)]);
            }
            else if (data.m_citizen1 != 0u && data.m_citizen0 == 0u)
            {
                this.TryFindPartner(data.m_citizen1, ref instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen1)]);
            }
            if (data.m_citizen2 != 0u)
            {
                this.TryMoveAwayFromHome(data.m_citizen2, ref instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen2)]);
            }
            if (data.m_citizen3 != 0u)
            {
                this.TryMoveAwayFromHome(data.m_citizen3, ref instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen3)]);
            }
            if (data.m_citizen4 != 0u)
            {
                this.TryMoveAwayFromHome(data.m_citizen4, ref instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen4)]);
            }
            int temp_num = process_citizen(homeID, ref data);
            data.m_goods = (ushort)Mathf.Max(0, (int)(data.m_goods - temp_num)); //here we can adjust demand
            if (data.m_goods < 200)
            {
                int num2 = Singleton<SimulationManager>.instance.m_randomizer.Int32(5u);
                for (int i = 0; i < 5; i++)
                {
                    uint citizen = data.GetCitizen((num2 + i) % 5);
                    if (citizen != 0u)
                    {
                        Citizen[] expr_2FA_cp_0 = instance.m_citizens.m_buffer;
                        UIntPtr expr_2FA_cp_1 = (UIntPtr)citizen;
                        expr_2FA_cp_0[(int)expr_2FA_cp_1].m_flags = (expr_2FA_cp_0[(int)expr_2FA_cp_1].m_flags | Citizen.Flags.NeedGoods);
                        break;
                    }
                }
            }
            if (building != 0 && (Singleton<BuildingManager>.instance.m_buildings.m_buffer[(int)building].m_problems & (Notification.Problem.MajorProblem | Notification.Problem.FatalProblem)) != Notification.Problem.None)
            {
                uint num3 = 0u;
                int num4 = 0;
                if (data.m_citizen4 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen4)].Dead)
                {
                    num4++;
                    num3 = data.m_citizen4;
                }
                if (data.m_citizen3 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen3)].Dead)
                {
                    num4++;
                    num3 = data.m_citizen3;
                }
                if (data.m_citizen2 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen2)].Dead)
                {
                    num4++;
                    num3 = data.m_citizen2;
                }
                if (data.m_citizen1 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen1)].Dead)
                {
                    num4++;
                    num3 = data.m_citizen1;
                }
                if (data.m_citizen0 != 0u && !instance.m_citizens.m_buffer[(int)((UIntPtr)data.m_citizen0)].Dead)
                {
                    num4++;
                    num3 = data.m_citizen0;
                }
                if (num3 != 0u)
                {
                    this.TryMoveFamily_1(homeID, num3, ref instance.m_citizens.m_buffer[(int)((UIntPtr)num3)], num4);
                }
            }
        }

        public int GetOutcomeRate(uint citizen_id, out int incomeAccumulation)
        {
            BuildingManager instance1 = Singleton<BuildingManager>.instance;
            CitizenManager instance2 = Singleton<CitizenManager>.instance;
            ItemClass @class = instance1.m_buildings.m_buffer[instance2.m_citizens.m_buffer[citizen_id].m_homeBuilding].Info.m_class;
            incomeAccumulation = 0;
            DistrictManager instance = Singleton<DistrictManager>.instance;
            byte district = instance.GetDistrict(instance1.m_buildings.m_buffer[instance2.m_citizens.m_buffer[citizen_id].m_homeBuilding].m_position);
            DistrictPolicies.Taxation taxationPolicies = instance.m_districts.m_buffer[(int)district].m_taxationPolicies;
            if (@class.m_subService == ItemClass.SubService.ResidentialLow)
            {
                switch (@class.m_level)
                {
                    case ItemClass.Level.Level1:
                        incomeAccumulation = comm_data.resident_low_level1_rent;
                        break;
                    case ItemClass.Level.Level2:
                        incomeAccumulation = comm_data.resident_low_level2_rent;
                        break;
                    case ItemClass.Level.Level3:
                        incomeAccumulation = comm_data.resident_low_level3_rent;
                        break;
                    case ItemClass.Level.Level4:
                        incomeAccumulation = comm_data.resident_low_level4_rent;
                        break;
                    case ItemClass.Level.Level5:
                        incomeAccumulation = comm_data.resident_low_level5_rent;
                        break;
                }
            }
            else if (@class.m_subService == ItemClass.SubService.ResidentialLowEco)
            {
                switch (@class.m_level)
                {
                    case ItemClass.Level.Level1:
                        incomeAccumulation = comm_data.resident_low_eco_level1_rent;
                        break;
                    case ItemClass.Level.Level2:
                        incomeAccumulation = comm_data.resident_low_eco_level2_rent;
                        break;
                    case ItemClass.Level.Level3:
                        incomeAccumulation = comm_data.resident_low_eco_level3_rent;
                        break;
                    case ItemClass.Level.Level4:
                        incomeAccumulation = comm_data.resident_low_eco_level4_rent;
                        break;
                    case ItemClass.Level.Level5:
                        incomeAccumulation = comm_data.resident_low_eco_level5_rent;
                        break;
                }
            }
            else if (@class.m_subService == ItemClass.SubService.ResidentialHigh)
            {
                switch (@class.m_level)
                {
                    case ItemClass.Level.Level1:
                        incomeAccumulation = comm_data.resident_high_level1_rent;
                        break;
                    case ItemClass.Level.Level2:
                        incomeAccumulation = comm_data.resident_high_level2_rent;
                        break;
                    case ItemClass.Level.Level3:
                        incomeAccumulation = comm_data.resident_high_level3_rent;
                        break;
                    case ItemClass.Level.Level4:
                        incomeAccumulation = comm_data.resident_high_level4_rent;
                        break;
                    case ItemClass.Level.Level5:
                        incomeAccumulation = comm_data.resident_high_level5_rent;
                        break;
                }
            }
            else
            {
                switch (@class.m_level)
                {
                    case ItemClass.Level.Level1:
                        incomeAccumulation = comm_data.resident_high_eco_level1_rent;
                        break;
                    case ItemClass.Level.Level2:
                        incomeAccumulation = comm_data.resident_high_eco_level2_rent;
                        break;
                    case ItemClass.Level.Level3:
                        incomeAccumulation = comm_data.resident_high_eco_level3_rent;
                        break;
                    case ItemClass.Level.Level4:
                        incomeAccumulation = comm_data.resident_high_eco_level4_rent;
                        break;
                    case ItemClass.Level.Level5:
                        incomeAccumulation = comm_data.resident_high_eco_level5_rent;
                        break;
                }
            }
            int temp = 0;
            if (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_flags == Citizen.Flags.Student)
            {
                temp = temp + 5;
            }

            if (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizen_id].m_flags == Citizen.Flags.Sick)
            {
                temp = temp + 5;
            }
            int num2;
            num2 = Singleton<EconomyManager>.instance.GetTaxRate(this.m_info.m_class, taxationPolicies);
            incomeAccumulation = (int)(num2 * incomeAccumulation * ((float)(instance.m_districts.m_buffer[(int)district].GetLandValue() + 50) / 10000));
            //temp = temp
            return temp;
        }

        public VehicleInfo GetVehicleInfo_impl(ushort instanceID, ref CitizenInstance citizenData, bool forceProbability)
        {
            return base.GetVehicleInfo(instanceID, ref citizenData, forceProbability);
        }

    }
}


namespace RealCity
{
    public class pc_ResidentAI_1 : HumanAI
    {
        protected override bool StartPathFind(ushort instanceID, ref CitizenInstance citizenData)
        {
            ushort temp_parked_car = 0;
            CitizenManager instance = Singleton<CitizenManager>.instance;
            VehicleManager instance2 = Singleton<VehicleManager>.instance;
            uint citizen1 = citizenData.m_citizen;
            ushort homeBuilding = instance.m_citizens.m_buffer[(int)((UIntPtr)citizen1)].m_homeBuilding;
            BuildingManager instance3 = Singleton<BuildingManager>.instance;
            uint homeid = instance.m_citizens.m_buffer[citizen1].GetContainingUnit(citizen1, instance3.m_buildings.m_buffer[(int)homeBuilding].m_citizenUnits, CitizenUnit.Flags.Home);
            ushort vehicle = instance.m_citizens.m_buffer[(int)((UIntPtr)citizenData.m_citizen)].m_vehicle;
            Randomizer randomizer = new Randomizer(citizen1);
            if (citizenData.m_citizen != 0u)
            {
                if (vehicle != 0 && (comm_data.citizen_money[homeid] > 0 || instance2.m_vehicles.m_buffer[vehicle].Info.m_vehicleType != VehicleInfo.VehicleType.Car))
                {
                    VehicleInfo info = instance2.m_vehicles.m_buffer[(int)vehicle].Info;
                    if (info != null)
                    {
                        uint citizen = info.m_vehicleAI.GetOwnerID(vehicle, ref instance2.m_vehicles.m_buffer[(int)vehicle]).Citizen;
                        if (citizen == citizenData.m_citizen)
                        {
                            info.m_vehicleAI.SetTarget(vehicle, ref instance2.m_vehicles.m_buffer[(int)vehicle], 0);
                            return false;
                        }
                    }
                    instance.m_citizens.m_buffer[(int)((UIntPtr)citizenData.m_citizen)].SetVehicle(citizenData.m_citizen, 0, 0u);
                    return false;
                }
                else if (comm_data.citizen_money[homeid] <= 0)
                {
                    VehicleInfo info1 = instance2.m_vehicles.m_buffer[(int)vehicle].Info;
                    if (info1 != null)
                    {
                        //DebugLog.LogToFileOnly("citizen too poor, and give up his car");
                        instance.m_citizens.m_buffer[(int)((UIntPtr)citizenData.m_citizen)].SetVehicle(citizenData.m_citizen, 0, 0u);
                        instance2.m_vehicles.m_buffer[(int)vehicle].m_citizenUnits = 0;
                        instance2.ReleaseVehicle(vehicle);
                    }
                    else
                    {
                        instance.m_citizens.m_buffer[(int)((UIntPtr)citizenData.m_citizen)].SetVehicle(citizenData.m_citizen, 0, 0u);
                        return false;
                    }
                }
            }
            if (citizenData.m_targetBuilding != 0)
            {
                VehicleInfo vehicleInfo;
                vehicleInfo = CustomGetVehicleInfo(instanceID, ref citizenData, false);
                if (comm_data.citizen_money[homeid] > 0)
                {
                    if (instance.m_citizens.m_buffer[citizen1].m_parkedVehicle != 0)
                    {
                        if (vehicleInfo == Singleton<VehicleManager>.instance.m_parkedVehicles.m_buffer[(int)instance.m_citizens.m_buffer[citizen1].m_parkedVehicle].Info)
                        {
                            //instance.m_citizens.m_buffer[citizen1].SetParkedVehicle(citizenData.m_citizen, 0);
                            //DebugLog.LogToFileOnly("find his packed car");
                        }
                    }
                    //DebugLog.LogToFileOnly("GetVehicleInfo" + Environment.StackTrace);
                }
                else
                {
                    if (vehicleInfo == Singleton<VehicleManager>.instance.m_parkedVehicles.m_buffer[(int)instance.m_citizens.m_buffer[citizen1].m_parkedVehicle].Info)
                    {
                        if (instance.m_citizens.m_buffer[citizen1].CurrentLocation == Citizen.Location.Home)
                        {
                            temp_parked_car = instance.m_citizens.m_buffer[citizen1].m_parkedVehicle;
                            instance.m_citizens.m_buffer[citizen1].m_parkedVehicle = 0;
                            //DebugLog.LogToFileOnly("citizen too poor and do not want to use car and stay car near his home");
                            if (randomizer.Int32(100u) < 50)
                            {
                                vehicleInfo = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref randomizer, ItemClass.Service.Residential, ItemClass.SubService.ResidentialHigh, (citizenData.Info.m_agePhase != Citizen.AgePhase.Child) ? ItemClass.Level.Level2 : ItemClass.Level.Level1);
                            }
                            else
                            {
                                vehicleInfo = null;
                            }
                        }                        
                    }
                    else
                    {
                        if (randomizer.Int32(100u) < 50)
                        {
                            vehicleInfo = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref randomizer, ItemClass.Service.Residential, ItemClass.SubService.ResidentialHigh, (citizenData.Info.m_agePhase != Citizen.AgePhase.Child) ? ItemClass.Level.Level2 : ItemClass.Level.Level1);
                        }
                        else
                        {
                            vehicleInfo = null;
                        }
                    }
                }
                BuildingInfo info2 = instance3.m_buildings.m_buffer[(int)citizenData.m_targetBuilding].Info;
                randomizer = new Randomizer((int)instanceID << 8 | (int)citizenData.m_targetSeed);
                Vector3 vector;
                Vector3 endPos;
                Vector2 vector2;
                CitizenInstance.Flags flags;
                info2.m_buildingAI.CalculateUnspawnPosition(citizenData.m_targetBuilding, ref instance3.m_buildings.m_buffer[(int)citizenData.m_targetBuilding], ref randomizer, this.m_info, instanceID, out vector, out endPos, out vector2, out flags);
                
                bool return_value_tmp = base.StartPathFind(instanceID, ref citizenData, citizenData.m_targetPos, endPos, vehicleInfo);
                if (temp_parked_car != 0)
                {
                    instance.m_citizens.m_buffer[citizen1].m_parkedVehicle = temp_parked_car;
                    //after caculate path, return parked_car to citizen
                }
                return return_value_tmp;
            }
            return false;
        }

        public VehicleInfo CustomGetVehicleInfo(ushort instanceID, ref CitizenInstance citizenData, bool forceCar)
        {
            if (citizenData.m_citizen == 0u)
            {
                return null;
            }
            bool flag = false;
            if (ExtCitizenInstanceManager.Instance.ExtInstances[(int)instanceID].pathMode == ExtCitizenInstance.ExtPathMode.TaxiToTarget)
            {
                flag = true;
            }
            Citizen.AgeGroup ageGroup = GetAgeGroup(citizenData.Info.m_agePhase);
            int num;
            int num2;
            int num3;
            if (flag)
            {
                num = 0;
                num2 = 0;
                num3 = 100;
            }
            else if (forceCar || (citizenData.m_flags & CitizenInstance.Flags.BorrowCar) != CitizenInstance.Flags.None)
            {
                num = 100;
                num2 = 0;
                num3 = 0;
            }
            else
            {
                num = this.GetCarProbability(instanceID, ref citizenData, ageGroup);
                num2 = this.GetBikeProbability(instanceID, ref citizenData, ageGroup);
                num3 = this.GetTaxiProbability(instanceID, ref citizenData, ageGroup);
            }
            Randomizer randomizer = new Randomizer(citizenData.m_citizen);
            bool flag2 = randomizer.Int32(100u) < num;
            bool flag3 = !flag2 && randomizer.Int32(100u) < num2;
            bool flag4 = !flag2 && !flag3 && randomizer.Int32(100u) < num3;
            bool flag5 = false;
            if (flag2)
            {
                int electricCarProbability = this.GetElectricCarProbability(instanceID, ref citizenData, this.m_info.m_agePhase);
                flag5 = (randomizer.Int32(100u) < electricCarProbability);
            }
            ItemClass.Service service = ItemClass.Service.Residential;
            ItemClass.SubService subService = flag5 ? ItemClass.SubService.ResidentialLowEco : ItemClass.SubService.ResidentialLow;
            if (flag4)
            {
                service = ItemClass.Service.PublicTransport;
                subService = ItemClass.SubService.PublicTransportTaxi;
            }
            VehicleInfo vehicleInfo = null;
            if (flag2)
            {
                ushort parkedVehicle = Singleton<CitizenManager>.instance.m_citizens.m_buffer[(int)citizenData.m_citizen].m_parkedVehicle;
                if (parkedVehicle != 0)
                {
                    vehicleInfo = Singleton<VehicleManager>.instance.m_parkedVehicles.m_buffer[(int)parkedVehicle].Info;
                }
            }
            if (vehicleInfo == null && (flag2 | flag4))
            {
                vehicleInfo = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref randomizer, service, subService, ItemClass.Level.Level1);
            }
            if (flag3)
            {
                VehicleInfo randomVehicleInfo = Singleton<VehicleManager>.instance.GetRandomVehicleInfo(ref randomizer, ItemClass.Service.Residential, ItemClass.SubService.ResidentialHigh, (ageGroup != Citizen.AgeGroup.Child) ? ItemClass.Level.Level2 : ItemClass.Level.Level1);
                if (randomVehicleInfo != null)
                {
                    return randomVehicleInfo;
                }
            }
            if ((flag2 | flag4) && vehicleInfo != null)
            {
                return vehicleInfo;
            }
            return null;
        }

        internal static Citizen.AgeGroup GetAgeGroup(Citizen.AgePhase agePhase)
        {
            switch (agePhase)
            {
                case Citizen.AgePhase.Child:
                    return Citizen.AgeGroup.Child;
                case Citizen.AgePhase.Teen0:
                case Citizen.AgePhase.Teen1:
                    return Citizen.AgeGroup.Teen;
                case Citizen.AgePhase.Young0:
                case Citizen.AgePhase.Young1:
                case Citizen.AgePhase.Young2:
                    return Citizen.AgeGroup.Young;
                case Citizen.AgePhase.Adult0:
                case Citizen.AgePhase.Adult1:
                case Citizen.AgePhase.Adult2:
                case Citizen.AgePhase.Adult3:
                    return Citizen.AgeGroup.Adult;
                case Citizen.AgePhase.Senior0:
                case Citizen.AgePhase.Senior1:
                case Citizen.AgePhase.Senior2:
                case Citizen.AgePhase.Senior3:
                    return Citizen.AgeGroup.Senior;
                default:
                    return Citizen.AgeGroup.Adult;
            }
        }

        private int GetTaxiProbability(ushort instanceID, ref CitizenInstance citizenData, Citizen.AgeGroup ageGroup)
        {
            return 20;
        }

        private int GetBikeProbability(ushort instanceID, ref CitizenInstance citizenData, Citizen.AgeGroup ageGroup)
        {
            return 20;
        }

        private int GetCarProbability(ushort instanceID, ref CitizenInstance citizenData, Citizen.AgeGroup ageGroup)
        {
            return 20;
        }

        private int GetElectricCarProbability(ushort instanceID, ref CitizenInstance citizenData, Citizen.AgePhase agePhase)
        {
            return 20;
        }

    }
}
