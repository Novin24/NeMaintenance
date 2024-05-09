using Domain.Common;
using Domain.MaintainEntity.Devices;

namespace Domain.MaintainEntity.Problems
{
    public class Problem : LocalEntity<Guid>
    {
        #region Navigation
        public ICollection<Device> Devices { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        #endregion

        #region ctor
        public Problem()
        {

        }

        public Problem(string name,
            string desc,
            string serial)
        {
            Name = name;
            Serial = serial;
            Description = desc;
            Devices = [];
        }
        #endregion

        #region Methods
        public Problem AddDevices(Device device)
        {
            Devices.Add(device);
            return this;
        }
        #endregion
    }
}


