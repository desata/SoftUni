using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;

        public RobotRepository()
        {
            models = new List<IRobot>();
        }

        public void AddNew(IRobot model)
        {
            models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            foreach (var model in models)
            {
                if (model.InterfaceStandards.Contains(interfaceStandard))
                {
                    return model;
                }
            }
            return null;
        }

        public IReadOnlyCollection<IRobot> Models() => models;

        public bool RemoveByName(string typeName)
        {
            return models.Remove(models.FirstOrDefault(m => m.GetType().Name == typeName));
        }
    }
}
