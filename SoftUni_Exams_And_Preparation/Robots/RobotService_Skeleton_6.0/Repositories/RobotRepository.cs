using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {

        private List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();    
        }

        public void AddNew(IRobot model)
        {
           robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.First(r => r.InterfaceStandards.Contains(interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models() => this.robots.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            return robots.Remove(robots.First(r => r.Model == typeName));
        }
    }
}
