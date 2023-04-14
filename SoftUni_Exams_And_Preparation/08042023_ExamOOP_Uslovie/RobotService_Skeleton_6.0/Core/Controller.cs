using RobotService.Core.Contracts;
using RobotService.Core;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{

    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        private IRobot robot;
        private ISupplement supplement;

        private int totalBatteryLevel = 0;
        private int usedRobotsCount = 0;


        public Controller()
        {
            this.supplements = new SupplementRepository();
            this.robots = new RobotRepository();
        }


        public string CreateRobot(string model, string typeName)
        {

            if (typeName != "IndustrialAssistant" && typeName != "DomesticAssistant")
            {
                return $"Robot type {typeName} cannot be created.";
            }
            if (typeName == "IndustrialAssistant")
            {
                robot = new IndustrialAssistant(model);
            }
            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }

            robots.AddNew(robot);

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return $"{typeName} is not compatible with our robots.";
            }
            if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            if (typeName == "LaserRadar")
            {
                supplement = new LaserRadar();
            }

            supplements.AddNew(supplement);

            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> supportRobots = new List<IRobot>();

            foreach (var validRobot in robots.Models())
            {
                if (validRobot.InterfaceStandards.Contains(intefaceStandard) && validRobot.BatteryLevel > 0)
                {
                    supportRobots.Add(validRobot);
                    totalBatteryLevel += validRobot.BatteryLevel;
                }
            }

            if (supportRobots.Count == 0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            if (totalPowerNeeded > totalBatteryLevel)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - totalBatteryLevel} more power needed.";
            }

            // int neededPower = totalPowerNeeded;
            usedRobotsCount = 0;

            foreach (var rob in supportRobots.OrderByDescending(r => r.BatteryLevel))
            {

                if (rob.BatteryLevel >= totalPowerNeeded)
                {
                    rob.ExecuteService(totalPowerNeeded);
                    usedRobotsCount++;
                    totalPowerNeeded -= totalPowerNeeded;
                    return $"{serviceName} is performed successfully with {usedRobotsCount} robots.";
                }
                else if (rob.BatteryLevel < totalPowerNeeded)
                {
                    rob.ExecuteService(rob.BatteryLevel);
                    totalPowerNeeded -= rob.BatteryLevel;
                    usedRobotsCount++;

                }
                if (totalPowerNeeded <= 0)
                {
                    break;
                }
            }
            return $"{serviceName} is performed successfully with {usedRobotsCount} robots.";

        }

        public string Report()
        {
            string results = " ";

            List<IRobot> robotsForReport = new List<IRobot>();

            foreach (var validRobot in robots.Models())
            {
                robotsForReport.Add(validRobot);
            }

            foreach (var item in robotsForReport.OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity))
            {
                results += item.ToString();
            }

            return results.TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            int fedCount = 0;

            foreach (var validRobot in robots.Models().Where(r => r.Model == model))
            {
                if (validRobot.BatteryLevel < (validRobot.BatteryCapacity / 2))
                {
                    validRobot.Eating(minutes);
                    fedCount++;
                }
            }

            return $"Robots fed: {fedCount}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplementForInstall = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            List<IRobot> supportRobots = new List<IRobot>();
            int interfaceValue = supplementForInstall.InterfaceStandard;

            foreach (var validRobot in robots.Models())
            {
                if ((!validRobot.InterfaceStandards.Contains(interfaceValue)) && validRobot.Model == model)
                {
                    supportRobots.Add(validRobot);
                }
            }

            if (supportRobots.Count == 0)
            {
                return $"All {model} are already upgraded!";
            }

            IRobot newRobot = supportRobots.First();
            newRobot.InstallSupplement(supplementForInstall);

            supplements.RemoveByName(supplementTypeName);

            return $"{model} is upgraded with {supplementTypeName}.";
        }
    }
}
