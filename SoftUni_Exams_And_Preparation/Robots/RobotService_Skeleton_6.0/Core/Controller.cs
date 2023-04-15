using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {

        private SupplementRepository supplements;
        private RobotRepository robots;
        private IRobot robot;
        private ISupplement supplement;


        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();

        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return $"Robot type {typeName} cannot be created.";
            }
            else if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            else 
            {
                robot = new IndustrialAssistant(model);
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
            else if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            else
            {
                supplement = new LaserRadar();
            }
            supplements.AddNew(supplement);
            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> selectedRobots = new List<IRobot>();
            int batteryLvlSum = 0;
            int usedRobotsCount = 0;

            foreach (var robot in robots.Models())
            {
                if (robot.InterfaceStandards.Contains(intefaceStandard))
                {
                    selectedRobots.Add(robot);
                    batteryLvlSum += robot.BatteryLevel;
                }
            }

            if (selectedRobots.Count() == 0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            if (batteryLvlSum < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - batteryLvlSum} more power needed.";
            }

            int power = totalPowerNeeded;
            selectedRobots = selectedRobots.OrderByDescending(s => s.BatteryLevel).ToList();

            foreach (var robot in selectedRobots) 
            {
                if (power > 0)
                    {
                    if (robot.BatteryLevel >= power)
                    {
                        robot.ExecuteService(power);
                        usedRobotsCount++;
                        break;
                    }
                    else
                    {
                        power -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);                        
                        usedRobotsCount++;
                    }
                }
               
            }

            return $"{serviceName} is performed successfully with {usedRobotsCount} robots.";

        }

        public string Report()
        {
            string result = "";
            foreach (var robot in robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity).ToList())
            {
                result += robot.ToString();
            }

            return result.TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            int fedCount = 0;

            List<IRobot> selectedRobots = robots.Models().Where(r => r.Model == model && r.BatteryLevel < r.BatteryCapacity / 2).ToList();


            foreach (var robot in selectedRobots)
            {
                robot.Eating(minutes);
                fedCount++;
            }

            return $"Robots fed: {fedCount}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {

            List<IRobot> selectedRobots = new List<IRobot>();

            supplement = supplements.Models().First(x => x.GetType().Name == supplementTypeName);

            int interfaceValue = supplement.InterfaceStandard;

            foreach (var robot in robots.Models())
            {
                if ((!robot.InterfaceStandards.Contains(interfaceValue)) && robot.Model == model)
                {
                    selectedRobots.Add(robot);
                }
            }

            if (selectedRobots.Count == 0)
            {
                return $"All {model} are already upgraded!";
            }

            selectedRobots.First().InstallSupplement(supplement);

            supplements.RemoveByName(supplementTypeName);

            return $"{model} is upgraded with {supplementTypeName}.";
        }
    }
}
