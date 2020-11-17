using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExamenParcial3.Models;

namespace ExamenParcial3.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CarContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.VehicleManufacters.Any())
            {
                return;   // DB has been seeded
            }

            var manufacter = new VehicleManufacter[]
            {
                new VehicleManufacter {ManufacterID = 01, ManufacterName = "BMW"},
                new VehicleManufacter {ManufacterID = 02, ManufacterName = "Audi"},
                new VehicleManufacter {ManufacterID = 03, ManufacterName = "Mercedes Benz"},
                new VehicleManufacter {ManufacterID = 04, ManufacterName = "Ferrari"},
                new VehicleManufacter {ManufacterID = 05, ManufacterName = "McLaren"},
                new VehicleManufacter {ManufacterID = 06, ManufacterName = "Nissan"},
            };

            foreach (VehicleManufacter m in manufacter)
            {
                context.VehicleManufacters.Add(m);
            }
            context.SaveChanges();

            var color = new VehicleColour[]
            {
                new VehicleColour {ColourID = 01, ColourName = "White"},
                new VehicleColour {ColourID = 02, ColourName = "Black"},
                new VehicleColour {ColourID = 03, ColourName = "Blue"},
                new VehicleColour {ColourID = 04, ColourName = "Green"},
                new VehicleColour {ColourID = 05, ColourName = "Red"},
                new VehicleColour {ColourID = 06, ColourName = "Orange"},
                new VehicleColour {ColourID = 07, ColourName = "Pink"},
            };
            foreach (VehicleColour c in color)
            {
                context.VehicleColours.Add(c);
            }
            context.SaveChanges();

            var feature = new VehicleFeature[]
            {
                new VehicleFeature {FeatureID = 01, FeatureDescription = "200km max"},
                new VehicleFeature {FeatureID = 02, FeatureDescription = "250km max"},
                new VehicleFeature {FeatureID = 03, FeatureDescription = "300km max"},
                new VehicleFeature {FeatureID = 04, FeatureDescription = "350km max"},
                new VehicleFeature {FeatureID = 05, FeatureDescription = "400km max"},
            };
            foreach (VehicleFeature f in feature)
            {
                context.VehicleFeatures.Add(f);
            }
            context.SaveChanges();

            var fuel = new VehicleFuelType[]
            {
                new VehicleFuelType {FuelTypeID = 01, FuelTypeName = "Magnus"},
                new VehicleFuelType {FuelTypeID = 02, FuelTypeName = "Premium"},
                new VehicleFuelType {FuelTypeID = 03, FuelTypeName = "Diesel"},
            };
            foreach (VehicleFuelType fu in fuel)
            {
                context.VehicleFuelTypes.Add(fu);
            }
            context.SaveChanges();

            var models = new VehicleModel[]
            {
                new VehicleModel {ModelID = 01, ModelName = "M3", ManufacterID = manufacter.Single(m => m.ManufacterName == "BMW").ManufacterID},
                new VehicleModel {ModelID = 02, ModelName = "Z4", ManufacterID = manufacter.Single(m => m.ManufacterName == "BMW").ManufacterID},
                new VehicleModel {ModelID = 03, ModelName = "M5", ManufacterID = manufacter.Single(m => m.ManufacterName == "BMW").ManufacterID},
                new VehicleModel {ModelID = 04, ModelName = "RS", ManufacterID = manufacter.Single(m => m.ManufacterName == "Audi").ManufacterID},
                new VehicleModel {ModelID = 05, ModelName = "SL65M6", ManufacterID = manufacter.Single(m => m.ManufacterName == "Mercedes Benz").ManufacterID},
                new VehicleModel {ModelID = 06, ModelName = "Enzo", ManufacterID = manufacter.Single(m => m.ManufacterName == "Ferrari").ManufacterID},
                new VehicleModel {ModelID = 07, ModelName = "Carrera", ManufacterID = manufacter.Single(m => m.ManufacterName == "Ferrari").ManufacterID},
                new VehicleModel {ModelID = 08, ModelName = "Senna", ManufacterID = manufacter.Single(m => m.ManufacterName == "McLaren").ManufacterID},
                new VehicleModel {ModelID = 09, ModelName = "Skyline", ManufacterID = manufacter.Single(m => m.ManufacterName == "Nissan").ManufacterID},
                new VehicleModel {ModelID = 10, ModelName = "GT R", ManufacterID = manufacter.Single(m => m.ManufacterName == "Nissan").ManufacterID},
            };
            foreach (VehicleModel mo in models)
            {
                context.VehicleModels.Add(mo);
            }
            context.SaveChanges();

            var details = new VehicleDetail[]
            {
                new VehicleDetail {CarRegistration = "BMW01", ModelID = models.Single(mo=> mo.ModelID == 01).ModelID, ManufactureYear = DateTime.Parse("01-01-2012"),
                ColourID = color.Single(c => c.ColourID == 01).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 02).FuelTypeID, CurrentMilage = 2300000, VehiclePrice = 500000},
                new VehicleDetail {CarRegistration = "BMW02", ModelID = models.Single(mo=> mo.ModelID == 02).ModelID, ManufactureYear = DateTime.Parse("01-01-2016"),
                ColourID = color.Single(c => c.ColourID == 04).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 02).FuelTypeID, CurrentMilage = 530000, VehiclePrice = 1500000},
                new VehicleDetail {CarRegistration = "BMW03", ModelID = models.Single(mo=> mo.ModelID == 03).ModelID, ManufactureYear = DateTime.Parse("01-01-2010"),
                ColourID = color.Single(c => c.ColourID == 02).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 01).FuelTypeID, CurrentMilage = 325000, VehiclePrice = 450000},
                new VehicleDetail {CarRegistration = "Audi01", ModelID = models.Single(mo => mo.ModelID == 04).ModelID, ManufactureYear = DateTime.Parse("01-01-2006"),
                ColourID = color.Single(c => c.ColourID == 01).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 01).FuelTypeID, CurrentMilage = 650000, VehiclePrice = 890000},
                new VehicleDetail {CarRegistration = "MB01", ModelID = models.Single(mo => mo.ModelID == 05).ModelID, ManufactureYear = DateTime.Parse("01-01-1998"),
                ColourID = color.Single(c => c.ColourID == 06).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 01).FuelTypeID, CurrentMilage = 125000, VehiclePrice = 1250000},
                new VehicleDetail {CarRegistration = "F01", ModelID = models.Single(mo => mo.ModelID == 06).ModelID, ManufactureYear = DateTime.Parse("01-01-2000"),
                ColourID = color.Single(c => c.ColourID == 05).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 01).FuelTypeID, CurrentMilage = 568900, VehiclePrice = 3500000},
                new VehicleDetail {CarRegistration = "F02", ModelID = models.Single(mo => mo.ModelID == 07).ModelID, ManufactureYear = DateTime.Parse("01-01-1992"),
                ColourID = color.Single(c => c.ColourID == 07).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 01).FuelTypeID, CurrentMilage = 2000000, VehiclePrice = 6500000},
                new VehicleDetail {CarRegistration = "MC01", ModelID = models.Single(mo => mo.ModelID == 08).ModelID, ManufactureYear = DateTime.Parse("01-01-2016"),
                ColourID = color.Single(c => c.ColourID == 02).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 02).FuelTypeID, CurrentMilage = 15000, VehiclePrice = 16000000},
                new VehicleDetail {CarRegistration = "NSS01", ModelID = models.Single(mo => mo.ModelID == 09).ModelID, ManufactureYear = DateTime.Parse("01-01-1971"),
                ColourID = color.Single(c => c.ColourID == 01).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 01).FuelTypeID, CurrentMilage = 6500000, VehiclePrice = 750000},
                new VehicleDetail {CarRegistration = "NSS02", ModelID = models.Single(mo => mo.ModelID == 10).ModelID, ManufactureYear = DateTime.Parse("01-01-2017"),
                ColourID = color.Single(c => c.ColourID == 06).ColourID, FuelTypeID = fuel.Single(fu => fu.FuelTypeID == 02).FuelTypeID, CurrentMilage = 40000, VehiclePrice = 830000},
            };
            foreach (VehicleDetail d in details)
            {
                context.VehicleDetails.Add(d);
            }
            context.SaveChanges();

            var link = new LinkFeatureToVehicle[]
            {
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "BMW01").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 01).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "BMW02").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 02).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "BMW03").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 02).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "Audi01").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 01).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "MB01").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 01).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "F01").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 03).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "F02").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 04).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "MC01").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 05).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "NSS01").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 01).FeatureID},
                new LinkFeatureToVehicle {CarRegistration = details.Single(d => d.CarRegistration == "NSS02").CarRegistration, FeatureID = feature.Single(f => f.FeatureID == 04).FeatureID},
            };
            foreach (LinkFeatureToVehicle l in link)
            {
                context.LinkFeatureToVehicles.Add(l);
            }
            context.SaveChanges();
        }
    }
}
