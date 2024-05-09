using Domain.Common;
using Domain.MaintainEntity.DeviceGroups;
using Domain.MaintainEntity.Problems;

namespace Domain.MaintainEntity.Devices
{
    public class Device : LocalEntity<Guid>
    {
        #region Navigation
        public ICollection<Problem> Problems { get; set; }

        /// <summary>
        /// لیست تجهیزات زیر دسته
        /// </summary>
        public ICollection<Device> ChiledDevice { get; set; }

        /// <summary>
        /// تجهیز والد
        /// </summary>
        public Device P_Device { get; set; }
        public Guid ParentId { get; set; } = Guid.Empty;

        /// <summary>
        /// دسته
        /// </summary>
        public Guid? GroupId { get; set; }
        public DeviceGroup Group { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        #endregion

        #region ctor
        public Device()
        {

        }

        public Device(string name,
            string serial,
            string des,
            Guid parentId,
            Guid? groupId)
        {
            Name = name;
            Serial = serial;
            ParentId = parentId;
            Description = des;
            GroupId = groupId;
        }
        #endregion

        #region Method
        public Device AddProblem(ICollection<Problem> problems)
        {
            Problems = problems;
            return this;
        }
        #endregion
    }
}


