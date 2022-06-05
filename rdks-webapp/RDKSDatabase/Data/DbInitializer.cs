using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RDKSDatabase.Data;
using RDKSDatabase.Models;
using System;
using System.Linq;

namespace RDKSDatabase.Data
{
    public static class DbInitializer
    {

        public static void Initialize(RDKSDatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Check the database for any existing records
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            // Create mock data for Customer
            var customers = new Customer[]
            {
                new Customer{CUS_ACCNUM="ABCD0123",CUS_COMPNAME="ABC Company Inc", CUS_FNAME="John", CUS_LNAME="Doe",
                    CUS_PHONE="222-333-4567", CUS_EMAIL="jdoe@abccompany.com", CUS_FR=false, CUS_TTS=false, CUS_MEZ=true, CUS_DEACTIVATED_COUNT=0},

                new Customer{CUS_ACCNUM="LASJ1234",CUS_COMPNAME="Construction Co.", CUS_FNAME="Kevin", CUS_LNAME="Smith",
                    CUS_PHONE="234-532-3838", CUS_EMAIL="ksmith@construction.com", CUS_FR=true, CUS_TTS=false, CUS_MEZ=false, CUS_DEACTIVATED_COUNT=1},

                new Customer{CUS_ACCNUM="FJAS2231",CUS_COMPNAME="123 Company Inc", CUS_FNAME="Jane", CUS_LNAME="Doe",
                    CUS_PHONE="432-123-9888", CUS_EMAIL="jdoe@123company.com", CUS_FR=false, CUS_TTS=true, CUS_MEZ=true, CUS_DEACTIVATED_COUNT=0},

                new Customer{CUS_ACCNUM="SFAF8272",CUS_COMPNAME="BCIT Construction", CUS_FNAME="Chris", CUS_LNAME="Adams",
                    CUS_PHONE="563-854-7347", CUS_EMAIL="cadams@bcitcon.com", CUS_FR=false, CUS_TTS=false, CUS_MEZ=true, CUS_DEACTIVATED_COUNT=0},

                new Customer{CUS_ACCNUM="HEEW9188",CUS_COMPNAME="Farms Inc", CUS_FNAME="Taylor", CUS_LNAME="Klein",
                    CUS_PHONE="323-381-5629", CUS_EMAIL="tklein@farmsinc.com", CUS_FR=true, CUS_TTS=false, CUS_MEZ=false, CUS_DEACTIVATED_COUNT=2}
            };

            foreach (Customer c in customers)
            {
                context.Customer.Add(c);
            }
            context.SaveChanges();

            // Create mock data for Address
            var addressses = new Address[]
            {
                new Address{ADDR_STREET="238 King Street",ADDR_CITY="Vancouver",ADDR_PROV="BC", ADDR_POCODE="A1B1C1", CUS_ID=1},
                new Address{ADDR_STREET="58 Queen Street",ADDR_CITY="Burnaby",ADDR_PROV="BC", ADDR_POCODE="A2B4C1", CUS_ID=2},
                new Address{ADDR_STREET="1789 Jack Street",ADDR_CITY="Burnaby",ADDR_PROV="BC", ADDR_POCODE="A4B2C2", CUS_ID=3},
                new Address{ADDR_STREET="83 Tenth Avenue",ADDR_CITY="Vancouver",ADDR_PROV="BC", ADDR_POCODE="B8A3V2", CUS_ID=4},
                new Address{ADDR_STREET="392 Seventh Avenue",ADDR_CITY="Vancouver",ADDR_PROV="BC", ADDR_POCODE="A9D8N2", CUS_ID=5}
            };

            foreach (Address a in addressses)
            {
                context.Address.Add(a);
            }
            context.SaveChanges();


            // Create mock data for Vehicle
            var vehicles = new Vehicle[]
            {
                new Vehicle{LICENSE_PLATE="AB1234", DESCRIPTION="Black F-150", BADGE="00178152", CUS_ID=1},
                new Vehicle{LICENSE_PLATE="BC1234", DESCRIPTION="5 Ton Dump Truck", BADGE="00628451", CUS_ID=2},
                new Vehicle{LICENSE_PLATE="CD2356", DESCRIPTION="2019 Grey Chevy", BADGE="00682133", CUS_ID=3},
                new Vehicle{LICENSE_PLATE="FE1234", DESCRIPTION="2006 GMC Sierra", BADGE="Deactivated", CUS_ID=4},
                new Vehicle{LICENSE_PLATE="BCD234", DESCRIPTION="Ford 350", BADGE="00633212", CUS_ID=5}
            };

            foreach (Vehicle v in vehicles)
            {
                context.Vehicle.Add(v);
            }
            context.SaveChanges();



            // Create mock data for Material
            var materials = new Material[]
            {
                new Material{MaterialCode=44,MaterialType="Asbestos"},
                new Material{MaterialCode=40,MaterialType="DLC Over 5m3"},
                new Material{MaterialCode=45,MaterialType="DLC Concrete - no rebar"},
                new Material{MaterialCode=10,MaterialType="Refuse"},
                new Material{MaterialCode=22,MaterialType="Organic Cleanwood Burn"},
            };

            foreach (Material m in materials)
            {
                context.Material.Add(m);
            }
            context.SaveChanges();


            // Create mock data for ABCRecycling
            var abcRecycling = new ABCRecycling[]
            {
                new ABCRecycling{ABCDateID=new DateTime(2022, 05, 16),ABC_LOCATION="White Rock",ABC_MATERIAL="paper",TOTAL_POUND_NETWEIGHT=1,TOTAL_TONNAGE_NETWEIGHT=2,TOTAL_TONNAGE_MATERIAL=3},
                new ABCRecycling{ABCDateID=new DateTime(2022, 05, 27),ABC_LOCATION="Vancouver",ABC_MATERIAL="paper",TOTAL_POUND_NETWEIGHT=(float)100.35,TOTAL_TONNAGE_NETWEIGHT=2,TOTAL_TONNAGE_MATERIAL=3},
                new ABCRecycling{ABCDateID=new DateTime(2010, 07, 02),ABC_LOCATION="BCIT",ABC_MATERIAL="bottle",TOTAL_POUND_NETWEIGHT=1,TOTAL_TONNAGE_NETWEIGHT=(float)13.45,TOTAL_TONNAGE_MATERIAL=3},
                new ABCRecycling{ABCDateID=new DateTime(2009, 08, 24),ABC_LOCATION="Granville Island",ABC_MATERIAL="glass",TOTAL_POUND_NETWEIGHT=1,TOTAL_TONNAGE_NETWEIGHT=2,TOTAL_TONNAGE_MATERIAL=(float)457.13},
                new ABCRecycling{ABCDateID=new DateTime(2018, 04, 29),ABC_LOCATION="Burnaby",ABC_MATERIAL="bottle",TOTAL_POUND_NETWEIGHT=1,TOTAL_TONNAGE_NETWEIGHT=2,TOTAL_TONNAGE_MATERIAL=3,ABC_COMPLETED=true},
            };

            foreach (ABCRecycling c in abcRecycling)
            {
                context.ABCRecycling.Add(c);
            }
            context.SaveChanges();


            // Create mock data for HWY37N_HAZELTON
            var hwy37Haz = new HWY37N_HAZELTON[]
            {
                new HWY37N_HAZELTON{HWY_HAZ_DATE=new DateTime(2022, 05, 16),HWY_HAZ_EST_OCC_TONNES=(float)123.6,HWY_HAZ_OCC_BIN_BILLING=123,HWY_HAZ_SCRAP_METAL_TONNES=2,HWY_HAZ_TIRE_COUNTS=3,HWY_HAZ_TIRE_COLLECTION_CHARGES=4,HWY_HAZ_FREON_REMOVAL_CHARGES=5,HWY_HAZ_MARR_INCOME=-231,HWY_HAZ_ABC_INCOME=-1245},
                new HWY37N_HAZELTON{HWY_HAZ_DATE=new DateTime(2022, 05, 27),HWY_HAZ_EST_OCC_TONNES=34,HWY_HAZ_OCC_BIN_BILLING=1,HWY_HAZ_SCRAP_METAL_TONNES=(float)100.35,HWY_HAZ_TIRE_COUNTS=3,HWY_HAZ_TIRE_COLLECTION_CHARGES=4,HWY_HAZ_FREON_REMOVAL_CHARGES=5,HWY_HAZ_MARR_INCOME=-52,HWY_HAZ_ABC_INCOME=-1245},
                new HWY37N_HAZELTON{HWY_HAZ_DATE=new DateTime(2010, 07, 02),HWY_HAZ_EST_OCC_TONNES=(float)62.7,HWY_HAZ_OCC_BIN_BILLING=1,HWY_HAZ_SCRAP_METAL_TONNES=2,HWY_HAZ_TIRE_COUNTS=(float)13.45,HWY_HAZ_TIRE_COLLECTION_CHARGES=4,HWY_HAZ_FREON_REMOVAL_CHARGES=5,HWY_HAZ_MARR_INCOME=-52,HWY_HAZ_ABC_INCOME=(float)-23.04},
                new HWY37N_HAZELTON{HWY_HAZ_DATE=new DateTime(2009, 08, 24),HWY_HAZ_EST_OCC_TONNES=(float)24.0,HWY_HAZ_OCC_BIN_BILLING=1,HWY_HAZ_SCRAP_METAL_TONNES=2,HWY_HAZ_TIRE_COUNTS=3,HWY_HAZ_FREON_REMOVAL_CHARGES=5,HWY_HAZ_TIRE_COLLECTION_CHARGES=(float)457.13,HWY_HAZ_MARR_INCOME=-52,HWY_HAZ_ABC_INCOME=-1245},
                new HWY37N_HAZELTON{HWY_HAZ_DATE=new DateTime(2018, 04, 29),HWY_HAZ_EST_OCC_TONNES=1,HWY_HAZ_OCC_BIN_BILLING=1,HWY_HAZ_SCRAP_METAL_TONNES=2,HWY_HAZ_TIRE_COUNTS=3,HWY_HAZ_TIRE_COLLECTION_CHARGES=4,HWY_HAZ_FREON_REMOVAL_CHARGES=1267,HWY_HAZ_MARR_INCOME=-52,HWY_HAZ_ABC_INCOME=-1245},
            };
            foreach (HWY37N_HAZELTON c in hwy37Haz)
            {
                context.HWY37N_HAZELTON.Add(c);
            }
            context.SaveChanges();


            // Create mock data for HWY37N_KITWANGA
            var hwy37Kit = new HWY37N_KITWANGA[]
            {
                new HWY37N_KITWANGA{HWY_KIT_DATE=new DateTime(2022, 05, 16),HWY_KIT_OCC_TONNAGE_EST=(float)123.6,HWY_KIT_PPP_TONNAGE=123,HWY_KIT_OCC_HAULING_BIN_RENTAL=90,HWY_KIT_PPP_HAULING=74,HWY_KIT_RECYCLE_BC_TONNAGE=4562,HWY_KIT_CESA_TONNES=90,HWY_KIT_EPRA_TONNES=78,HWY_KIT_LIGHT_RECYCLE_COUNTS=45,HWY_KIT_PAINT_RECYCLE_COUNTS=34,HWY_KIT_SCRAP_METAL_MARR_INCLUDED=78,HWY_KIT_LAB_TONNES=32,HWY_KIT_TIRE_COUNTS=44,HWY_KIT_TIRE_CHARGES=100,HWY_KIT_FREON_REMOVAL_CHARGES=352,HWY_KIT_RECYCLE_BC_INCOME=-314,HWY_KIT_CESA_INCOME=-41,HWY_KIT_EPRA_INCOME=-231,HWY_KIT_LIGHT_RECYCLE_INCOME=-41,HWY_KIT_PAINT_RECYCLE_INCOME=(float)-35.2,HWY_KIT_MARR_INCOME=-235,HWY_KIT_LAB_INCOME=-463,HWY_KIT_TOTAL_TONNES_EPR=32,HWY_KIT_NET_INCOME=(float)-46.112},
                new HWY37N_KITWANGA{HWY_KIT_DATE=new DateTime(2022, 05, 27),HWY_KIT_OCC_TONNAGE_EST=34,HWY_KIT_PPP_TONNAGE=43,HWY_KIT_OCC_HAULING_BIN_RENTAL=(float)100.35,HWY_KIT_PPP_HAULING=74,HWY_KIT_RECYCLE_BC_TONNAGE=4562,HWY_KIT_CESA_TONNES=90,HWY_KIT_EPRA_TONNES=78,HWY_KIT_LIGHT_RECYCLE_COUNTS=45,HWY_KIT_PAINT_RECYCLE_COUNTS=34,HWY_KIT_SCRAP_METAL_MARR_INCLUDED=78,HWY_KIT_LAB_TONNES=32,HWY_KIT_TIRE_COUNTS=44,HWY_KIT_TIRE_CHARGES=100,HWY_KIT_FREON_REMOVAL_CHARGES=352,HWY_KIT_RECYCLE_BC_INCOME=-314,HWY_KIT_CESA_INCOME=-41,HWY_KIT_EPRA_INCOME=-231,HWY_KIT_LIGHT_RECYCLE_INCOME=-41,HWY_KIT_PAINT_RECYCLE_INCOME=(float)-35.2,HWY_KIT_MARR_INCOME=-235,HWY_KIT_LAB_INCOME=-463,HWY_KIT_TOTAL_TONNES_EPR=32,HWY_KIT_NET_INCOME=(float)-46.112},
                new HWY37N_KITWANGA{HWY_KIT_DATE=new DateTime(2010, 07, 02),HWY_KIT_OCC_TONNAGE_EST=(float)62.7,HWY_KIT_PPP_TONNAGE=43,HWY_KIT_OCC_HAULING_BIN_RENTAL=90,HWY_KIT_PPP_HAULING=(float)13.45,HWY_KIT_RECYCLE_BC_TONNAGE=4562,HWY_KIT_CESA_TONNES=90,HWY_KIT_EPRA_TONNES=78,HWY_KIT_LIGHT_RECYCLE_COUNTS=45,HWY_KIT_PAINT_RECYCLE_COUNTS=34,HWY_KIT_SCRAP_METAL_MARR_INCLUDED=78,HWY_KIT_LAB_TONNES=32,HWY_KIT_TIRE_COUNTS=44,HWY_KIT_TIRE_CHARGES=100,HWY_KIT_FREON_REMOVAL_CHARGES=352,HWY_KIT_RECYCLE_BC_INCOME=-314,HWY_KIT_CESA_INCOME=(float)-23.04,HWY_KIT_EPRA_INCOME=-231,HWY_KIT_LIGHT_RECYCLE_INCOME=-41,HWY_KIT_PAINT_RECYCLE_INCOME=(float)-35.2,HWY_KIT_MARR_INCOME=-235,HWY_KIT_LAB_INCOME=-463,HWY_KIT_TOTAL_TONNES_EPR=32,HWY_KIT_NET_INCOME=(float)-46.112},
                new HWY37N_KITWANGA{HWY_KIT_DATE=new DateTime(2009, 08, 24),HWY_KIT_OCC_TONNAGE_EST=(float)24.0,HWY_KIT_PPP_TONNAGE=43,HWY_KIT_OCC_HAULING_BIN_RENTAL=90,HWY_KIT_PPP_HAULING=74,HWY_KIT_RECYCLE_BC_TONNAGE=(float)457.13,HWY_KIT_CESA_TONNES=90,HWY_KIT_EPRA_TONNES=78,HWY_KIT_LIGHT_RECYCLE_COUNTS=45,HWY_KIT_PAINT_RECYCLE_COUNTS=45,HWY_KIT_SCRAP_METAL_MARR_INCLUDED=78,HWY_KIT_LAB_TONNES=32,HWY_KIT_TIRE_COUNTS=44,HWY_KIT_TIRE_CHARGES=100,HWY_KIT_FREON_REMOVAL_CHARGES=352,HWY_KIT_RECYCLE_BC_INCOME=-314,HWY_KIT_CESA_INCOME=-41,HWY_KIT_EPRA_INCOME=-231,HWY_KIT_LIGHT_RECYCLE_INCOME=-41,HWY_KIT_PAINT_RECYCLE_INCOME=(float)-35.2,HWY_KIT_MARR_INCOME=-235,HWY_KIT_LAB_INCOME=-463,HWY_KIT_TOTAL_TONNES_EPR=32,HWY_KIT_NET_INCOME=(float)-46.112},
                new HWY37N_KITWANGA{HWY_KIT_DATE=new DateTime(2018, 04, 29),HWY_KIT_OCC_TONNAGE_EST=1,HWY_KIT_PPP_TONNAGE=43,HWY_KIT_OCC_HAULING_BIN_RENTAL=90,HWY_KIT_PPP_HAULING=74,HWY_KIT_RECYCLE_BC_TONNAGE=4562,HWY_KIT_CESA_TONNES=1267,HWY_KIT_EPRA_TONNES=78,HWY_KIT_LIGHT_RECYCLE_COUNTS=45,HWY_KIT_PAINT_RECYCLE_COUNTS=34,HWY_KIT_SCRAP_METAL_MARR_INCLUDED=78,HWY_KIT_LAB_TONNES=32,HWY_KIT_TIRE_COUNTS=44,HWY_KIT_TIRE_CHARGES=100,HWY_KIT_FREON_REMOVAL_CHARGES=352,HWY_KIT_RECYCLE_BC_INCOME=-314,HWY_KIT_CESA_INCOME=-41,HWY_KIT_EPRA_INCOME=-231,HWY_KIT_LIGHT_RECYCLE_INCOME=-41,HWY_KIT_PAINT_RECYCLE_INCOME=(float)-35.2,HWY_KIT_MARR_INCOME=-235,HWY_KIT_LAB_INCOME=-463,HWY_KIT_TOTAL_TONNES_EPR=32,HWY_KIT_NET_INCOME=(float)-46.112},
            };


            foreach (HWY37N_KITWANGA c in hwy37Kit)
            {
                context.HWY37N_KITWANGA.Add(c);
            }
            context.SaveChanges();


            // Create mock data for HWY37N_STEWART
            var hwy37Ste = new HWY37N_STEWART[]
            {
                new HWY37N_STEWART{HWY_STE_DATE=new DateTime(2022, 05, 16),HWY_STE_OCC_TONNES=14,HWY_STE_BANDSTRA_OCC_HAULING=525,HWY_STE_OCC_TOTAL=(float)245.4,HWY_STE_RECYCLE_BC_TONNAGE=(float)24.11,HWY_STE_CESA_TONNES=(float)46.25,HWY_STE_EPRA_TONNES=521,HWY_STE_LIGHT_RECYCLE_COUNTS=64,HWY_STE_PAINT_RECYCLE_COUNTS=(float)52.65,HWY_STE_SCRAP_METAL_MARR_TONNE_EST=(float)56.77,HWY_STE_LAB_TONNES=43,HWY_STE_TIRE_COUNTS=626,HWY_STE_TIRE_CHARGES=(float)451.3,HWY_STE_FREON_REMOVAL_CHARGES=(float)53.23,HWY_STE_RECYCLE_BC_INCOME=-345,HWY_STE_CESA_INCOME=-632,HWY_STE_EPRA_INCOME=-643,HWY_STE_LIGHT_RECYCLE_INCOME=(float)-514.3,HWY_STE_RECYCLE_INCOME=(float)-64.33,HWY_STE_MARR_INCOME=-6432,HWY_STE_LAB_INCOME=-642,HWY_STE_TOTAL_TONNES_EPR=(float)532.33,HWY_STE_NET_INCOME=-531},
                new HWY37N_STEWART{HWY_STE_DATE=new DateTime(2022, 05, 27),HWY_STE_OCC_TONNES=14,HWY_STE_BANDSTRA_OCC_HAULING=525,HWY_STE_OCC_TOTAL=(float)289.7,HWY_STE_RECYCLE_BC_TONNAGE=(float)26.0,HWY_STE_CESA_TONNES=(float)435,HWY_STE_EPRA_TONNES=75,HWY_STE_LIGHT_RECYCLE_COUNTS=94,HWY_STE_PAINT_RECYCLE_COUNTS=(float)32.65,HWY_STE_SCRAP_METAL_MARR_TONNE_EST=(float)357,HWY_STE_LAB_TONNES=24,HWY_STE_TIRE_COUNTS=246,HWY_STE_TIRE_CHARGES=(float)562.6,HWY_STE_FREON_REMOVAL_CHARGES=(float)56.7,HWY_STE_RECYCLE_BC_INCOME=-345,HWY_STE_CESA_INCOME=-632,HWY_STE_EPRA_INCOME=-643,HWY_STE_LIGHT_RECYCLE_INCOME=(float)-514.3,HWY_STE_RECYCLE_INCOME=(float)-64.33,HWY_STE_MARR_INCOME=-6432,HWY_STE_LAB_INCOME=-642,HWY_STE_TOTAL_TONNES_EPR=(float)532.33,HWY_STE_NET_INCOME=-531},
                new HWY37N_STEWART{HWY_STE_DATE=new DateTime(2010, 07, 02),HWY_STE_OCC_TONNES=14,HWY_STE_BANDSTRA_OCC_HAULING=525,HWY_STE_OCC_TOTAL=(float)35.8,HWY_STE_RECYCLE_BC_TONNAGE=(float)564.9,HWY_STE_CESA_TONNES=(float)736,HWY_STE_EPRA_TONNES=25,HWY_STE_LIGHT_RECYCLE_COUNTS=57,HWY_STE_PAINT_RECYCLE_COUNTS=(float)56.65,HWY_STE_SCRAP_METAL_MARR_TONNE_EST=(float)35.8,HWY_STE_LAB_TONNES=62,HWY_STE_TIRE_COUNTS=246,HWY_STE_TIRE_CHARGES=(float)245.76,HWY_STE_FREON_REMOVAL_CHARGES=(float)24.7,HWY_STE_RECYCLE_BC_INCOME=-345,HWY_STE_CESA_INCOME=-632,HWY_STE_EPRA_INCOME=-643,HWY_STE_LIGHT_RECYCLE_INCOME=(float)-514.3,HWY_STE_RECYCLE_INCOME=(float)-64.33,HWY_STE_MARR_INCOME=-6432,HWY_STE_LAB_INCOME=-642,HWY_STE_TOTAL_TONNES_EPR=(float)532.33,HWY_STE_NET_INCOME=-531},
                new HWY37N_STEWART{HWY_STE_DATE=new DateTime(2009, 08, 24),HWY_STE_OCC_TONNES=14,HWY_STE_BANDSTRA_OCC_HAULING=525,HWY_STE_OCC_TOTAL=(float)974.22,HWY_STE_RECYCLE_BC_TONNAGE=(float)854.7,HWY_STE_CESA_TONNES=(float)79.75,HWY_STE_EPRA_TONNES=270,HWY_STE_LIGHT_RECYCLE_COUNTS=15,HWY_STE_PAINT_RECYCLE_COUNTS=(float)521.65,HWY_STE_SCRAP_METAL_MARR_TONNE_EST=(float)31,HWY_STE_LAB_TONNES=46,HWY_STE_TIRE_COUNTS=145,HWY_STE_TIRE_CHARGES=(float)146.7,HWY_STE_FREON_REMOVAL_CHARGES=(float)42.7,HWY_STE_RECYCLE_BC_INCOME=-345,HWY_STE_CESA_INCOME=-632,HWY_STE_EPRA_INCOME=-643,HWY_STE_LIGHT_RECYCLE_INCOME=(float)-514.3,HWY_STE_RECYCLE_INCOME=(float)-64.33,HWY_STE_MARR_INCOME=-6432,HWY_STE_LAB_INCOME=-642,HWY_STE_TOTAL_TONNES_EPR=(float)532.33,HWY_STE_NET_INCOME=-531},
                new HWY37N_STEWART{HWY_STE_DATE=new DateTime(2018, 04, 29),HWY_STE_OCC_TONNES=14,HWY_STE_BANDSTRA_OCC_HAULING=525,HWY_STE_OCC_TOTAL=(float)567.6,HWY_STE_RECYCLE_BC_TONNAGE=(float)13.7,HWY_STE_CESA_TONNES=(float)754.66,HWY_STE_EPRA_TONNES=54,HWY_STE_LIGHT_RECYCLE_COUNTS=900,HWY_STE_PAINT_RECYCLE_COUNTS=(float)52.57,HWY_STE_SCRAP_METAL_MARR_TONNE_EST=(float)85.8,HWY_STE_LAB_TONNES=89,HWY_STE_TIRE_COUNTS=864,HWY_STE_TIRE_CHARGES=(float)132.8,HWY_STE_FREON_REMOVAL_CHARGES=(float)245.6,HWY_STE_RECYCLE_BC_INCOME=-345,HWY_STE_CESA_INCOME=-632,HWY_STE_EPRA_INCOME=-643,HWY_STE_LIGHT_RECYCLE_INCOME=(float)-514.3,HWY_STE_RECYCLE_INCOME=(float)-64.33,HWY_STE_MARR_INCOME=-6432,HWY_STE_LAB_INCOME=-642,HWY_STE_TOTAL_TONNES_EPR=(float)532.33,HWY_STE_NET_INCOME=-531},
            };

            foreach (HWY37N_STEWART c in hwy37Ste)
            {
                context.HWY37N_STEWART.Add(c);
            }
            context.SaveChanges();


            // Create mock data for WasteSource
            var wasteSources = new WasteSource[]
            {
                new WasteSource{WasteGenerator="first",WasteSourceSiteAddress="4901 Walsh"},
                new WasteSource{WasteGenerator="second",WasteSourceSiteAddress="4620 Lakelse Ave"},
                new WasteSource{WasteGenerator="third",WasteSourceSiteAddress="3747 River Dr"},
                new WasteSource{WasteGenerator="fourth",WasteSourceSiteAddress="5022 Mcrae Cres"},
                new WasteSource{WasteGenerator="fifth",WasteSourceSiteAddress="520 Keith Ave"},
            };

            foreach (WasteSource w in wasteSources)
            {
                context.WasteSource.Add(w);
            }
            context.SaveChanges();

            
            // Create mock data for Validation
            var validations = new Validation[]
            {
                new Validation{VALID_IMPORT_CODE="DYP1", VALID_MATERIAL_NAME="Recycle Curbside - Terrace", VALID_IN_AND_OUT="In SA", 
                    VALID_AIRSPACE_OR_NONAIRSPACE="Non-ASC", VALID_FUNCTION="Curbside", VALID_FACILITY="DYP", VALID_MATERIAL_GROUP="Recycle",
                    VALID_CURBSIED_AREA="Terrace", VALID_CURBSIDE_STREAM="Recycle", VALID_SERVICE_AREA="Terrace & Area" },

                new Validation{VALID_IMPORT_CODE="F40", VALID_CODE=40, VALID_MATERIAL_NAME="C&D", VALID_IN_AND_OUT="In SA",
                    VALID_AIRSPACE_OR_NONAIRSPACE="ASC", VALID_FUNCTION="Transactions", VALID_FACILITY="FR", VALID_MATERIAL_GROUP="C&D",
                    VALID_FR_ANNUAL_REPORTING_GROUP="C&D", VALID_FR_ANNUAL_REPORT_WASTE_TYPE="Controlled Waste", VALID_SERVICE_AREA="Terrace & Area" },
                
                new Validation{VALID_IMPORT_CODE="F10", VALID_CODE=10, VALID_MATERIAL_NAME="Refuse", VALID_IN_AND_OUT="In SA",
                    VALID_AIRSPACE_OR_NONAIRSPACE="ASC", VALID_FUNCTION="Transactions", VALID_FACILITY="FR", VALID_MATERIAL_GROUP="Refuse",
                    VALID_FR_ANNUAL_REPORTING_GROUP="Refuse", VALID_FR_ANNUAL_REPORT_WASTE_TYPE="Non-Controlled Waste", VALID_SERVICE_AREA="Terrace & Area" },

                new Validation{VALID_IMPORT_CODE="HWMF10", VALID_CODE=10, VALID_MATERIAL_NAME="Garbage - Uncompacted", VALID_IN_AND_OUT="In SA",
                    VALID_AIRSPACE_OR_NONAIRSPACE="ASC", VALID_FUNCTION="Transactions", VALID_FACILITY="HWMF", VALID_MATERIAL_GROUP="Refuse",
                    VALID_SERVICE_AREA="Hazelton & Highway 37 North" },

                new Validation{VALID_IMPORT_CODE="HWMF11", VALID_CODE=10, VALID_MATERIAL_NAME="Garbage - Compacted", VALID_IN_AND_OUT="In SA",
                    VALID_AIRSPACE_OR_NONAIRSPACE="ASC", VALID_FUNCTION="Transactions", VALID_FACILITY="HWMF", VALID_MATERIAL_GROUP="Refuse",
                    VALID_SERVICE_AREA="Hazelton & Highway 37 North" },
            };

            foreach (Validation v in validations)
            {
                context.Validation.Add(v);
            }
            context.SaveChanges();


            // Create mock data for Transaction
            var transactions = new Transaction[]
            {
                new Transaction{TRANS_NUM="TTS89002", LICENSE_PLATE="AB1234", TRANS_COMPLETION_DATE=new DateTime(2021, 10, 27, 2, 48, 00),
                    TRANS_COMPLETION_TIME=new DateTime(2021, 10, 27, 2, 48, 00), TRANS_LOAD_NUM=1, TRANS_NETWEIGHT=450.00F, TRANS_TOTALPRICE=49.50F,
                    TRANS_HAULER="The Yard", CUS_ID=1, VALID_IMPORT_CODE="F10", TRANS_OPERATION="Received", TRANS_STATUS="Complete", TRANS_ISMANUAL=false,
                    TRANS_HASEXCEPTION=false, TRANS_SOURCE_TYPE="Other Waste", TRANS_ADJUSTED_PRICE=49.50F, TRANS_FACILITY_CODE="TTS", TRANS_TONNES=0.45F,
                    TRANS_CUBIC_METERS=450.00F, TRANS_IN_SERVICE_AREA="In SA", TRANS_ASC_NON_ASC="ASC", TRANS_FUNCTION="Transactions", TRANS_CURBSIDE_AREA="0", 
                    TRANS_CURBSIDE_STREAM="0", TRANS_ANNUAL_REPORTING_GROUP="0", TRANS_ANNUAL_REPORTING_SOURCE="0", TRANS_SERVICE_AREA="Terrace & Area" },

                new Transaction{TRANS_NUM="TTS88505", LICENSE_PLATE="AB1234", TRANS_COMPLETION_DATE=new DateTime(2021, 10, 20, 12, 51, 00),
                    TRANS_COMPLETION_TIME=new DateTime(2021, 10, 20, 12, 51, 00), TRANS_LOAD_NUM=1, TRANS_NETWEIGHT=853.00F, TRANS_TOTALPRICE=91.85F,
                    TRANS_HAULER="The Yard", CUS_ID=1, VALID_IMPORT_CODE="F40", TRANS_OPERATION="Received", TRANS_STATUS="Complete", TRANS_ISMANUAL=false,
                    TRANS_HASEXCEPTION=false, TRANS_SOURCE_TYPE="Other Waste", TRANS_ADJUSTED_PRICE=91.85F, TRANS_FACILITY_CODE="TTS", TRANS_TONNES=0.84F,
                    TRANS_CUBIC_METERS=835.00F, TRANS_IN_SERVICE_AREA="In SA", TRANS_ASC_NON_ASC="ASC", TRANS_FUNCTION="Transactions", TRANS_CURBSIDE_AREA="0",
                    TRANS_CURBSIDE_STREAM="0", TRANS_ANNUAL_REPORTING_GROUP="0", TRANS_ANNUAL_REPORTING_SOURCE="0", TRANS_SERVICE_AREA="Terrace & Area" },

                new Transaction{TRANS_NUM="TTS88999", LICENSE_PLATE="BC1234", TRANS_COMPLETION_DATE=new DateTime(2021, 10, 26, 1, 45, 00),
                    TRANS_COMPLETION_TIME=new DateTime(2021, 10, 26, 1, 45, 00), TRANS_LOAD_NUM=1, TRANS_NETWEIGHT=2890.00F, TRANS_TOTALPRICE=0.00F,
                    TRANS_HAULER="Waste Services", CUS_ID=2, VALID_IMPORT_CODE="F10", TRANS_OPERATION="Received", TRANS_STATUS="Complete", TRANS_ISMANUAL=false,
                    TRANS_HASEXCEPTION=false, TRANS_SOURCE_TYPE="Other Waste", TRANS_ADJUSTED_PRICE=0.00F, TRANS_FACILITY_CODE="TTS", TRANS_TONNES=2.89F,
                    TRANS_CUBIC_METERS=2890.00F, TRANS_IN_SERVICE_AREA="In SA", TRANS_ASC_NON_ASC="ASC", TRANS_FUNCTION="Curbside", TRANS_CURBSIDE_AREA="RDKS",
                    TRANS_CURBSIDE_STREAM="Refuse", TRANS_ANNUAL_REPORTING_GROUP="0", TRANS_ANNUAL_REPORTING_SOURCE="0", TRANS_SERVICE_AREA="Terrace & Area" },

                new Transaction{TRANS_NUM="TTS89862", LICENSE_PLATE="BC1234", TRANS_COMPLETION_DATE=new DateTime(2021, 11, 8, 2, 59, 00),
                    TRANS_COMPLETION_TIME=new DateTime(2021, 11, 8, 2, 59, 00), TRANS_LOAD_NUM=1, TRANS_NETWEIGHT=3000.00F, TRANS_TOTALPRICE=0.00F,
                    TRANS_HAULER="Waste Services", CUS_ID=2, VALID_IMPORT_CODE="HWMF10", TRANS_OPERATION="Received", TRANS_STATUS="Complete", TRANS_ISMANUAL=false,
                    TRANS_HASEXCEPTION=false, TRANS_SOURCE_TYPE="Other Waste", TRANS_ADJUSTED_PRICE=0.00F, TRANS_FACILITY_CODE="TTS", TRANS_TONNES=2.89F,
                    TRANS_CUBIC_METERS=3000.00F, TRANS_IN_SERVICE_AREA="In SA", TRANS_ASC_NON_ASC="ASC", TRANS_FUNCTION="Curbside", TRANS_CURBSIDE_AREA="Kitsumkalum",
                    TRANS_CURBSIDE_STREAM="Refuse", TRANS_ANNUAL_REPORTING_GROUP="0", TRANS_ANNUAL_REPORTING_SOURCE="0", TRANS_SERVICE_AREA="Terrace & Area" },

                new Transaction{TRANS_NUM="TTS89935", LICENSE_PLATE="CD2356", TRANS_COMPLETION_DATE=new DateTime(2021, 11, 10, 2, 49, 00),
                    TRANS_COMPLETION_TIME=new DateTime(2021, 11, 10, 2, 49, 00), TRANS_LOAD_NUM=1, TRANS_NETWEIGHT=1030.00F, TRANS_TOTALPRICE=0.00F,
                    TRANS_HAULER="Waste Services", CUS_ID=3, VALID_IMPORT_CODE="HWMF10", TRANS_OPERATION="Received", TRANS_STATUS="Complete", TRANS_ISMANUAL=false,
                    TRANS_HASEXCEPTION=false, TRANS_SOURCE_TYPE="Other Waste", TRANS_ADJUSTED_PRICE=0.00F, TRANS_FACILITY_CODE="TTS", TRANS_TONNES=1.03F,
                    TRANS_CUBIC_METERS=1030.00F, TRANS_IN_SERVICE_AREA="In SA", TRANS_ASC_NON_ASC="Non-ASC", TRANS_FUNCTION="Curbside", TRANS_CURBSIDE_AREA="RDKS",
                    TRANS_CURBSIDE_STREAM="Organics", TRANS_ANNUAL_REPORTING_GROUP="0", TRANS_ANNUAL_REPORTING_SOURCE="0", TRANS_SERVICE_AREA="Terrace & Area" },
            };

            foreach (Transaction t in transactions)
            {
                context.Transaction.Add(t);
            }
            context.SaveChanges();

            
            // Create mock data for Permit
            var permits = new Permit[]
            {
                new Permit{PermitNumberPrefix=536008, PermitNumber=1, FacilityCode="FRWMF",PermitApplicationDate = new DateTime(2016,11,03),EstimatedLoads=0,EstimatedVolume=0,units="NA",Frequency="Bi_Weekly",Comments="NA",ContaminateLoadsDate=new DateTime(2016,11,2),ContaminateLoadsComments="NA",ContaminatedLoads=0,PermitSentToOperatorAndWMF="N",PermitSavedOnServerAndFiled="N",HardCopyPermitSavedInFile="N",ApprovedBy="NA",PermitClosedCardPermissionsRevolked="N",PermitStatus="Permit Issued",PermitType="Single Event",PermitFee=25,ExpirationDate=new DateTime(2016,11,10),ApplicationFeeInvoiced="N",ApplicantName="Universal Restoration Systems LTD",Hauler="Universal",MaterialCode=44, WasteGenerator="first", CUS_ID=1},
                new Permit{PermitNumberPrefix=53600902, PermitNumber=3, FacilityCode="ML",PermitApplicationDate = new DateTime(2016,11,16),EstimatedLoads=0,EstimatedVolume=0,units="NA",Frequency="Bi_Monthly",Comments="NA",ContaminateLoadsDate=new DateTime(2016,11,22),ContaminateLoadsComments="NA",ContaminatedLoads=0,PermitSentToOperatorAndWMF="N",PermitSavedOnServerAndFiled="N",HardCopyPermitSavedInFile="N",ApprovedBy="NA",PermitClosedCardPermissionsRevolked="N",PermitStatus="Permit Issued",PermitType="Single Event",PermitFee=25,ExpirationDate=new DateTime(2016,11,30),ApplicationFeeInvoiced="N",ApplicantName="Days Inn",Hauler="Waste Management",MaterialCode=40,WasteGenerator="second", CUS_ID=2},
                new Permit{PermitNumberPrefix=53600902, PermitNumber=8, FacilityCode="ML",PermitApplicationDate = new DateTime(2016,11,28),EstimatedLoads=0,EstimatedVolume=0,units="NA",Frequency="Monthly",Comments="NA",ContaminateLoadsComments="NA",ContaminatedLoads=0,PermitSentToOperatorAndWMF="N",PermitSavedOnServerAndFiled="N",HardCopyPermitSavedInFile="N",ApprovedBy="NA",PermitClosedCardPermissionsRevolked="N",PermitStatus="Permit Issued",PermitType="Single Event",PermitFee=25,ExpirationDate=new DateTime(2016,12,30),ApplicationFeeInvoiced="N",ApplicantName="Lafarge concrete",Hauler="Provac",MaterialCode=45,WasteGenerator="third", CUS_ID=3},
                new Permit{PermitNumberPrefix=536008, PermitNumber=9, FacilityCode="FRWMF",PermitApplicationDate = new DateTime(2016,11,29),EstimatedLoads=0,EstimatedVolume=0,units="NA",Frequency="Monthly",Comments="NA",ContaminateLoadsComments="NA",ContaminatedLoads=0,PermitSentToOperatorAndWMF="N",PermitSavedOnServerAndFiled="N",HardCopyPermitSavedInFile="N",ApprovedBy="NA",PermitClosedCardPermissionsRevolked="N",PermitStatus="Permit Issued",PermitType="Single Event",PermitFee=25,ExpirationDate=new DateTime(2017,1,4),ApplicationFeeInvoiced="Y",ApplicantName="Technicon",Hauler="Technicon",MaterialCode=10,WasteGenerator="fourth", CUS_ID=4},
                new Permit{PermitNumberPrefix=536008, PermitNumber=17,FacilityCode="FRWMF",PermitApplicationDate = new DateTime(2016,11,29),EstimatedLoads=0,EstimatedVolume=0,units="NA",Frequency="Semi_Annual",Comments="NA",ContaminateLoadsComments="NA",ContaminatedLoads=0,PermitSentToOperatorAndWMF="N",PermitSavedOnServerAndFiled="N",HardCopyPermitSavedInFile="N",ApprovedBy="NA",PermitClosedCardPermissionsRevolked="N",PermitStatus="Permit Issued",PermitType="Single Event",PermitFee=25,ExpirationDate=new DateTime(2017,1,4),ApplicationFeeInvoiced="Y",ApplicantName="Ministry of Forest",Hauler="NBC",MaterialCode=10,WasteGenerator="fifth", CUS_ID=5},
            };
            foreach (Permit p in permits)
            {
                context.Permit.Add(p);
            }
            context.SaveChanges();

        }
    }
}
