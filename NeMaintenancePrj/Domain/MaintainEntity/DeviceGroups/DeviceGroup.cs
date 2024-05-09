using Domain.Common;
using Domain.MaintainEntity.Devices;

namespace Domain.MaintainEntity.DeviceGroups
{
    public class DeviceGroup : LocalEntity<Guid>
    {
        #region Navigation
        public ICollection<Device> MyProperty { get; set; }
        #endregion

        #region Properties
        public string GroupName { get; set; }
        public string Descripion { get; set; }
        #endregion

        #region ctor
        public DeviceGroup()
        {
                
        }

        public DeviceGroup(string groupName,
            string description)
        {
            GroupName = groupName;
            Descripion = description;
        }
        #endregion
    }
}